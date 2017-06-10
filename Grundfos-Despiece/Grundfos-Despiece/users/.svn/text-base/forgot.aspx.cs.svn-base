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

namespace GrundFos.Despiece.Website.users
{
    public partial class forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PasswordRecovery1_SendMailError(object sender, SendMailErrorEventArgs e)
        {
            Flash.Attributes["class"] = "flash_alert";
            lblInfo.Text = "Error al enviar el mail, intente de nuevo";
        }

        protected void PasswordRecovery1_UserLookupError(object sender, EventArgs e)
        {
            Flash.Attributes["class"] = "flash_alert";
            lblInfo.Text = "El usuario ingresado es incorrecto";
        }

        protected void PasswordRecovery1_AnswerLookupError(object sender, EventArgs e)
        {
            Flash.Attributes["class"] = "flash_alert";
            lblInfo.Text = "Respuesta incorrecta";
        }

        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
            Flash.Attributes["class"] = "flash_notice";
            lblInfo.Text = "Su contraseña fue enviada con exito!";
        }
    }
}
