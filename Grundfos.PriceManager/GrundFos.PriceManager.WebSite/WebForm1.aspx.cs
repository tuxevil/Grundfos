using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Core;
using NMembership = NybbleMembership;
using NybbleMembership.Core.Domain;
using PriceManager.Business.Actions;


namespace GrundFos.PriceManager.WebSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            List<PriceCalculation> priceCalculations = ControllerManager.PriceCalculation.GetAllSorted() as List<PriceCalculation>;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            List<PriceCalculation> priceCalculations = ControllerManager.PriceCalculation.GetAllSorted() as List<PriceCalculation>;
        }
    }
}
