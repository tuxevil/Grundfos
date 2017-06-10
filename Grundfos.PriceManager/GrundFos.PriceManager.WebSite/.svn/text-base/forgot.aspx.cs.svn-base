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
using ProjectBase.Utils.Email;
using NybbleMembership;
using System.IO;
using PriceManager.Common;


namespace GrundFos.PriceManager.WebSite
{
    public partial class forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                txtUser.Focus();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            MembershipUser mu = Membership.GetUser(txtUser.Text);
            if (mu != null)
            {
                string newPassword = mu.ResetPassword();
                WebMailing w = new WebMailing();
                string body = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath(Config.MailTemplatePath), "newpassword.htm"));
                body = body.Replace("[NEW_PASSWORD]", newPassword);
                body = body.Replace("[USUARIO]", MembershipHelper.GetUser(mu.UserName).FullName);
                w.SendMail(mu.Email, "Cambio de Contraseña", "Cambio de Contraseña", body, false);
                Flash.Attributes["class"] = "flash_notice";
                lblInfo.Text = "Su contraseña fue enviada con éxito.";
            }
            else
            { 
              Flash.Attributes["class"] = "flash_alert";
              lblInfo.Text = "El usuario ingresado es incorrecto";
            }
        }
    }
}
