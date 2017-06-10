using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PriceManager.Business;
using PriceManager.Core;
using PriceManager.Core.Interfaces;
using PriceManager.Core.State;

namespace PriceManager.TestsUsingDevelopmentDatabase.PriceManager.Business
{
    [TestFixture]
    public class QuoteTest : DatabaseRepositoryTestsBase
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
            ControllerManager.Quote.BeginTransactions();
            Quote q = new Quote();
            q.Distributor = ControllerManager.Distributor.GetById(141);
            q.Description = "NUnit Testing #1";
            q.Vigency = ControllerManager.Lookup.GetById(12);
            q.IntroText = ControllerManager.Lookup.GetById(17);
            q.Condition = ControllerManager.Lookup.GetById(16);
            q.AddNotification(null, "Sebastian Real", "sebastian.real@nybblegroup.com");
            ControllerManager.Quote.Save(q);
            ControllerManager.Quote.CommitChange();

            Assert.AreEqual(1, q.QuoteNotifications.Count);
        }

        [Test]
        public void FullTestCreation()
        {
            ControllerManager.Quote.BeginTransactions();
            Distributor distributor = ControllerManager.Distributor.GetById(2);

            Quote q = new Quote();
            q.Distributor = ControllerManager.Distributor.GetById(141);
            q.Description = "NUnit Testing #2";
            q.Vigency = ControllerManager.Lookup.GetById(12);
            q.IntroText = ControllerManager.Lookup.GetById(17);
            q.Condition = ControllerManager.Lookup.GetById(16);
            foreach (Contact contact in distributor.Contacts)
            {
                q.AddNotification(contact, string.Empty, string.Empty);
            }
            q.AddNotification(null, "Alejandro Bezares", "alejandro.bezares@nybblegroup.com");
            ControllerManager.Quote.Save(q);
            ControllerManager.Quote.CommitChange();

            Assert.AreEqual(5, q.QuoteNotifications.Count);

        }

        [Test]
        public void FullTestModification()
        {
            Quote test = ControllerManager.Quote.GetById(65);
            test.AddNotification(null, "Sebastian Real", "sebastian.real@nybblegroup.com");
            Assert.AreEqual(6, test.QuoteNotifications.Count);
        }

        [Test]
        public void UIFullTestModification()
        {
            bool canfinal;
            List<int> contactselected = new List<int>();
            contactselected.Add(4);
            contactselected.Add(6);
            contactselected.Add(7);
            List<int> productselected = new List<int>();
            productselected.Add(15271);
            productselected.Add(7387);
            
            Quote q = ControllerManager.Quote.AddItems(new GridState(productselected, 100, 1, "Code", true, false, DateTime.Now, null), 0, "Pepe Asoc.", "Probando desde Testing", "Observaciones desde testing", 12, 16, 17, "sebastian.real@probando.com", "Sebastian Probando", out canfinal, contactselected, 1);
            
            Assert.AreEqual(3, q.QuoteNotifications.Count);
            Assert.IsTrue(canfinal);
        }

        [Test]
        public void CanEditQuoteItem()
        {
            QuoteItem qi = ControllerManager.Quote.EditQuoteItem(2, 1, 3, "4", ControllerManager.Lookup.GetById(26), ControllerManager.Lookup.GetById(29), 20);

            Assert.AreEqual(qi.Subtotal, 60);
            Assert.AreEqual(qi.DeliveryTime, "4");
            Assert.AreEqual(qi.SaleCondition.Description, "EXW");
            Assert.AreEqual(qi.DeliveryTerm.Description, "A Confirmar Por Fábrica");
        }
    }
}
