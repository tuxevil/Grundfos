using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;
using PriceManager.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web;
using Table = iTextSharp.text.Table;
using System.Threading;
using NybbleMembership.Core.Domain;
using PriceManager.Common;
using NybbleMembership;

namespace PriceManager.Business.Actions
{
    public class ExportToPdfAction : ImageButtonAction
    {
        public bool CanExportAll
        {
            get
            {
                if (ViewState["CanExport"] != null)
                    return (bool)ViewState["CanExport"];
                else
                    return false;
            }
            set { ViewState["CanExport"] = value; }
        }

        public override bool ExecuteAction(GridState gs, IList<IFilter> filters, params object[] parameters)
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(ProductListView);
            epv.KeyIdentifier = Config.CanExportAll;
            CanExportAll = PermissionManager.Check(epv);

            ExportToPDF(gs, filters);

            return false;
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
                    this.ImageUrl = "~/img/adobe-acrobat-pdf-icon.edited.JPG";
                else
                    this.ImageUrl = "~/img/adobe-acrobat-pdf-icon.edited-blocked.JPG";

                base.Enabled = value;
            }
        }

        #region Export to PDF
        protected void ExportToPDF(GridState gs, IList<IFilter> filters)
        {
            Document document = new Document(PageSize.LETTER);
            if (CanExportAll)
                document.SetPageSize(PageSize.A1);

            document.AddHeader("Expires", "0");

            MemoryStream stream = new MemoryStream();
            PdfWriter.GetInstance(document, stream).CloseStream = false;

            GeneratePDFHeaderFooter(document);

            document.Open();
            document.NewPage();

            GeneratePDFHeaderFooter(document);


            IList<ProductListView> lst = GetFiltered(gs, filters);

            string[] titles;
            string[] columns;

            SetTitlesAndColumns(out titles, out columns);
            document.Add(GeneratePDFTable(lst, titles, columns));
            document.Close();


            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=ListadePrecios.pdf");
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.OutputStream.Write(stream.GetBuffer(), 0, (int)stream.Length);
            HttpContext.Current.Response.OutputStream.Flush();
            HttpContext.Current.Response.End();
        }

        private void GeneratePDFHeaderFooter(Document document)
        {
            Font myfont = new Font(
                  FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));

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

            if(!CanExportAll)
                headerwidths = new float[] { 85, 450, 65, 120 };
            else
                headerwidths = new float[] { 85, 200, 110, 90, 120, 60, 120, 65, 65, 65, 65, 65, 65, 65, 65, 100 };
            datatable.Widths = headerwidths;
            datatable.WidthPercentage = 100;
            datatable.DefaultCellBorderWidth = 1;
            datatable.BackgroundColor = Color.LIGHT_GRAY;
           
            Font myfont = new Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL));

            Font myfontTitle = new Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, new Color(255, 255, 255)));

            Cell cel = new Cell();

            foreach (string title in titles)
            {
                cel = new Cell();
                cel.Add(new Phrase(title, myfontTitle));
                cel.BackgroundColor = new Color(0, 51, 102);
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

                    cel.SetHorizontalAlignment(ElementTags.LEFT);
                    if (column != "FinalInfo" && column != "Provider")
                        cel.HorizontalAlignment = Element.ALIGN_RIGHT;

                    datatable.AddCell(cel);
                }
            }
            return datatable;
        }

        private void SetTitlesAndColumns(out string[] titles, out string[] columns)
        {
            if (!CanExportAll)
            {
                titles = new string[]
                             {
                                 "Código",
                                 "Modelo",
                                 "Moneda",
                                 "PL"
                                 
                             };
                columns = new string[]
                            {
                                 "Code",
                                 "FinalInfo",
                                 "PriceListCurrency",
                                 "Price"
                            };
            }
            else
            {
                titles = new string[]
                             {
                                 "Código",
                                 "Modelo",
                                 "Proveedor",
                                 "Index",
                                 "Frecuencia",
                                 "M. TP",
                                 "TP",
                                 "M. GRP",
                                 "GRP",
                                 "M. PV",
                                 "PV",
                                 "M. PL",
                                 "PL",
                                 "M. CTM",
                                 "CTM",
                                 "CTR"
                                 
                             };
                columns = new string[]
                            {
                                "Code",
                                "FinalInfo",
                                "Provider",
                                "Index",
                                "Type",
                                "PricePurchaseCurrency",
                                "PricePurchase",
                                "PriceSuggestCurrency",
                                "PriceSuggest",
                                "PriceListCurrency",
                                "PriceSell",
                                "PriceListCurrency",
                                "Price",
                                "PriceListCurrency",
                                "CTM",
                                "CTR"
                            };
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
