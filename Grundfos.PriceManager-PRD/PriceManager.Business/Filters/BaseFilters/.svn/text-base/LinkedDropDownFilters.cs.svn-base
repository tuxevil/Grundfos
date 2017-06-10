using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using PriceManager.Common;
using NybbleMembership;
using PriceManager.Core;
using PriceManager.Business.Controls;

namespace PriceManager.Business.Filters
{
    public class LinkedDropDownFilters :  LinkedDropDown, IFilter
    {

        public LinkedDropDownFilters()
        {
            this.PropertyName = "ID";
        }

        public LinkedDropDownFilters(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        protected override void OnInit(EventArgs e)
        {
            this.EnsureChildControls();

            this.ID = string.Format("{0}_{1}", this.ClassName.ToString().Replace(".", "_"), this.FilterName);

            base.OnInit(e);

            //this.Visible = PermissionManager.Check(this);
        }

        #region IFilter Members

        public void Clear()
        {
            this.EnsureChildControls();
            this.Index = 0;
        }

        public bool HasValue
        {
            get
            {
                this.EnsureChildControls();
                return categoryResult.SelectedIndex > 0;
            }
        }

        public Type ClassName
        {
            get { return typeof(CategoryBase);  }
        }

        public string PropertyName
        {
            get { return (ViewState["PropertyName"] != null) ? ViewState["PropertyName"].ToString() : string.Empty; }
            set
            {
                ViewState["PropertyName"] = value;
                this.ID = string.Format("{0}.{1}", this.ClassName, this.PropertyName);
            }
        }

        public string FilterName
        {
            get { return PropertyName; }
        }

        public bool IsStructure
        {
            get { return false; }
        }

        #endregion

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "filter range");
            writer.Write(HtmlTextWriter.TagRightChar);

            FilterHelper.RenderLabel(this, writer);

            writer.WriteBeginTag("div");
            writer.AddAttribute("class", "boxes");
            writer.Write(HtmlTextWriter.TagRightChar);

            base.Render(writer);

            writer.WriteEndTag("div");
            writer.WriteEndTag("div");
        }

        public void Refresh()
        {
            

        }
    }
}
