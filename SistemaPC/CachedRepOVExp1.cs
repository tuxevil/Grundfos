namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxBitmap(typeof(ExportOptions), "report.bmp")]
    public class CachedRepOVExp1 : Component, ICachedReport
    {
        public virtual ReportDocument CreateReport()
        {
            RepOVExp1 exp = new RepOVExp1();
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

        public virtual TimeSpan CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
        {
            get
            {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set
            {
            }
        }

        public virtual bool CrystalDecisions.ReportSource.ICachedReport.IsCacheable
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public virtual bool CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
        {
            get
            {
                return false;
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

