using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PriceManager.Common;
using PriceManager.Core;
using PriceManager.Core.Interfaces;
using PriceManager.Data.ControllerRepositories;
using PriceManager.Business;

namespace PriceManager.TestsUsingDevelopmentDatabase
{
    [TestFixture]
    [Category("DB Tests")]
    public class DistributorRepositoryTests : DatabaseRepositoryTestsBase
    {
        private IDistributorRepository repository = new DistributorRepository(Config.GrundfosFactoryConfigPath);

        [Test]
        public void CanGetDistributorByCode()
        {
            string code = "9945554";

            // There are two options:
            //    1. Assume the Distributor should exists
            //    2. Create the necessary data before (this may lead to inconsistent results)
            // Is better to use directly the Development Database because of table creation and DB integration issues.

            Distributor d = repository.GetByCode(code);
            Assert.IsNotNull(d, string.Format("Distributor was not found by code {0}", code) );
            Assert.AreEqual(d.Code, code);
        }

        [Test]
        public void CanAddContactToDistributor()
        {
            DistributorRepository dRepos = new DistributorRepository(Config.GrundfosFactoryConfigPath);

            DistributorController dc = new DistributorController(dRepos);
            Distributor d = dc.GetById(2);

            int initialCount = d.Contacts.Count;
            string email = string.Format("emi{0}@emi.com", new Random().Next());
            Contact c = dc.AddContact(d.ID, "emi2", "emi2", email);
            d = dc.GetById(2);

            Assert.AreEqual(d.Contacts.Count, initialCount + 1);
        }

        [Test]
        public void CanChangeContactStatus()
        {
            DistributorRepository dRepos = new DistributorRepository(Config.GrundfosFactoryConfigPath);

            DistributorController dc = new DistributorController(dRepos);

            Contact c = dc.FindContactInDistributor(2, 3);
            ContactStatus previousCs = c.Status;

            c = dc.ChangeStatus(2, 3);

            Assert.AreNotEqual(c.Status, previousCs);
        }

        [Test]
        public void CanGetByCode()
        { 
            DistributorRepository dRepos = new DistributorRepository(Config.GrundfosFactoryConfigPath);

            DistributorController dc = new DistributorController(dRepos);
            Distributor d = dc.GetByCode("000001");

            Assert.AreEqual(d.Code, "000001");
        
        }

        [Test]
        public void CanChangeDistributorStatus()
        {
            DistributorRepository dRepos = new DistributorRepository(Config.GrundfosFactoryConfigPath);

            DistributorController dc = new DistributorController(dRepos);
            Distributor d = dc.GetById(2);

            string initialStatus = d.DistributorStatus.ToString();

            dc.ActivateDeactivate(2);

            d = dc.GetById(2);

            if (initialStatus == DistributorStatus.Active.ToString())
                Assert.AreEqual(d.DistributorStatus, DistributorStatus.Disable);
            else
                Assert.AreEqual(d.DistributorStatus, DistributorStatus.Active);
        }

        [Test]
        public void CanGetActives()
        {
            DistributorRepository dRepos = new DistributorRepository(Config.GrundfosFactoryConfigPath);

            DistributorController dc = new DistributorController(dRepos);

            IList<Contact> lst = dc.GetById(2).GetActiveContacs();

            foreach (Contact c in lst)
            {
                Assert.AreEqual(c.Status, ContactStatus.Active);
            }
        }

        [Test]
        public void CanEditContact()
        {
            DistributorRepository dRepos = new DistributorRepository(Config.GrundfosFactoryConfigPath);
            DistributorController dc = new DistributorController(dRepos);

            Contact c = dc.EditContact(2, 3, "emi Repo", "gali repo", "emirepo@hot");

            Assert.AreEqual(c.Name, "emi Repo");
        }

        [Test]
        [ExpectedException(typeof(DistributorContactAlreadyExistsException))]
        public void CanEditContactWithSameEmail()
        {
            DistributorRepository dRepos = new DistributorRepository(Config.GrundfosFactoryConfigPath);
            DistributorController dc = new DistributorController(dRepos);

            Contact c = dc.EditContact(2, 4, "emi Repo", "gali repo", "emirepeat@hot");

            c = dc.EditContact(2, 3, "emi Repeat", "gali repeat", "cambioelmail@hot");
            c = dc.EditContact(2, 3, "emi Repeat", "gali repeat", "emirepeat@hot");
        }
    }
}
