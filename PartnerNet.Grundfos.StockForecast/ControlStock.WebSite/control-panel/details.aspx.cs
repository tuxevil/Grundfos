using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PartnerNet.Business;
using PartnerNet.Domain;
using System.Data.SqlClient;
using System.Drawing;
using PartnerNet.Domain.Helpers;

namespace Grundfos.StockForecast.control_panel
{
    public partial class details : System.Web.UI.Page
    {
        public string OrderField
        {
            get
            {
                if (ViewState["OrderField"] != null)
                    return ViewState["OrderField"].ToString();
                return string.Empty;
            }
            set { ViewState["OrderField"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["sortOrder"] = "";
            }
            if (Request.QueryString["alert"] != null)
            {
                List<Provider> providers = ControllerManager.Provider.GetFullProviderList();
                switch (Request.QueryString["alert"])
                {
                    case "1":
                        {
                            lblAlertName.Text = "Seguimiento de Ordenes de Compra";
                            DateTime? from;
                            DateTime? until;
                            bool? license;
                            WayOfDelivery? wayOfDelivery;
                            AlertPurchaseOrderType? type = GetAlert1Filters(out from, out until, out license, out wayOfDelivery);
                            List<AlertPurchaseOrder> lstConfNoEntregadas = ControllerManager.AlertPurchaseOrder.Search(type, txtProvider.Text, txtProduct.Text, txtPurchaseOrder.Text, from, until, license, OrderField, sortOrder, wayOfDelivery);
                            GVSeguimientoOc.DataSource = lstConfNoEntregadas;
                            GVSeguimientoOc.DataBind();
                            pnSeguimientoOc.Visible = true;
                            btnExportToExcel.Visible = (lstConfNoEntregadas.Count > 0);
                            Form.DefaultButton = btnAlert1Search.UniqueID;
                            lblTotalCountAlert1.Text = "Total: " + lstConfNoEntregadas.Count + " registros";
                            break;
                        }
                    case "3":
                        {
                            lblAlertName.Text = "Productos con Stock Negativo";
                            List<AlertProduct> lstStockNegativo = ControllerManager.AlertProduct.ShowAlert(OrderField, sortOrder, 1);
                            GVStockNegativo.DataSource = lstStockNegativo;
                            GVStockNegativo.DataBind();
                            pnStockNegativo.Visible = true;
                            btnExportToExcel.Visible = (lstStockNegativo.Count > 0);
                            lblTotalCountAlert3.Text = "Total: " + lstStockNegativo.Count + " registros";
                            break;
                        }
                    case "4":
                        {
                            lblAlertName.Text = "Seguimiento de Entregas";
                            if (Page.Request.Form.HasKeys())
                            {
                                Alert4Search(Page.Request.Form.Get("ctl00$cphContent$ddlClient"), OrderField);
                                pnSeguimientoOv.Visible = true;
                            }
                            else
                            {
                                List<AlertSaleOrder> lstNoCumplimentadas = ControllerManager.AlertSaleOrder.ShowAlert4();
                                FillAlert4(lstNoCumplimentadas, string.Empty);
                            }
                            Form.DefaultButton = btnAlert4Search.UniqueID;
                            break;
                        }
                    case "6":
                        {
                            lblAlertName.Text = "Nivel de Reposición";
                            GVRepositionFill();
                            break;
                        }
                }
            }
        }

        private void FillAlert4(List<AlertSaleOrder> lstNoCumplimentadas, string customerCode)
        {
            GVSeguimientoOV.DataSource = lstNoCumplimentadas;
            GVSeguimientoOV.DataBind();
            lblTotalCountAlert4.Text = "Total: " + lstNoCumplimentadas.Count + " registros";
            pnSeguimientoOv.Visible = true;
            btnExportToExcel.Visible = (lstNoCumplimentadas.Count > 0);
            List<CustomerHelper> finalCustomerNames = new List<CustomerHelper>();
            CustomerHelper def = new CustomerHelper("--Cliente--", "--00--");
            def.Name = "--Cliente--";
            finalCustomerNames.Add(def);
            finalCustomerNames.AddRange(ControllerManager.AlertSaleOrder.GetCustomers());
            ddlClient.DataSource = finalCustomerNames;
            ddlClient.DataTextField = "Name";
            ddlClient.DataValueField = "Code";
            if(!string.IsNullOrEmpty(customerCode))
                ddlClient.SelectedValue = customerCode;
            ddlClient.DataBind();
        }

        #region SortingGVOcConfirmadasNoEntregadas
        protected void GVOcConfirmadasNoEntregadas_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (OrderField == e.SortExpression)
                ChangeOrder();
            OrderField = e.SortExpression;
            DateTime? from;
            DateTime? until;
            bool? license;
            WayOfDelivery? wayOfDelivery;
            AlertPurchaseOrderType? type = GetAlert1Filters(out from, out until, out license, out wayOfDelivery);
            List<AlertPurchaseOrder> lstConfNoEntregadas = ControllerManager.AlertPurchaseOrder.Search(type, txtProvider.Text, txtProduct.Text, txtPurchaseOrder.Text, from, until, license, OrderField, sortOrder, wayOfDelivery); 
            GVSeguimientoOc.DataSource = lstConfNoEntregadas;
            GVSeguimientoOc.DataBind();
            pnSeguimientoOc.Visible = true;
            lblTotalCountAlert1.Text = "Total: " + lstConfNoEntregadas.Count + " registros";
        }
        #endregion

        #region SortingGVStockNegativo
        protected void GVStockNegativo_Sorting(object sender, GridViewSortEventArgs e)
         {
             if (OrderField == e.SortExpression)
                 ChangeOrder();
             OrderField = e.SortExpression;
             List<AlertProduct> lstStockNegativo = ControllerManager.AlertProduct.ShowAlert(OrderField, sortOrder, 1);
             GVStockNegativo.DataSource = lstStockNegativo;
             GVStockNegativo.DataBind();
             pnStockNegativo.Visible = true;
             lblTotalCountAlert3.Text = "Total: " + lstStockNegativo.Count + " registros";
          }
        #endregion

        #region SortingGVNoCumplimentadas
        protected void GVNoCumplimentadas_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (OrderField == e.SortExpression)
                ChangeOrder();
            OrderField = e.SortExpression;

            Alert4Search(Page.Request.Form.Get("ctl00$cphContent$ddlClient"), OrderField);
        }

        #endregion

        #region SortingGVReposicionDiferente
        
        protected void GVReposicionDiferente_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (OrderField == e.SortExpression)
                ChangeOrder();
            OrderField = e.SortExpression;
            GVRepositionFill();
        }

        #endregion

        #region DataGridSortOrder
        public string sortOrder
        {
            get
            {
                if (ViewState["sortOrder"] == null)
                    ViewState["sortOrder"] = "asc";
                return ViewState["sortOrder"].ToString();
            }
            set
            {
                ViewState["sortOrder"] = value;
            }
        }

        public void ChangeOrder()
        {
            if (ViewState["sortOrder"].ToString() == "desc")
                ViewState["sortOrder"] = "asc";
            else
                ViewState["sortOrder"] = "desc";
        }
        #endregion

        #region IndexChanged

        protected void GVOcConfirmadasNoEntregadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVSeguimientoOc.PageIndex = e.NewPageIndex;
            GVSeguimientoOc.DataBind();
        }

        protected void GVStockNegativo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVStockNegativo.PageIndex = e.NewPageIndex;
            GVStockNegativo.DataBind();
        }

        protected void GVNoCumplimentadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVSeguimientoOV.PageIndex = e.NewPageIndex;
            GVSeguimientoOV.DataBind();
        }

        protected void GVReposicionDiferente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVReposicionDiferente.PageIndex = e.NewPageIndex;
            GVReposicionDiferente.DataBind();
        }
        #endregion

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            switch (Request.QueryString["alert"])
            {
                case "1":
                    DateTime? fromAlert1;
                    DateTime? untilAlert1;
                    bool? license;
                    WayOfDelivery? wayOfDelivery;
                    AlertPurchaseOrderType? typeAlert1 = GetAlert1Filters(out fromAlert1, out untilAlert1, out license, out wayOfDelivery);
                    ControllerManager.AlertPurchaseOrder.ExportToExcel(typeAlert1, txtProvider.Text, txtProduct.Text, txtPurchaseOrder.Text, fromAlert1, untilAlert1, license, OrderField, sortOrder, wayOfDelivery);
                    break;
                case "3":
                    ControllerManager.AlertProduct.ExportToExcel(OrderField, sortOrder, 1);
                    break;
                case "4":
                    DateTime? from;
                    DateTime? until;
                    AlertSaleOrderType? type = GetAlert4Data(out from, out until);
                    ControllerManager.AlertSaleOrder.ExportToExcel(type, Page.Request.Form.Get("ctl00$cphContent$ddlClient"), txtAlert4Product.Text, from, until, OrderField, sortOrder, ddlOVType.SelectedValue);
                    break;
                case "5":
                    ControllerManager.AlertProduct.ExportToExcel(OrderField, sortOrder, 2);
                    break;
                case "6":
                    bool lowCost;
                    bool scalaRep0;
                    bool desc;
                    bool normal;
                    bool marked = GetFilters(out lowCost, out scalaRep0, out desc, out normal);
                    ControllerManager.AlertReposition.ExportToExcel(OrderField, sortOrder, marked, lowCost, scalaRep0, desc, normal);
                    break;
            }

        }

        protected void GVReposicionDiferente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                AlertReposition ar = (e.Row.DataItem as AlertReposition);
                if (ar != null)
                {
                    if (ar.IsConflicted)
                        e.Row.BackColor = Color.FromArgb(250, 128, 114);
                    Button temp = ((Button) e.Row.Cells[11].Controls[0]);
                    int id = Convert.ToInt32(temp.Text);
                    temp.CommandArgument = id.ToString();
                    if (ar.Product.AlertRepositionShow)
                        temp.Text = "Ocultar";
                    else temp.Text = "Mostrar";
                    temp = ((Button) e.Row.Cells[12].Controls[0]);
                    temp.CommandArgument = id.ToString();
                    if (ar.Product.LowCost)
                        temp.Text = "Alto";
                    else temp.Text = "Bajo";
                    if (ar.ProductName.EndsWith("#"))
                        e.Row.Cells[4].Text = ar.SemestralSales.ToString();
                }
            }
        }

        protected void GVReposicionDiferente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Show/Hide" || e.CommandName == "LowCost")
            {
                AlertReposition alert = ControllerManager.AlertReposition.GetById(Convert.ToInt32(e.CommandArgument));
                if (e.CommandName == "Show/Hide")
                    if (alert.Product.AlertRepositionShow)
                        alert.Product.AlertRepositionShow = false;
                    else alert.Product.AlertRepositionShow = true;
                else if (e.CommandName == "LowCost")
                    if (alert.Product.LowCost)
                        alert.Product.LowCost = false;
                    else alert.Product.LowCost = true;
                ControllerManager.AlertReposition.SaveOrUpdate(alert);

                GVRepositionFill();
            }
        }

        protected void cblFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            GVRepositionFill();
        }

        private void GVRepositionFill()
        {
            bool lowCost;
            bool scalaRep0;
            bool desc;
            bool normal;
            bool marked = GetFilters(out lowCost, out scalaRep0, out desc, out normal);
            List<AlertReposition> lstReposicionDife = ControllerManager.AlertReposition.ShowAlert(OrderField, sortOrder, marked, lowCost, scalaRep0, desc, normal);
            GVReposicionDiferente.DataSource = lstReposicionDife;
            GVReposicionDiferente.DataBind();
            pnReposicionDiferente.Visible = true;
            btnExportToExcel.Visible = (lstReposicionDife.Count > 0);
            lblTotalCountAlert6.Text = "Total: " + lstReposicionDife.Count + " registros";
        }

        private bool GetFilters(out bool lowCost, out bool scalaRep0, out bool desc, out bool normal)
        {
            bool marked = false;
            lowCost = false;
            scalaRep0 = false;
            desc = false;
            normal = false;
            foreach (ListItem item in cblFilters.Items)
            {
                if(item.Selected)
                    switch (item.Value)
                    {
                        case "0":
                            normal = true;
                            break;
                        case "1":
                            marked = true;
                            break;
                        case "2":
                            lowCost = true;
                            break;
                        case "3":
                            scalaRep0 = true;
                            break;
                        case "4":
                            desc = true;
                            break;
                    }
            }
            return marked;
        }

        protected void Alert4Search(string clientCode, string column)
        {
            DateTime? from;
            DateTime? until;
            AlertSaleOrderType? type = GetAlert4Data(out from, out until);

            List<AlertSaleOrder> lstNoCumplimentadas = ControllerManager.AlertSaleOrder.Search(type, clientCode, txtAlert4Product.Text, from, until, column, sortOrder, ddlOVType.SelectedValue);
            FillAlert4(lstNoCumplimentadas, clientCode);
        }

        private AlertSaleOrderType? GetAlert4Data(out DateTime? from, out DateTime? until)
        {
            from = null;
            until = null;
            AlertSaleOrderType? type = null;

            if (!string.IsNullOrEmpty(txtAlert4From.Text))
                from = DateTime.ParseExact(txtAlert4From.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(txtAlert4Until.Text))
                until = DateTime.ParseExact(txtAlert4Until.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (ddlAlert4Status.SelectedValue == "1")
                type = AlertSaleOrderType.Cumplimentada;
            else if (ddlAlert4Status.SelectedValue == "2")
                type = AlertSaleOrderType.NoCumplimentada;
            return type;
        }

        protected void GVNoCumplimentadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                AlertSaleOrder ar = (e.Row.DataItem as AlertSaleOrder);
                if (ar != null)
                {
                    if (ar.Type == AlertSaleOrderType.Cumplimentada)
                        e.Row.Cells[8].Text = "Disponible";
                    else e.Row.Cells[8].Text = "No Disponible";
                }
            }
        }

        protected void GVOcConfirmadasNoEntregadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                AlertPurchaseOrder ar = (e.Row.DataItem as AlertPurchaseOrder);
                if (ar != null)
                {
                    if (ar.WayOfDelivery == WayOfDelivery.Aereo)
                        e.Row.Cells[8].Text = "Aéreo";
                    else if (ar.WayOfDelivery == WayOfDelivery.Maritimo)
                        e.Row.Cells[8].Text = "Marítimo";
                    
                    if (ar.Type == AlertPurchaseOrderType.Confirmada)
                        e.Row.Cells[9].Text = "Confirmada";
                    else if (ar.Type == AlertPurchaseOrderType.NoConfirmada)
                        e.Row.Cells[9].Text = "No Confirmada";
                    else e.Row.Cells[9].Text = "En Tránsito";

                    if(ar.WayOfDelivery == WayOfDelivery.ND)
                        e.Row.Cells[8].Text = "N/D";
                }
            }
        }

        protected void btnAlert1Search_Click(object sender, EventArgs e)
        {
            DateTime? from;
            DateTime? until;
            bool? license;
            WayOfDelivery? wayOfDelivery;
            AlertPurchaseOrderType? type = GetAlert1Filters(out from, out until, out license, out wayOfDelivery);

            List<AlertPurchaseOrder> lstConfNoEntregadas = ControllerManager.AlertPurchaseOrder.Search(type, txtProvider.Text, txtProduct.Text, txtPurchaseOrder.Text, from, until, license, string.Empty, string.Empty, wayOfDelivery);
            GVSeguimientoOc.DataSource = lstConfNoEntregadas;
            GVSeguimientoOc.DataBind();
            btnExportToExcel.Visible = (lstConfNoEntregadas.Count > 0);
            lblTotalCountAlert1.Text = "Total: " + lstConfNoEntregadas.Count + " registros";
        }

        private AlertPurchaseOrderType? GetAlert1Filters(out DateTime? from, out DateTime? until, out bool? license, out WayOfDelivery? wayOfDelivery)
        {
            from = null;
            until = null;
            AlertPurchaseOrderType? type = null;
            license = null;
            wayOfDelivery = null;

            if (!string.IsNullOrEmpty(txtAlert1From.Text))
                from = DateTime.ParseExact(txtAlert1From.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(txtAlert1Until.Text))
                until = DateTime.ParseExact(txtAlert1Until.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (ddlAlert1Status.SelectedValue == "1")
                type = AlertPurchaseOrderType.NoConfirmada;
            else if (ddlAlert1Status.SelectedValue == "2")
                type = AlertPurchaseOrderType.Confirmada;
            else if (ddlAlert1Status.SelectedValue == "3")
                type = AlertPurchaseOrderType.Transito;
            if (ddlAlert1Licence.SelectedValue == "1")
                license = true;
            else if (ddlAlert1Licence.SelectedValue == "2")
                license = false;
            if(ddlWayOfDelivery.SelectedValue != "-1")
                wayOfDelivery = (WayOfDelivery) Convert.ToInt32(ddlWayOfDelivery.SelectedValue);
            return type;
        }

        protected void btnAlert4Search_Click(object sender, EventArgs e)
        {
            Alert4Search(Page.Request.Form.Get("ctl00$cphContent$ddlClient"), string.Empty);
        }
   } 
}
