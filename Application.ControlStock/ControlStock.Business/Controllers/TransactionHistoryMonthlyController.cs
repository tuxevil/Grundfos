using PartnerNet.Domain;
using ProjectBase.Data;

namespace PartnerNet.Business
{
    public class TransactionHistoryMonthlyController : AbstractNHibernateDao<TransactionHistoryMonthly, int>
    {
        public TransactionHistoryMonthlyController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public void FilterLastMonth()
        {
            throw new System.NotImplementedException();
        }

        public void Filter2Months()
        {
            throw new System.NotImplementedException();
        }

        public void Filter3Months()
        {
            throw new System.NotImplementedException();
        }

        public void Filter6Months()
        {
            throw new System.NotImplementedException();
        }

        public void FilterLastyear()
        {
            throw new System.NotImplementedException();
        }
    }
}
