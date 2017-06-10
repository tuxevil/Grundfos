using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using GrundFos.Despiece.Common;



namespace GeneradorXML
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
#if DEBUG
            Debugger.Launch();
            Debugger.Break();
#endif
            log4net.Config.XmlConfigurator.Configure();

            timer = new Timer(
                    OnElapsedTime,
                    this,
                    0, Convert.ToInt32(ConfigurationManager.AppSettings["TimerElapsed"])
                    );

            Utils.GetLogger().Info(this.GetType().Name + " service started");
        }

        private void OnElapsedTime(object sender)
        {
            try
            {
                GrundFos.Despiece.Processor.Client.Execute();
            }
            catch (Exception e)
            {
                Utils.GetLogger().Error(e);
            }
        }


        protected override void OnStop()
        {
            timer.Dispose();

            Utils.GetLogger().Info(this.GetType().Name + " service stopped");
        }
    }
}
