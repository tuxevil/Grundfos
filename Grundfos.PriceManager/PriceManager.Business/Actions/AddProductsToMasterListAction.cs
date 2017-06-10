using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;
using PriceManager.Core;
using PriceManager.Core.State;

namespace PriceManager.Business.Actions
{
    public class AddProductsToMasterListAction : LinkButtonAction
    {
        protected override void OnInit(EventArgs e)
        {
            ShouldConfirm = true;
            base.OnInit(e);
        }

        public override bool ExecuteAction(GridState gs, IList<IFilter> filters, params object[] parameters)
        {
            ControllerManager.PriceBase.ChangePriceBaseStatus(gs, filters, PriceBaseStatus.Verified);
            return false;
        }
    }
}