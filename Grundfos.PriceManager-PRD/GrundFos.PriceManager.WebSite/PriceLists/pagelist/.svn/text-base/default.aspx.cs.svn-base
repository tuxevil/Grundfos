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
using PriceManager.Business;
using System.Collections.Generic;
using PriceManager;

namespace GrundFos.PriceManager.WebSite.PriceLists.pagelist
{
    public partial class _default : PriceListPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    PriceListId = Convert.ToInt32(Request.QueryString["Id"]);

                CategoryTreeView1.PriceListID = PriceListId;
                CategoryTreeView1.DataBind();
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IList<CatalogPage> destinationPages = new List<CatalogPage>();
            foreach (TreeNode node in CategoryTreeView1.Nodes)
                foreach (TreeNode childnode in node.ChildNodes)
                    foreach (TreeNode grandchild in childnode.ChildNodes)
                        if (grandchild.Checked)
                            destinationPages.Add(new CatalogPage(Convert.ToInt32(grandchild.Value)));
            
            ControllerManager.PriceList.UpdatePagesFromPriceList(PriceListId, destinationPages);

            Utils.ShowMessage(Page, "Listas de Precios procesada con éxito.", Utils.MessageType.Info);

            //Utils.ShowMessage(Page, "Marcados: " + destinationPages.Count + " restantes: " + sourcePages.Count, Utils.MessageType.Info);
            Response.Redirect("/pricelists/pagelist/default.aspx?Id=" + PriceListId);
        }
    }
}
