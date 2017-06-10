using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Text.RegularExpressions;

namespace PriceManager.Business.Filters
{
    public abstract class TextBoxFilter : TextBox, IFilter
    {
        protected override void OnInit(EventArgs e)
        {
            this.ID = string.Format("{0}_{1}", this.ClassName.ToString().Replace(".", "_"), this.FilterName);
            base.OnInit(e);
        }
        protected override void CreateChildControls()
        {

            CustomValidator cv = new CustomValidator();
            cv.ControlToValidate = this.ID;
            cv.ValidationGroup = "Filters";
            cv.ErrorMessage = "Por favor, no ingrese código malicioso.";
            cv.CssClass = "valerror";
            cv.Display = ValidatorDisplay.Dynamic;
            cv.ClientValidationFunction = "ContainsHtml";
            
            this.Controls.Add(cv);
            base.CreateChildControls();
        }

        #region IFilter Members

        public object Values
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value.ToString();
            }
        }

        public object TextValue
        {
            get
            {
                return this.Text;
            }
        }

        public void Clear()
        {
            this.Text = string.Empty;
        }

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(this.Text); }
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
            get { return true; }
        }

        #endregion

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "filter");
            writer.Write(HtmlTextWriter.TagRightChar);

            FilterHelper.RenderLabel(this, writer);
            base.Render(writer);
            
            foreach(Control c in Controls)
                if (!(c is ExtenderControlBase)) 
                    c.RenderControl(writer);

            writer.WriteEndTag("div");
        }

        public void Refresh()
        {
        }
    }
}
