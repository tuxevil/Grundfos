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
    public partial class newuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
        {
            Flash.Attributes["class"] = "flash_notice";
            lblInfo.Text = "Usuario creado con exito!";
            Roles.AddUserToRole(this.CreateUserWizard.UserName, "Usuarios");

        }

        protected void CreateUserWizard_CreateUserError(object sender, CreateUserErrorEventArgs e)
        {
            Flash.Attributes["class"] = "flash_alert";
            lblInfo.Text = "Error en la creación de cuenta";
        }
    }
}
