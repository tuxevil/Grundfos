using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using AjaxControlToolkit;
using PriceManager.Common;
using PriceManager.Core;
using System.Web.UI.WebControls;

namespace PriceManager.Business.Filters
{
    public class PriceBaseModifiedOnFilter : TextBoxFilter
    {
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            CalendarExtender ce = new AjaxControlToolkit.CalendarExtender();
            ce.TargetControlID = this.ID;
            
            CompareValidator cv = new CompareValidator();
            cv.ControlToValidate = this.ID;
            cv.Operator = ValidationCompareOperator.DataTypeCheck;
            cv.Type = ValidationDataType.Date;
            cv.Display = ValidatorDisplay.Dynamic;
            cv.Text = Resource.Business.GetString("Validator_Invalid_Date");
            cv.ValidationGroup = "Filters";
            cv.CssClass = "valerror";

            this.Controls.Add(ce);
            this.Controls.Add(cv);
        }

        public override Type ClassName
        {
            get { return typeof(PriceBase); }
        }

        public override string PropertyName
        {
            get { return "TimeStamp.ModifiedOn"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            Controls[0].RenderControl(writer);
        }
    }
}
