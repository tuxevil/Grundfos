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
using GrundFos.PriceManager.WebSite.ctrl;
using NybbleMembership;
using NybbleMembership.Core.Domain;
using PriceManager.Business;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Utils.Email;

namespace GrundFos.PriceManager.WebSite.Quotes.view
{
    public partial class _default : QuotePage
    {
        public int QuoteId
        {
            get
            {
                if (ViewState["Id"] != null)
                    return Convert.ToInt32(ViewState["Id"]);
                else
                    return 0;
            }
            set { ViewState["Id"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    QuoteId = Convert.ToInt32(Request.QueryString["Id"]);

                QuoteView1.QuoteId = QuoteId;
                QuoteView1.View = true;
                QuoteView1.DataBind();
            }
        }
       
    }
}
