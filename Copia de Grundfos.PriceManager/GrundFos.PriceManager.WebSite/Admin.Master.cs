using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace GrundFos.PriceManager.WebSite
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Assembly a = Assembly.GetExecutingAssembly();
                AssemblyName name = a.GetName();
                lblVersion.Text = "v" + name.Version.Major + "." + name.Version.Minor + "." + name.Version.Build;
            }
        }
    }
}
