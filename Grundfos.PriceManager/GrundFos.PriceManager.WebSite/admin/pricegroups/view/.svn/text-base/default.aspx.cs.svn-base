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

namespace GrundFos.PriceManager.WebSite.admin.pricegroups.view
{
    public partial class _default : PriceGroupPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int pgId = Convert.ToInt32(Request.QueryString["Id"]);
                    ucNotes.NoteType = typeof(PriceGroup);
                    ucNotes.TypeIdentifier = pgId;
                    ucNotes.DataBind();

                    PriceGroupEditor1.PriceGroupId = pgId;
                    PriceGroupEditor1.DataBind();
                }
            }
        }
    }
}
