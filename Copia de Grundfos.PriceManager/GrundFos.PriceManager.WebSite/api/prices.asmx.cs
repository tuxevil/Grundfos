using System;
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

namespace GrundFos.PriceManager.WebSite.api
{
    /// <summary>
    /// Summary description for prices
    /// </summary>
    [WebService(Namespace = "http://localhost:4030/api/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class prices : System.Web.Services.WebService
    {

        [WebMethod]
        public TempPrice getPrice(string id, string value, string type)
        {
            decimal price = 0;
            return ControllerManager.ProductPrice.GetTempPrice(id, value, type, out price);
          
        }

        [WebMethod]
        public ProductView ChangePrice(string id, string value, string type)
        {
            return ControllerManager.ProductPrice.ChangePrice(id, value, type, (Guid)Membership.GetUser().ProviderUserKey);
        }
    }
}
