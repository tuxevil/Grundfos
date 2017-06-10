using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NybbleMembership;
using PriceManager.Core.State;
using ProjectBase.Data;

namespace PriceManager.Core.Interfaces
{
    public interface IRepository<T, IdT> : IDao<T, IdT>
    {
        void BeginTransactions();
        void CommitChange();
        void GenericDelete(object o);
        void Refresh(object o);
    }

    public interface IDistributorRepository : IRepository<Distributor, int>
    {
        IList<Distributor> GetSelecteds(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, Lookup saleCondition, Lookup type, CatalogPage page, IList priceListIds, bool isActive);
        List<Distributor> GetDistributorList(List<int> distributorID, bool markedAll);
        Distributor GetByName(string name);
        Distributor GetByCode(string code);
        IList<Distributor> GetActives();
        List<string> GetActives(string name, int count, IList priceListIds);
        decimal FindMaxDiscountPerList(PriceList pl);
        decimal FindMaxDiscountPerPriceBase(PriceBase priceBase);
        IList<Distributor> GetActivesByPriceList(IList priceListIds);
        IList<Distributor> GetActivesByPriceGroup(PriceGroup pG, int? maxResults, IList priceListIds);
        IList<Distributor> GetDistributors(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, out int totalRecords, Lookup saleCondition, Lookup type, CatalogPage page, IList priceListIds, bool isActive);
        IList<Distributor> GetByPriceList(int id);
        bool Check(string name);
        IList<Contact> GetOrderedByStatus(int distributorId);
        //IList<Contact> GetActiveContacts(int distributorId);
        Contact SaveContact(Contact c);
    }

    public interface IQuoteRepository : IRepository<Quote, int>
    {
        IList<Quote> List(GridState gridState, string text, Distributor distributor, QuoteStatus? status, out int records, Guid? userId, IList quoteIds);
        ICriteria ListCriteria(string text, Distributor distributor, QuoteStatus? status, Guid? userId, IList quoteIds);
        IList<Quote> GetQuotesByUser(Distributor d, Guid userId);
        QuoteItem SaveQuoteItem(QuoteItem qi);
    }

    public interface IQuoteRangeRepository : IRepository<QuoteRange, int>
    {
        IList<QuoteRange> List(GridState gridState, out int totalRecords);
        QuoteRange GetByTitle(string title);
    }
}
