using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using PriceManager.Core;

namespace PriceManager.Business.Filters
{
    public abstract class RadioButtonListFilter : RadioButtonList, IFilter
    {
        protected override void OnInit(EventArgs e)
        {
            this.ID = string.Format("{0}.{1}", this.ClassName, this.FilterName);
            base.OnInit(e);
        }

        #region IFilter Members

        public object Values
        {
            get
            {
                return SelectedValue;
            }

            set
            {
                if(value != null)
                    SelectedValue = value.ToString();
                else
                    SelectedValue = "0";
            }
        }

        public object TextValue
        {
            get
            {
                return SelectedItem.Text;
            }
        }

        public bool HasValue
        {
            get { return (this.SelectedIndex != 0); }
        }

        public void Clear()
        {
            this.SelectedIndex = 0;
        }

        public abstract Type ClassName
        {
            get;
        }

        public abstract string PropertyName
        {
            get;
        }

        public abstract string FilterName
        {
            get;
        }

        public bool IsStructure
        {
            get { return false; }
        }

        #endregion

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "filter");
            writer.Write(HtmlTextWriter.TagRightChar);

            FilterHelper.RenderLabel(this, writer);
            base.Render(writer);
            writer.WriteEndTag("div");
        }

        public abstract void Refresh();
    }
}