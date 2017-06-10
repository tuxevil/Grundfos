using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using ProjectBase.Data;

namespace GrundFos.ScalaConnector
{
    public class ScalaConnector
    {
        private string sessionFactoryConfigPath;

        public ScalaConnector(string sessionFactoryConfigPath)
        {
            this.sessionFactoryConfigPath = sessionFactoryConfigPath;
        }

        public IList<ScalaProvider> GetProvidersData()
        {
            ISession session = NHibernateSessionManager.Instance.GetSessionFrom(sessionFactoryConfigPath);
            
            ICriteria crit = session.CreateCriteria(typeof(ScalaProvider));

            return crit.List<ScalaProvider>();
        }

        public IList<ScalaProvider> GetProvidersData(List<string> providersCode)
        {
            ISession session = NHibernateSessionManager.Instance.GetSessionFrom(sessionFactoryConfigPath);

            ICriteria crit = session.CreateCriteria(typeof(ScalaProvider));
            crit.Add(Expression.In("Code", providersCode));

            return crit.List<ScalaProvider>();
        }

        public IList<ScalaDistributor> GetDistributorsData()
        {
            ISession session = NHibernateSessionManager.Instance.GetSessionFrom(sessionFactoryConfigPath);

            ICriteria crit = session.CreateCriteria(typeof(ScalaDistributor));

            return crit.List<ScalaDistributor>();
        }

        public IList<ScalaDistributor> GetDistributorsData(List<string> distributorsCode)
        {
            ISession session = NHibernateSessionManager.Instance.GetSessionFrom(sessionFactoryConfigPath);

            ICriteria crit = session.CreateCriteria(typeof(ScalaDistributor));
            crit.Add(Expression.In("Code", distributorsCode));

            return crit.List<ScalaDistributor>();
        }
    }
}
