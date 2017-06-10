using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PriceManager.Business.Filters;
using NybbleMembership.Core.Domain;
using NybbleMembership;
using System.Web.UI;

namespace PriceManager.Business.Actions
{
    public abstract class JavascriptAnchorAction : HtmlAnchor, IAction
    {
        public JavascriptAnchorAction(string id) { this.ID = id; }
        public JavascriptAnchorAction() { }

        protected override void OnInit(EventArgs e)
        {
            this.InnerText = PriceManager.Common.Resource.Business.GetString(this.GetType().Name);
            this.HRef = "#";
            //Uncomment when all the actions are correctly loaded.
            //if(!MembershipManager.IsAdministrator())
                this.Visible = PermissionManager.Check(this);
            base.OnInit(e);
        }

        public bool Enabled
        {
            get { return (ViewState[this.ID + "Enabled"] != null) ? (bool)ViewState[this.ID + "Enabled"] : true; }
            set { ViewState[this.ID + "Enabled"] = value; }
        }

        public string JavascriptCode
        {
            get { return (ViewState[this.ID + "JavascriptCode"] != null) ? (string)ViewState[this.ID + "JavascriptCode"] : string.Empty; }
            set { ViewState[this.ID + "JavascriptCode"] = value; }
        }

        public virtual void EnableControl(GridState gs)
        {
            Enabled = true;
        }


        public abstract bool ExecuteAction(GridState gh, IList<IFilter> filters, params object[] parameters);

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (!Enabled)
            {
                Label lbl = new Label();
                lbl.Text = InnerText;
                lbl.RenderControl(writer);
            }
            else
            {
                Attributes["onclick"] = this.JavascriptCode + "return false;";
                Attributes["style"] = "cursor:pointer;";
                base.Render(writer);
            }

            writer.Write("&nbsp;");
        }
    }
}
