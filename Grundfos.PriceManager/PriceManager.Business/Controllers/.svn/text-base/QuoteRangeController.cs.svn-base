using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using PriceManager.Core.Interfaces;
using PriceManager.Core.State;
using NHibernate.SqlCommand;
using NybbleMembership;
using NybbleMembership.Core.Domain;
using PriceManager.Common;
using NybbleMembership.Core;



namespace PriceManager.Business
{
    public class QuoteRangeController
    {
         private readonly IQuoteRangeRepository repository;

        public QuoteRangeController(IQuoteRangeRepository repository)
        {
            this.repository = repository;
        }

        public QuoteRange Create(string title, Int32 max, Int32 min)
        {
            if (!AlreadyExists(title))
            {
                QuoteRange qr = new QuoteRange();
                PermissionManager.AddEntityPermision(qr.GetType(), title);
                return Update(qr, title, max, min);
            }
            else
                throw new Exception("Title already exists.");

        }

        public QuoteRange Edit(int id, string title, Int32 max, Int32 min)
        {
            QuoteRange qr = repository.GetById(id);
            if (!AlreadyExists(title, qr))
            {
                PermissionManager.UpdateEntityPermission(qr.GetType(), qr.Title, title);
                return Update(qr, title, max, min);
            }
            else
                throw new Exception("Title already exists.");
        }

        private QuoteRange Update (QuoteRange qr,string title, Int32 max, Int32 min)
        {
            qr.Title = title;
            qr.Maximum = max;
            qr.Minimum = min;

            repository.Save(qr);

            return qr;
        }

        private bool AlreadyExists(string title)
        {
            return AlreadyExists(title, repository.GetAll());
        }

        private bool AlreadyExists(string title, QuoteRange qr)
        {
            IList<QuoteRange> lst = repository.GetAll();

            lst.Remove(qr);

            return AlreadyExists(title, lst);
        }

        private bool AlreadyExists(string title, IList<QuoteRange> lstQr)
        {
            List<QuoteRange> lst = new List<QuoteRange>(lstQr);
            QuoteRange qr = lst.Find(delegate(QuoteRange record)
                                   {
                                       if (record.Title == title)
                                           return true;

                                       return false;
                                   });
            if (qr != null)
                return true;

            return false;
        }

        public IList<QuoteRange> List(GridState gridState, out int totalRecords)
        {
            return repository.List(gridState, out totalRecords);
        }

        public void Delete(int id)
        {
            QuoteRange qr = repository.GetById(id);

            PermissionManager.RemovePermission(qr.GetType(), qr.Title);
            repository.Delete(qr);
            repository.CommitChange();
        }

        public QuoteRange GetRange()
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(QuoteRange);
            epv.KeyIdentifier = Config.BestQuoteRange;

            if (!PermissionManager.Check(epv))
            {
                IList quoteRangeTitles = PermissionManager.GetPermissionIdentifiersFromFunction(typeof(QuoteRange), PermissionAction.Create);
                IList<QuoteRange> qrLst = new List<QuoteRange>();
                for (int i = 0; i < quoteRangeTitles.Count; i++)
                    qrLst.Add(GetByTitle(quoteRangeTitles[i].ToString()));

               return GetBestRange(qrLst);
            }
            else
                return GetBestRange();
        }

        private QuoteRange GetByTitle(string title)
        {
            return repository.GetByTitle(title);
        }

        private QuoteRange GetBestRange()
        { 
            return GetBestRange(repository.GetAll());
        }

        private QuoteRange GetBestRange(IList<QuoteRange> lst)
        {
            Int32 amplitude = 0;
            QuoteRange bestQr = null;

            foreach (QuoteRange qr in lst)
            { 
                if(amplitude <= (qr.Maximum - qr.Minimum))
                {
                    amplitude = qr.Maximum - qr.Minimum;
                    bestQr = qr;
                }
            }
            return bestQr;
        }

        public string GetQuoteMinimumCtr()
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(QuoteRange);
            epv.KeyIdentifier = Config.BestQuoteRange;

            if (!PermissionManager.Check(epv))
            {
                return ControllerManager.Lookup.List(LookupType.CtrCommitment)[0].Description;
            }
            else
            {
                return "-1";
            }
        }

        public string GetQuoteMinimumIndex()
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(QuoteRange);
            epv.KeyIdentifier = Config.BestQuoteRange;

            if (!PermissionManager.Check(epv))
            {
                return ControllerManager.Lookup.List(LookupType.IndexCommitment)[0].Description;
            }
            else
            {
                return "-1";
            }
        }

        public QuoteRange GetById(int id)
        {
            return repository.GetById(id);
        }
        
    }
}