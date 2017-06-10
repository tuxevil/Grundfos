using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ProjectBase.Utils.Email;
using GrundFos.Despiece.Common;

namespace GrundFos.Despiece.Website
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
#if !DEBUG
            string error = Server.GetLastError().ToString();
            SmtpMailing wm = new SmtpMailing();
            wm.SendMail(Config.SupportEmail, "", "Error en Despiece", error, false);
            Utils.GetLogger().Error(Server.GetLastError().Message, Server.GetLastError().GetBaseException());
#endif
        }
    }
}