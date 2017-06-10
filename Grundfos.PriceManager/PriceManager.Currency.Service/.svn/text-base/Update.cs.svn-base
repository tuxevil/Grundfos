using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace PriceManager.Currency.Service
{
    partial class Update : ServiceBase
    {
        private Timer timer;

        public Update()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            timer = new Timer(
                OnElapsedTime,
                this,
                0,
                Convert.ToInt32(ConfigurationManager.AppSettings["TimeSlice"]));

            EventLog.WriteEntry(ServiceName, ServiceName + " Started.");
        }

        protected override void OnStop()
        {
            
        }

        private void OnElapsedTime(object sender)
        {
            UpdateRun updateRun = new UpdateRun();
            string errors;
            updateRun.Execute(out errors);
        }
    }
}
