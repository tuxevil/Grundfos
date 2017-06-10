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
        private bool running = false;

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
            if (running)
                return;
            else
                running = true;

            string errors = string.Empty;

            //if (!GrundFos.Despiece.Processor.Server.ActualizarDatos(out errors))
            //    EventLog.WriteEntry(ServiceName, errors);

            //if (!GrundFos.Despiece.Processor.Server.ActualizarDespiece(out errors))
            //    EventLog.WriteEntry(ServiceName, errors);

            //if (!GrundFos.Despiece.Processor.Server.Finalizado(out errors))
                //EventLog.WriteEntry(ServiceName, errors);

            running = false;
        }
       
    }
}
