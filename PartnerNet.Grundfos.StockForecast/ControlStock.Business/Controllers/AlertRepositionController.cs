using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Expression;
using PartnerNet.Domain;
using ProjectBase.Data;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace PartnerNet.Business
{
    public class AlertRepositionController : AbstractNHibernateDao<AlertReposition, int>
    {
        public AlertRepositionController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public List<AlertReposition> ShowAlert6(bool? marked, bool? lowCost, bool? scalaRep0, bool? desc, bool? normal)
        {
            ICriteria product;
            ICriteria crit = GetCrit(marked, lowCost, scalaRep0, desc, normal, out product);

            return crit.List<AlertReposition>() as List<AlertReposition>;
        }

        private ICriteria GetCrit(bool? marked, bool? lowCost, bool? scalaRep0, bool? desc, bool? normal, out ICriteria product)
        {
            product = null;
            ICriteria crit = GetCriteria();
            if (marked != null || lowCost != null || desc != null)
            {
                product = crit.CreateCriteria("Product");
                if (normal != null && (bool)normal)
                {
                    if (marked != null && (bool) !marked)
                        product.Add(Expression.Eq("AlertRepositionShow", (bool) !marked));
                    if (lowCost != null && (bool) !lowCost)
                        product.Add(Expression.Eq("LowCost", (bool) lowCost));
                    if (scalaRep0 != null && (bool) !scalaRep0)
                        product.Add(Expression.Eq("ScalaRep0", (bool) scalaRep0));
                    if (desc != null && (bool) !desc)
                        product.Add(Expression.Not(Expression.InsensitiveLike("Description", "#", MatchMode.End)));
                }
                else
                {
                    if (marked != null && (bool)marked)
                        product.Add(Expression.Eq("AlertRepositionShow", (bool)!marked));
                    if (lowCost != null && (bool)lowCost)
                        product.Add(Expression.Eq("LowCost", (bool)lowCost));
                    if (scalaRep0 != null && (bool)scalaRep0)
                        product.Add(Expression.Eq("ScalaRep0", (bool)scalaRep0));
                    if (desc != null && (bool)desc)
                        product.Add(Expression.InsensitiveLike("Description", "#", MatchMode.End));
                }
            }
            return crit;
        }

        public List<AlertReposition> ShowAlert(string column, string order)
        {
            return ShowAlert(column, order, null, null, null, null, null);
        }

        public List<AlertReposition> ShowAlert(string column, string order, bool? marked, bool? lowCost, bool? scalaRep0, bool? desc, bool? normal)
        {
            if (string.IsNullOrEmpty(column))
                return ShowAlert6(marked, lowCost, scalaRep0, desc, normal);

            bool boolorder = true;
            if (order == "desc")
                boolorder = false;

            ICriteria products;
            ICriteria crit = GetCrit(marked, lowCost, scalaRep0, desc, normal, out products);
            string[] sortfield = new string[2];
            char[] separator = new char[1];
            separator[0] = '.';
            sortfield = column.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (sortfield.Length == 1)
                crit.AddOrder(new Order(sortfield[0], boolorder));
            else if (sortfield.Length == 2)
            {
                if(products == null)
                    products = crit.CreateCriteria("Product");
                products.AddOrder(new Order(sortfield[1], boolorder));
            }
            return crit.List<AlertReposition>() as List<AlertReposition>;
        }

        public void CleanAlertReposition()
        {
            IQuery q = NHibernateSession.GetNamedQuery("sp_alertreposition_clean");
            q.UniqueResult();
        }

        public void ExportToExcel(string column, string order, bool? marked, bool? lowCost, bool? scalaRep0, bool? desc, bool? normal)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");// Thread.CurrentThread.CurrentUICulture;

            GridView grdProductList = new GridView();
            grdProductList.AutoGenerateColumns = false;

            #region Columns
            BoundField bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "ProductCode";
            bf.HeaderText = "Producto";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "ProductName";
            bf.HeaderText = "Descripci&oacute;n";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "Group";
            bf.HeaderText = "Grupo";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "Sales";
            bf.HeaderText = "VTA. 12M";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "CuatrimestralSales";
            bf.HeaderText = "VTA. 12M/3";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "SaleMonths";
            bf.HeaderText = "Vida del Producto";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "RepositionLevel";
            bf.HeaderText = "N. Reposici&oacute;n";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "Result";
            bf.HeaderText = "Diferenc&iacute;a %";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "Price";
            bf.HeaderText = "Precio";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "Provider";
            bf.HeaderText = "Proveedor";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "OrderInfo";
            bf.HeaderText = "Informaci&oacute;n de Orden de Venta (Cant. Ordenes/%/N. Orden)";
            bf.HtmlEncode = false;
            grdProductList.Columns.Add(bf);

            #endregion

            grdProductList.DataSource = ShowAlert(column, order, marked, lowCost, scalaRep0, desc, normal);
            grdProductList.DataBind();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=DiferenciaEnNivelDeReposicion.xls"));
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
                    table.Rows[0].Cells[i].BackColor =Color.FromArgb(225, 224, 224);
            }

            //  add each of the data rows to the table
            List<AlertReposition> arLSt = grdProductList.DataSource as List<AlertReposition>;
            foreach (GridViewRow row in grdProductList.Rows)
            {
                PrepareControlForExport(row);
                int pos = table.Rows.Add(row);
                table.Rows[pos].Cells[0].Attributes.Add("class", "cF");
                
                //ver esto
                AlertReposition ar = arLSt[pos-1] ;
                if (ar != null && ar.IsConflicted)
                {
                    for (int i = 0; i < table.Rows[pos].Cells.Count; i++)
                        table.Rows[pos].Cells[i].BackColor = Color.FromArgb(250, 128, 114);
                }
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
