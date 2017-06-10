using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Core;
using PriceManager.Common;

namespace GrundFos.PriceManager.WebSite
{
    public partial class Base : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            if (!Page.ClientScript.IsStartupScriptRegistered("BugAbbrMonth"))
            {
                string script = "Sys.CultureInfo.prototype._getAbbrMonthIndex = function(value) { if (!this._upperAbbrMonths) { this._upperAbbrMonths = this._toUpperArray(this.dateTimeFormat.AbbreviatedMonthNames); } return Array.indexOf(this._upperAbbrMonths, this._toUpper(value)); };";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "BugAbbrMonth", script, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Assembly a = Assembly.GetExecutingAssembly();
                AssemblyName name = a.GetName();
                lblVersion.Text = "v" + name.Version.Major + "." + name.Version.Minor + "." + name.Version.Build;

                lnksearch.Attributes["class"] = "";
                lnkresult.Attributes["class"] = "";

                if (!string.IsNullOrEmpty(Request.QueryString[Config.QS_SELECTION]))
                {
                    int selectionId = Convert.ToInt32(Request.QueryString[Config.QS_SELECTION]);

                    Selection s = ControllerManager.Selection.GetById(selectionId);
                    if (s != null)
                    {
                        lnkresult.InnerText = s.Description;
                        lnkresult.Visible = true;
                        lnkresult.HRef = "/pl/?s=" + selectionId;
                        lnkresult.Attributes["class"] = "current";
                    }
                }
                else
                    lnksearch.Attributes["class"] = "current";
            }
        }
    }
}
