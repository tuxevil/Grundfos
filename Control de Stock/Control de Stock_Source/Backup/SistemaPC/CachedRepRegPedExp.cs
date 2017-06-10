namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxBitmap(typeof(ExportOptions), "report.bmp")]
    public class CachedRepRegPedExp : Component, ICachedReport
    {
        public virtual ReportDocument CreateReport()
        {
            RepRegPedExp exp = new RepRegPedExp();
            exp.Site = this.Site;
            return exp;
        }

        public virtual string GetCustomizedCacheKey(RequestContext request)
        {
            return null;
        }

        public virtual TimeSpan CacheTimeOut
        {
            get
            {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set
            {
            }
        }

        public virtual bool IsCacheable
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public virtual bool ShareDBLogonInfo
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}

