using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using MbUnit.Framework;
using Microdesk.Utility.UnitTest;
using NHibernate;
using PriceManager.Business;
using PriceManager.Core;
using ProjectBase.Data;

namespace PriceManager.UnitTest
{
    [TestFixture]
    public class LongRunningTest : DatabaseUnitTestBase
    {
        #region Import Products

        [Test]
        public void CanCreateProductsFromImport()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestData\");

            PriceImport pi = ControllerManager.PriceImport.Create("9.csv", "9", true, ';', path, "9.csv");
            Assert.IsNotNull(pi);

            Assert.IsTrue(pi.ImportStatus != ImportStatus.Invalid, "Import Status Is Invalid.");
            Assert.IsTrue(ControllerManager.PriceImport.Import(pi.ID, Guid.NewGuid()), "Products could not be imported.");

            // Verify is marked as processed
            pi = ControllerManager.PriceImport.GetById(pi.ID);
            Assert.IsTrue(pi.ImportStatus == ImportStatus.Processed);

            //TODO: Verify the amount of products inserted is equal to the amount of products validated
            Assert.AreEqual(10772, pi.LogResults.Count);
        }

        [Test]
        public void CanUpdateProductsFromImport()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestData\");

            // Create new products
            PriceImport pi = ControllerManager.PriceImport.Create("9.csv", "9", true, ';', path, "9.csv");
            Assert.IsNotNull(pi);
            Assert.IsTrue(pi.ImportStatus != ImportStatus.Invalid, "Import Status Is Invalid.");
            Assert.IsTrue(ControllerManager.PriceImport.Import(pi.ID, Guid.NewGuid()), "Products could not be imported.");

            pi = ControllerManager.PriceImport.GetById(pi.ID);
            Assert.IsTrue(pi.ImportStatus == ImportStatus.Processed);

            ControllerManager.CurrentSession.Flush();

            // Update products
            PriceImport pi2 = ControllerManager.PriceImport.Create("9.csv", "9u", true, ';', path, "9.csv");
            Assert.IsNotNull(pi2);
            Assert.IsTrue(pi2.ImportStatus != ImportStatus.Invalid, "Import Status Is Invalid.");
            Assert.IsTrue(ControllerManager.PriceImport.Import(pi2.ID, Guid.NewGuid()), "Products could not be imported.");

            pi2 = ControllerManager.PriceImport.GetById(pi2.ID);
            Assert.IsTrue(pi2.ImportStatus == ImportStatus.Processed);
        }

        #endregion

        #region Update Distributors

        [Test]
        public void UpdateDistributors()
        {
            ControllerManager.Distributor.ScalaUpdate();

            Assert.AreEqual(1942, ControllerManager.Distributor.GetAll().Count);
        }

        [Test]
        public void UpdateTwiceDistributors()
        {
            ControllerManager.Distributor.ScalaUpdate();

            Assert.AreEqual(1942, ControllerManager.Distributor.GetAll().Count);

            ControllerManager.Distributor.ScalaUpdate();

            Assert.AreEqual(1933, (ControllerManager.Distributor.GetAll() as List<Distributor>).FindAll(delegate(Distributor record) { if (record.DistributorStatus == DistributorStatus.Incomplete) { return true; } return false; }).Count);
        }

        [Test]
        public void UpdateSomeDistributors()
        {
            ControllerManager.Distributor.ScalaUpdate();

            Assert.AreEqual(1942, ControllerManager.Distributor.GetAll().Count);

            List<int> lstId = new List<int>();
            lstId.Add(12);
            lstId.Add(16);
            lstId.Add(28);
            lstId.Add(22);
            lstId.Add(34);
            lstId.Add(765);
            lstId.Add(953);

            ControllerManager.Distributor.ScalaUpdate(lstId, false);

            Assert.AreEqual(1942, ControllerManager.Distributor.GetAll().Count);

            ControllerManager.Distributor.ScalaUpdate(lstId, true);

            Assert.AreEqual(1942, ControllerManager.Distributor.GetAll().Count);
        }

        [Test]
        public void UpdateOneDistributor()
        {
            ControllerManager.Distributor.ScalaUpdate();
            Assert.AreEqual(1942, ControllerManager.Distributor.GetAll().Count);
            ControllerManager.CurrentSession.Flush();

            Distributor distributor = ControllerManager.Distributor.GetByCode("100167");

            Assert.Contains("TERMICAL SRL *", distributor.Name);
            Assert.Contains("MARTINEZ ROSAS 1361 1414 - BUENOS AIRES    ", distributor.Address);
            Assert.Contains("RESPONSABLE INSCRIPTO", distributor.Comment);
            Assert.Contains("1", distributor.CompleteName);
            Assert.Contains("MARIA LUISA JUAN MANUEL MALLIE ALBERTO LOPEZ Regina(pago prov.)", distributor.Contact);
            Assert.Contains("4854-8954", distributor.Fax);
            Assert.Contains("9338.71", distributor.ProfitYTD);
            Assert.Contains("0", distributor.ImpExpCustomer);
            Assert.Contains("30-65559857-6", distributor.SalesTaxCode);
            Assert.Contains("20003.37", distributor.SaleYTD);
            Assert.Contains("6516.16", distributor.SalePrevYear);
            Assert.Contains("032", distributor.ScalaCountryCode);
            Assert.Contains("0", distributor.ScalaPaymentTerm);
            Assert.Contains("855 68 79/53 61", distributor.Telephone);


        }

        #endregion

        #region Update Providers

        [Test]
        public void UpdateProviders()
        {
            ControllerManager.Provider.ScalaUpdate();

            Assert.AreEqual(1163, ControllerManager.Provider.GetAll().Count);
        }

        [Test]
        public void UpdateTwiceProviders()
        {
            ControllerManager.Provider.ScalaUpdate();
            Assert.AreEqual(1163, ControllerManager.Provider.GetAll().Count);

            ControllerManager.CurrentSession.Flush();

            ControllerManager.Provider.ScalaUpdate();

            Assert.AreEqual(1160, (ControllerManager.Provider.GetAll() as List<Provider>).FindAll(delegate(Provider record) { if (record.ProviderStatus == ProviderStatus.Incomplete) { return true; } return false; }).Count);
        }

        [Test]
        public void UpdateSomeProviders()
        {
            ControllerManager.Provider.ScalaUpdate();
            Assert.AreEqual(1163, ControllerManager.Provider.GetAll().Count);
            ControllerManager.CurrentSession.Flush();

            List<int> lstId = new List<int>();
            lstId.Add(12);
            lstId.Add(16);
            lstId.Add(28);
            lstId.Add(22);
            lstId.Add(34);
            lstId.Add(765);
            lstId.Add(953);

            ControllerManager.Provider.ScalaUpdate(lstId, false);
            Assert.AreEqual(1163, ControllerManager.Provider.GetAll().Count);
            ControllerManager.CurrentSession.Flush();

            ControllerManager.Provider.ScalaUpdate(lstId, true);
            Assert.AreEqual(1163, ControllerManager.Provider.GetAll().Count);
        }

        [Test]
        public void UpdateOneProvider()
        {
            ControllerManager.Provider.ScalaUpdate();
            Assert.AreEqual(1163, ControllerManager.Provider.GetAll().Count);
            ControllerManager.CurrentSession.Flush();

            Provider provider = ControllerManager.Provider.GetByCode("900936");

            Assert.Contains("GRUNDFOS CANADA INC. (GCA)", provider.Name);
            Assert.Contains("5647 MC ADAM ROAD MISSISSAUGA ONTARIO, L4Z 1N9 CANADA", provider.Address);
            Assert.Contains("EXTERIOR  ", provider.Comment);
            Assert.Contains("GRUNDFOS CANADA INC. (GCA)", provider.CompleteName);
            Assert.Contains("SIMMON FEDDEMA", provider.Contact);
            Assert.Contains("905-890-9644", provider.Fax);
            Assert.AreEqual(new DateTime(1996, 07, 02), provider.LastInvDate);
            Assert.Contains("GRUNDFOS CANADA INC. (GCA)", provider.Name);
            Assert.Contains("0", provider.PurchaseYTD);
            Assert.Contains("64.54", provider.PurchPrevYear);
            Assert.Contains("068", provider.ScalaCountryCode);
            Assert.Contains("55-00000204-5", provider.TaxCode);
            Assert.Contains("905-890-9595", provider.Telephone);

        }

        #endregion

        #region Standar DB Setup Methods

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            DatabaseFixtureSetUp();
            IInterceptor interceptor = new SessionInterceptor();
            NHibernateSessionManager.Instance.RegisterInterceptorOn(@"..\..\WebNHibernate.config", interceptor);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            DatabaseFixtureTearDown();
        }

        [SetUp]
        public void Setup()
        {
            DatabaseSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseTearDown();
        }

        public void GetMyTestDataXMLFile()
        {
            SaveTestDatabase();
        }

        #endregion
    }

}
