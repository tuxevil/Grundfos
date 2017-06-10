using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Core.Interfaces;
using PriceManager.Common;
using PriceManager.Business;
using ProjectBase.Utils;

namespace GrundFos.PriceManager.Bussines
{
    public class FactoryControllerManager : IControllerFactory 
    {
        public FactoryControllerManager(string sessionFactoryConfigPath)
        {
            Check.Require(sessionFactoryConfigPath != null, "sessionFactoryConfigPath may not be null");
            SessionFactoryConfigPath = sessionFactoryConfigPath;
        }

        private string sessionFactoryConfigPath;
        protected string SessionFactoryConfigPath {
            get {
                return sessionFactoryConfigPath;
            }
            set {
                sessionFactoryConfigPath = value;
            }
        }

        public IDistributor Distributor()
        {
            return new DistributorController(sessionFactoryConfigPath);
        }
    }
}
