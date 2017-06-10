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

namespace GrundFos.PriceManager.WebSite
{
    public partial class accessdenied : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(!string.IsNullOrEmpty(Request.QueryString["Url"]))
                    lblInfo.Text = lblInfo.Text + " " + Request.QueryString["Url"];
            }
        }
    }
}
