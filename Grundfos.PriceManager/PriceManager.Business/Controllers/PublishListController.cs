using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;

namespace PriceManager.Business
{
    public class PublishListController : AbstractNHibernateDao<PublishList, int>
    {
        public PublishListController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public PublishList Create(PriceList priceList, DateTime validFrom, bool isCurrent)
        {
            PublishList pbl = new PublishList();

            pbl.PriceList = priceList;
            pbl.ValidFrom = validFrom;
            
            Save(pbl);

            return pbl;
        }

        public PublishList GetPublishedList(int priceListId)
        {
            ICriteria crit = this.GetCriteria();
            crit.CreateCriteria("PriceList").Add(Expression.Eq("ID", priceListId));
            crit.AddOrder(new Order("TimeStamp.CreatedOn", false));
            crit.SetMaxResults(1);
            PublishList pl = crit.UniqueResult<PublishList>();

            // If there is no publish list, try to get the current list and show it as the published.
            if (pl == null)
                pl = GetCurrentList(priceListId);
            return pl;
        }

        public PublishList GetCurrentList(int priceListId)
        {
            ICriteria crit = this.GetCriteria();
            crit.CreateCriteria("PriceList").Add(Expression.Eq("ID", priceListId));
            crit.Add(Expression.Le("ValidFrom", DateTime.Today));
            crit.AddOrder(new Order("ValidFrom", false));
            crit.AddOrder(new Order("TimeStamp.CreatedOn", false));
            crit.SetMaxResults(1);
            return crit.UniqueResult<PublishList>();
        }

        public PublishItem GetPublishItem(Distributor distributor, PriceBase priceBase)
        {
            ICriteria crit = GetCriteria();
            ICriteria pricelist = crit.CreateCriteria("PriceList");
            ICriteria dist = pricelist.CreateCriteria("Distributors");
            dist.Add(Expression.Eq("ID", distributor.ID));
            crit.Add(Expression.Le("ValidFrom", DateTime.Today));
            pricelist.Add(Expression.Eq("PriceListStatus", PriceListStatus.Active));
            crit.AddOrder(new Order("ValidFrom", false));
            crit.AddOrder(new Order("TimeStamp.CreatedOn", false));
            
            crit.SetMaxResults(1);

            PublishList publishList = crit.UniqueResult<PublishList>();

            if(publishList != null)
                return ControllerManager.PublishItem.GetPublishItem(distributor, priceBase, publishList.ID);
            return null;
        }
    }

    public class PublishItemController : AbstractNHibernateDao<PublishItem, int>
    {
        public PublishItemController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public PublishItem GetPublishItem(Distributor distributor, PriceBase priceBase, int publishListId)
        {
            ICriteria crit = GetCriteria();
            ICriteria publishlist = crit.CreateCriteria("PublishList");
            ICriteria pricelist = publishlist.CreateCriteria("PriceList");
            ICriteria dist = pricelist.CreateCriteria("Distributors");

            crit.Add(Expression.Eq("PriceBase", priceBase));
            dist.Add(Expression.Eq("ID", distributor.ID));
            publishlist.Add(Expression.Eq("ID", publishListId));
            
            crit.SetMaxResults(1);

            return crit.UniqueResult<PublishItem>();
        }


        
    }
}
