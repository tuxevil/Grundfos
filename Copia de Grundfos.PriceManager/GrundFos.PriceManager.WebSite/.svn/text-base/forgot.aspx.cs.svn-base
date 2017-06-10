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
    public partial class forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Control control in PasswordRecovery1.Controls)
            {
                TextBox t = (TextBox)control.FindControl("UserName");

                if (t != null)
                {
                    t.Focus();
                    Form.DefaultButton = control.FindControl("SubmitButton").UniqueID;
                    break;
                }
            }
        }

        protected void PasswordRecovery1_UserLookupError(object sender, EventArgs e)
        {
            Flash.Attributes["class"] = "flash_alert";
            lblInfo.Text = "El usuario ingresado es incorrecto";
        }

        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
            Flash.Attributes["class"] = "flash_notice";
            lblInfo.Text = "Su contraseña fue enviada con exito!";
        }

      
    }
}
