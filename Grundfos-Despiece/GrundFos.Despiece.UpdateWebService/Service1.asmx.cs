using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace GrundFos.Despiece.UpdateWebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public bool UpdateData(DataSet ds)
        {
            
            return Processor.Server.ActualizarDatos(ds, ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        }
    }
}
