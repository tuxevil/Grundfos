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
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite.ctrl.Viewers
{
    public partial class QuoteView : System.Web.UI.UserControl
    {
        public bool View;
        public int QuoteId
        {
            get
            {
                if (ViewState["QuoteId"] != null)
                    return Convert.ToInt32(ViewState["QuoteId"]);
                else
                    return 0;
            }
            set { ViewState["QuoteId"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                ChangeView();
        }

        public void ChangeView()
        {
            if (View)
            {
                QuoteDetailView1.QuoteId = QuoteId;
                QuoteDetailView1.Visible = true;
                QuoteEditor1.Visible = false;
                QuoteDetailView1.DataBind();
            }
            else
            {
                QuoteEditor1.QuoteId = QuoteId;
                QuoteDetailView1.Visible = false;
                QuoteEditor1.Visible = true;
                QuoteEditor1.Mode = EditionMode.Edit;
                QuoteEditor1.DataBind();
            }
        }
    }
}