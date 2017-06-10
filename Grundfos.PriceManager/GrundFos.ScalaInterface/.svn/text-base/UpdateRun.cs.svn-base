using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using NHibernate;
using PriceManager;
using PriceManager.Business;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;
using NybbleMembership;
using NybbleMembership.Core.Domain;
using ProjectBase.Utils;

namespace GrundFos.ScalaInterface
{
    public class UpdateRun
    {
        public string Name
        {
            get { return "PriceManager Sync Process"; }
        }

        public bool Execute()
        {
            try
            {
                IList<UserMember> lstUsers = MembershipManager.GetAdministrators();
                if (lstUsers.Count > 0)
                {
                    IInterceptor interceptor = new SessionInterceptor(new UserContext(lstUsers[0].ID, lstUsers[0].UserName, DateTime.Now));
                    NHibernateSessionManager.Instance.RegisterInterceptorOn(Config.GrundfosFactoryConfigPath, interceptor);
                }
                else
                    throw new Exception("Could not retrieve Administrator user from Membership database.");

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

                Utils.GetLogger().Info("[[SCALA UPDATE]] Distributors Update Starting ");
                ControllerManager.Distributor.ScalaUpdate();

                Utils.GetLogger().Info("[[SCALA UPDATE]] Providers Update Starting ");
                ControllerManager.Provider.ScalaUpdate();

                ControllerManager.CurrentSession.Flush();

                //Utils.GetLogger().Info("[[CURRENCY UPDATE]] Currency Update Starting");
                //ControllerManager.CurrencyRate.Synchronize();

                //Utils.GetLogger().Info("[[CURRENCY UPDATE]] Currency Update Finished");
                //ControllerManager.CurrentSession.Flush();


                ControllerManager.Log.Add(Name, ExecutionStatus.Finished, "Sync process finished successfully");
            }
            catch (Exception e)
            {
                Utils.GetLogger().Error(e);
                ControllerManager.Log.Add(Name, ExecutionStatus.Running, e.ToString());
                return false;
            }

            return true;
        }
        
    }
}
