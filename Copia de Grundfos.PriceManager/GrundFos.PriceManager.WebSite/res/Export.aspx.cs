using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PriceManager.Core;
using System.Collections.Generic;
using PriceManager.Business;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web;
using Table=iTextSharp.text.Table;
using System.Threading;


namespace GrundFos.PriceManager.WebSite.res
{
    public partial class Export : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack && !string.IsNullOrEmpty(Request.QueryString["btn"]))
           {
               if (Request.QueryString["btn"] == "1")
                   ExportToExcel();
               else
                   ExportToPDF();
           }
        }

        #region Export to Excel 

        protected void ExportToExcel()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            grdProductList.DataSource = GetFiltered();
            grdProductList.DataBind();
           
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=ListadePrecios.xls"));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            
            System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();
            table.GridLines = grdProductList.GridLines;

            //Set the Cell format 
            string priceFormat = @"<style>.pF  { mso-number-format:'Fixed'; }</style>";
            string codeFormat = @"<style>.cF  { mso-number-format:'\@'; }</style>";

            HttpContext.Current.Response.Write(priceFormat);
            HttpContext.Current.Response.Write(codeFormat);
            
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
                table.Rows[pos].Cells[0].Width = 95;
                table.Rows[pos].Cells[1].Width = 600;
                table.Rows[pos].Cells[2].Width = 70;
                //Set Euro Symbol Correctly
                if (row.Cells[2].Text == "€")
                    table.Rows[pos].Cells[2].Text = "&#8364";
                
                table.Rows[pos].Cells[3].Attributes.Add("class", "pF");
                table.Rows[pos].Cells[3].Width = 110;
             }

            //  render the table into the htmlwriter
            table.RenderControl(htw);

            //  render the htmlwriter into the response
            HttpContext.Current.Response.Write(sw.ToString());
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

        #region Export to PDF
        protected void ExportToPDF()
        {
            Document document = new Document(PageSize.LETTER);
            document.AddHeader("Expires", "0");

            MemoryStream stream = new MemoryStream();
            PdfWriter.GetInstance(document, stream).CloseStream = false;

            GeneratePDFHeaderFooter(document);

            document.Open();
            document.NewPage();

            GeneratePDFHeaderFooter(document);

            IList<ProductListView> lst = GetFiltered();

            string[] titles;
            string[] columns;

            SetTitlesAndColumns(out titles, out columns);
            document.Add(GeneratePDFTable(lst, titles, columns));
            document.Close();

            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment;filename=ListadePrecios.pdf");
            Response.ContentType = "application/pdf";
            Response.OutputStream.Write(stream.GetBuffer(), 0, (int)stream.Length);
            Response.OutputStream.Flush();
            Response.End();

        }

        private void GeneratePDFHeaderFooter(Document document)
        {
            Font myfont = new Font(
                  FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL));

            Paragraph p = new Paragraph();
            p.Alignment = HeaderFooter.ALIGN_CENTER;
            p.Add(new Phrase("Datos al: " + DateTime.Now, myfont));

            HeaderFooter footer = new HeaderFooter(p, true);
            footer.Alignment = HeaderFooter.ALIGN_CENTER;
            footer.Border = Rectangle.NO_BORDER;

            document.Footer = footer;
        }

        private Table GeneratePDFTable(IList<ProductListView> list, string[] titles, string[] columns)
        {
            Table datatable = new Table(columns.Length);
            datatable.Padding = 2;
            datatable.Spacing = 0;
            float[] headerwidths;
            
            headerwidths = new float[] { 85, 500, 45, 90 };
            datatable.Widths = headerwidths;
            datatable.WidthPercentage = 100;

            datatable.DefaultCellBorderWidth = 1;
            datatable.BackgroundColor = Color.LIGHT_GRAY;

            Font myfont = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 7, Font.NORMAL));

            Font myfontTitle = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 7, Font.BOLD));

            Cell cel = new Cell();

            foreach (string title in titles)
            {
                cel = new Cell();
                cel.Add(new Phrase(title, myfontTitle));
                cel.BackgroundColor = Color.LIGHT_GRAY;
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.AddCell(cel);
            }

            datatable.EndHeaders();
            datatable.BackgroundColor = Color.WHITE;
            foreach (object r in list)
            {
                foreach (string column in columns)
                {
                    object o = r.GetType().GetProperty(column).GetValue(r, new object[0]);
                    string val;
                    if (o is double || o is decimal)
                        val = Convert.ToDouble(o).ToString("0.00");
                    else
                        val = Convert.ToString(o);

                    cel = new Cell();
                    cel.Add(new Phrase(val, myfont));

                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    if (column != "Description")
                        cel.HorizontalAlignment = Element.ALIGN_RIGHT;

                    datatable.AddCell(cel);
                }
            }
            return datatable;
        }

        private void SetTitlesAndColumns(out string[] titles, out string[] columns)
        {
            titles = new string[]
                     {
                         "Código",
                         "Descripción",
                         "Moneda",
                         "Precio de Lista"
                     };
            columns = new string[]
                    {
                         "Code",
                         "Description",
                         "PriceCurrency",
                         "Price"
                    };
        }
        #endregion

        #region Get Information
        public IList<ProductListView> GetFiltered()
        {
            SearchParams filters = (SearchParams)Session["SearchParams"];

            //Checked Products in Product List
            List<string> selecteditems = (List<string>)Session["SelectedItems"];
            bool marked = (bool)Session["Marked"];

            Family tempfam = ControllerManager.Family.GetById(filters.Family);
            CtrRange tempctr = ControllerManager.CtrRange.GetById(filters.CtrRange);
            Selection tempsel = ControllerManager.Selection.GetById(filters.Selection);
            ProductType tempprodtype = (ProductType)filters.ProductType;
            Currency tempcurr = ControllerManager.Currency.GetById(filters.Currency);
            Family tempcat = ControllerManager.Family.GetById(filters.Category);

            int recordcount = 0;
            return ControllerManager.Product.GetProductList(filters.Description, tempfam, tempcat,
                                                                     tempctr, tempsel, tempprodtype, 0, 0, filters.SortColumn, filters.SortOrder,
                                                                     tempcurr, out recordcount, marked, selecteditems);
        }
        #endregion
    }
}
