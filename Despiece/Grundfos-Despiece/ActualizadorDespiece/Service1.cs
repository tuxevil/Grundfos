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

namespace ActualizadorDespiece
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

            timer = new Timer(
                    OnElapsedTime,
                    this,
                    0, Convert.ToInt32(ConfigurationManager.AppSettings["TimerElapsed"])
                    );

            EventLog.WriteEntry(ServiceName, ServiceName + " Started.");

           
        }

        private void OnElapsedTime(object sender)
        {
             FtpWatcherInstance.fwc = new FtpWatcher();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
