using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Grundfos_Despiece
{
    public partial class administration : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.ScriptTimeout = 3600;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string errors = string.Empty;
            //if (!GrundFos.Despiece.Processor.Server.ActualizarDatos(out errors))
            //    Response.Write(errors);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string errors = string.Empty;
            //if (!GrundFos.Despiece.Processor.Server.ActualizarDespiece(out errors))
            //    Response.Write(errors);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GrundFos.Despiece.Processor.Client.Execute();
        }

    }
}
