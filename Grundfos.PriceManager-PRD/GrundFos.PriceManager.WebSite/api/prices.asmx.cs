using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Security;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Script.Services;
using PriceManager.Business; 
using PriceManager.Core;
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite.api
{
    /// <summary>
    /// Summary description for prices
    /// </summary>
    [WebService(Namespace = "http://prices.service.grundfos.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class prices : System.Web.Services.WebService
    {

        [WebMethod]
        public TempPrice getPrice(string id, string value, string type, string masterListType, string globalToCurrency)
        {
            decimal price = 0;
            return ControllerManager.PriceBase.GetTempPrice(id, value, type, out price, masterListType, globalToCurrency);

        }

        [WebMethod]
        public ProductView ChangePrice(string id, string value, string type, string masterListType, string globalToCurrency)
        {
            return ControllerManager.PriceBase.ChangePrice(id, value, type, MembershipHelper.GetUser().UserId, masterListType, globalToCurrency);
        }
    }
}
