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
using NybbleMembership;
using PriceManager.Core;
using System.Collections.Generic;
using NybbleMembership.Core.Domain;
using NybbleMembership.Core;

namespace GrundFos.PriceManager.WebSite.PriceLists.PriceLists.AddUsers
{
    public partial class _default : System.Web.UI.Page
    {
        public int PriceListId
        {
            get
            {
                if (ViewState["PriceListId"] != null)
                    return Convert.ToInt32(ViewState["PriceListId"]);
                else
                    return 0;
            }
            set 
            {
                ViewState["PriceListId"] = value; 
               
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    PriceListId = Convert.ToInt32(Request.QueryString["Id"]);

                PriceList pl = null;
                if (PriceListId != 0)
                {
                    pl = ControllerManager.PriceList.GetById(PriceListId);
                    lblPriceList.Text = pl.Name;

                }
                    UsersSelected(pl);
            }
        }

        private void UsersSelected(PriceList pl)
        {
            ltUsers.Clear();
            //usuario de la lista de precios
            ArrayList users = PermissionManager.GetUsersForEntity(pl, pl.ID.ToString(), PermissionAction.Create) as ArrayList;
            //usuarios del sitio
            IList<UserMember> lstUsers = MembershipManager.ListBySite();
            bool wasAdded = false;
            foreach (UserMember u in lstUsers)
            {
                if (pl != null)
                {
                    foreach (string um in users)
                    {
                        wasAdded = false;
                        if (um == u.Email)
                        {
                            wasAdded = true;
                            ltUsers.AddDestinationItem(new ListItem(u.UserName, u.ID.ToString()));
                            break;
                        }
                    }
                    if (!wasAdded)
                        ltUsers.AddItem(new ListItem(u.UserName, u.ID.ToString()));
                }
                else
                    ltUsers.AddItem(new ListItem(u.UserName, u.ID.ToString()));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PriceList pl = ControllerManager.PriceList.GetById(PriceListId);
            
            //IList<UserMember> lstUsers = new List<UserMember>();

            foreach (ListItem liUM in ltUsers.DestinationItems)
                PermissionManager.AddEntityPermision(pl.GetType(), pl.ID.ToString(), liUM.Text);

            foreach (ListItem liUM in ltUsers.SourceItems)
                PermissionManager.RemovePermission(pl.GetType(), pl.ID.ToString(), liUM.Text);

            Response.Redirect("/pricelists/addusers/default.aspx?Id="+ pl.ID);
        
        }
    }
}
