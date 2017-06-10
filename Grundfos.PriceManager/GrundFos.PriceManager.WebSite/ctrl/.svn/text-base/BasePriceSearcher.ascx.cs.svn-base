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

namespace GrundFos.PriceManager.WebSite.ctrl
{
    public partial class BasePriceSearcher : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            Response.Write(this.Module);
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public BasePriceSearcherType Module
        {
            get { return (BasePriceSearcherType)ViewState["Module"]; }
            set { ViewState["Module"] = value; }
        }
    }

    public enum BasePriceSearcherType
    {
        Administration = 1,
        BasePrice = 2,
        BasePriceOut = 3,
        PerAttribute = 4
    }
}