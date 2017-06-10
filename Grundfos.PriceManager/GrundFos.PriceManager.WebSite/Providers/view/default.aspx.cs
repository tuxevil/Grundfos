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

namespace GrundFos.PriceManager.WebSite.Providers.view
{
    public partial class _default : ProviderPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int providerId = Convert.ToInt32(Request.QueryString["Id"]);
                    ucNotes.NoteType = typeof(Provider);
                    ucNotes.TypeIdentifier = providerId;
                    ucNotes.DataBind();

                    ucProviderEditor.ProviderId= providerId;
                    ucProviderEditor.DataBind();
                }
            }
        }
    }
}
