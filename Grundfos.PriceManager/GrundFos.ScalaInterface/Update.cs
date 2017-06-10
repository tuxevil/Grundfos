using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using PriceManager.Business;
using NHibernate;
using ProjectBase.Data;
using PriceManager.Common;
using PriceManager;
using ProjectBase.Utils;
using NybbleMembership;
using NybbleMembership.Core.Domain;

namespace GrundFos.ScalaInterface
{
    partial class UpdateService : ServiceBase
    {
        private Timer timer;

        public UpdateService()
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

            Utils.GetLogger().Info("[[SCALA UPDATE]] Start Service");
        }

        private void OnElapsedTime(object sender)
        {
            new UpdateRun().Execute();
        }

        protected override void OnStop()
        {
            Utils.GetLogger().Info("[[SCALA UPDATE]] Stop Service");

            base.OnStop();
        }

    }
}
