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

namespace Grundfos_Despiece.users
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Control control in ChangePassword1.Controls)
            {
                TextBox t = (TextBox)control.FindControl("UserName");

                if (t != null)
                {
                    t.Focus();
                    Form.DefaultButton = control.FindControl("ChangePasswordPushButton").UniqueID;
                    break;
                }
            }
        }

        protected void ChangePassword1_ChangePasswordError(object sender, EventArgs e)
        {
            Flash.Attributes["class"] = "flash_alert";
            lblInfo.Text = "El usuario/contraseña ingresado es incorrecto";
        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
            Flash.Attributes["class"] = "flash_notice";
            lblInfo.Text = "Contraseña cambiada con exito!";

            foreach (Control control in ChangePassword1.Controls)
            {
                Button b = (Button)control.FindControl("ContinuePushButton");

                if (b != null)
                {
                    Form.DefaultButton = control.FindControl("ContinuePushButton").UniqueID;
                    break;
                }
            }
        }
    }
}
