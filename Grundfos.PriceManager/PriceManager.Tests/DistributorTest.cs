using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PriceManager.Business;
using PriceManager.Core.Interfaces;
using Rhino.Mocks;
using PriceManager.Core;
using PriceManager.Core.State;

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
        public void CanChangeContactStatus()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Contact contact = new Contact("Gali", "Emi", "EE@hot.com");
            Expect.Call(mockedRepos.GetContactById(1)).Return(contact);
            Expect.Call(mockedRepos.SaveContact(contact)).Return(contact);
            //Para los metodos de tipo de void se llama al metodo desde el repositorio directamente
            //y si o si se debe hacer un LastCall para todo el repositorio MOCK
            mockedRepos.CommitChanges();
            LastCall.On(mockedRepos);
            mock.ReplayAll();
            DistributorController dc = new DistributorController(mockedRepos);

            Contact test = dc.GetContactById(1);

            test = dc.ChangeContactStatus(test);

            Assert.AreEqual(test.Status, ContactStatus.Disable);
        }

        [Test]
        public void CanGetActives()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Contact expContact1 = new Contact("1", "l1", "1@1");
            Contact expContact2 = new Contact("2", "l2", "2@1");
            Contact expContact3 = new Contact("3", "l3", "3@1");
            Contact expContact4 = new Contact("4", "l4", "4@1");


            IList<Contact> expContactsLst = new List<Contact>();
            expContactsLst.Add(expContact1);
            expContactsLst.Add(expContact2);
            expContactsLst.Add(expContact3);
            expContactsLst.Add(expContact4);

            Expect.Call(mockedRepos.GetActiveContacts()).Return(expContactsLst);
            mock.ReplayAll();

            DistributorController dc = new DistributorController(mockedRepos);

            IList<Contact> lst = dc.GetActivesContacts();

            Assert.AreEqual(lst.Count, 4);

        }

        [Test]
        public void CanEditContact()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Contact contact = new Contact("Gali", "Emi", "EE@hot.com");
            Expect.Call(mockedRepos.GetContactById(1)).Return(contact);
            Expect.Call(mockedRepos.SaveContact(contact)).Return(contact);
            mockedRepos.CommitChanges();
            LastCall.On(mockedRepos);
            mock.ReplayAll();
            DistributorController dc = new DistributorController(mockedRepos);

            Contact c = dc.EditContact(1, "Emi Cambiado", "Gali cambiado", "otro@email.com");
            
            Assert.AreNotEqual("Emi", c.Name);
            Assert.AreEqual("Gali cambiado", c.LastName);
            Assert.AreNotEqual("EE@hot.com", c.Email);
        }
    }
}
