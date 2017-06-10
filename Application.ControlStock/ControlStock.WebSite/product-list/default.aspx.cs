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
using Grundfos.StockForecast.Templates;
using PartnerNet.Business;
using PartnerNet.Common;
using PartnerNet.Domain;

namespace Grundfos.StockForecast.product_list
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
            Label6.Visible = false;
            Pager1.PageChanged += Pager1_PageChanged;
            Pager2.PageChanged += Pager1_PageChanged;
            if (!IsPostBack)
            {
                Cargar_Grupo();
                Cargar_Selecciones();
                Cargar_Proveedores();
            }
        }

        protected void repItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            ProductInformation pi = (ProductInformation)e.Item.DataItem;

            Detalle det = (Detalle)e.Item.FindControl("ucDetalle");
            det.ProductId = pi.Id;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            IList<Product> selectedproduct = new List<Product>();

            foreach (RepeaterItem rep in repItems.Items)
            {
                if (((CheckBox)rep.FindControl("CheckBox1")).Checked)
                {
                    Product prod = ControllerManager.Product.GetById(Convert.ToInt32(((CheckBox)rep.FindControl("CheckBox1")).ToolTip));
                    selectedproduct.Add(prod);
                }
            }
            if (selectedproduct.Count > 0 && txtChangeSafety.Text != "")
            {
                ControllerManager.Product.UpdateProductSafety(selectedproduct, Convert.ToInt32(txtChangeSafety.Text));
            }
            else
            {
                Label6.Visible = true;
            }
            Cargar_Busqueda();
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            string selection = DropDownList4.SelectedValue;
            if (TextBox6.Text != "")
            {
                ControllerManager.ProductSet.CreateNewProductSet(TextBox6.Text);
                IList<ProductSet> selections = ControllerManager.ProductSet.GetProductSetList();

                if (selections != null)
                {
                    DropDownList3.Items.Clear();
                    DropDownList4.Items.Clear();
                    DropDownList5.Items.Clear();
                    ListItem NA = new ListItem("--Seleccion--", "0");
                    DropDownList3.Items.Add(NA);
                    DropDownList4.Items.Add(NA);
                    DropDownList5.Items.Add(NA);
                    foreach (ProductSet sel in selections)
                    {
                        ListItem selectionlist = new ListItem(sel.Name, sel.Id.ToString());
                        DropDownList3.Items.Add(selectionlist);
                        DropDownList4.Items.Add(selectionlist);
                        DropDownList5.Items.Add(selectionlist);
                        if (sel.Name == TextBox6.Text)
                            selection = sel.Id.ToString();
                    }
                }
            }

            IList<Product> selectedproduct = new List<Product>();

            foreach (RepeaterItem rep in repItems.Items)
            {
                if (((CheckBox)rep.FindControl("CheckBox1")).Checked)
                {
                    Product prod = ControllerManager.Product.GetById(Convert.ToInt32(((CheckBox)rep.FindControl("CheckBox1")).ToolTip));
                    selectedproduct.Add(prod);
                }
            }
            if (selectedproduct.Count > 0)
            {
                ControllerManager.ProductSet.AddProductToProductSet(Convert.ToInt32(selection), selectedproduct);

                Cargar_Busqueda();
                TextBox6.Text = "";
            }
            else
            {
                Label6.Visible = true;
                TextBox6.Text = "";
            }
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            IList<Product> selectedproduct = new List<Product>();

            foreach (RepeaterItem rep in repItems.Items)
            {
                if (((CheckBox)rep.FindControl("CheckBox1")).Checked)
                {
                    Product prod = ControllerManager.Product.GetById(Convert.ToInt32(((CheckBox)rep.FindControl("CheckBox1")).ToolTip));
                    selectedproduct.Add(prod);
                }
            }
            if (selectedproduct.Count > 0)
            {
                ControllerManager.ProductSet.DelProductFromProductSet(Convert.ToInt32(DropDownList5.SelectedValue), selectedproduct);
                Cargar_Busqueda();
            }
            else
            {
                Label6.Visible = true;
            }
        }

        protected void Cargar_Busqueda()
        {
            DisplayInfo(10, Convert.ToInt32(ViewState["page"]));
        }

        protected void Cargar_Grupo()
        {
            IList<string> groups = ControllerManager.Product.GetGroups();
            if (groups != null)
            {
                foreach (string group in groups)
                {
                    DropDownList2.Items.Add(group);
                }
            }
        }

        protected void Cargar_Proveedores()
        {
            IList<Provider> providers = ControllerManager.Provider.GetProviderList();
            if (providers != null)
            {

                foreach (Provider prov in providers)
                {
                    ListItem LI = new ListItem(prov.Name, prov.Id.ToString());
                    DropDownList1.Items.Add(LI);
                }
            }
        }

        protected void Cargar_Selecciones()
        {
            IList<ProductSet> selections = ControllerManager.ProductSet.GetProductSetList();

            if (selections != null)
            {
                DropDownList3.Items.Clear();
                DropDownList4.Items.Clear();
                DropDownList5.Items.Clear();
                ListItem NA = new ListItem("--Seleccion--", "0");
                DropDownList3.Items.Add(NA);
                DropDownList4.Items.Add(NA);
                DropDownList5.Items.Add(NA);
                foreach (ProductSet sel in selections)
                {
                    ListItem selectionlist = new ListItem(sel.Name, sel.Id.ToString());
                    DropDownList3.Items.Add(selectionlist);
                    DropDownList4.Items.Add(selectionlist);
                    DropDownList5.Items.Add(selectionlist);
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value != "" || (args.Value == "" && (Convert.ToInt32(DropDownList1.SelectedValue) > 0 || Convert.ToInt32(DropDownList2.SelectedValue) > 0 || Convert.ToInt32(DropDownList3.SelectedValue) > 0)));

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rep in repItems.Items)
            {
                ((CheckBox)rep.FindControl("CheckBox1")).Checked = true;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rep in repItems.Items)
            {
                ((CheckBox)rep.FindControl("CheckBox1")).Checked = false;
            }
        }

        protected void repItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {


            if (e.CommandName == "Expand")
            {
                Detalle det = (Detalle)e.Item.FindControl("ucDetalle");
                det.Visible = true;
                det.LoadInformation();
            }
            else if (e.CommandName == "Save")
            {
                IList<Product> selectedproduct = new List<Product>();
                Product prod = ControllerManager.Product.GetById(Convert.ToInt32(((ImageButton)e.Item.FindControl("btnGuardarInd")).ToolTip));
                selectedproduct.Add(prod);

                ControllerManager.Product.UpdateProductSafety(selectedproduct, Convert.ToInt32(((TextBox)e.Item.FindControl("TextBox2")).Text));
                ControllerManager.Product.UpdateProductLeadTime(selectedproduct, Convert.ToInt32(((TextBox)e.Item.FindControl("TextBox3")).Text));
                ControllerManager.Product.UpdateProductRepositionPoint(selectedproduct, Convert.ToInt32(((TextBox)e.Item.FindControl("TextBox5")).Text));
            }
        }

        private void Pager1_PageChanged(object sender, Controls_Pager.PageChangedEventArgs e)
        {
            DisplayInfo(10, e.NewPageNumber);
        }

        private void DisplayInfo(int pageSize, int currentPage)
        {
            PagedDataSource pagedItems = new PagedDataSource();

            pagedItems.DataSource = ControllerManager.Product.GetProductInformation(TextBox1.Text, DropDownList2.SelectedValue, Convert.ToInt32(DropDownList3.SelectedValue), Convert.ToInt32(DropDownList1.SelectedValue), Config.CurrentWeek, Config.CurrentDate.Year, 0, 0);
            pagedItems.AllowPaging = true;
            pagedItems.PageSize = pageSize;
            pagedItems.CurrentPageIndex = currentPage - 1;
            Pager1.PageCount = pagedItems.PageCount;
            Pager2.PageCount = Pager1.PageCount;
            Pager1.CurrentPage = currentPage;
            Pager2.CurrentPage = Pager1.CurrentPage;
            repItems.DataSource = pagedItems;
            repItems.DataBind();
            if (pagedItems.PageCount < 1)
            {
                Pager1.Visible = false;
                Pager2.Visible = false;
            }

            Pager1.Step = 4;
            Pager2.Step = 4;
            Pager1.DataBind();
            Pager2.DataBind();

        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsValid)
                return;

            ViewState["page"] = "1";
            Cargar_Busqueda();
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            IList<Product> selectedproduct = new List<Product>();

            foreach (RepeaterItem rep in repItems.Items)
            {
                if (((CheckBox)rep.FindControl("CheckBox1")).Checked)
                {
                    Product prod = ControllerManager.Product.GetById(Convert.ToInt32(((CheckBox)rep.FindControl("CheckBox1")).ToolTip));
                    selectedproduct.Add(prod);
                }
            }
            if (selectedproduct.Count > 0)
            {
                foreach (Product prod in selectedproduct)
                    ControllerManager.PurchaseOrder.GeneratePO(prod, Config.CurrentWeek + 1, Config.CurrentDate.Year, (PurchaseOrderType)2, prod.RepositionPoint);
                //cambiar la semana, quitarle el +1, es solo para pruebas
            }

        }

        protected void TextBox1_DataBinding(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            ViewState["page"] = "1";
            Cargar_Busqueda();
        }
    }
}
