using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using PriceManager.Business;
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite.api
{
    /// <summary>
    /// Summary description for SearchAutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class SearchAutoComplete : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] GetCompletionList(string prefixText, int count)
        {
            return ControllerManager.Distributor.GetActives(prefixText, count).ToArray();
        }
    }
}
