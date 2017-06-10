using System;
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["QuoteItemError"] != null && (bool)Session["QuoteItemError"])
                {
                    Utils.ShowMessage(Page, "Hubo productos que no se pudieron cotizar.", Utils.MessageType.Error);
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

            if (q == null)
                Response.Redirect("/accessdenied.aspx");

            if (q.Status == QuoteStatus.Sent)
                lnkEdit.Visible = false;

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Quote);
            epv.KeyIdentifier = Config.SeeQuotes;

            if (PermissionManager.Check(epv) == false)
                PermissionManager.Validate(q);

            lblDistributor.Text = q.Distributor.Name;

            if (!string.IsNullOrEmpty(q.Contact))
                lblContact.Text = q.Contact;
            else
                lblContact.Text = q.Distributor.Contact;
            if (!string.IsNullOrEmpty(q.Email))
                lblMail.Text = q.Email;
            else if (!string.IsNullOrEmpty(q.Distributor.Email))
                lblMail.Text = q.Distributor.Email;
            else if (!string.IsNullOrEmpty(q.Distributor.AlternativeEmail))
                lblMail.Text = q.Distributor.AlternativeEmail;
            else
                lblMail.Text = "N/D";
            lblDate.Text = q.TimeStamp.CreatedOn.ToShortDateString();
            lblDiscount.Text = q.Distributor.Discount.ToString("#0.00") + "%";
            lblVigency.Text = q.Vigency.Description + " dias";
            lblQuoteNumber.Text = q.Number;
            if (q.Distributor.PaymentTerm != null)
                lblPaymentCondition.Text = q.Distributor.PaymentTerm.Title;
            lblIntroText.Text = q.IntroText.Description;
            lblCondition.Text = q.Condition.Description;
            lblStatus.Text = EnumHelper.GetDescription(q.Status);
            if (q.TimeStamp != null && MembershipHelper.GetUser(q.TimeStamp.CreatedBy) != null)
                lblAutor.Text = MembershipHelper.GetUser(q.TimeStamp.CreatedBy).UserName;
            //lblObservation.Text = q.Observations;
            lblObservation.Text = StringFormat.Cut(q.Observations, 100);
            lblObservation.Attributes["title"] = q.Observations;
            if (!Page.IsPostBack)
            {
                BoundField bf = new BoundField();
                bf.DataField = "Code";
                bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                bf.SortExpression = "Code";
                GridView1.Columns.Add(bf);

                bf = new BoundField();
                bf.DataField = "Description";
                bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                bf.SortExpression = "Description";
                GridView1.Columns.Add(bf);

                bf = new BoundField();
                bf.DataField = "PriceSell";
                bf.HeaderText = Resource.Business.GetString("GridViewColumnPriceSell");
                bf.SortExpression = "PriceSell";
                GridView1.Columns.Add(bf);

                bf = new BoundField();
                bf.DataField = "PriceList";
                bf.HeaderText = Resource.Business.GetString("GridViewColumnPrice");
                bf.SortExpression = "PriceList";
                GridView1.Columns.Add(bf);

                bf = new BoundField();
                bf.DataField = "LeadTime";
                bf.HeaderText = Resource.Business.GetString("GridViewColumnLeadTime");
                bf.SortExpression = "LeadTime";
                GridView1.Columns.Add(bf);

                epv = new ExecutePermissionValidator();
                epv.ClassType = typeof(QuoteItem);
                epv.KeyIdentifier = Config.QuoteItemSourceColumn;

                bf = new BoundField();
                bf.DataField = "Source";
                bf.HeaderText = Resource.Business.GetString("GridViewColumnSource");
                bf.SortExpression = "Source";
                bf.Visible = PermissionManager.Check(epv);
                GridView1.Columns.Add(bf);
            }

            GridView1.DataSource = q.QuoteItems;
            GridView1.DataBind();

            if ((string.IsNullOrEmpty(q.Distributor.Email) && string.IsNullOrEmpty(q.Distributor.AlternativeEmail) && string.IsNullOrEmpty(q.Email)) || q.Status == QuoteStatus.Rejected)
            {
                btnSendPDF.Visible = false;
                Utils.ShowMessage(this.Page, "No se podra enviar la cotización por correo ya que el Canal de Ventas no tiene correo electronico asignado.", Utils.MessageType.Warning);
            }
        }
        
        protected void btnGetPDF_Click(object sender, EventArgs e)
        {
            Quote q = ControllerManager.Quote.GetById(QuoteId); 
            MemoryStream ms = ControllerManager.Quote.ExportToPDF(q, Server.MapPath("/img/") + "PdfHeader.GIF", cbxIncludePriceSell.Checked);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=Cotizacion_" + QuoteId + ".pdf");
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);
            HttpContext.Current.Response.OutputStream.Flush();
            HttpContext.Current.Response.End();

        }

        protected void btnSendPDF_Click(object sender, EventArgs e)
        {
            Quote q = ControllerManager.Quote.GetById(QuoteId);
            ControllerManager.Quote.Send(q, ControllerManager.Quote.ExportToPDF(q, Server.MapPath("/img/") + "PdfHeader.GIF", cbxIncludePriceSell.Checked).GetBuffer());
            Utils.ShowMessage(this.Page, "La cotización  se ha enviado correctamente al Canal de Ventas.", Utils.MessageType.Info);
            LoadFields();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            QuoteView qv = ((QuoteView)this.Parent);
            qv.View = false;
            qv.ChangeView();
        }
    }

}
