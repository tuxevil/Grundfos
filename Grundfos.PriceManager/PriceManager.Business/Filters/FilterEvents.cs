using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Business.Filters
{
    #region Filter Event Definition

    public delegate void FilterEventHandler(object sender, FilterEventArgs sp);

    public class FilterEventArgs : EventArgs
    {
        private List<IFilter> filters;

        public FilterEventArgs(List<IFilter> filters)
        {
            this.filters = filters;
        }

        public List<IFilter> Filters
        {
            get { return filters; }
            set { filters = value; }
        }

    }

    #endregion
}
