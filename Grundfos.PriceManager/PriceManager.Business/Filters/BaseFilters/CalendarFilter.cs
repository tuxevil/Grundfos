using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace PriceManager.Business.Filters
{
    public abstract class CalendarFilter : Calendar, IFilter
    {
        protected override void OnInit(EventArgs e)
        {
            this.ID = string.Format("{0}.{1}", this.ClassName, this.FilterName);
            base.OnInit(e);
        }

        #region IFilter Members

        public abstract string FilterName
        {
            get;
        }

        public object Values
        {
            get
            {
                return this.SelectedDate;
            }

            set
            {
                if(value != null)
                    this.SelectedDate = Convert.ToDateTime(value);
                
            }
        }

        public object TextValue
        {
            get
            {
                return SelectedDate.ToShortDateString();
            }
        }

        public bool HasValue
        {
            get {return Convert.ToDateTime(Values)  > DateTime.MinValue;}
        }

        public abstract Type ClassName
        { 
            get;
        }

        public abstract string PropertyName
        {
            get;
        }

        public bool IsStructure
        {
            get { return true; }
        }

        public void Clear()
        {
            this.SelectedDate = DateTime.MinValue;
        }

        #endregion

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            FilterHelper.RenderLabel(this, writer);

            base.Render(writer);
        }

        public void Refresh() 
        {
        }
    }
}
