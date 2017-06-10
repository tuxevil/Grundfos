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
using Productos = PriceManager.Core.Product;


namespace GrundFos.PriceManager.WebSite.admin.Products.view
{
    public partial class deafult : ProductsPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    ucNotes.NoteType = typeof(Productos);
                    ucNotes.TypeIdentifier = id;
                    ucNotes.DataBind();

                    ProductsEditor1.PriceBaseId = id;
                    ProductsEditor1.DataBind();
                }
            }
        }
    }
}
