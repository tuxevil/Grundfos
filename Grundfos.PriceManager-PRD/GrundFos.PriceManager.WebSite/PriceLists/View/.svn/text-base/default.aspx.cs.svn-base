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

namespace GrundFos.PriceManager.WebSite.PriceLists.View
{
    public partial class _default : PriceListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack )
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int priceListId = Convert.ToInt32(Request.QueryString["Id"]);
                    ucNotes.NoteType = typeof(PriceList);
                    ucNotes.TypeIdentifier = priceListId;
                    ucNotes.DataBind();
 
                    ucPriceListEditor.PriceListId = priceListId;
                    ucPriceListEditor.DataBind();
                }
            }
        }
    }
}
