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

namespace Grundfos_Despiece
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            AssemblyName name = a.GetName();
            Label1.Text = "v" + name.Version.Major + "." + name.Version.Minor + "." + name.Version.Build;

            if(Membership.GetUser() != null)
                if(Roles.IsUserInRole(Membership.GetUser().UserName, "Administradores"))
                    LinkButton1.Visible = true;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/users/newuser.aspx");
        }
    }
}
