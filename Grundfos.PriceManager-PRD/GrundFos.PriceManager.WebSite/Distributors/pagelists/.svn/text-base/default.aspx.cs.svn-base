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
using PriceManager.Common;

namespace GrundFos.PriceManager.WebSite.Distributors.pagelists
{
    public partial class _default : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int distributorId = Convert.ToInt32(Request.QueryString["Id"]);
                    Distributor d = ControllerManager.Distributor.GetById(distributorId);
                    
                    
                    if (d.PriceList != null)
                    {
                        if (d.PriceList.CategoryPages.Count > 0)
                        {
                            IList<CatalogPage> lst = new List<CatalogPage>();
                            foreach (CatalogPage cp in d.PriceList.CategoryPages)
                                lst.Add(cp);

                            rpterDistributors.DataSource = lst;
                            rpterDistributors.DataBind();
                        }
                        else
                            litNoItems.Visible = true;
                    }
                    else
                        litNoItems.Visible = true;
                }
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
                if (cp.Parent != null)
                    (e.Item.FindControl("litParent") as Literal).Text = cp.Parent.Name;

                (e.Item.FindControl("litDescription") as Literal).Text = "N/D";
                if (!string.IsNullOrEmpty(cp.Description))
                    (e.Item.FindControl("litDescription") as Literal).Text = StringFormat.Cut(cp.Description, 32);
            }
        }
    }
}
