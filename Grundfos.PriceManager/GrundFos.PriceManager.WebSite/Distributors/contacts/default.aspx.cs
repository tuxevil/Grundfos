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
using GrundFos.PriceManager.WebSite.ctrl.editors;
using NybbleMembership.Core.Domain;
using PriceManager.Common;
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite.Distributors.contacts
{
    public partial class _default : DistributorPage
    {
        public int DistributorId
        {
            get
            {
                if (ViewState["distributorId"] != null)
                    return Convert.ToInt32(ViewState["distributorId"]);
                else
                    return 0;
            }
            set { ViewState["distributorId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    DistributorId = Convert.ToInt32(Request.QueryString["Id"]);

                    dceCreate.DistributorId = DistributorId;
                    dceCreate.Mode = EditionMode.Create;
                    dceCreate.DataBind();
                    LoadContacts(DistributorId);
                    
                    //permiso para poder crear contacto
                    ExecutePermissionValidator epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(Contact);
                    epv.KeyIdentifier = Config.CanCreateContact;
                    btnNew.Visible = PermissionManager.Check(epv);
                }
            }

            dceCreate.SaveCreation += new CommandEventHandler(dceCreate_SaveCreation); 
        }

        protected void dceCreate_SaveCreation(object sender, CommandEventArgs e)
        {
            if ((e.CommandName == "ChangeStatus" && ((ContactStatus)e.CommandArgument) == ContactStatus.Disable)
                || e.CommandName == "Created")
                Response.Redirect("/distributors/contacts/default.aspx?id=" + DistributorId);

            if (e.CommandName == "CloseCreate")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "closeCreate", "<Script> hideCreate(); </Script>", false);
                dceCreate.EraseFields();
            }
        }

        private void LoadContacts(int distributorId)
        {
            IList<Contact> lst = new List<Contact>();
            Distributor d = ControllerManager.Distributor.GetById(distributorId);
            if (chkAll.Checked)
                lst = ControllerManager.Distributor.GetOrderedByStatus(d.ID);
            else
                lst = d.GetActiveContacs();

            rptDistributorContacts.DataSource = lst;
            rptDistributorContacts.DataBind();

            if(d.Contacts.Count <= 0)
                chkAll.Enabled = false;
        }

        protected void rptDistributorContacts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Contact c = (e.Item.DataItem as Contact);

                if (c != null)
                {
                    DistributorContactEditor dceEdit = (e.Item.FindControl("DistributorContactEditor1") as DistributorContactEditor);

                    dceEdit.Mode = EditionMode.View;
                    dceEdit.DistributorId = c.Distributor.ID;
                    dceEdit.DistributorContact = c;
                    dceEdit.DataBind();
                }
            }
        }

        protected void chkAll_Check(object sender, EventArgs e)
        {
            LoadContacts(DistributorId);
        }
    }
}
