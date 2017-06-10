using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;
using PriceManager.Core;

namespace PriceManager.Business.Actions
{
    public class MoveProductsToOutOfListAction : LinkButtonAction   
    {
        protected override void OnInit(EventArgs e)
        {
            ShouldConfirm = true;
            base.OnInit(e);
        }

        public override bool ExecuteAction(GridState gs, IList<IFilter> filters, params object[] parameters)
        {
            if (!ControllerManager.PriceBase.ChangePriceBaseStatus(gs, filters, PriceBaseStatus.NotVerified))
               return false;

           return true;
        }
    }
}
