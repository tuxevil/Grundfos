using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Common;
using PriceManager.Core;
using System.Web.UI;

namespace GrundFos.PriceManager.WebSite.admin
{
    public partial class modifyProduct : System.Web.UI.Page
    {
        #region Properties 

        private SearchParams param
        {
            get
            {
                if (Session["AdminSearchParams"] == null)
                {
                    SearchParams temp = new SearchParams();
                    temp.PageNumber = 1;
                    temp.SortOrder = "";
                    temp.SortColumn = "Code";
                    Session["AdminSearchParams"] = temp;
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "cleanFilters", "<script>cleanAllFilters();</script>", false);
                    SearchParameters();
                    return temp;
                }
                else
                    return (SearchParams)Session["AdminSearchParams"];    
            }
            set { Session["AdminSearchParams"] = value; }
        }

        private List<string> selecteditems
        {
            get { return (List<string>)ViewState["Selected"]; }
            set { ViewState["Selected"] = value; }
        }

        private bool Marked
        {
            get { return (ViewState["Marked"] == null) ? false : (bool)ViewState["Marked"]; }
            set
            {
                if (!value)
                    MarkedAll.Attributes["class"] = "";
                else
                {
                    MarkedAll.Attributes["class"] = "pressed";
                    UnMarkedAll.Attributes["class"] = "";
                }

                ViewState["Marked"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            Pager1.PageChanged += Pager1_PageChanged;

            if (!IsPostBack)
            {
                HtmlAnchor temp = (HtmlAnchor)Master.FindControl("lnkproduct");
                temp.Attributes["class"] = "current";

                ViewState["Pagina"] = 1;
                ViewState["Currency"] = ControllerManager.Currency.GetBaseCurrency();
                InitializeSearchParameters();
                List<string> temp2 = new List<string>();
                selecteditems = temp2;
                txtDescripcion.Focus();
                LoadCombos();
                LoadSearch();
                SetSearchParameters(param);

                if (Request.QueryString[Config.QS_SELECTION] != null)
                {
                    if (param.Selection == 0)
                    {
                        param.PageNumber = 1;
                        CleanCheckedItemsList();
                        param.Selection = ControllerManager.Selection.GetById(Convert.ToInt32(Request.QueryString[Config.QS_SELECTION])).ID;
                        LoadSearch();
                    }
                }

                if (param.Selection != 0)
                {
                    Selection seltemp = ControllerManager.Selection.GetById(Convert.ToInt32(param.Selection));
                    litSeleccion.Text = "Se encuentra filtrando su selección [" + seltemp.Description + "] por:";
                }


            }
            
        }

        private void InitializeSearchParameters()
        {
            SearchParams temp = new SearchParams();
            temp.PageNumber = 1;
            temp.SortOrder = "";
            temp.SortColumn = "Code";
            temp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);

            param = temp;
           
        }

        private void SetSearchParameters(SearchParams param)
        {
            string type;

            if (param.Description != null)
                txtDescripcion.Text = param.Description;
            if (param.Family != 0)
                ddlFamilia.SelectedValue = ddlFamilia.Items.FindByValue(param.Family.ToString()).Value;
            if (param.CtrRange != 0)
                ddlRange.SelectedValue = ddlRange.Items.FindByValue(param.CtrRange.ToString()).Value;
            if (param.Currency != 0)
                ddlCurrency.SelectedValue = ddlCurrency.Items.FindByValue(param.Currency.ToString()).Value;
            if (param.Category != 0)
                ddlCategoryPage.SelectedValue = ddlCategoryPage.Items.FindByValue(param.Category.ToString()).Value;
            ddlPageSize.SelectedValue = param.PageSize.ToString();

            ProductType tempprodtype = (ProductType) param.ProductType;

            if (tempprodtype == ProductType.Hz50)
                type = "1";
            else if (tempprodtype == ProductType.Hz60)
                type = "2";
            else
                type = "3";

            rblProductType.SelectedValue = type;
            
        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbox = (CheckBox)sender;
            if (Marked)
            {
                if (!chbox.Checked)
                    selecteditems.Add(chbox.ValidationGroup);
                else
                    selecteditems.Remove(chbox.ValidationGroup);
            }
            else
            {
                if (chbox.Checked)
                    selecteditems.Add(chbox.ValidationGroup);
                else
                    selecteditems.Remove(chbox.ValidationGroup);
            }
            QuantitySelectedAndChecked(Convert.ToInt32(lblSelectedCount.Text));
            if ((Marked) && (selecteditems.Count > 0))
                MarkedAll.Attributes["class"] = "";
            else if ((!Marked) && (selecteditems.Count > 0))
                UnMarkedAll.Attributes["class"] = "";
        }

        protected void rpterProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                LinkButton orderArrow;
                switch (param.SortColumn)
                {
                    case "P.Description":
                        orderArrow = (LinkButton)e.Item.FindControl("lnkDescription");
                        break;
                    case "PP.Price":
                        orderArrow = (LinkButton)e.Item.FindControl("lnkPrice");
                        break;
                    case "LPPA.Price":
                        orderArrow = (LinkButton)e.Item.FindControl("lnkLastPrice");
                        break;
                    default:
                        orderArrow = (LinkButton)e.Item.FindControl("lnk" + param.SortColumn);
                        break;
                }

                if (param.SortOrder == "asc")
                    orderArrow.CssClass = "up";
                else
                    orderArrow.CssClass = "down";
                return;
            }

            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            ProductListView prodlisttemp = (ProductListView)e.Item.DataItem;

            if (!Marked)
            {
                if (!string.IsNullOrEmpty(selecteditems.Find(delegate(string record)
                                                                 {
                                                                     if (record == prodlisttemp.ID.ToString())
                                                                     {
                                                                         return true;
                                                                     }
                                                                     return false;
                                                                 })))
                {
                    CheckBox chktemp = (CheckBox)e.Item.FindControl("chbSelected");
                    chktemp.Checked = true;
                }
                else
                {
                    CheckBox chktemp = (CheckBox)e.Item.FindControl("chbSelected");
                    chktemp.Checked = false;
                }
            }
            else if (Marked)
            {
                if (!string.IsNullOrEmpty(selecteditems.Find(delegate(string record)
                                                                 {
                                                                     if (record == prodlisttemp.ID.ToString())
                                                                     {
                                                                         return true;
                                                                     }
                                                                     return false;
                                                                 })))
                {
                    CheckBox chktemp = (CheckBox)e.Item.FindControl("chbSelected");
                    chktemp.Checked = false;
                }
                else
                {
                    CheckBox chktemp = (CheckBox)e.Item.FindControl("chbSelected");
                    chktemp.Checked = true;
                }
            }

            ProductListView plvtemp = (ProductListView)e.Item.DataItem;
            HtmlTableCell temp = (HtmlTableCell)e.Item.FindControl("tdPrice");
            if (plvtemp.LastPrice > plvtemp.Price)
            {
                temp.Attributes["class"] = "down";
            }
            else if ((plvtemp.LastPrice > 0) && (plvtemp.LastPrice < plvtemp.Price))
            {
                temp.Attributes["class"] = "up";
            }
            if (plvtemp.LastPrice > 0)
                temp.Attributes["title"] = plvtemp.PriceCurrency.ToString() + " " + plvtemp.LastPrice.ToString("#,##0.00");

            Label lbltemp = (Label)e.Item.FindControl("lblPrice");
            if (prodlisttemp.PriceSell > prodlisttemp.PriceSuggest)
                lbltemp.ForeColor = System.Drawing.Color.Green;
            else if ((prodlisttemp.PriceSell < prodlisttemp.PriceSuggest) && (prodlisttemp.PriceSell > prodlisttemp.PricePurchase))
                lbltemp.ForeColor = System.Drawing.Color.Black;
            else if (prodlisttemp.PriceSell < prodlisttemp.PricePurchase)
                lbltemp.ForeColor = System.Drawing.Color.Red;

            HtmlTableCell temptype = (HtmlTableCell)e.Item.FindControl("tdType");
            if (plvtemp.Type == ProductType.Hz50)
            {
                temptype.Attributes["class"] = "hz50";
            }
            else if (plvtemp.Type == ProductType.Hz60)
            {
                temptype.Attributes["class"] = "hz60";
            }
        }

        protected void LoadSearch()
        {
            int recordcount;

            List<ProductListView> p = ControllerManager.Product.GetProductList(param, out recordcount);

            param.Pagecount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(recordcount) / Convert.ToDouble(param.PageSize)));

            QuantitySelectedAndChecked(recordcount);

            if (recordcount == 0)
                recordcount = param.PageSize;

            Pager1.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(recordcount) / Convert.ToDouble(param.PageSize)));
            Pager1.CurrentPage = param.PageNumber;
            Pager1.Step = 10;
            Pager1.DataBind();

            rpterProductList.DataSource = p;
            rpterProductList.DataBind();

            ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "closePopup", "<script>closePopup();</script>", false);
            ScriptManager.RegisterStartupScript(this.upFilters, GetType(), "closePopup", "<script>closePopup();</script>", false);
            ScriptManager.RegisterStartupScript(this.upFilters_Data, GetType(), "closePopup", "<script>closePopup();</script>", false);

        }

        protected void rpterProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                if (param.SortColumn == e.CommandArgument.ToString())
                    ChangeOrder();
                else
                {
                    param.SortColumn = e.CommandArgument.ToString();
                    param.SortOrder = "asc";
                }

                LoadSearch();
            }
        }

        #region ColumnOrder
        private void ChangeOrder()
        {
            if (param.SortOrder == "desc")
                param.SortOrder = "asc";
            else
                param.SortOrder = "desc";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CleanCheckedItemsList();
            SearchParameters();
            LoadSearch();
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "flipfilters", "<script>flip_filters();</script>", false);
        }

        protected void LoadCombos()
        {
            ddlFamilia.DataSource = ControllerManager.Family.GetCategoryList(2);
            ddlFamilia.DataTextField = "Name";
            ddlFamilia.DataValueField = "ID";
            ddlFamilia.DataBind();

            ddlRange.DataSource = ControllerManager.CtrRange.GetCTRRangeList();
            ddlRange.DataTextField = "Description";
            ddlRange.DataValueField = "ID";
            ddlRange.DataBind();

            ddlCurrency.DataSource = ControllerManager.Currency.GetAll();
            ddlCurrency.DataTextField = "Description";
            ddlCurrency.DataValueField = "ID";
            ddlCurrency.DataBind();

            ddlRange.Items.Insert(0, new ListItem("--Rango--", "0"));
            ddlFamilia.Items.Insert(0, new ListItem("--Familia--", "0"));
            ddlCurrency.Items.Insert(0, new ListItem("--Moneda--", "0"));

            //Load Categoy dropDown list in popUp
            
            ddlCategoryPage.DataSource = ControllerManager.Family.GetListItemCollection(ControllerManager.Family.GetCategoryList());
            ddlCategoryPage.DataTextField = "Text";
            ddlCategoryPage.DataValueField = "Value";
            ddlCategoryPage.DataBind();
            ddlCategoryPage.Items.Insert(0, new ListItem("--Categoría--", "0"));

            ddlCategory.DataSource = ControllerManager.Family.GetListItemCollection(ControllerManager.Family.GetAllFamily());
            ddlCategory.DataTextField = "Text";
            ddlCategory.DataValueField = "Value";
            ddlCategory.DataBind();

            ddlCategoryRemove.DataSource = ControllerManager.Family.GetListItemCollection(ControllerManager.Family.GetAllFamily()); ;
            ddlCategoryRemove.DataTextField= "Text";
            ddlCategoryRemove.DataValueField = "Value";
            ddlCategoryRemove.DataBind();
        }

        protected void lnkCheckAll_Click(object sender, EventArgs e)
        {
            selecteditems.Clear();
            Marked = true;
            MarkedAll.Attributes["class"] = "pressed";
            UnMarkedAll.Attributes["class"] = "";
            LoadSearch();
        }

        protected void lnkUnCheckAll_Click(object sender, EventArgs e)
        {
            CleanCheckedItemsList();
            UnMarkedAll.Attributes["class"] = "pressed";
            MarkedAll.Attributes["class"] = "";
            LoadSearch();
        }

        private void QuantitySelectedAndChecked(int recordcount)
        {
            if (Marked)
                lblMarkedCount.Text = (recordcount - (selecteditems.Count)).ToString();
            else if (!Marked)
                lblMarkedCount.Text = (selecteditems.Count).ToString();
            lblSelectedCount.Text = recordcount.ToString();
            if (Convert.ToInt32(lblMarkedCount.Text) > 0)
            {
                addToCategory.Enabled = true;
                lnkUnCheckAll.Enabled = true;
                addToCategory.Attributes.Add("onclick", "openAddCategoryPopup();");
                removeFromCategory.Enabled = true;
                removeFromCategory.Attributes.Add("onclick", "openRemoveCategoryPopup();");
            }
            else
            {
                addToCategory.Enabled = false;
                lnkUnCheckAll.Enabled = false;
                addToCategory.Attributes.Add("onclick", "");
                removeFromCategory.Enabled = false;
                removeFromCategory.Attributes.Add("onclick", "");
            }
        }

        protected void SearchParameters()
        {
            ProductType type;

            if (rblProductType.SelectedValue == "1")
                type = ProductType.Hz50;
            else if (rblProductType.SelectedValue == "2")
                type = ProductType.Hz60;
            else
                type = ProductType.Vacio;

            //Description or Code
            param.Description = txtDescripcion.Text;
            //Family Id
            param.Family = Convert.ToInt32(ddlFamilia.SelectedValue);
            //Range Id
            param.CtrRange = Convert.ToInt32(ddlRange.SelectedValue);
            //Product Type Enum Id
            param.ProductType = Convert.ToInt32(type);
            //Page Number
            param.PageNumber = Convert.ToInt32(ViewState["Pagina"]);
            //Page Size
            param.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            //Category Id
            param.Category = Convert.ToInt32(ddlCategoryPage.SelectedValue);
            //Currency Id
            param.Currency = Convert.ToInt32(ddlCurrency.SelectedValue);

            if (param.CtrRange != 0)
            {
                CtrRange tempctr = ControllerManager.CtrRange.GetById(param.CtrRange);
                lblFilterCTR.Text = string.Format("{0} a {1}", tempctr.Min.ToString("#0"), tempctr.Max.ToString("#0"));
                lblFilterCTR.Visible = true;
                btnCancelFilterCTR.Visible = true;
                if (param.Selection != 0)
                {
                    Selection seltemp = ControllerManager.Selection.GetById(Convert.ToInt32(param.Selection));
                    litSeleccion.Text = "Se encuentra filtrando su selección [" + seltemp.Description + "] por:";
                }
                else
                    litSeleccion.Text = "Se encuentra filtrando por: ";
            }
            else
            {
                lblFilterCTR.Visible = false;
                btnCancelFilterCTR.Visible = false;
            }
            if (param.Family != 0)
            {
                Family tempfam = ControllerManager.Family.GetById(param.Family);
                lblFilterFamily.Text = tempfam.Name;
                lblFilterFamily.Visible = true;
                btnCancelFilterFamily.Visible = true;
                if (param.Selection != 0)
                {
                    Selection seltemp = ControllerManager.Selection.GetById(Convert.ToInt32(param.Selection));
                    litSeleccion.Text = "Se encuentra filtrando su selección [" + seltemp.Description + "] por:";
                }
                else
                    litSeleccion.Text = "Se encuentra filtrando por: ";
            }
            else
            {
                lblFilterFamily.Visible = false;
                btnCancelFilterFamily.Visible = false;
            }
            if (param.Category != 0)
            {
                Family tempcat = ControllerManager.Family.GetById(param.Category);
                lblFilterCategory.Text = tempcat.Name;
                lblFilterCategory.Visible = true;
                btnCancelFilterCategory.Visible = true;
                if (param.Selection != 0)
                {
                    Selection seltemp = ControllerManager.Selection.GetById(Convert.ToInt32(param.Selection));
                    litSeleccion.Text = "Se encuentra filtrando su selección [" + seltemp.Description + "] por:";
                }
                else
                    litSeleccion.Text = "Se encuentra filtrando por: ";
            }
            else
            {
                lblFilterCategory.Visible = false;
                btnCancelFilterCategory.Visible = false;
            }
            if (param.ProductType != 0)
            {
                ProductType tempprodtype = (ProductType)param.ProductType;
                lblFilterType.Text = tempprodtype.ToString();
                lblFilterType.Visible = true;
                btnCancelFilterType.Visible = true;
                if (param.Selection != 0)
                {
                    Selection seltemp = ControllerManager.Selection.GetById(Convert.ToInt32(param.Selection));
                    litSeleccion.Text = "Se encuentra filtrando su selección [" + seltemp.Description + "] por:";
                }
                else
                    litSeleccion.Text = "Se encuentra filtrando por: ";
            }
            else
            {
                lblFilterType.Visible = false;
                btnCancelFilterType.Visible = false;
            }
            if (param.Currency != 0)
            {
                Currency tempcurr = ControllerManager.Currency.GetById(param.Currency);
                lblFilterCurrency.Text = tempcurr.Description;
                lblFilterCurrency.Visible = true;
                btnCancelFilterCurrency.Visible = true;
                if (param.Selection != 0)
                {
                    Selection seltemp = ControllerManager.Selection.GetById(Convert.ToInt32(param.Selection));
                    litSeleccion.Text = "Se encuentra filtrando su selección [" + seltemp.Description + "] por:";
                }
                else
                    litSeleccion.Text = "Se encuentra filtrando por: ";
            }
            else
            {
                lblFilterCurrency.Visible = false;
                btnCancelFilterCurrency.Visible = false;
            }
            if (!String.IsNullOrEmpty(param.Description))
            {
                if (param.Description.Length > 32)
                    lblFilterDescription.Text = param.Description.Substring(0, 29) + "...";
                else
                    lblFilterDescription.Text = param.Description;
                lblFilterDescription.Visible = true;
                btnCancelFilterDescription.Visible = true;
                if (param.Selection != 0)
                {
                    Selection seltemp = ControllerManager.Selection.GetById(Convert.ToInt32(param.Selection));
                    litSeleccion.Text = "Se encuentra filtrando su selección [" + seltemp.Description + "] por:";
                }
                else
                    litSeleccion.Text = "Se encuentra filtrando por: ";
            }
            else
            {
                lblFilterDescription.Visible = false;
                btnCancelFilterDescription.Visible = false;
            }
            if ((param.CtrRange == 0) && (param.Family == 0) && (param.Category == 0) && (param.ProductType == 0) && (param.Currency == 0) && (String.IsNullOrEmpty(param.Description)))
            {
                litSeleccion.Text = "No hay ningún filtro activo.";
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "flipfilters", "<script>flip_filters();</script>", false);
            }
        }
       
        private void Pager1_PageChanged(object sender, ctrl.Pager.PageChangedEventArgs e)
        {
            param.PageNumber = e.NewPageNumber;
            LoadSearch();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchParameters();
            LoadSearch();
        }

        private void CleanCheckedItemsList()
        {
            selecteditems.Clear();
            Marked = false;
        }

        #region CancelFilter

        protected void btnCancelFilterType_Click(object sender, EventArgs e)
        {
            rblProductType.SelectedIndex = 2;
            lblFilterType.Visible = false;
            btnCancelFilterType.Visible = false;
            SearchParameters();
            CleanCheckedItemsList();
            LoadSearch();
        }

        protected void btnCancelFilterFamily_Click(object sender, EventArgs e)
        {
            ddlFamilia.SelectedIndex = 0;
            lblFilterFamily.Visible = false;
            btnCancelFilterFamily.Visible = false;
            SearchParameters();
            CleanCheckedItemsList();
            LoadSearch();
        }

        protected void btnCancelFilterCategory_Click(object sender, EventArgs e)
        {
            ddlCategoryPage.SelectedIndex = 0;
            lblFilterCategory.Visible = false;
            btnCancelFilterCategory.Visible = false;
            SearchParameters();
            CleanCheckedItemsList();
            LoadSearch();
        }

        protected void btnCancelFilterCTR_Click(object sender, EventArgs e)
        {
            ddlRange.SelectedIndex = 0;
            lblFilterCTR.Visible = false;
            btnCancelFilterCTR.Visible = false;
            SearchParameters();
            CleanCheckedItemsList();
            LoadSearch();
        }

        protected void btnCancelFilterCurrency_Click(object sender, EventArgs e)
        {
            ddlCurrency.SelectedIndex = 0;
            lblFilterCurrency.Visible = false;
            btnCancelFilterCurrency.Visible = false;
            SearchParameters();
            CleanCheckedItemsList();
            LoadSearch();
        }

        protected void btnCancelFilterDescription_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            lblFilterDescription.Visible = false;
            btnCancelFilterDescription.Visible = false;
            SearchParameters();
            CleanCheckedItemsList();
            LoadSearch();
        }

        #endregion

        protected void btnAddToCategory_Click(object sender, EventArgs e)
        {

            if (!(((!Marked) && (selecteditems.Count > 0)) || (Marked)))
                btnAddToCategory.Enabled = false;

            if(ControllerManager.Family.Add(Marked, selecteditems, param, ControllerManager.Family.GetById(Convert.ToInt32(ddlCategory.SelectedValue))))
            {
                CleanCheckedItemsList();
                LoadSearch();
            }
        }

        protected void btnRemoveFromCategory_Click(object sender, EventArgs e)
        {
            if (!(((!Marked) && (selecteditems.Count > 0)) || (Marked)))
                btnAddToCategory.Enabled = false;

            if(ControllerManager.Family.Remove(Marked, selecteditems, param, ControllerManager.Family.GetById(Convert.ToInt32(ddlCategoryRemove.SelectedValue))))
                Response.Redirect("~/admin/modifyProduct.aspx");

        }

    }
}


