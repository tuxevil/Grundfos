using System;
using System.Collections.Generic;
using NHibernate;
using NybbleMembership;
using PriceManager.Core;
using ProjectBase.Data;
using System.Collections;
using PriceManager.Core.State;

namespace PriceManager.Repositories
{
    public interface IRepository<T, IdT> : IDao<T, IdT>
    {
        void BeginTransaction();
        void CommitChanges();
    }

    public interface IDistributorRepository: IRepository<Distributor,int>
    {
        IList<Distributor> GetSelecteds(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, Incoterm? saleCondition, Lookup type, CatalogPage page, IList priceListIds, bool isActive);
        List<Distributor> GetDistributorList(List<int> distributorID, bool markedAll);
        Distributor GetByName(string name);
        Distributor GetByCode(string code);
        IList<Distributor> GetActives();
        List<string> GetActives(string name, int count);
        decimal FindMaxDiscountPerList(PriceList pl);
        decimal FindMaxDiscountPerPriceBase(PriceBase priceBase);
        IList<Distributor> GetActivesByPriceList(IList priceListIds);
        IList<Distributor> GetActivesByPriceGroup(PriceGroup pG, int? maxResults, IList priceListIds);
        IList<Distributor> GetDistributors(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, out int totalRecords, Incoterm? saleCondition, Lookup type, CatalogPage page, IList priceListIds, bool isActive);
        IList<Distributor> GetByPriceList(int id);
        bool Check(string name);
        IList<Contact> GetContacts();
        IList<Contact> GetActiveContacts();
        Contact GetContactById(int id);
        Contact SaveContact(Contact c);
    }

    public interface IQuoteRepository : IRepository<Quote, int>
    {
        IList<Quote> List(GridState gridState, string text, Distributor distributor, QuoteStatus? status, out int records, Guid? userId, IList quoteIds);
        ICriteria ListCriteria(string text, Distributor distributor, QuoteStatus? status, Guid? userId, IList quoteIds);
        IList<Quote> GetQuotesByUser(Distributor d, MembershipHelperUser user);
    }

    
}
