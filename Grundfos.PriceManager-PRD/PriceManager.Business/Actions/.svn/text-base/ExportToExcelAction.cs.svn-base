using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using PriceManager.Core;
using NybbleMembership.Core.Domain;
using PriceManager.Common;
using NybbleMembership;

namespace PriceManager.Business.Actions
{
    public class ExportToExcelAction : ImageButtonAction
    {
        public override bool ExecuteAction(GridState gs, IList<IFilter> filters, params object[] parameters)
        {

            ExportToExcel(gs, filters);
            return true;
        }

        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                if (value)
                    this.ImageUrl = "~/img/Excel Icon.edited.JPG";
                else
                    this.ImageUrl = "~/img/Excel Icon.edited-blocked.JPG";

                base.Enabled = value;
            }
        }

        #region Export To Excel


        private void ExportToExcel(GridState gs, IList<IFilter> filters)
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            
            GridView grdProductList = new GridView();
            grdProductList.AutoGenerateColumns = false;

            BoundField bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(95);
            bf.DataField = "Code";
            bf.HeaderText = "C&oacute;digo";
            bf.HtmlEncode = false;
           // bf.DataFormatString = "{0:00000000}";
            grdProductList.Columns.Add(bf);


            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(600);
            bf.DataField = "FinalInfo";
            bf.HeaderText = "Modelo";
            bf.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            grdProductList.Columns.Add(bf);

            //si sos Admin
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(ProductListView);
            epv.KeyIdentifier = Config.CanExportAll;
            bool canExporAll = PermissionManager.Check(epv);
            if (canExporAll)
            {
                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(150);
                bf.DataField = "Provider";
                bf.HeaderText = "Proveedor";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(50);
                bf.DataField = "Index";
                bf.HeaderText = "Index";
                bf.HtmlEncode = false;
                bf.DataFormatString = "{0:F2}";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(70);
                bf.DataField = "Type";
                bf.HeaderText = "Frecuencia";
                grdProductList.Columns.Add(bf);


                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(30);
                bf.DataField = "PricePurchaseCurrency";
                bf.HeaderText = "M. TP";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(70);
                bf.DataField = "PricePurchase";
                bf.HeaderText = "TP";
                bf.HtmlEncode = false;
                bf.DataFormatString = "{0:F2}";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(30);
                bf.DataField = "PriceSuggestCurrency";
                bf.HeaderText = "M. GRP";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(70);
                bf.DataField = "PriceSuggest";
                bf.HeaderText = "GRP";
                bf.HtmlEncode = false;
                bf.DataFormatString = "{0:F2}";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(30);
                bf.DataField = "PriceListCurrency";
                bf.HeaderText = "M. PV";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(70);
                bf.DataField = "PriceSell";
                bf.HeaderText = "PV";
                bf.HtmlEncode = false;
                bf.DataFormatString = "{0:F2}";
                grdProductList.Columns.Add(bf);
            }

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(10);
            bf.DataField = "PriceListCurrency";
            bf.HeaderText = "M. PL";
            grdProductList.Columns.Add(bf);

            bf = new BoundField();
            bf.ItemStyle.Width = Unit.Pixel(70);
            bf.DataField = "Price";
            bf.HeaderText = "PL";
            bf.HtmlEncode = false;
            bf.DataFormatString = "{0:F2}";
            grdProductList.Columns.Add(bf);

            if(canExporAll)
            {
                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(30);
                bf.DataField = "PriceListCurrency";
                bf.HeaderText = "M. CTM";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(70);
                bf.DataField = "CTM";
                bf.HeaderText = "CTM";
                bf.HtmlEncode = false;
                bf.DataFormatString = "{0:F2}";
                grdProductList.Columns.Add(bf);

                bf = new BoundField();
                bf.ItemStyle.Width = Unit.Pixel(70);
                bf.DataField = "CTR";
                bf.HeaderText = "CTR";
                bf.HtmlEncode = false;
                bf.DataFormatString = "{0:F2}";
                grdProductList.Columns.Add(bf);

                //bf = new BoundField();
                //bf.ItemStyle.Width = Unit.Pixel(70);
                //bf.DataField = "Status";
                //bf.HeaderText = "Estado";
                //grdProductList.Columns.Add(bf);
            }
            //***************//

            

            grdProductList.DataSource = GetFiltered(gs, filters);
            grdProductList.DataBind();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=ListadePrecios.xls"));
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
                table.Rows[0].ForeColor = System.Drawing.Color.FromArgb(102,102,102);

                for (int i=0; i < table.Rows[0].Cells.Count; i++)
                    table.Rows[0].Cells[i].BackColor = System.Drawing.Color.FromArgb(225,224,224);
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in grdProductList.Rows)
            {
                PrepareControlForExport(row);
                int pos = table.Rows.Add(row);

                table.Rows[pos].Cells[0].Attributes.Add("class", "cF");
                table.Rows[pos].Cells[0].HorizontalAlign = HorizontalAlign.Right;
                table.Rows[pos].Cells[0].Width = 95;
                table.Rows[pos].Cells[1].Width = 600;
                table.Rows[pos].Cells[2].Width = 110;
                table.Rows[pos].Cells[2].HorizontalAlign = HorizontalAlign.Left;
                table.Rows[pos].Cells[4].HorizontalAlign = HorizontalAlign.Right;
                table.Rows[pos].Cells[5].HorizontalAlign = HorizontalAlign.Right;
                table.Rows[pos].Cells[7].HorizontalAlign = HorizontalAlign.Right;
                table.Rows[pos].Cells[9].HorizontalAlign = HorizontalAlign.Right;
                table.Rows[pos].Cells[11].HorizontalAlign = HorizontalAlign.Right;
                table.Rows[pos].Cells[13].HorizontalAlign = HorizontalAlign.Right;
                //Set Euro Symbol Correctly
                if (row.Cells[13].Text == "€")
                    table.Rows[pos].Cells[13].Text = "&#8364";
                if (canExporAll)
                {
                    if (row.Cells[5].Text == "€")
                        table.Rows[pos].Cells[5].Text = "&#8364";
                    if (row.Cells[7].Text == "€")
                        table.Rows[pos].Cells[7].Text = "&#8364";
                    if (row.Cells[9].Text == "€")
                        table.Rows[pos].Cells[9].Text = "&#8364";
                    if (row.Cells[11].Text == "€")
                        table.Rows[pos].Cells[11].Text = "&#8364";
                }
                table.Rows[pos].Cells[3].Attributes.Add("class", "pF");
                table.Rows[pos].Cells[3].Width = 110;
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

        #endregion


        public IList<ProductListView> GetFiltered(GridState gs, IList<IFilter> filters)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            int totalrecords;
            return ControllerManager.PriceBase.GetProductList(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, mpsp.Currency, out totalrecords, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, gs, mpsp.PriceBaseStatus, mpsp.ProductStatus, true, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor); 
        }
    }
}
