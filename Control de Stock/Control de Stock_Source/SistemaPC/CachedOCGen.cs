namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxBitmap(typeof(ExportOptions), "report.bmp")]
    public class CachedOCGen : Component, ICachedReport
    {
        public virtual ReportDocument CreateReport()
        {
            OCGen gen = new OCGen();
            gen.Site = this.Site;
            return gen;
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

