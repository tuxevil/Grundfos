using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PriceManager.Business;
using PriceManager.Core;
using PriceManager.Core.Interfaces;
using PriceManager.Core.State;
using Rhino.Mocks;

namespace PriceManager.Tests
{
    [TestFixture]
    public class QuoteTest
    {
        [Test]
        [ExpectedException(typeof(QuoteNotificationAlreadyExistException))]
        public void AddNotificationWhitException()
        {
            Quote q = new Quote();
            q.AddNotification(null, "Sebastian Real", "sebastian.real@nybblegroup.com");
            Contact c = new Contact("Sebastian", "Real", "sebastian.real@nybblegroup.com");
            q.AddNotification(c, string.Empty, string.Empty);
        }

        [Test]
        public void AddNotification()
        {
            Quote q = new Quote();
            q.AddNotification(null, "Sebastian Real", "sebastian.real@nybblegroup.com");
            Contact c = new Contact("Emiliano", "Galizio", "emiliano.galizio@nybblegroup.com");
            q.AddNotification(c, string.Empty, string.Empty);
            c = new Contact("Santiago", "Lanus", "santiago.lanus@nybblegroup.com");
            q.AddNotification(c, string.Empty, string.Empty);

            Assert.AreEqual(3, q.QuoteNotifications.Count);
        }

        [Test]
        public void FullTestCreation()
        {
            MockRepository mock = new MockRepository();
            IDistributorRepository mockedRepos = mock.CreateMock<IDistributorRepository>();

            Distributor expDistributor = new Distributor();
            expDistributor.AddContact("Sebastian", "Real", "sebastian.real@nybblegroup.com");
            expDistributor.AddContact("Emiliano", "Galizio", "emiliano.galizio@nybblegroup.com");
            expDistributor.AddContact("Santiago", "Lanus", "santiago.lanus@nybblegroup.com");

            Expect.Call(mockedRepos.GetById(123321)).Return(expDistributor);
            mock.ReplayAll();
            DistributorController dc = new DistributorController(mockedRepos);
            
            Distributor distributor = dc.GetById(123321);
            
            Quote q = new Quote();
            foreach (Contact contact in distributor.Contacts)
            {
                q.AddNotification(contact, string.Empty, string.Empty);
            }
            q.AddNotification(null, "Alejandro Bezares", "alejandro.bezares@nybblegroup.com");

            Assert.AreEqual(4, q.QuoteNotifications.Count);

        }

        [Test]
        public void FullTestModification()
        {
            MockRepository mock = new MockRepository();
            IQuoteRepository mockedRepos = mock.CreateMock<IQuoteRepository>();

            Quote q = new Quote();
            
            Distributor expDistributor = new Distributor();
            expDistributor.AddContact("Sebastian", "Real", "sebastian.real@nybblegroup.com");
            expDistributor.AddContact("Emiliano", "Galizio", "emiliano.galizio@nybblegroup.com");
            expDistributor.AddContact("Santiago", "Lanus", "santiago.lanus@nybblegroup.com");

            q.Distributor = expDistributor;

            foreach (Contact contact in expDistributor.Contacts)
            {
                q.AddNotification(contact, string.Empty, string.Empty);
            }
            
            Expect.Call(mockedRepos.GetById(12)).Return(q);
            mock.ReplayAll();
            QuoteController qc = new QuoteController(mockedRepos);

            Quote test = qc.GetById(12);
            
            test.AddNotification(null, "Alejandro Bezares", "alejandro.bezares@nybblegroup.com");

            Assert.AreEqual(4, test.QuoteNotifications.Count);

        }

        [Test]
        public void CanEditQuoteItem()
        {
            MockRepository mock = new MockRepository();
            IQuoteRepository mockedRepos = mock.CreateMock<IQuoteRepository>();

            Quote q = new Quote();
            q.Description = "get test";
            q.Status = QuoteStatus.Draft;
            
            QuoteItem expQi = new QuoteItem();
            expQi.Observation = "hijo";
            expQi.Quantity = 1;
            expQi.Price = 3;
            q.QuoteItems.Add(expQi);

            QuoteItem qi = new QuoteItem();
            qi.Observation = "hijo cambio";
            qi.Quantity = 2;
            qi.Price = 7;
            qi.DeliveryTime = null;

            Expect.Call(mockedRepos.GetById(666)).Return(q);
            Expect.Call(mockedRepos.SaveQuoteItem(expQi)).Return(qi);
            mock.ReplayAll();

            QuoteController qc = new QuoteController(mockedRepos);

            QuoteItem resQi = qc.EditQuoteItem(666, 0, 2, null, null, null, 7);

            Assert.AreEqual(2, resQi.Quantity);
            Assert.AreEqual(7, resQi.Price);
        }
    }
}
