using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PriceManager
{
    public class Utils
    {
        public static log4net.ILog GetLogger()
        {
            return log4net.LogManager.GetLogger("PriceManagerAdvanced");
        }
        public static int AdjustPageNumber(int pageNumber, int pageSize, int totalRecords)
        {
            if (pageNumber > 1 && Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalRecords) / Convert.ToDouble(pageSize))) < pageNumber)
               pageNumber = pageNumber - 1;
            return pageNumber;
        }

        public static void ShowMessage(Page page, string message, MessageType messageType)
        {
            message = message.Replace("'", @"\'");

            string messageCode = Guid.NewGuid().ToString();
            switch (messageType)
            {
                case MessageType.Info:
                    page.ClientScript.RegisterStartupScript(page.GetType(), messageCode, "<Script> showInfoMessage('" + message + "'); </Script>", false);
                    break;
                case MessageType.Warning:
                    page.ClientScript.RegisterStartupScript(page.GetType(), messageCode, "<Script> showWarningMessage('" + message + "'); </Script>", false);
                    break;
                case MessageType.Error:
                    page.ClientScript.RegisterStartupScript(page.GetType(), messageCode, "<Script> showErrorMessage('" + message + "'); </Script>", false);
                    break;
                    
            }
        }

        public static void ShowMessageInAjax(Control control, string message, MessageType messageType)
        {
            string messageCode = Guid.NewGuid().ToString();
            switch (messageType)
            {
                case MessageType.Info:
                    ScriptManager.RegisterStartupScript(control, control.GetType(), messageCode, "<Script> showInfoMessage('" + message + "'); </Script>", false);
                    break;
                case MessageType.Warning:
                    ScriptManager.RegisterStartupScript(control, control.GetType(), messageCode, "<Script> showWarningMessage('" + message + "'); </Script>", false);
                    break;
                case MessageType.Error:
                    ScriptManager.RegisterStartupScript(control, control.GetType(), messageCode, "<Script> showErrorMessage('" + message + "'); </Script>", false);
                    break;

            }

        }

        public static void SetupLongWaitButton(LinkButton b)
        {
            b.OnClientClick = "this.disabled=true;showInfoMessage('Procesando su solicitud. Espere por favor...');return true;";
        }

        public enum MessageType
        {
            Info = 1,
            Warning = 2,
            Error = 3,
        }
    }
}
