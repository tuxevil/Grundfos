using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PriceManager.Business.Filters;
using NybbleMembership.Core.Domain;
using NybbleMembership;
using PriceManager.Core.State;

namespace PriceManager.Business.Actions
{
    public abstract class LinkButtonAction : LinkButton, IAction, IActionClick
    {
        #region IActionClick Members

        public event ActionClickEventHandler ActionClick;
        protected virtual void OnActionClick(EventArgs e)
        {
            if (ActionClick != null)
                ActionClick(this, e);
        }

        #endregion

        #region IAction Members

        protected override void OnInit(EventArgs e)
        {
            this.Text = PriceManager.Common.Resource.Business.GetString(this.GetType().Name);
            //Uncomment when all the actions are correctly loaded.
            //if(!MembershipManager.IsAdministrator())
                this.Visible = PermissionManager.Check(this);

            base.OnInit(e);
        }

        public abstract bool ExecuteAction(GridState gs, IList<IFilter> filters,  params object[] parameters);

        public void EnableControl(GridState gs)
        {
            Enabled = true;
        }

        protected override void OnClick(EventArgs e)
        {
            OnActionClick(new EventArgs());
            base.OnClick(e);
        }

        #endregion

        private bool shouldConfirm = false;
        public bool ShouldConfirm
        {
            get { return shouldConfirm; }
            set { shouldConfirm = value; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (ShouldConfirm && Enabled)
                this.OnClientClick = string.Format("javascript: return longProcessClickWithConfirm(this,'{0}');", string.Format(Common.Resource.Business.GetString("ActionConfirmText"), this.Text.ToLower()));
            else
                this.OnClientClick = null;

            base.OnPreRender(e);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            writer.Write("&nbsp;");
        }
        
        public LinkButtonAction(string id) { this.ID = id; }
        public LinkButtonAction() {  }
    }
}
