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
using GrundFos.PriceManager.WebSite.ctrl;
using PriceManager.Core;
using System.Collections.Generic;
using PriceManager.Business;
using System.IO;
using System.Reflection;
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
                Response.Redirect("login.aspx");
        }
    }
}
