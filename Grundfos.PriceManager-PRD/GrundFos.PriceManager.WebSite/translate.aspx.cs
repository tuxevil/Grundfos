using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Resources;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;

namespace GrundFos.PriceManager.WebSite
{
    public partial class translate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.lblOutput.Text = Resources.Business.Error;
            this.lblTranslate.Text = ControllerManager.PriceImport.TestResource();
        }
    }
}
