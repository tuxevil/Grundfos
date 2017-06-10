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

namespace GrundFos.PriceManager.WebSite.admin
{
    public partial class usercreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlAnchor temp = (HtmlAnchor)Master.FindControl("lnkcreateuser");
                temp.Attributes["class"] = "current";
            }
            txtUsername.Focus();
            Form.DefaultButton = btnSubmit.UniqueID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                if (Membership.GetUser(txtUsername.Text) == null)
                {
                    Membership.CreateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                    Roles.AddUserToRole(txtUsername.Text, "ROUser");
                    lblConfirmacion.Text = "Usuario creado con exito.";
                    txtUsername.Text = "";
                    txtEmail.Text = "";
                }
                else
                {
                    Flash.Attributes["class"] = "flash_alert";
                    lblConfirmacion.Text = "El usuario ingresado ya existe.";
                }
            }
        }

    }
}
