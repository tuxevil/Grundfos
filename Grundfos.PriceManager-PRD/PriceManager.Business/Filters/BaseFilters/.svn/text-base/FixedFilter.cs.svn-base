using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Business.Filters
{
    /// <summary>
    /// Used to manage filters that are not visible to the user
    /// </summary>
    public class FixedFilter : System.Web.UI.Control, IFilter
    {
        public FixedFilter(Type className, string propertyName)
        {
            Initialize(className, propertyName, null, null, true);
        }

        public FixedFilter(Type className, string propertyName, bool isStructure)
        {
            Initialize(className, propertyName, null, null, isStructure);
        }

        public FixedFilter(Type className, string propertyName, object textValue, object values)
        {
            Initialize(className, propertyName, textValue, values, true);
        }

        public FixedFilter(Type className, string propertyName, object textValue, object values, bool isStructure)
        {
            Initialize(className, propertyName, textValue, values, isStructure);
        }

        public void Initialize(Type className, string propertyName, object textValue, object values, bool isStructure)
        {
            this.className = className;
            this.propertyName = propertyName;
            this.textValue = textValue;
            this.Values = values;
            this.ID = ClassName + "." + PropertyName;
            this.isStructure = isStructure;
            this.Visible = false;
        }

        #region IFilter Members

        public string FilterName
        {
            get { return propertyName; }
        }

        private Type className;

        public Type ClassName
        {
            get { return className; }
        }

        private string propertyName;

        public string PropertyName
        {
            get { return propertyName; }
        }

        private object textValue;

        public object TextValue
        {
            get { return textValue; }
        }

        private bool isStructure;

        public bool IsStructure
        {
            get { return isStructure; }
        }

        public object Values
        {
            get { return ViewState["Values"]; }
            set { ViewState["Values"] = value; }
        }

        public bool HasValue
        {
            get { return (Values != null ); }
        }

        public void Clear()
        {
        }

        public void Refresh()
        {
        }


        #endregion
    }
}
