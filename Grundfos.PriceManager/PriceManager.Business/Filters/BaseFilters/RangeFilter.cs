using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using PriceManager.Common;
using NybbleMembership;

namespace PriceManager.Business.Filters
{
    public class RangeFilter :  CompositeControl, IFilter
    {

        public RangeFilter()
        {
            
        }

        public RangeFilter(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        private TextBox txtFrom;
        private TextBox txtTo;

        protected override void CreateChildControls()
        {
            Controls.Clear();

            txtFrom = new TextBox();
            txtFrom.ID = "txtFrom";

            txtTo = new TextBox();
            txtTo.ID ="txtTo";

            CompareValidator cv = new CompareValidator();
            cv.ControlToValidate = txtFrom.ID;
            cv.Operator = ValidationCompareOperator.DataTypeCheck;
            cv.Type = ValidationDataType.Date;
            cv.Display = ValidatorDisplay.Dynamic;
            cv.Text = Resource.Business.GetString("Validator_Invalid_Date");
            cv.ValidationGroup = "Filters";
            cv.CssClass = "valerror";

            this.Controls.Add(txtFrom);
            this.Controls.Add(cv);

            this.Controls.Add(new LiteralControl("&nbsp;al&nbsp;"));

            cv = new CompareValidator();
            cv.ControlToValidate = txtTo.ID;
            cv.Operator = ValidationCompareOperator.DataTypeCheck;
            cv.Type = ValidationDataType.Date;
            cv.Display = ValidatorDisplay.Dynamic;
            cv.Text = Resource.Business.GetString("Validator_Invalid_Date");
            cv.ValidationGroup = "Filters";
            cv.CssClass = "valerror";

            this.Controls.Add(txtTo);
            this.Controls.Add(cv);

            cv = new CompareValidator();
            cv.ControlToValidate = txtTo.ID;
            cv.ControlToCompare = txtFrom.ID;
            cv.Operator = ValidationCompareOperator.GreaterThanEqual;
            cv.Type = ValidationDataType.Date;
            cv.Display = ValidatorDisplay.Dynamic;
            cv.Text = Resource.Business.GetString("Validator_Invalid_Range");
            cv.ValidationGroup = "Filters";
            cv.CssClass = "valerror";
            this.Controls.Add(cv);

            CalendarExtender ce = new AjaxControlToolkit.CalendarExtender();
            ce.TargetControlID = txtFrom.ID;
            this.Controls.Add(ce);

            ce = new AjaxControlToolkit.CalendarExtender();
            ce.TargetControlID = txtTo.ID;
            this.Controls.Add(ce);

            ClearChildViewState();
        }

        protected override void OnInit(EventArgs e)
        {
            this.ID = string.Format("{0}_{1}", this.ClassName.ToString().Replace(".", "_"), this.FilterName);
            this.Font.Size = FontUnit.Small;
            base.OnInit(e);

            this.Visible = PermissionManager.Check(this);
        }

        #region IFilter Members

        public object Values
        {
            get
            {
                this.EnsureChildControls();
                Pair p = new Pair();
                p.First = this.txtFrom.Text;
                p.Second = this.txtTo.Text;
                return p;
            }

            set
            {
                if (value != null)
                {
                    Pair p = (Pair) value;
                    if(p.First != null)
                        txtFrom.Text = p.First.ToString();
                    if (p.Second != null)
                        txtTo.Text = p.Second.ToString();
                }
                else
                {
                    txtFrom.Text = "";
                    txtTo.Text = "";
                }
            }
        }

        public object TextValue
        {
            get
            {
                this.EnsureChildControls();
                string text = string.Empty;

                if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text))
                   text = string.Format("{0} a  {1}", this.txtFrom.Text, this.txtTo.Text);
               else if (!string.IsNullOrEmpty(txtFrom.Text))
                   text = string.Format("Del {0}", this.txtFrom.Text);
               else if (!string.IsNullOrEmpty(txtTo.Text))
                   text = string.Format("Al {0}", this.txtTo.Text);

                return text;

            }
        }

        public void Clear()
        {
            this.EnsureChildControls();
            txtFrom.Text = string.Empty;
            txtTo.Text = string.Empty;

        }

        public bool HasValue
        {
            get
            {
                this.EnsureChildControls();
                return !string.IsNullOrEmpty(txtFrom.Text) || !string.IsNullOrEmpty(txtFrom.Text);
            }
        }

        public Type ClassName
        {
            get { return typeof(Pair);  }
        }

        public string FilterName
        {
            get { return PropertyName; }
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

        public bool IsStructure
        {
            get { return true; }
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

            foreach (Control c in Controls)
                if (!(c is ExtenderControlBase))
                    c.RenderControl(writer);

            writer.WriteEndTag("div");
            writer.WriteEndTag("div");

            foreach (Control c in Controls)
                if ((c is ExtenderControlBase))
                    c.RenderControl(writer);
        }

        public void Refresh()
        {
        }
    }
}
