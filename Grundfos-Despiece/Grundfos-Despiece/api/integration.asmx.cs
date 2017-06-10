using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using GrundFos.Despiece.Common;

namespace GrundFos.Despiece.Website.api
{
    /// <summary>
    /// Summary description for integration
    /// </summary>
    [WebService(Namespace = "http://extratool.grundfos.partnernet.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class integration : System.Web.Services.WebService
    {
        [WebMethod]
        public bool UpdateData(DataSet ds)
        {
            try
            {
                bool tmp = Processor.Server.ActualizarDatos(ds, ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
                if (tmp)
                    Processor.Server.Log("Process Finished", "Actualizacion", ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
                return tmp;
            }
            catch (Exception ex)
            {
                Utils.GetLogger().Error(ex);
                return false;
            }
        }
    }
}
