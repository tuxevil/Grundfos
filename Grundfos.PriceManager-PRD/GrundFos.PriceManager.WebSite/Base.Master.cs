using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Core;
using PriceManager.Common;
using MenuItem=PriceManager.Business.MenuItem;
using NybbleMembership.Core.Domain;
using NybbleMembership;
using ProjectBase.Utils.Cache;

namespace GrundFos.PriceManager.WebSite
{
    public partial class Base : BaseMasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
                return;

            if (!Page.IsPostBack)
            {
                MembershipHelperUser mhs = MembershipHelper.GetUser();
                if (mhs == null)
                    return;
                Trace.Write("Begin Validate");
                PermissionManager.Validate(this.Page);
                Trace.Write("Finish Validate");
                lblUser.Text = mhs.FullName;
            }

            LoadMenu();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Assembly a = Assembly.GetExecutingAssembly();
                AssemblyName name = a.GetName();
                lblVersion.Text = "v" + name.Version.Major + "." + name.Version.Minor + "." + name.Version.Build;
                lnkClearCache.Visible = MembershipHelper.GetUser().IsAdministrator;
                lnkGoToMembership.Visible = MembershipHelper.GetUser().IsAdministrator;
            }
        }

        public override void LoadMenu()
        {
            Trace.Write("Begin Menu");
            MenuItem mu = MenuItem.FindMenu(this.Page.AppRelativeVirtualPath);

            if (mu != null)
            {
                plhMenu.Controls.Clear();
                plhDropDownMenus.Controls.Clear();

                Trace.Write("Begin Basic Menu");
                HtmlControl hc = mu.CreateMenu();
                if (hc != null)
                    plhMenu.Controls.Add(hc);
                Trace.Write("Begin Basic Menu");

                Trace.Write("Begin DropDowns");
                IList<HtmlControl> dropMenus = mu.CreateDropDownMenus();
                if (dropMenus != null)
                    foreach (HtmlControl ctrl in dropMenus)
                        plhDropDownMenus.Controls.Add(ctrl);
                Trace.Write("End DropDowns");
 
                if (this.Page is MenuPage)
                {
                    string title = (this.Page as MenuPage).GetTitle();
                    if (!string.IsNullOrEmpty(title))
                    {
                        mu.AlternativeTitle = title;
                        this.Page.Title = "Prices Manager Advanced - " + title;
                    }
                }
                else
                    this.Page.Title = "Prices Manager Advanced - " + mu.Description;

                this.lblPageTitle.Controls.Clear();
                this.lblPageTitle.Controls.Add(mu.GetCurrentPageTitle());
            }

            Trace.Write("End Menu");
        }

        protected void lnkClearCache_Click(object sender, EventArgs e)
        {
            CacheManager.ExpireAll();
        }

        protected void lnkGoToMembership_Click(object sender, EventArgs e)
        {
            Response.Redirect(Config.MembershipUrl);
        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
       
    }
}
