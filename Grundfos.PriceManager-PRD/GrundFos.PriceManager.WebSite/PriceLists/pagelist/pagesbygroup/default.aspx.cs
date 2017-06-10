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
using System.Collections.Generic;
using PriceManager.Business;
using PriceManager.Common;

namespace GrundFos.PriceManager.WebSite.PriceLists.pagelist.pagesbygroup
{
    public partial class _default : PriceListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PriceList pl = ControllerManager.PriceList.GetById(PriceListId);
                IList<CatalogPage> lst = new List<CatalogPage>();

                foreach (CatalogPage cp in pl.CategoryPages)
                    lst.Add(cp);
                
                if (lst.Count > 0)
                {
                    rpterDistributors.DataSource = lst;
                    rpterDistributors.DataBind();
                }
                else
                    litNoItems.Visible = true;

            }
        }

        protected void rpterPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CatalogPage cp = (e.Item.DataItem as CatalogPage);

                HyperLink hl = (e.Item.FindControl("lnkGo") as HyperLink);
                hl.NavigateUrl = "/pagelist/view/default.aspx?Id=" + cp.ID;
                hl.Text = cp.Name;
                hl.ToolTip = string.Format("Ingresar al distribuidor {0}", cp.Name);

                (e.Item.FindControl("litParent") as Literal).Text = "N/D";
                if(cp.Parent != null)
                    (e.Item.FindControl("litParent") as Literal).Text = cp.Parent.Name;

                (e.Item.FindControl("litDescription") as Literal).Text = "N/D";
                if(!string.IsNullOrEmpty(cp.Description))
                    (e.Item.FindControl("litDescription") as Literal).Text = StringFormat.Cut(cp.Description, 32);
            }
        }
    }
}
