using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using NHibernate;
using PriceManager.Business;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;

namespace PriceManager.Currency.Service
{
    public class UpdateRun
    {
        public string Name
        {
            get { return "Scala Sync Process"; }
        }

        public bool Execute(out string errors)
        {
#if DEBUG
            Debugger.Break();
#endif

            errors = "";

            IInterceptor interceptor = new SessionInterceptor();
            NHibernateSessionManager.Instance.RegisterInterceptorOn(Config.GrundfosFactoryConfigPath, interceptor);

            try
            {
                #region Check if needs to be executed

                if (DateTime.Now.Hour >= Convert.ToInt32(ConfigurationManager.AppSettings["ExecuteHour"]))
                {
                    if (ControllerManager.Log.IsExecuting(Name, ExecutionStatus.Start))
                        return true;
                    else
                        ControllerManager.Log.Add(Name, ExecutionStatus.Start, string.Empty);
                }
                else
                    return true;

                #endregion

                Utils.GetLogger().Info("[[CURRENCY UPDATE]] Currency Update Starting");
                ControllerManager.CurrencyRate.Synchronize();
                Utils.GetLogger().Info("[[CURRENCY UPDATE]] Currency Update Finished");
                ControllerManager.CurrentSession.Flush();

                ControllerManager.Log.Add(Name, ExecutionStatus.Finished, "Sync process finished successfully");
            }
            catch (Exception e)
            {
                errors = e.ToString();
                ControllerManager.Log.Add(Name, ExecutionStatus.Running, errors);
                return false;
            }

            return true;
        }

    }
}
