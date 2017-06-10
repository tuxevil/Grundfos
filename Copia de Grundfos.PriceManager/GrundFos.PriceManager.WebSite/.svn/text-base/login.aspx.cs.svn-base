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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Control control in Login1.Controls)
            {
                TextBox t = (TextBox)control.FindControl("UserName");

                if (t != null)
                {
                    t.Focus();
                    Form.DefaultButton = control.FindControl("LoginButton").UniqueID;
                    break;
                }
            }
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
            Flash.Attributes["class"] = "flash_alert";
            lblInfo.Text = "El usuario/contraseña ingresado es incorrecto";
        }

    }
}
