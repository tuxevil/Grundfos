using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using MbUnit.Framework;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace PriceManager.UnitTest
{
    [TestFixture]
    public class SchemaTest
    {
        [Test]
        public void CanExportSchema()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestData\");

            string internalSessionFactoryConfigPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\WebNHibernate.config");

            Configuration cfg = new Configuration();
            cfg.Configure(internalSessionFactoryConfigPath);

            //SchemaExport se = new SchemaExport(cfg);
            //se.SetOutputFile(Path.Combine(path, "export.sql"));
            //se.Execute(false, false, false, true);
        }
    }
}
