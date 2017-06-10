using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Business.Filters
{
    #region Filter Event Definition

    public delegate void ActionClickEventHandler(object sender, EventArgs sp);

    public delegate void ActionExecuteEventHandler(object sender, GridStateEventArgs sp);

    public delegate void FilterExecuteEventHandler(object sender, GridStateEventArgs sp);

    public class GridStateEventArgs : EventArgs
    {
        public GridStateEventArgs(IList<IFilter> filters, GridState state)
        {
            this.filters = filters;
            this.state = state;
        }

        private IList<IFilter> filters;
        private GridState state;

        public IList<IFilter> Filters
        {
            get { return filters;  }
        }

        public GridState State
        {
            get { return state;  }
        }

    }

    #endregion
}
