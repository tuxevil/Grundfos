using System;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using PriceManager;
using PriceManager.Business;
using PriceManager.Common;
using ProjectBase.Utils.Email;

namespace GrundFos.PriceManager.WebSite
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            string error = Server.GetLastError().ToString();
            if (Server.GetLastError().InnerException != null && Server.GetLastError().InnerException.GetType() == typeof(NybbleMembership.NotValidPermissionException))
                Response.Redirect("/accessdenied.aspx?Url="+ Request.Url);

#if !DEBUG  
            Utils.GetLogger().Error(Server.GetLastError().Message, Server.GetLastError().GetBaseException());     
            WebMailing wm = new WebMailing();
            wm.SendMail(Config.SupportEmail, "", "Error en PriceManager Advance", error, false);
            
#endif
        }

    }
}