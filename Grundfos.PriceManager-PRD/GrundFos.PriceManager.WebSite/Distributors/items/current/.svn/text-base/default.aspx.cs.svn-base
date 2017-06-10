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
using PriceManager.Business;
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite.Distributors.items.current
{
    public partial class _default : DistributorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack || string.IsNullOrEmpty(Request.QueryString["Id"])) return;

            Distributor d = ControllerManager.Distributor.GetById(Convert.ToInt32(Request.QueryString["Id"]));
            if (d != null && d.PriceList != null)
            {
                PublishList pl = ControllerManager.PublishList.GetCurrentList(d.PriceList.ID);
                if (pl != null)
                    PriceMasterList1.PublishListID = pl.ID;

                PriceMasterList1.DistributorID = d.ID;
                PriceMasterList1.DataBind();
            }
            else
            {
                PriceMasterList1.Visible = false;
                lblNoPriceList.Visible = true;
            }
        }
    }
}
