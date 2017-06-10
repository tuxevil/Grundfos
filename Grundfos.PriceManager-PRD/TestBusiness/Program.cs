using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business;
using PriceManager.Core;

namespace TestBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            PriceImportController pic = new PriceImportController("WebNHibernate.config");
            ControllerManager.PriceImport.Import(new Guid("5aed9017-dcf6-40ca-97a7-9cb0011a46f7"), new Guid("5aed9017-dcf6-40ca-97a7-9cb0011a46f7"));
            //pic.GetAll();
        }
    }
}
