using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PriceManager.Business;
using PriceManager.Core.Interfaces;
using Rhino.Mocks;
using PriceManager.Core;
using PriceManager.Core.State;
using PriceManager.Data.ControllerRepositories;
using PriceManager.Common;

namespace PriceManager.Tests
{
    [TestFixture]
    public class DistributorTest
    {
        [Test]
        public void CanCreate()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Distributor expDistributor = new Distributor();
            expDistributor.Address = "pepe street.";
            expDistributor.Code = "1234";
            expDistributor.Discount = 15;
            expDistributor.Email = "epep@pepe.com";
            expDistributor.Name = "testing Distributor";

            Expect.Call(mockedRepos.GetById(123321)).Return(expDistributor);
            mock.ReplayAll();

            DistributorController dc = new DistributorController(mockedRepos);

            Distributor distributor = dc.GetById(123321);

            Assert.AreEqual(distributor.Code, "1234");
        }

        [Test]
        [ExpectedException(typeof(DistributorContactAlreadyExistsException))]
        public void AddContactToDistributor()
        {
            Distributor d = new Distributor();
            
            d.AddContact("Sebastian", "Real", "sebastian.real@nybblegroup.com");
            d.AddContact("Emiliano", "Galizio", "emiliano.galizio@nybblegroup.com");
            d.AddContact("Sebastian", "Real", "sebastian.real@nybblegroup.com");
        }

        [Test]
        public void ActivateDeactivate()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository repository = mock.CreateMock<IDistributorRepository>();
            Distributor d = new Distributor();
            d.DistributorStatus = DistributorStatus.Active;
            Expect.Call(repository.GetById(1)).Return(d);
            mock.ReplayAll();
            DistributorController distributorController = new DistributorController(repository);
           
            distributorController.ActivateDeactivate(1);
            Assert.AreEqual(DistributorStatus.Disable, d.DistributorStatus);
        }

        [Test]
        public void CanGetByCode()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Distributor expDistributor = new Distributor();
            expDistributor.Address = "pepe street.";
            expDistributor.Code = "1234";
            expDistributor.Discount = 15;
            expDistributor.Email = "epep@pepe.com";
            expDistributor.Name = "testing Distributor";

            Expect.Call(mockedRepos.GetByCode("1234")).Return(expDistributor);
            mock.ReplayAll();
            DistributorController dc = new DistributorController(mockedRepos);

            Distributor d = dc.GetByCode("1234");
            Assert.IsNotNull(d);
        }

        [Test]
        public void CanActivateDeactivateContact()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Distributor expDistributor = new Distributor();
            expDistributor.Address = "pepe street.";
            expDistributor.Code = "1234";
            expDistributor.Discount = 15;
            expDistributor.Email = "epep@pepe.com";
            expDistributor.Name = "testing Distributor";

            Expect.Call(mockedRepos.GetById(5)).Return(expDistributor);

            Expect.Call(mockedRepos.GetById(5)).Return(expDistributor).Repeat.AtLeastOnce();
            Expect.Call(mockedRepos.Save(expDistributor)).Return(expDistributor);
            mock.ReplayAll();
            DistributorController dc = new DistributorController(mockedRepos);
            Distributor d = dc.GetById(5);
            dc.AddContact(5, "Gali", "Emi", "EE@hot.com");

            Contact test = dc.ChangeStatus(5,0);

            Assert.AreEqual(test.Status, ContactStatus.Disable);

            test = dc.ChangeStatus(5, 0);

            Assert.AreEqual(test.Status, ContactStatus.Active);
        }

        [Test]
        public void CanGetActives()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Distributor expDistributor = new Distributor();
            expDistributor.Address = "pepe street.";
            expDistributor.Code = "1234";
            expDistributor.Discount = 15;
            expDistributor.Email = "epep@pepe.com";
            expDistributor.Name = "testing Distributor";
            Contact expC = new Contact("Gali", "Emi", "EE@hot.com");
            Contact expC2 = new Contact("Gali2", "Emi2", "EE2@hot.com");
            expC2.Deactivate();
            expC.Distributor = expDistributor;
            expDistributor.Contacts.Add(expC);
            expDistributor.Contacts.Add(expC2);

            Expect.Call(mockedRepos.GetById(666)).Return(expDistributor);
            mock.ReplayAll();

            DistributorController dc = new DistributorController(mockedRepos);

            IList<Contact> lst = dc.GetById(666).GetActiveContacs();

            Assert.AreEqual(lst.Count, 1);
        }

        [Test]
        public void CanEditContact()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Distributor expDistributor = new Distributor();
            expDistributor.Address = "pepe street.";
            expDistributor.Code = "1234";
            expDistributor.Discount = 15;
            expDistributor.Email = "epep@pepe.com";
            expDistributor.Name = "testing Distributor";
            Contact expC = new Contact("Gali", "Emi", "EE@hot.com");
            expC.Distributor = expDistributor;
            expDistributor.Contacts.Add(expC);

            Contact contact = new Contact("Emi Cambiado", "Gali cambiado", "otro@email.com");
            contact.Distributor = expDistributor;

            Expect.Call(mockedRepos.GetById(5)).Return(expDistributor).Repeat.AtLeastOnce();
            Expect.Call(mockedRepos.SaveContact(expC)).Return(contact);
            mockedRepos.CommitChange();
            LastCall.On(mockedRepos);
            mock.ReplayAll();
            DistributorController dc = new DistributorController(mockedRepos);

            Contact c = dc.EditContact(5,0, "Emi Cambiado", "Gali cambiado", "otro@email.com");

            Assert.AreNotEqual("Emi", c.Name);
            Assert.AreEqual("Gali cambiado", c.LastName);
            Assert.AreNotEqual("EE@hot.com", c.Email);
        }

        [Test]
        public void CanAddContactToDistributor()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Distributor expDistributor = new Distributor();
            expDistributor.Address = "pepe street.";
            expDistributor.Code = "1234";
            expDistributor.Discount = 15;
            expDistributor.Email = "epep@pepe.com";
            expDistributor.Name = "testing Distributor";

            Expect.Call(mockedRepos.GetById(666)).Return(expDistributor).Repeat.AtLeastOnce();
            Expect.Call(mockedRepos.Save(expDistributor)).Return(expDistributor);
            mock.ReplayAll();

            DistributorController dc = new DistributorController(mockedRepos);
            Contact c = dc.AddContact(666, "emi", "emi", "emi@mail");
            Distributor d = dc.GetById(666);

            Assert.AreEqual(d.Contacts.Count, 1);
        }
    }
}
