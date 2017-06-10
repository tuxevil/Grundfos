using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Text.RegularExpressions;
using PriceManager.Core;

namespace PriceManager.Business.Controls
{
    public class AutoCompleteTextbox : TextBox
    {
        private string servicePath;
        public string ServicePath
        {
            get { return servicePath; }
            set { servicePath = value; }
        }

        private string serviceMethod;
        public string ServiceMethod
        {
            get { return serviceMethod; }
            set { serviceMethod = value; }
        }

        protected override void CreateChildControls()
        {
            AutoCompleteExtender ace = new AutoCompleteExtender();
            ace.ID = "autoCompleteExtender";
            ace.TargetControlID = this.ID;
            ace.ServiceMethod = this.ServiceMethod;
            ace.ServicePath = this.ServicePath; ;
            ace.MinimumPrefixLength = 2;
            ace.CompletionInterval = 1000;
            ace.CompletionListCssClass = "completionList";
            ace.CompletionListItemCssClass = "completionListItem";
            ace.FirstRowSelected = true;
            ace.CompletionListHighlightedItemCssClass = "completionListItemSelected";
            ace.EnableCaching = false;
            ace.CompletionSetCount = 20;
            
            this.Controls.Add(ace);

            base.CreateChildControls();
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            foreach (Control c in Controls)
                c.RenderControl(writer);

            base.Render(writer);
        }
    }
}
