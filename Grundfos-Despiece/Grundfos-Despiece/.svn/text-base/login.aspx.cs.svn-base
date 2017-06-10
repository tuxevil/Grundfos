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

namespace Grundfos_Despiece
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((TextBox)Login1.FindControl("UserName")).Focus();
            Form.DefaultButton = ((Button)Login1.FindControl("LoginButton")).UniqueID;
        }

        protected void Login1_LoginError1(object sender, EventArgs e)
        {
            Flash.Attributes["class"] = "flash_alert";
            lblInfo.Text = "El usuario/contraseña ingresado es incorrecto";
        }

       
    }
}
