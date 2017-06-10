using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Expression;
using NHibernate.Transform;
using PartnerNet.Domain;
using ProjectBase.Data;
using System.Threading;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Globalization;

namespace PartnerNet.Business
{
    public class AlertPurchaseOrderController : AbstractNHibernateDao<AlertPurchaseOrder, int>
    {
        public AlertPurchaseOrderController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public List<AlertPurchaseOrder> ShowAlert1()
        {
            ICriteria crit = GetCriteria();
            return crit.List<AlertPurchaseOrder>() as List<AlertPurchaseOrder>;
        }

        public List<AlertPurchaseOrder> ShowAlert(string column, string order)
        {
            return Search(null, string.Empty, string.Empty, string.Empty, null, null, null, column, order, null);
        }

        public List<AlertPurchaseOrder> Search(AlertPurchaseOrderType? type, string provider, string product, string purchaseOrder, DateTime? fromDate, DateTime? untilDate, bool? license, WayOfDelivery? wayOfDelivery)
        {
            return Search(type, provider, product, purchaseOrder, fromDate, untilDate, license, string.Empty, string.Empty, wayOfDelivery);
        }

        public List<AlertPurchaseOrder> Search(AlertPurchaseOrderType? type, string provider, string product, string purchaseOrder, DateTime? fromDate, DateTime? untilDate, bool? license, string column, string order, WayOfDelivery? wayOfDelivery)
        {
            bool boolorder = true;
            if (order == "desc")
                boolorder = false;
            
            ICriteria crit = GetCriteria();
            ICriteria productCrit = null;

            if (type != null)
                crit.Add(Expression.Eq("Type", type));
            if (!string.IsNullOrEmpty(provider))
                crit.Add(Expression.InsensitiveLike("PurchaseOrderProviderCode", provider, MatchMode.Anywhere));
            if (!string.IsNullOrEmpty(purchaseOrder))
                crit.Add(Expression.InsensitiveLike("PurchaseOrderCode", purchaseOrder, MatchMode.Anywhere));
            if(!string.IsNullOrEmpty(product) || license != null)
            {
                productCrit = crit.CreateCriteria("Product"); 
                if(!string.IsNullOrEmpty(product))
                    productCrit.Add(Expression.Or(Expression.Like("Description", product, MatchMode.Anywhere), Expression.Like("ProductCode", product, MatchMode.Anywhere)));
                if(license != null && (bool)license)
                    productCrit.Add(Expression.Like("Description", "#", MatchMode.End));
                else if (license != null && (bool)!license)
                    productCrit.Add(Expression.Not(Expression.Like("Description", "#", MatchMode.End)));
            }

            if (fromDate != null)
                crit.Add(Expression.Ge("ArrivalDate", (DateTime)fromDate));
            if (untilDate != null)
                crit.Add(Expression.Le("ArrivalDate", (DateTime)untilDate));

            if (wayOfDelivery != null && (int)wayOfDelivery >= 0)
                crit.Add(Expression.Eq("WayOfDelivery", wayOfDelivery));

            string[] sortfield = new string[2];
            char[] separator = new char[1];
            separator[0] = '.';
            sortfield = column.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (sortfield.Length == 1)
                crit.AddOrder(new Order(sortfield[0], boolorder));
            else if (sortfield.Length == 2)
            {
                if (productCrit == null)
                    productCrit = crit.CreateCriteria("Product");
                productCrit.AddOrder(new Order(sortfield[1], boolorder));
            }

            return crit.List<AlertPurchaseOrder>() as List<AlertPurchaseOrder>;
        }

        public void CleanAlertPurchaseOrder()
        {
            IQuery q = NHibernateSession.GetNamedQuery("sp_alertpurchaseorder_clean");
            q.UniqueResult();
        }

        public void ExportToExcel(AlertPurchaseOrderType? type, string provider, string product, string purchaseOrder, DateTime? fromDate, DateTime? untilDate, bool? license, string column, string order, WayOfDelivery? wayOfDelivery)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");// Thread.CurrentThread.CurrentUICulture;

            GridView grdProductList = new GridView();
            grdProductList.AutoGenerateColumns = false;

            #region Columns
            BoundField bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "PurchaseOrderCode";
            bf.HeaderText = "OC";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "PurchaseOrderProviderCode";
            bf.HeaderText = "C&oacute;digo de Proveedor";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "ProductCode";
            bf.HeaderText = "Producto";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "ProductDescription";
            bf.HeaderText = "Descripci&oacute;n";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);
            
            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "Quantity";
            bf.HeaderText = "Cantidad";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "ArrivalDate";
            bf.HeaderText = "Confirmaci&oacute;n";
            bf.HtmlEncode = false;
            bf.DataFormatString = "{0:dd/MM/yyyy}";  
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "PurchaseOrderDate";
            bf.HeaderText = "Creada";
            bf.HtmlEncode = false;
            bf.DataFormatString = "{0:dd/MM/yyyy}";  
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "GAP";
            bf.HeaderText = "GAP";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "WayOfDelivery";
            bf.HeaderText = "Modo Env&iacute;o";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "Type";
            bf.HeaderText = "Status";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);
            #endregion
            grdProductList.DataSource = Search(type, provider, product, purchaseOrder, fromDate, untilDate, license, column, order, wayOfDelivery);
            
            grdProductList.DataBind();

            HttpContext.Current.Response.Clear();
            
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=SeguimientoOC.xls"));
            
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();
            table.GridLines = grdProductList.GridLines;

            //Set the Cell format 
            string codeFormat = @"<style>.cF  { mso-number-format:'\@'; }</style>";

            //  add the header row to the table
            if (grdProductList.HeaderRow != null)
            {
                PrepareControlForExport(grdProductList.HeaderRow);
                table.Rows.Add(grdProductList.HeaderRow);
                table.Rows[0].ForeColor = Color.FromArgb(102, 102, 102);

                for (int i = 0; i < table.Rows[0].Cells.Count; i++)
                    table.Rows[0].Cells[i].BackColor = Color.FromArgb(225, 224, 224);
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in grdProductList.Rows)
            {
                PrepareControlForExport(row);
                int pos = table.Rows.Add(row);
                table.Rows[pos].Cells[1].Attributes.Add("class", "cF");
                table.Rows[pos].Cells[2].Attributes.Add("class", "cF");
                table.Rows[pos].Cells[3].Width = 300;
            }

            //  render the table into the htmlwriter
            table.RenderControl(htw);

            //  render the htmlwriter into the response adding de style
            HttpContext.Current.Response.Write(codeFormat + sw.ToString());
            HttpContext.Current.Response.End();
        }

        private void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];


                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }

                if (current.HasControls())
                {
                    PrepareControlForExport(current);
                }
            }
        }
    }
}
