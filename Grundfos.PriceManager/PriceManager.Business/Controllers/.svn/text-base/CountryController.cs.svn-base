using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;


namespace PriceManager.Business
{
    public class CountryController : AbstractNHibernateDao<Country, int>
    {
        public CountryController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Country> GetAll(string orderField)
        {
            string query = "SELECT C FROM Country C";
            query += " ORDER BY UPPER(" + orderField + ")";
            IQuery q = NHibernateSession.CreateQuery(query);
            return q.List<Country>();
        }

    }
}