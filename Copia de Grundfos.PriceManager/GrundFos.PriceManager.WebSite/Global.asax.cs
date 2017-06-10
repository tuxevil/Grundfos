using System;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

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

            SmtpClient mailclient = new SmtpClient();
                
            MailMessage mm = new MailMessage();
            mm.To.Add(ConfigurationManager.AppSettings["SupportEmail"]);
            mm.Subject = "Error in PriceManager";
            mm.Body = error;

            mailclient.Send(mm);
        }
    }
}