using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Expression;
using NHibernate.Transform;
using PartnerNet.Domain;
using PartnerNet.Domain.Helpers;
using ProjectBase.Data;
using System.Threading;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Drawing;
using System.Globalization;

namespace PartnerNet.Business
{
    public class AlertSaleOrderController : AbstractNHibernateDao<AlertSaleOrder, int>
    {
        public AlertSaleOrderController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public List<AlertSaleOrder> ShowAlert4()
        {
            ICriteria crit = GetCriteria();
            //crit.AddOrder(new Order("WayOfDelivery", true));
            return crit.List<AlertSaleOrder>() as List<AlertSaleOrder>;
        }

        public IList<CustomerHelper> GetCustomers()
        {
            ICriteria crit = GetCriteria();
            crit.SetProjection(Projections.ProjectionList()
                                   .Add(Projections.GroupProperty("CustomerName"))
                                   .Add(Projections.GroupProperty("CustomerCode"))
                );
            crit.AddOrder(new Order("CustomerCode", true));
            crit.SetResultTransformer(new AliasToBeanConstructorResultTransformer(typeof(CustomerHelper).GetConstructors()[0]));
            
            return crit.List<CustomerHelper>();
        }

        public List<AlertSaleOrder> Search(AlertSaleOrderType? type, string client, string product, DateTime? fromDate, DateTime? untilDate, string ovCode)
        {
            return Search(type, client, product, fromDate, untilDate, string.Empty, string.Empty, ovCode);
        }

        public List<AlertSaleOrder> Search(AlertSaleOrderType? type, string client, string product, DateTime? fromDate, DateTime? untilDate, string column, string order, string ovCode)
        {
            if (client == "--00--")
                client = string.Empty;
            bool boolorder = true;
            if (!string.IsNullOrEmpty(order) && order == "desc")
                boolorder = false;

            ICriteria crit = GetCriteria();
            ICriteria productCrit = null;

            if (type != null)
                crit.Add(Expression.Eq("Type", type));
            if (!string.IsNullOrEmpty(client))
                crit.Add(Expression.Eq("CustomerCode", client));
            if(!string.IsNullOrEmpty(product))
            {
                productCrit = crit.CreateCriteria("Product");
                productCrit.Add(Expression.Or(Expression.Like("Description", product, MatchMode.Anywhere), Expression.Like("ProductCode", product, MatchMode.Anywhere)));
            }

            if (fromDate != null)
                crit.Add(Expression.Ge("SaleOrderDeliveryDate", (DateTime) fromDate));
            if (untilDate != null)
                crit.Add(Expression.Le("SaleOrderDeliveryDate", (DateTime) untilDate));

            crit.Add(Expression.InsensitiveLike("SaleOrderCode", ovCode, MatchMode.Start));

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

            return crit.List<AlertSaleOrder>() as List<AlertSaleOrder>;
        }

        public void CleanAlertSaleOrder()
        {
            IQuery q = NHibernateSession.GetNamedQuery("sp_alertsaleorder_clean");
            q.UniqueResult();
        }

        public void ExportToExcel(AlertSaleOrderType? type, string client, string product, DateTime? fromDate, DateTime? untilDate, string column, string order, string ovCode)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");// Thread.CurrentThread.CurrentUICulture;

            GridView grdProductList = new GridView();
            grdProductList.AutoGenerateColumns = false;

            #region Columns
            BoundField bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "SaleOrderCode";
            bf.HeaderText = "OV";
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
            bf.DataField = "CustomerCode";
            bf.HeaderText = "Cliente";
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
            bf.DataField = "ProductDescription";
            bf.HeaderText = "Descripci&oacute;n";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "SaleOrderDeliveryDate";
            bf.HeaderText = "Fecha Entrega";
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
            bf.DataField = "Type";
            bf.HeaderText = "Status";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);
            #endregion

            grdProductList.DataSource = Search(type, client, product, fromDate, untilDate, column, order, ovCode);

            grdProductList.DataBind();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=SeguimientoDeEntregas.xls"));
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
                table.Rows[pos].Cells[0].Attributes.Add("class", "cF");
                table.Rows[pos].Cells[1].Attributes.Add("class", "cF");
                table.Rows[pos].Cells[2].Attributes.Add("class", "cF");
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
