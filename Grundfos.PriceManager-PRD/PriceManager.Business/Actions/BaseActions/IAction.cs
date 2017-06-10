using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;

namespace PriceManager.Business.Actions
{
    public interface IAction
    {
        bool ExecuteAction(GridState gh, IList<IFilter> filters, params object[] parameters);
        bool Enabled { get; set; }
        void EnableControl(GridState gh);
        string ID { get; set; }
        bool Visible { get; set; }
    }

    public interface IActionClick
    {
        event ActionClickEventHandler ActionClick;
    }
}
