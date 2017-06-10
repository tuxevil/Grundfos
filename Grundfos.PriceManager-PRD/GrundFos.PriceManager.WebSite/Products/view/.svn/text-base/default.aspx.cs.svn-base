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

namespace GrundFos.PriceManager.WebSite.Products.view
{
    public partial class _default : ProductsPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id;
                if (!string.IsNullOrEmpty(Request.QueryString["PriceBaseId"]))
                {
                    id = Convert.ToInt32(Request.QueryString["PriceBaseId"]);
                    ucProductView.PriceBaseId = id;
                    ucNotes.NoteType = typeof(PriceBase);
                    ucNotes.TypeIdentifier = id;
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    id = Convert.ToInt32(Request.QueryString["Id"]);
                    ucProductView.ProductId = id;
                    ucNotes.NoteType = typeof(Product);
                    ucNotes.TypeIdentifier = id;
                    
                }
                
                ucNotes.DataBind();
                ucProductView.DataBind();
            }
        }
    }
}
