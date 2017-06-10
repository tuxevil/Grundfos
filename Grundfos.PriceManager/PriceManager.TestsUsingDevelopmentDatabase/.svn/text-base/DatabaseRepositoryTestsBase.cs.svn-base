using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using PriceManager.Common;
using NUnit.Framework;
using NHibernate;
using ProjectBase.Utils;

namespace PriceManager.TestsUsingDevelopmentDatabase
{
    /// <summary>
    /// Initiates a transaction before each test is run and rolls back the transaction after
    /// the test completes.  Consequently, tests make no permanent changes to the DB.
    /// 
    /// This is appropriate as a base class if you're unit tests run against a live, development
    /// database.  If, alternatively, you'd prefer to use an in-memory database such as SqlLite,
    /// then use <see cref="RepositoryTestsBase" /> or <see cref="RepositoryBehaviorSpecificationTestsBase" />
    /// as your base class.
    /// 
    /// As the preferred mechanism is for in-memory unit testsing, this class is provided mainly
    /// for backward compatibility.
    /// </summary>
    public abstract class DatabaseRepositoryTestsBase
    {
        [SetUp]
        public virtual void SetUp()
        {
            log4net.Config.XmlConfigurator.Configure();

            IInterceptor interceptor = new SessionInterceptor(new UserContext(Guid.NewGuid(), "DevelopmentTests", DateTime.Now));
            NHibernateSessionManager.Instance.RegisterInterceptorOn(Config.GrundfosFactoryConfigPath, interceptor);
            NHibernateSessionManager.Instance.BeginTransactionOn(Config.GrundfosFactoryConfigPath);
        }

        [TearDown]
        public virtual void TearDown()
        {
            NHibernateSessionManager.Instance.RollbackTransactionOn(Config.GrundfosFactoryConfigPath);
            NHibernateSessionManager.Instance.CloseSessionOn(Config.GrundfosFactoryConfigPath);
        }

        protected void FlushSessionAndEvict(object instance)
        {
            ISession session = NHibernateSessionManager.Instance.GetSessionFrom(Config.GrundfosFactoryConfigPath);
            session.Flush();
            session.Evict(instance);
        }
    }
}
