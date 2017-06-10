using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Core;
using System.Collections.Generic;
using Quo = PriceManager.Core.Quote;
using PriceManager.Common;
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite.Distributors.quotes
{
    public partial class _default : DistributorPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack )
            {
               Distributor d = ControllerManager.Distributor.GetById(DistributorId);

               IList<Quo> quotesLst = ControllerManager.Quote.GetQuotesByUser(d, MembershipHelper.GetUser());
               if (quotesLst != null && quotesLst.Count > 0)
               {
                   rpterQuotes.DataSource = quotesLst;
                   rpterQuotes.DataBind();
               }
               else
                   litNoItems.Visible = true;
            }
        }

        protected void rpterQuotes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                 Quo q = (e.Item.DataItem as Quo);

                HyperLink hl = (e.Item.FindControl("lnkGo") as HyperLink);
                hl.NavigateUrl = "/quotes/view/default.aspx?Id=" + q.ID;
                hl.Text = string.Format("[{0}] {1}", q.Number, q.TimeStamp.CreatedOn.ToShortDateString());
                hl.ToolTip = string.Format("Ingresar a la cotización {0}", q.Description);

                (e.Item.FindControl("litDescription") as Literal).Text = StringFormat.FormatHasValue(q.Description);
                (e.Item.FindControl("litObservations") as Literal).Text = StringFormat.FormatHasValue(q.Observations);

            }
        }
    }
}
