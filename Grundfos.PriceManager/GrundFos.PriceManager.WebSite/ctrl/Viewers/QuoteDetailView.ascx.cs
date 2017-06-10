using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NybbleMembership;
using NybbleMembership.Core.Domain;
using PriceManager;
using PriceManager.Business;
using PriceManager.Common;
using PriceManager.Core;
using GrundFos.PriceManager.WebSite.ctrl.editors;

namespace GrundFos.PriceManager.WebSite.ctrl.Viewers
{
    public partial class QuoteDetailView : System.Web.UI.UserControl
    {
        public int QuoteId
        {
            get
            {
                if (ViewState["QuoteId"] != null)
                    return Convert.ToInt32(ViewState["QuoteId"]);
                else
                    return 0;
            }
            set { ViewState["QuoteId"] = value; }
        }

        public decimal TotalCount
        {
            get 
            {
                if (ViewState["TotalCount"] != null)
                    return Convert.ToDecimal(ViewState["TotalCount"]);
                else
                    return 0;
            }
            set { ViewState["TotalCount"] = value; }
        }
        
        public override void DataBind()
        {
            ucNotes.NoteType = typeof(Quote);
            ucNotes.TypeIdentifier = QuoteId;
            ucNotes.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["QuoteItemError"] != null && (bool)Session["QuoteItemError"])
                {
                    Utils.ShowMessage(Page, "Algunos productos no se pudieron cotizar por falta de Precio de Lista.", Utils.MessageType.Error);
                    Session["QuoteItemError"] = null;
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    QuoteId = Convert.ToInt32(Request.QueryString["Id"]);
                
                LoadFields();
            }
        }

        private void LoadFields()
        {
            Quote q = null;

            if (QuoteId > 0)
                q = ControllerManager.Quote.GetById(QuoteId);

            if (q == null || ((q.Status == QuoteStatus.InAssistence || q.Status == QuoteStatus.AssistenceRequired) && "Chequear si no sos administrador" == "Chequear si no sos administrador"))
                Response.Redirect("/accessdenied.aspx");

            if (q.Status == QuoteStatus.Sent)
                lnkEdit.Visible = false;
            else
                if (!ControllerManager.Quote.ValidateQuote(q))
                    Utils.ShowMessage(this.Page, "Se modifico la información de la cotización.", Utils.MessageType.Warning);

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Quote);
            epv.KeyIdentifier = Config.SeeQuotes;

            if (PermissionManager.Check(epv) == false)
                PermissionManager.Validate(q);

            lblDistributor.Text = q.Distributor.Name;

            if (!string.IsNullOrEmpty(q.Contacts))
                lblContact.Text = q.Contacts;
            else
                lblContact.Text = "N/D";

            lblDate.Text = q.TimeStamp.CreatedOn.ToShortDateString();
            lblDiscount.Text = q.Distributor.Discount.ToString("#0.00") + "%";
            lblVigency.Text = q.Vigency.Description + " dias";
            lblQuoteNumber.Text = q.Number;
            if (q.Distributor.PaymentTerm != null)
                lblPaymentCondition.Text = q.Distributor.PaymentTerm.Description;
            lblIntroText.Text = q.IntroText.Description;
            lblCondition.Text = q.Condition.Description;
            lblStatus.Text = EnumHelper.GetDescription(q.Status);
            MembershipHelperUser mhu = MembershipHelper.GetUser(q.TimeStamp.CreatedBy);
            if (q.TimeStamp != null && mhu != null)
                lblAutor.Text = mhu.FullName;
            //lblObservation.Text = q.Observations;
            lblObservation.Text = StringFormat.Cut(q.Observations, 100);
            lblObservation.Attributes["title"] = q.Observations;
            if(q.Currency != null && q.CurrencyRate != null)
                lblCurrency.Text = q.Currency.Description + " (" + q.CurrencyRate.Rate + ")";
            btnGetAssistence.Visible = q.Status == QuoteStatus.Draft;

            rptQuoteLine.DataSource = q.QuoteItems;
            rptQuoteLine.DataBind();

            lblTotalCount.Text = q.Currency.Description + " " + TotalCount.ToString("0.##");

            if (q.QuoteNotifications.Count == 0 || q.Status == QuoteStatus.Rejected)
            {
                btnSendPDF.Visible = false;
                if (q.QuoteNotifications.Count == 0)
                    Utils.ShowMessage(this.Page, "La cotización no podrá ser enviada por email ya que no tiene contactos asignados.", Utils.MessageType.Warning);
            }
        }
        
        protected void btnGetPDF_Click(object sender, EventArgs e)
        {
            Quote q = ControllerManager.Quote.GetById(QuoteId);
            if (ControllerManager.Quote.ValidateQuote(q))
            {
                MemoryStream ms = ControllerManager.Quote.ExportToPDF(q, Server.MapPath("/img/") + "PdfHeader.GIF", cbxIncludePriceSell.Checked);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=Cotizacion_" + QuoteId + ".pdf");
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);
                HttpContext.Current.Response.OutputStream.Flush();
                HttpContext.Current.Response.End();
            }
            else
            {
                Utils.ShowMessage(this.Page, "Se modifico la información de la cotización.", Utils.MessageType.Warning);
                //GridView1.DataSource = q.SortedQuoteItems;
                //GridView1.DataBind();
                //UpdatePanel1.Update();
                rptQuoteLine.DataSource = q.SortedQuoteItems;
                rptQuoteLine.DataBind();
            }
        }

        protected void btnSendPDF_Click(object sender, EventArgs e)
        {
            Quote q = ControllerManager.Quote.GetById(QuoteId);
            if(ControllerManager.Quote.ValidateQuote(q))
            {
                ControllerManager.Quote.Send(q, ControllerManager.Quote.ExportToPDF(q, Server.MapPath("/img/") + "PdfHeader.GIF", cbxIncludePriceSell.Checked).GetBuffer());
                Utils.ShowMessage(this.Page, "La cotización  se ha enviado correctamente al Canal de Ventas.", Utils.MessageType.Info);
                LoadFields();
            }
            else
            {
                Utils.ShowMessage(this.Page, "Se modifico la información de la cotización.", Utils.MessageType.Warning);
                //GridView1.DataSource = q.QuoteItems;
                //GridView1.DataBind();
                //UpdatePanel1.Update();
                rptQuoteLine.DataSource = q.SortedQuoteItems;
                rptQuoteLine.DataBind();
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            QuoteView qv = ((QuoteView)this.Parent);
            qv.View = false;
            qv.ChangeView();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                QuoteItem qi = (e.Row.DataItem as QuoteItem);

                int colIndex = FindColumnIndex(e.Row, "PriceSell");
                if (colIndex > 0)
                {
                    if (qi.Price == 0)
                        e.Row.Cells[colIndex].Text = "N/D";
                }

                colIndex = FindColumnIndex(e.Row, "PriceList");
                if (colIndex > 0)
                {
                    if (qi.Price == 0)
                        e.Row.Cells[colIndex].Text = "N/D";
                }
            }
        }

        private int FindColumnIndex(GridViewRow row, string dataField)
        {
            return FindColumnIndex(row, dataField, null);
        }

        private int FindColumnIndex(GridViewRow row, string dataField, string dataPropertyField)
        {
            int columnIndex = 0;

            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (dataPropertyField == null)
                {
                    if (cell.ContainingField is BoundField)
                        if (((BoundField)cell.ContainingField).DataField.Equals(dataField))
                            return columnIndex;
                }
                else
                {
                    if ((cell.ContainingField is TemplateField) && ((TemplateField)cell.ContainingField).ItemTemplate is PropertyTemplateField)
                        if ((((PropertyTemplateField)(((TemplateField)cell.ContainingField).ItemTemplate)).DataTextField.Equals(dataField))
                            && (((PropertyTemplateField)(((TemplateField)cell.ContainingField).ItemTemplate)).DataPropertyField.Equals(dataPropertyField))) //.Equals(dataField))
                            return columnIndex;
                }
                columnIndex++;
            }

            return -1;
        }

        protected void rptQuoteLine_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                QuoteItem qi = (e.Item.DataItem as QuoteItem);

                if (qi != null)
                {
                    TotalCount = TotalCount + qi.Subtotal;
                    QuoteLineEditor qle = (e.Item.FindControl("QuoteLineEditor1") as QuoteLineEditor);
                    qle.Mode = EditionMode.View;
                    qle.QuoteId = QuoteId;
                    qle.QuoteItemId = qi.ID;
                    qle.QuoteItem = qi;
                    qle.DataBind();
                }
            }
        }

        protected void btnAssistense_Click(object sender, EventArgs e)
        {
            ControllerManager.Quote.GetAssistence(new Quote(QuoteId), Request.Url.OriginalString);
            LoadFields();
        }
    }

}
