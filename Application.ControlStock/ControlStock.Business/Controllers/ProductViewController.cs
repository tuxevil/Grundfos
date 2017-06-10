using PartnerNet.Domain;
using ProjectBase.Data;

namespace PartnerNet.Business
{
    public class ProductViewController : AbstractNHibernateDao<ProductView, int>
    {
        public ProductViewController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public void FilterProvider()
        {
            throw new System.NotImplementedException();
        }
    }
}
