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
using System.Reflection;
using System.Data.SqlClient;

namespace GrundFos.Despiece.Website
{
    public partial class Base : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Assembly a = Assembly.GetExecutingAssembly();
                AssemblyName name = a.GetName();
                Label1.Text = "v" + name.Version.Major + "." + name.Version.Minor + "." + name.Version.Build;

                if (Membership.GetUser() != null)
                    if (Roles.IsUserInRole(Membership.GetUser().UserName, "Administradores"))
                        LinkButton1.Visible = true;

                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
                SqlCommand com = new SqlCommand("select top 1 actualizacion from log order by actualizacion desc", myConnection);
                SqlDataReader dr;
                myConnection.Open();
                dr = com.ExecuteReader();
                dr.Read();
                Label2.Text = "Actualizado hasta: " + Convert.ToDateTime(dr[0]).ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/administration/default.aspx");
        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}
