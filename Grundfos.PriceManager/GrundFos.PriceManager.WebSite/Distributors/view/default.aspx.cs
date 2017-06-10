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

namespace GrundFos.PriceManager.WebSite.Distributors.View
{
    public partial class _default : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack )
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int distributorId = Convert.ToInt32(Request.QueryString["Id"]);
                    ucNotes.NoteType = typeof(Distributor);
                    ucNotes.TypeIdentifier = distributorId;
                    ucNotes.DataBind();
                    
                    ucDistributorEditor.DistributorId = distributorId ;
                    ucDistributorEditor.DataBind();
                }
            }
        }
    }
}
