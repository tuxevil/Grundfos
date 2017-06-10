using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Common;
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite.pl
{
    public partial class _default : System.Web.UI.Page
    {
        #region Properties 

        private SearchParams param
        {
            get
            {
                if (ViewState["SearchParams"] == null)
                {
                    SearchParams temp = new SearchParams();
                    temp.SortOrder = "asc";
                    ViewState["SearchParams"] = temp;
                }

                return (SearchParams)ViewState["SearchParams"];
            }
        }

        private List<string> SelectedItems
        {
            get
            {
                if (ViewState["Selected"] == null)
                    ViewState["Selected"] = new List<string>();


                return (List<string>)ViewState["Selected"];
            }
            set { ViewState["Selected"] = value; }
        }

        private DateTime searchDate
        {
            get { return (DateTime)ViewState["searchDate"]; }
            set { ViewState["searchDate"] = value; }
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

        private int TotalCount
        {
            get { return (ViewState["TotalCount"] == null) ? 0 : (int)ViewState["TotalCount"]; }
            set { ViewState["TotalCount"] = value; }
        }
    
        private int TotalSelected
        {
            get
            {
                int totalSelected = 0;
                if (Marked)
                    totalSelected = TotalCount - SelectedItems.Count;
                else
                    totalSelected = SelectedItems.Count;
                return totalSelected;
            }
        }

        #endregion

        #region Page Load Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Pager1.PageChanged += Pager1_PageChanged;
            PagerSelections1.PageChanged += PagerSelections1_PageChanged;

            if (!IsPostBack)
            {
                ViewState["Pagina"] = 1;
                ViewState["Currency"] = ControllerManager.Currency.GetBaseCurrency(); 
                txtDescripcion.Focus();

                LoadCombos();

                if (Request.QueryString[Config.QS_SELECTION] != null)
                {
                    param.PageNumber = 1;
                    CleanCheckedItemsList();

                    Selection s = ControllerManager.Selection.GetById(Convert.ToInt32(Request.QueryString[Config.QS_SELECTION]));

                    if (s == null)
                        return;

                    param.Selection = s.ID;
                    litSeleccion.Text = "Se encuentra filtrando su selección [" + s.Description + "] por:";
                    lnkTakeOutOfSelection.Text = "Quitar de Selección [" + s.Description + "]";
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "flipfilters", "<script>flip_filters();</script>", false);
                    btnAddToSelection.Visible = false;
                    //ddlSelecciones.Items.Remove(s.Description);
                }

                LoadSelections(1);
                LoadSearch();
                btnUpdateChecked.Attributes.Add("onclick", "closePopup();");
                
                if (User.IsInRole("User") || User.IsInRole("Administrator"))
                    EnableUserControls();
            }
        }

        protected void LoadCombos()
        {
            LoadSelections(1);

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

            ddlCategory.DataSource = ControllerManager.Family.GetListItemCollection(ControllerManager.Family.GetCategoryList());
            ddlCategory.DataTextField = "Text";
            ddlCategory.DataValueField = "Value";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Categoría--", "0"));
        }

        protected void EnableUserControls()
        {
            do_change_price_selection.Visible = true;
            if(User.IsInRole("Administrator"))
                EnableAdminControls();
        }

        protected void EnableAdminControls()
        {
            HtmlGenericControl temp = (HtmlGenericControl) Master.FindControl("lnkAdmin");
            temp.Visible = true;
        }

        #endregion

        #region Search Events

        protected void LoadSearch()
        {
            int recordcount = 0;
            param.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);

            List<ProductListView> p = ControllerManager.Product.GetProductList(param, out recordcount);
            param.Pagecount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(recordcount) / Convert.ToDouble(param.PageSize)));

            TotalCount = recordcount;

            QuantitySelectedAndChecked();

            if (recordcount == 0)
                recordcount = param.PageSize;

            Pager1.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(recordcount) / Convert.ToDouble(param.PageSize)));
            Pager1.CurrentPage = param.PageNumber;
            Pager1.Step = 10;
            Pager1.DataBind();

            rpterProductList.DataSource = p;
            rpterProductList.DataBind();

            searchDate = DateTime.Now;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CleanCheckedItemsList();
            SearchParameters();
            LoadSearch();
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "flipfilters", "<script>flip_filters();</script>", false);
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
            param.Category = Convert.ToInt32(ddlCategory.SelectedValue);
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
            if((param.CtrRange == 0)&&(param.Family == 0)&&(param.Category == 0)&&(param.ProductType == 0)&&(param.Currency == 0)&&(String.IsNullOrEmpty(param.Description)))
            {
                litSeleccion.Text = "No hay ningún filtro activo.";
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "flipfilters", "<script>flip_filters();</script>", false);
            }
        }

        #endregion

        #region Grid Events

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbox = (CheckBox)sender;
            if (Marked)
            {
                if (!chbox.Checked)
                    SelectedItems.Add(chbox.ValidationGroup);
                else
                    SelectedItems.Remove(chbox.ValidationGroup);
            }
            else
            {
                if (chbox.Checked)
                    SelectedItems.Add(chbox.ValidationGroup);
                else
                    SelectedItems.Remove(chbox.ValidationGroup);
            }

            QuantitySelectedAndChecked();
            if ((Marked) && (SelectedItems.Count > 0))
                MarkedAll.Attributes["class"] = "";
            else if ((!Marked) && (SelectedItems.Count > 0))
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
                    case "LPPA.PCR":
                        orderArrow = (LinkButton)e.Item.FindControl("lnkPCR");
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
            
            string currency = ViewState["Currency"].ToString();
            ((Label)e.Item.FindControl("lblBaseCurrency")).Text = currency + " ";
            CheckBox chktemp = (CheckBox)e.Item.FindControl("chbSelected");
            if (!Marked)
            {
                if (!string.IsNullOrEmpty(SelectedItems.Find(delegate(string record)
                                                                 {
                                                                     if (record == prodlisttemp.ID.ToString())
                                                                     {
                                                                         return true;
                                                                     }
                                                                     return false;
                                                                 })))
                {
                    chktemp.Checked = true;
                }
                else
                {
                    chktemp.Checked = false;
                }
            }
            else if (Marked)
            {
                if (!string.IsNullOrEmpty(SelectedItems.Find(delegate(string record)
                                                                 {
                                                                     if (record == prodlisttemp.ID.ToString())
                                                                     {
                                                                         return true;
                                                                     }
                                                                     return false;
                                                                 })))
                {
                    chktemp.Checked = false;
                }
                else
                {
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

        protected void rpterProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                if (param.SortColumn == e.CommandArgument.ToString())
                    if (param.SortOrder == "desc")
                        param.SortOrder = "asc";
                    else
                        param.SortOrder = "desc";
                else
                {
                    param.SortColumn = e.CommandArgument.ToString();
                    param.SortOrder = "asc";
                }
                param.PageNumber = 1;
                LoadSearch();
                UpdatePanel1.Update();
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

        protected void btnCheckUncheck_Click(object sender, EventArgs e)
        {
            LinkButton tempbutton = (LinkButton)sender;
            foreach (RepeaterItem item in rpterProductList.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chbSelected");
                if (chk.Checked != Convert.ToBoolean(tempbutton.ValidationGroup))
                {
                    chk.Checked = Convert.ToBoolean(tempbutton.ValidationGroup);
                    CheckBox_CheckedChanged((CheckBox)item.FindControl("chbSelected"), e);
                }
            }
            if (tempbutton.ValidationGroup == "true")
                tempbutton.ValidationGroup = "false";
            else
                tempbutton.ValidationGroup = "true";
        }

        #endregion

        #region Selection List Events

        protected void LoadSelections(int pageNumber)
        {
            int recordcount;
            int pageSize = 5;

            rptSelection.DataSource = ControllerManager.Selection.GetSelectionList(pageNumber, out recordcount);

            if (recordcount == 0)
                recordcount = pageSize;

            PagerSelections1.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(recordcount) / Convert.ToDouble(pageSize)));
            PagerSelections1.CurrentPage = pageNumber;
            PagerSelections1.Step = 3;
            PagerSelections1.DataBind();

            rptSelection.DataBind();

            ddlSelecciones.DataSource = ControllerManager.Selection.GetSelectionList(0, out recordcount);
            ddlSelecciones.DataTextField = "Description";
            ddlSelecciones.DataValueField = "ID";
            ddlSelecciones.DataBind();

            ddlSelecciones.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        protected void rptSelection_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            
            HtmlGenericControl tbrtemp = (HtmlGenericControl)e.Item.FindControl("listitem");
            
            if (param.Selection != 0)
            {
                Selection tempsel = ControllerManager.Selection.GetById(param.Selection);
                if ((Selection)e.Item.DataItem == tempsel)
                {
                    tbrtemp.Attributes["class"] = "current";
                    //litSeleccion.Text = tempsel.Description;
                    lnkTakeOutOfSelection.Text = "Quitar de Selección [" + tempsel.Description + "]";
                    lnkTakeOutOfSelection.Visible = true;
                }
                else tbrtemp.Attributes["class"] = "";
            }
        }

        private void PagerSelections1_PageChanged(object sender, ctrl.PagerSelections.PageChangedEventArgs e)
        {
            LoadSelections(e.NewPageNumber);
        }

        #endregion

        #region Mark Events

        protected void lnkCheckAll_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            SelectedItems.Clear();
            Marked = true;
            LoadSearch();
        }

        protected void lnkUnCheckAll_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            CleanCheckedItemsList();
            Marked = false;
            LoadSearch();
        }

        private void CleanCheckedItemsList()
        {
            SelectedItems.Clear();
            Marked = false;
        }

        private void QuantitySelectedAndChecked()
        {
            lblMarkedCount.Text = TotalSelected.ToString();
            lblSelectedCount.Text = TotalCount.ToString();

            if (this.TotalSelected > 0)
            {
                lnkTakeOutOfSelection.Enabled = true;
                lnkUnCheckAll.Enabled = true;
                btnExportExcel.Enabled = true;
                btnExportExcel.ImageUrl = "~/img/Excel Icon.edited.JPG";
                btnExportPDF.Enabled = true;
                btnExportPDF.ImageUrl = "~/img/adobe-acrobat-pdf-icon.edited.JPG";
                if (Request.QueryString[Config.QS_SELECTION] == null)
                {
                    addToSelection.Enabled = true;
                    addToSelection.Attributes.Add("onclick", "openAddSelectionPopup();");
                }
                do_change_price_selection.Enabled = true;
                do_change_price_selection.Attributes.Add("onclick", "openChangePricePopupTotal();");
            }
            else
            {
                lnkTakeOutOfSelection.Enabled = false;
                lnkUnCheckAll.Enabled = false;
                btnExportExcel.Enabled = false;
                btnExportExcel.ImageUrl = "~/img/Excel Icon.edited-blocked.JPG";
                btnExportPDF.Enabled = false;
                btnExportPDF.ImageUrl = "~/img/adobe-acrobat-pdf-icon.edited-blocked.JPG";
                addToSelection.Enabled = false;
                do_change_price_selection.Enabled = false;
                addToSelection.Attributes.Add("onclick", "");
                do_change_price_selection.Attributes.Add("onclick", "");
            }
            if (param.Selection != 0)
                lnkTakeOutOfSelection.Visible = true;

            pnlBar.Update();
            UpdatePanel2.Update();
            UpdatePanel3.Update();
        }

        #endregion

        #region Add/Remove To/From Selection Events

        protected void lnkTakeOutOfSelection_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (ControllerManager.Selection.Remove(Marked, SelectedItems, param))
            {
                CleanCheckedItemsList();
                LoadSearch();
            }
                
        }

        protected void btnAddToSelection_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            
            //TODO: Move to database processing, is vey expensive to do this kind of updates on several records that could be thousands.
            string error;
            int newselectionid;
            if (ControllerManager.Selection.Add(Marked, SelectedItems, param, txtNewSelection.Text, ddlSelecciones.SelectedValue, out error, out newselectionid))
                Response.Redirect("~/pl/default.aspx?s=" + newselectionid);
            else
                 Response.Redirect("~/pl/default.aspx");
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "openConcurrencyErrorAlert", "closePopup();", true);
               
        }

        #endregion

        #region Global Price Change Events 

        protected void btnUpdateChecked_Click(object sender, EventArgs e)
        {
            
            if ((!Page.IsValid) || (string.IsNullOrEmpty(txtModValor.Text) && string.IsNullOrEmpty(txtModCTR.Text)))
            {
                return;
            }
            List<ProductPrice> lstProductPrices = new List<ProductPrice>();
            if(ControllerManager.Product.Update(Marked, SelectedItems, param, txtModValor.Text, txtModCTR.Text, searchDate, out lstProductPrices))
            {
                QuantitySelectedAndChecked();
                LoadSearch();

                txtModCTR.Text = "";
                txtModValor.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "openConcurrencyErrorAlert", "alert('Hubo " + lstProductPrices.Count + " productos que se modificaron con anterioridad por otro usuario.');", true);

                CleanCheckedItemsList();
                foreach (ProductPrice pp in lstProductPrices)
                    SelectedItems.Add(pp.ID.ToString());
            }
        }

        #endregion

        #region Export Events

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (lblMarkedCount.Text != "0")
            {
                Session["SearchParams"] = param;
                Session["SelectedItems"] = SelectedItems;
                Session["Marked"] = Marked;
                
                //SearchParameters();
                Response.Redirect("~/res/Export.aspx?btn=1");
            }
        }

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (lblMarkedCount.Text != "0")
            {
                Session["SearchParams"] = param;
                Session["SelectedItems"] = SelectedItems;
                Session["Marked"] = Marked;

                //SearchParameters();
                Response.Redirect("~/res/Export.aspx?btn=2");
            }

        }

        #endregion

        #region Filter Removing Events

        protected void btnCancelFilterType_Click(object sender, EventArgs e)
        {
            rblProductType.SelectedIndex = 2;
            lblFilterType.Visible = false;
            btnCancelFilterType.Visible = false;
            SearchParameters();
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
            ddlCategory.SelectedIndex = 0;
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

        protected void btnCancelSelection_Click(object sender, EventArgs e)
        {
            Response.Redirect("../pl/");
        }

        #endregion

    }
}
