using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;
using PriceManager.Core;
using PriceManager.Core.State;

namespace PriceManager.Business.Actions
{
    public class MoveProductsToBaseListAction : LinkButtonAction   
    {
        protected override void OnInit(EventArgs e)
        {
            ShouldConfirm = true;
            base.OnInit(e);
        }

        public override bool ExecuteAction(GridState gs, IList<IFilter> filters, params object[] parameters)
        {
            return ControllerManager.PriceBase.RemoveFromPriceGroup(gs, filters, FilterHelper.FindObjectFromFilter(filters, typeof(PriceGroup), "ID") as PriceGroup);
                
        }
    }
}
