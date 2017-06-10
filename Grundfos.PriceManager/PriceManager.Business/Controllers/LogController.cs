using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;

namespace PriceManager.Business
{
    public class LogController : AbstractNHibernateDao<Log, int>
    {
        public LogController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public void Create(string processName, ExecutionStatus executionStatus, string observation, DateTime dateCreated)
        {
            Log log = new Log();
            log.CreationDate = dateCreated;
            log.ExecutionStatus = executionStatus;
            log.Observations = observation;
            log.ProcessName = processName;

            Save(log);
        }

        public bool IsExecuting(string processName, ExecutionStatus executionStatus)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ProcessName", processName));
            crit.Add(Expression.Eq("ExecutionStatus", executionStatus));
            crit.Add(Expression.Eq("CreationDate", DateTime.Today));
            return crit.UniqueResult<Log>() != null;
        }

        public void Add(string processName, ExecutionStatus executionStatus, string observations)
        {
            Log lg = new Log();

            if (executionStatus == ExecutionStatus.Start)
                lg.CreationDate = DateTime.Today;
            else
                lg.CreationDate = DateTime.Now;

            lg.ExecutionStatus = executionStatus;
            lg.Observations = observations;
            lg.ProcessName = processName;
            Save(lg);
        }
    }
}
