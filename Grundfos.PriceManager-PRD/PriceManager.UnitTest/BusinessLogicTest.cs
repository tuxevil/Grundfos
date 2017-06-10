using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Web.Security;
using System.Web.UI;
using MbUnit.Framework;
using Microdesk.Utility.UnitTest;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Business;
using PriceManager.Core;
using ProjectBase.Data;
using ProjectBase.Utils.Email;
using IFilter=PriceManager.Business.Filters.IFilter;

namespace PriceManager.UnitTest
{
    [TestFixture]
    public class BusinessLogicTest : DatabaseUnitTestBase
    {
        #region GridHelper Tests

        [Test]
        public void CanGridHelperMarkAllItems()
        {
            GridHelper gvh = new GridHelper();
            gvh.MarkAllItems();
            Assert.IsTrue(gvh.State.MarkedAll);
            Assert.AreEqual(0, gvh.State.Items.Count );
        }

        [Test]
        public void CanGridHelperUnMarkAllItems()
        {
            GridHelper gvh = new GridHelper();
            gvh.UnMarkAllItems();
            Assert.IsTrue(!gvh.State.MarkedAll);
            Assert.AreEqual(0, gvh.State.Items.Count);
        }

        [Test]
        public void CanGridHelperMarkSomeTimes()
        {
            GridHelper gvh = new GridHelper();
            gvh.MarkItem(1);
            gvh.MarkItem(2);
            gvh.MarkItem(3);
            Assert.IsTrue(!gvh.State.MarkedAll);
            Assert.AreEqual(3, gvh.State.Items.Count);
        }

        [Test]
        public void CanGridHelperUnMarkSomeTimes()
        {
            GridHelper gvh = new GridHelper();
            gvh.MarkAllItems();
            gvh.UnMarkItem(1);
            gvh.UnMarkItem(2);
            gvh.UnMarkItem(3);
            Assert.IsTrue(gvh.State.MarkedAll);
            Assert.AreEqual(3, gvh.State.Items.Count);
        }

        /// <summary>
        /// User marks all items, then unmark 3 items and then mark 1 item back.
        /// Finally unmarks all items, and mark 3 items.
        /// </summary>
        [Test]
        public void CanGridHelperMarkComplex()
        {
            GridHelper gvh = new GridHelper();
            gvh.MarkAllItems();
            gvh.UnMarkItem(1);
            gvh.UnMarkItem(2);
            gvh.UnMarkItem(3);
            gvh.MarkItem(1);
            Assert.IsTrue(gvh.State.MarkedAll);
            Assert.AreEqual(2, gvh.State.Items.Count);

            gvh.UnMarkAllItems();
            Assert.IsTrue(!gvh.State.MarkedAll);
            Assert.AreEqual(0, gvh.State.Items.Count);

            gvh.MarkItem(1);
            gvh.MarkItem(2);
            gvh.MarkItem(3);
            Assert.IsTrue(!gvh.State.MarkedAll);
            Assert.AreEqual(3, gvh.State.Items.Count);
        }

        [RowTest]
        [Row(10, 40)]
        [Row(25, 40, ExpectedException = typeof(Exception))]
        public void CanGridHelperBeSerialized(int pageSize, int pageNumber)
        {
            // Create a new GridHelper all items markeds expect 100.
            GridHelper gvh = new GridHelper();
            gvh.MarkAllItems();
            for (int i = 0; i < 100;i++ )
                gvh.UnMarkItem(i);

            gvh.PageNumber = pageNumber;
            gvh.PageSize = pageSize;

            // Emulate Serialization of ViewState
            LosFormatter los = new LosFormatter();
            StringWriter sw = new StringWriter();
            los.Serialize(sw, gvh);
            string resultSt = sw.GetStringBuilder().ToString();
            int size = resultSt.Length;

            //TODO: Size could be much less if we implemented this article:
            //TODO: http://weblogs.asp.net/vga/archive/2004/05/11/DontLetTheBinaryFormatterGetAtIt.aspx
            Console.WriteLine(size);

            // Emulate Deserialization of ViewState
            gvh = los.Deserialize(resultSt) as GridHelper;

            // Validate the information is valid after Deserialize
            Assert.IsNotNull(gvh, "GridHelper is null");
            Assert.IsTrue(gvh.State.MarkedAll, "GridHelper is not marked all");
            Assert.AreEqual(100, gvh.State.Items.Count, "GridHelper does not contains 100 items as expected");
            Assert.AreEqual(pageSize, gvh.PageSize, "GridHelper Page Size is invalid.");
            Assert.AreEqual(pageNumber, gvh.PageNumber, "GridHelper Page Number is invalid.");
        }

        #endregion

        #region Search Test

        [Test]
        public void Search()
        {
            int count;
            GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
            IList<ProductListView> plv = ControllerManager.PriceBase.GetProductList("", null, null, null, null, null, out count, null, null, null, gs, PriceBaseStatus.Verified, ProductStatus.Active, false, null, null, null, null, null, null, null);
            Assert.AreEqual(88, count);
        }

        #endregion

        //#region Category Tests

        //[Test]
        //public void AddFamilyToCategory()
        //{
        //    Family f = new Family();
        //    f.Name = "prueba";
        //    f.Parent = null;
        //    f.Description = "ninguna";

        //    GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, f, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
        //    Assert.AreEqual(53, f.Products.Count);
        //}

        //[Test]
        //public void RemoveFamilyFromCategory()
        //{
        //    Family f = new Family();
        //    f.Name = "prueba";
        //    f.Parent = null;
        //    f.Description = "ninguna";

        //    GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, null, "P.Code", "ASC", true, new List<int>(), null, f, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
        //    ControllerManager.PriceBase.RemoveFromCategory("", null, null, null, Frequency.Hz60, "P.Code", "ASC", true, new List<int>(), null, f, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
        //    Assert.AreEqual(53, f.Products.Count);
        //}

        //[Test]
        //public void CanListSearch()
        //{
        //    Family f = new Family();
        //    f.Name = "prueba";
        //    f.Parent = null;
        //    f.Description = "ninguna";
        //    GridState gs = new GridState(null, 0, 0, "Name", false, false, DateTime.Now, null);
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, f, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
        //    int records;
        //    ControllerManager.CategoryBase.ListSearch("prueba", typeof(Family), null, gs, out records);
            
        //    Assert.AreEqual(1, records);

        //    CatalogPage l = new CatalogPage();
        //    l.Name = "pepe";
        //    l.Parent = null;
        //    l.Description = "ninguna";
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, l, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);

        //    ControllerManager.CategoryBase.ListSearch("pepe", typeof(CatalogPage), null, gs, out records);

        //    Assert.AreEqual(1, records);

        //    CatalogPage parent = new CatalogPage();
        //    parent.Name = "papá";
        //    parent.Parent = null;
        //    parent.Description = "luke i´m your father";
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, parent, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);

        //    l = new CatalogPage();
        //    l.Name = "pipo";
        //    l.Parent = parent;
        //    l.Description = "ninguna";
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, l, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);

        //    ControllerManager.CategoryBase.ListSearch("", typeof(CatalogPage), parent, gs, out records);

        //    Assert.AreEqual(1, records);

        //    ControllerManager.CategoryBase.ListSearch("", null, parent, gs, out records);
        //    Assert.AreEqual(1, records);

        //    ControllerManager.CategoryBase.ListSearch("pipo", null, null, gs, out records);
        //    Assert.AreEqual(1, records);

        //    ProductType pt = new ProductType();
        //    pt.Name = "prodtype";
        //    pt.Parent = null;
        //    pt.Description = "njk";
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, pt, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
        //    ControllerManager.CategoryBase.ListSearch("njk", typeof(ProductType), null, gs, out records);
        //    Assert.AreEqual(1, records);

        //    ControllerManager.CategoryBase.ListSearch("", typeof(ProductType), null, gs, out records);
        //    Assert.AreEqual(2, records);

        //    Application c = new Application();
        //    c.Name = "cate";
        //    c.Parent = null;
        //    c.Description = "categ";
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, c, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
        //    ControllerManager.CategoryBase.ListSearch("ca", null, null, gs, out records);
        //    Assert.AreEqual(1, records);

        //    ControllerManager.CategoryBase.ListSearch("", typeof(Application), null, gs, out records);
        //    Assert.AreEqual(2, records);
        //}

        //[Test]
        //public void TestType()
        //{
        //    ICriteria crit = ControllerManager.CurrentSession.CreateCriteria(typeof(CategoryBase));
        //    crit.AddOrder(new Order("Type", true));
        //    IList lst = crit.List();
        //}

        //[Test]
        //public void CanEraseCategory()
        //{
        //    CatalogPage l = new CatalogPage();
        //    l.Name = "prueba";
        //    l.Parent = null;
        //    l.Description = "ninguna";

        //    GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, null, "P.Code", "ASC", true, new List<int>(), null, l, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);

        //    bool erased = ControllerManager.CategoryBase.EraseCategory(l.ID);

        //    Assert.IsTrue(erased);

        //    CatalogPage parent = new CatalogPage();
        //    parent.Name = "papá";
        //    parent.Parent = null;
        //    parent.Description = "luke i´m your father";
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, parent, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);

        //    l = new CatalogPage();
        //    l.Name = "pipo";
        //    l.Parent = parent;
        //    l.Description = "ninguna";
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, l, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);

        //    erased = ControllerManager.CategoryBase.EraseCategory(parent.ID);
        //    Assert.IsFalse(erased);
        //}

        //[Test]
        //public void CanCreateCategory()
        //{ 
        //    CatalogPage parent = new CatalogPage();
        //    parent.Name = "papá";
        //    parent.Parent = null;
        //    parent.Description = "luke i´m your father";
        //    ControllerManager.PriceBase.AddToCategory("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, parent, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);

        //    CategoryBase cb = ControllerManager.CategoryBase.CreateCategory(typeof(CatalogPage), parent, "Create", "cancreate","","","");
        //    cb = ControllerManager.CategoryBase.GetById(cb.ID);

        //    Assert.AreEqual(cb.Parent.Name, parent.Name);
        //    Assert.AreEqual(cb.Name, "Create");
        //    Assert.AreEqual(cb.Description, "cancreate");
        //}

        //[Test]
        //public void CanModifyCategory()
        //{
        //    CategoryBase cb = ControllerManager.CategoryBase.CreateCategory(typeof(CatalogPage), null, "Create", "cancreate", "", "", "");
        //    CategoryBase modCb = ControllerManager.CategoryBase.ModifyCategory(cb.ID, null, "Modify", "canModify", "", "", "");

        //    Assert.AreEqual(cb.Name, "Modify");
        //    Assert.AreEqual(cb.Description, "canModify");
        //    //Assert.AreEqual(cb.Type, typeof(CatalogPage));

        //}
        //#endregion

        #region Notes Test
        [Test]
        public void CanCreateNote()
        {
            Note n = ControllerManager.Note.Create(typeof(Product), 1, "SUBJECT", "DESCRIPTION");
            n = ControllerManager.Note.GetById(n.ID);

            Assert.AreEqual(n.TypeName, typeof(Product).FullName);
            Assert.AreEqual(n.TypeIdentifier, 1);
            Assert.AreEqual(n.Subject, "SUBJECT");
            Assert.AreEqual(n.Description, "DESCRIPTION");
        }

        [Test]
        public void CanListNotes()
        {
            for(int i = 1; i<=20; i++)
                ControllerManager.Note.Create(typeof(Product), i, "SUBJECT", "DESCRIPTION");

            for (int i = 1; i <= 20; i++)
                ControllerManager.Note.Create(typeof(Family), i, "SUBJECT", "DESCRIPTION");

            Assert.AreEqual(20, ControllerManager.Note.ListByType(typeof(Product)).Count);
            Assert.AreEqual(1, ControllerManager.Note.ListByType(typeof(Family),4).Count);
        }
        #endregion

        #region Selection Tests

        [Test]
        public void AddToSelection()
        {
            Selection s = new Selection();
            s.Description = "prueba";
            s.User = new Guid();

            GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
            ControllerManager.PriceBase.AddToSelection("", null, null, null, Frequency.Hz50, "P.Code", "ASC", true, new List<int>(), null, s, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
            Assert.AreEqual(53, s.Products.Count);
        }

        [Test]
        public void RemoveFromSelection()
        {
            Selection s = new Selection();
            s.Description = "prueba";
            s.User = new Guid();

            GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
            ControllerManager.PriceBase.AddToSelection("", null, null, null, null, "P.Code", "ASC", true, new List<int>(), null, s, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
            ControllerManager.PriceBase.RemoveFromSelection("", null, null, s, Frequency.Hz60, "P.Code", "ASC", true, new List<int>(), null, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, null, null, null, null);
            Assert.AreEqual(53, s.Products.Count);
        }

        #endregion

        #region Change PriceBase Status Tests

        public void ChangePriceBaseStatus()
        {
            int count;

            GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
            //ControllerManager.PriceBase.ChangePriceBaseStatus("", null, null, null, new Hz50Frequency(), "P.Code", "ASC", true, new List<int>(), null, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, PriceBaseStatus.NotVerified);
            IList<ProductListView> plv = ControllerManager.PriceBase.GetProductList("", null, null, null, Frequency.All, null, out count, null, null, null, gs, PriceBaseStatus.NotVerified, ProductStatus.Active, false, null, null, null, null, null, null, null);
            Assert.AreEqual(56, count);
        }
        
        #endregion

        #region Change Product Status Tests
       
        public void ChangeProductStatus()
        {
            int count;

            GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
            //ControllerManager.PriceBase.ChangeProductStatus("", null, null, null, new Hz50Frequency(), "P.Code", "ASC", true, new List<int>(), null, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, ProductStatus.Disable);
            IList<ProductListView> plv = ControllerManager.PriceBase.GetProductList("", null, null, null, Frequency.All, null, out count, null, null, null, gs, PriceBaseStatus.Verified, ProductStatus.Disable, false, null, null, null, null, null, null, null);
            Assert.AreEqual(56, count);
        }

        #endregion

        #region Update Prices

        [Test]
        public void ChangePrices()
        {
            //GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now);

            //List<int> list = ControllerManager.PriceBase.UpdateProductPrices("", null, null, null, new Hz60Frequency(), null, true, gs.Items, DateTime.Now, new Guid(), true, 100, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active);
            //Assert.AreEqual(44, list.Count);
        }

        #endregion

        #region Price List Tests
        //[Test]
        //public void CanGetPriceLists()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(2));

        //    GridState gs = new GridState(null, 10, 1, "Name", false, false, DateTime.Now, null);
        //    int totalRecords;
        //    IList<PriceList> lst = ControllerManager.PriceList.GetPriceLists("test1", Frequency.All, null, null, Incoterm.DES, null, gs, ControllerManager.PriceGroup.GetById(2), out totalRecords, null);

        //    Assert.AreEqual(1, totalRecords);
        //}

        //[Test]
        //public void CanCreatePriceList()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(2));
        //    pl = ControllerManager.PriceList.GetById(pl.ID);

        //    Assert.AreEqual(pl.Name, "test1");
        //    Assert.AreEqual(pl.Description, "testdesc");
        //    Assert.IsNull(pl.Type);
        //    Assert.AreEqual(pl.SaleCondition, Incoterm.DES);
        //    Assert.AreEqual(pl.PriceListStatus, PriceListStatus.Active);
        //    Assert.AreEqual(pl.Frecuency, Frequency.All);
        //    Assert.AreEqual(pl.PriceGroup, ControllerManager.PriceGroup.GetById(2));
        //}

        //[Test]
        //public void CanModifyPriceList()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(2));

        //    ControllerManager.PriceList.Modify(pl.ID, "modifTest", "modifdesc", null, Incoterm.EXW, PriceListStatus.Disable, Frequency.Hz50);
        //    pl = ControllerManager.PriceList.GetById(pl.ID);

        //    Assert.AreEqual(pl.Name, "modifTest");
        //    Assert.AreEqual(pl.Description, "modifdesc");
        //    Assert.IsNull(pl.Type);
        //    Assert.AreEqual(pl.SaleCondition, Incoterm.EXW);
        //    Assert.AreEqual(pl.PriceListStatus, PriceListStatus.Disable);
        //    Assert.AreEqual(pl.Frecuency, Frequency.Hz50);
        //    Assert.AreEqual(pl.PriceGroup, ControllerManager.PriceGroup.GetById(2));
        //}
        //[Test]
        //public void CanErasePriceList()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(2));
        //    ControllerManager.PriceList.EraseAndActivate(pl.ID);
        //    Assert.AreEqual(ControllerManager.PriceList.GetById(pl.ID).PriceListStatus, PriceListStatus.Deleted);
        //}
        //[Test]
        //public void CanPublishList()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("name", "description", null, Incoterm.EXW, PriceListStatus.Active, Frequency.Hz50, new PriceGroup(1));

        //    GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
        //    ControllerManager.PriceBase.AddToPriceGroup(gs, new List<IFilter>(), "1");

        //    foreach(PriceAttribute pa in ControllerManager.PriceAttribute.GetAll())
        //    {
        //        WorkListItem wli = new WorkListItem();
        //        wli.PriceList = pl;
        //        wli.WorkListItemStatus = WorkListItemStatus.Added;
        //        wli.Price = 10;
        //        wli.PriceCurrency = ControllerManager.Currency.GetBaseCurrency();
        //        wli.PriceAttribute = pa;
        //        pl.Items.Add(wli);

        //        WorkListItemHistory wlih = new WorkListItemHistory();
        //        wlih.PriceList = pl;
        //        wlih.WorkListItemStatus = WorkListItemStatus.Added;
        //        wlih.Price = 10;
        //        wlih.PriceCurrency = ControllerManager.Currency.GetBaseCurrency();
        //        wlih.PriceAttribute = pa;
        //        ControllerManager.CurrentSession.Save(wlih);
        //    }

        //    // We need to force Flush before trying to refresh PL for View to update correctly.
        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(pl);

        //    foreach (WorkListItem wli in pl.Items)
        //    {
        //        wli.WorkListItemStatus = WorkListItemStatus.Approved;
        //    }

        //    // We need to force Flush before trying to refresh PL for View to update correctly.
        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(pl);
        //    ControllerManager.CurrentSession.Refresh(pl.CurrentState);

        //    PublishList publ = ControllerManager.PriceList.Publish(pl.ID, DateTime.Today);
        //    Assert.IsNotNull(publ);
        //    Assert.AreEqual(pl.Items.Count, publ.PublishItems.Count);

        //    foreach (WorkListItem item in pl.Items)
        //        Assert.AreEqual(WorkListItemStatus.Published, item.WorkListItemStatus);
        //}

        //[Test]
        //public void CanStatusChangeToApprovedOnPriceList() 
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("name", "description", null, Incoterm.EXW, PriceListStatus.Active, Frequency.Hz50, new PriceGroup(1));

        //    GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
        //    ControllerManager.PriceBase.AddToPriceGroup(gs, new List<IFilter>(), "1");

        //    foreach (PriceAttribute pa in ControllerManager.PriceAttribute.GetAll())
        //    {
        //        WorkListItem wli = new WorkListItem();
        //        wli.PriceList = pl;
        //        wli.WorkListItemStatus = WorkListItemStatus.Approved;
        //        wli.Price = 10;
        //        wli.PriceCurrency = ControllerManager.Currency.GetBaseCurrency();
        //        wli.PriceAttribute = pa;
        //        pl.Items.Add(wli);
        //    }

        //    // We need to force Flush before trying to refresh PL for View to update correctly.
        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(pl);
        //    ControllerManager.CurrentSession.Refresh(pl.CurrentState);
        //    Assert.AreEqual(PublishListStatus.New, pl.CurrentState.Status);
        //}

        //public void CanStatusChangeToApprovedOnPriceList2()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("name", "description", null, Incoterm.EXW, PriceListStatus.Active, Frequency.Hz50, new PriceGroup(1));

        //    GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
        //    ControllerManager.PriceBase.AddToPriceGroup(gs, new List<IFilter>(), "1");

        //    foreach (PriceAttribute pa in ControllerManager.PriceAttribute.GetAll())
        //    {
        //        WorkListItem wli = new WorkListItem();
        //        wli.PriceList = pl;
        //        wli.WorkListItemStatus = WorkListItemStatus.Published;
        //        wli.Price = 10;
        //        wli.PriceCurrency = ControllerManager.Currency.GetBaseCurrency();
        //        wli.PriceAttribute = pa;
        //        pl.Items.Add(wli);
        //    }

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(pl);
        //    ControllerManager.CurrentSession.Refresh(pl.CurrentState);
        //    Assert.AreEqual(PublishListStatus.Approved, pl.CurrentState.Status);
        //}

        //public void CanStatusChangeToApprovedOnPriceList3()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("name", "description", null, Incoterm.EXW, PriceListStatus.Active, Frequency.Hz50, new PriceGroup(1));

        //    GridState gs = new GridState(null, 0, 0, "P.Code", false, false, DateTime.Now, null);
        //    ControllerManager.PriceBase.AddToPriceGroup(gs, new List<IFilter>(), "1");

        //    foreach (PriceAttribute pa in ControllerManager.PriceAttribute.GetAll())
        //    {
        //        WorkListItem wli = new WorkListItem();
        //        wli.PriceList = pl;
        //        wli.WorkListItemStatus = WorkListItemStatus.Modified;
        //        wli.Price = 10;
        //        wli.PriceCurrency = ControllerManager.Currency.GetBaseCurrency();
        //        wli.PriceAttribute = pa;
        //        pl.Items.Add(wli);
        //    }

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(pl);
        //    ControllerManager.CurrentSession.Refresh(pl.CurrentState);
        //    Assert.AreEqual(PublishListStatus.Modified, pl.CurrentState.Status);
        //}

        //[Test]
        //public void CanEraseFromSelection()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("name", "description", "color", Incoterm.EXW, PriceListStatus.Active, Frequency.Hz50, new PriceGroup(1));
        //    List<int> items = new List<int>();
        //    items.Add(1);
        //    items.Add(2);
        //    GridState gs = new GridState(items, 0, 0, "P.Code", false, false, DateTime.Now);
        //    ControllerManager.PriceBase.AddToPriceGroup(gs, new List<IFilter>(), "1");

        //    foreach (PriceAttribute pa in ControllerManager.PriceAttribute.GetAll())
        //    {
        //        WorkListItem wli = new WorkListItem();
        //        wli.PriceList = pl;
        //        wli.WorkListItemStatus = WorkListItemStatus.Approved;
        //        wli.Price = 10;
        //        wli.PriceCurrency = ControllerManager.Currency.GetBaseCurrency();
        //        wli.PriceAttribute = pa;
        //        pl.Items.Add(wli);
        //    }

        //    // We need to force Flush before trying to refresh PL for View to update correctly.
        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(pl);
        //    ControllerManager.CurrentSession.Refresh(pl.CurrentState);

        //    ControllerManager.PriceList.EraseFromPriceList(gs, new List<IFilter>());
        //    Assert.AreEqual(
        //}

        //[Test]
        //public void CanAddToPriceList()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("name", "description", "color", Incoterm.EXW, PriceListStatus.Active, Frequency.Hz50, new PriceGroup(1));
        //    List<int> items = new List<int>();
        //    items.Add(1);
        //    GridState gs = new GridState(items, 0, 0, "P.Code", false, false, DateTime.Now);

        //    List<IFilter> filter = new List<IFilter>();
        //    //(ucFilters.FindFilter(typeof(PriceList), "ID") as FixedFilter).Values = 1;
        //    filter.Add(pg);
        //    ControllerManager.PriceBase.AddToPriceGroup(gs, new List<IFilter>(), "1");

        //    foreach (PriceAttribute pa in ControllerManager.PriceAttribute.GetAll())
        //    {
        //        WorkListItem wli = new WorkListItem();
        //        wli.PriceList = pl;
        //        wli.WorkListItemStatus = WorkListItemStatus.Approved;
        //        wli.Price = 10;
        //        wli.PriceCurrency = ControllerManager.Currency.GetBaseCurrency();
        //        wli.PriceAttribute = pa;
        //        pl.Items.Add(wli);
        //    }

        //    PriceList pl2 = ControllerManager.PriceList.Add(gs, filter, "", 1);

        //    Assert.AreEqual(2, pl2.Items.Count);
        //}

        #endregion

        #region Publish List test

        //[Test]
        //public void CanGetPublishLists()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(2));

        //    GridState gs = new GridState(null, 10, 1, "Name", false, false, DateTime.Now, null);
        //    int totalRecords;
        //    IList<PriceList> lst = ControllerManager.PriceList.GetPriceLists("test1", Frequency.All, null, null, Incoterm.DES, null, gs, ControllerManager.PriceGroup.GetById(2), out totalRecords, null);

        //    Assert.AreEqual(1, totalRecords);

        //    PublishList pbl = ControllerManager.PublishList.Create(pl, DateTime.Today, true);

        //    IList<PublishList> lst2 = ControllerManager.PublishList.GetAll();

        //    Assert.AreEqual(1, lst2.Count);
        //}

        #endregion

        #region Distributor Tests
        //[Test]
        //public void CanCreateDistributor()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(2));

        //    Distributor d = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl, "Code",
        //                                                         new Country(1), 20, PaymentTerm.condition1, null, null);

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(d);

        //    Assert.AreEqual(d.Name, "Distribuidor");
        //    Assert.AreEqual(d.Telephone, "Phone");
        //    Assert.AreEqual(d.Email, "Email");
        //    Assert.AreEqual(d.Contact, "Contact");
        //    Assert.AreEqual(d.PriceList.ID, pl.ID);
        //    Assert.AreEqual(d.Code, "Code");
        //    Assert.AreEqual(d.Country.ID, new Country(1).ID);
        //    Assert.AreEqual(d.Discount, 20);
        //}

        //[Test]
        //public void CanUpdateDistributor()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(2));

        //    Distributor d = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl, "Code",
        //                                                         new Country(1), 20, PaymentTerm.condition1, null, null);

        //    d = ControllerManager.Distributor.Update(d.ID, "Description1", "Contact1", pl, new Country(2), 10, PaymentTerm.condition1, null, null);

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(d);

        //    Assert.AreEqual(d.Description, "Description1");
        //    Assert.AreEqual(d.Contact, "Contact1");
        //    Assert.AreEqual(d.PriceList.ID, pl.ID);
        //    Assert.AreEqual(d.Country.ID, new Country(2).ID);
        //    Assert.AreEqual(d.Discount, 10);
        //}

        //[Test]
        //public void CanDisablePriceList()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(2));

        //    Distributor d = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl, "Code",
        //                                                         new Country(1), 20, PaymentTerm.condition1, null, null);

        //    ControllerManager.Distributor.Disable(d.ID);

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(d);

        //    Assert.AreEqual(d.DistributorStatus, DistributorStatus.Disable);
        //}

        //[Test]
        //public void CanAssignNewDiscount()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(4));

        //    Distributor d = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl, "AA",
        //                                                         new Country(1), 20, PaymentTerm.condition1, null, null);

        //    Distributor d2 = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl, "AA",
        //                                             new Country(1), 30, PaymentTerm.condition1, null, null);

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(d2.PriceList);
        //    ControllerManager.CurrentSession.Refresh(d2.PriceList.PriceGroup);

        //    decimal expectedPriceListDiscount = 30;
        //    decimal expectedPriceGroupDiscount = Convert.ToDecimal(50);
        //    decimal expectedProviderDiscount = Convert.ToDecimal(50);

        //    Assert.AreEqual(expectedPriceListDiscount, d2.PriceList.Discount);
        //    Assert.AreEqual(expectedPriceGroupDiscount, d2.PriceList.PriceGroup.Discount);

        //    foreach (Provider p in ControllerManager.Provider.GetAll())
        //        Assert.AreEqual(p.Discount.ToString("#0.###"), expectedProviderDiscount.ToString());
        //}

        //[Test]
        //public void CanAssignNewDiscountWithDisabledItems()
        //{
        //    PriceList pl = ControllerManager.PriceList.Create("test1", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(4));
        //    PriceList pl2 = ControllerManager.PriceList.Create("test2", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(4));

        //    PriceList pl3 = ControllerManager.PriceList.Create("test3", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(5));
        //    PriceList pl4 = ControllerManager.PriceList.Create("test4", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(5));

        //    PriceList pl5 = ControllerManager.PriceList.Create("test5", "testdesc", null, Incoterm.DES, PriceListStatus.Disable, Frequency.All, ControllerManager.PriceGroup.GetById(5));
        //    PriceList pl6 = ControllerManager.PriceList.Create("test6", "testdesc", null, Incoterm.DES, PriceListStatus.Active, Frequency.All, ControllerManager.PriceGroup.GetById(5));

        //    Distributor d = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl, "AA",
        //                                                         new Country(1), 20, PaymentTerm.condition1, null, null);

        //    Distributor d2 = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl, "AA",
        //                                             new Country(1), 30, PaymentTerm.condition1, null, null);

        //    Distributor d3 = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl2, "AA",
        //                                             new Country(1), 40, PaymentTerm.condition1, null, null);

        //    Distributor d4 = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl2, "AA",
        //                                 new Country(1), 50, PaymentTerm.condition1, null, null);

        //    Distributor d5 = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl3, "AA",
        //                     new Country(1), 10, PaymentTerm.condition1, null, null);

        //    Distributor d6 = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl4, "AA",
        //         new Country(1), 20, PaymentTerm.condition1, null, null);

        //    decimal expectedPriceListDiscount = 30;
        //    decimal expectedPriceGroup1Discount = 50;
        //    decimal expectedPriceGroup2Discount = Convert.ToDecimal(40);
        //    decimal expectedProviderDiscount = Convert.ToDecimal(50);

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(d2.PriceList);
        //    ControllerManager.CurrentSession.Refresh(d2.PriceList.PriceGroup);
        //    ControllerManager.CurrentSession.Refresh(d5.PriceList.PriceGroup);

        //    Assert.AreEqual(expectedPriceListDiscount, d2.PriceList.Discount);
        //    Assert.AreEqual(expectedPriceGroup1Discount, d2.PriceList.PriceGroup.Discount);
        //    Assert.AreEqual(expectedPriceGroup2Discount, d5.PriceList.PriceGroup.Discount);

        //    foreach (Provider p in ControllerManager.Provider.GetAll())
        //        Assert.AreEqual(p.Discount, expectedProviderDiscount);

        //    // Add a distributor to inactive list, should not change.
        //    Distributor d7 = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl5, "AA",
        //                     new Country(1), 20, PaymentTerm.condition1, null, null);

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(d2.PriceList);
        //    ControllerManager.CurrentSession.Refresh(d2.PriceList.PriceGroup);
        //    ControllerManager.CurrentSession.Refresh(d5.PriceList.PriceGroup);

        //    Assert.AreEqual(expectedPriceListDiscount, d2.PriceList.Discount);
        //    Assert.AreEqual(expectedPriceGroup1Discount, d2.PriceList.PriceGroup.Discount);
        //    Assert.AreEqual(expectedPriceGroup2Discount, d5.PriceList.PriceGroup.Discount);

        //    foreach (Provider p in ControllerManager.Provider.GetAll())
        //        Assert.AreEqual(p.Discount, expectedProviderDiscount);

        //    // Add a distributor to active list and disable it, should not change.
        //    Distributor d8 = ControllerManager.Distributor.Create("Distribuidor", "Description", "Phone", "Email", "Contact", pl6, "AA",
        //         new Country(1), 40, PaymentTerm.condition1, null, null);

        //    ControllerManager.CurrentSession.Flush();

        //    ControllerManager.Distributor.Disable(d8.ID);

        //    ControllerManager.CurrentSession.Flush();
        //    ControllerManager.CurrentSession.Refresh(d2.PriceList);
        //    ControllerManager.CurrentSession.Refresh(d2.PriceList.PriceGroup);
        //    ControllerManager.CurrentSession.Refresh(d5.PriceList.PriceGroup);

        //    Assert.AreEqual(expectedPriceListDiscount, d2.PriceList.Discount);
        //    Assert.AreEqual(expectedPriceGroup1Discount, d2.PriceList.PriceGroup.Discount);
        //    Assert.AreEqual(expectedPriceGroup2Discount, d5.PriceList.PriceGroup.Discount);

        //    foreach (Provider p in ControllerManager.Provider.GetAll())
        //        Assert.AreEqual(p.Discount, expectedProviderDiscount);
        //}
        #endregion

        #region Lookup Test
        [Test]
        public void CanCreateLookup()
        {
            string description = "Description1";
            Lookup l = ControllerManager.Lookup.Create(LookupType.DistributorType, description);

            Assert.IsNotNull(l);
            Assert.GreaterThan(l.ID, 0);
            Assert.AreEqual(l.Description, description);
        }

        [Test]
        public void CanSearchLookup()
        {
            string description = "Description1";
            ControllerManager.Lookup.Create(LookupType.DistributorType, description);
            ControllerManager.Lookup.Create(LookupType.DistributorType, description);
            ControllerManager.Lookup.Create(LookupType.DistributorType, description);
            ControllerManager.Lookup.Create(LookupType.PriceListType, description);
            ControllerManager.Lookup.Create(LookupType.PriceListType, description);
            ControllerManager.Lookup.Create(LookupType.PriceListType, description);
            ControllerManager.Lookup.Create(LookupType.PriceListType, description);
            ControllerManager.Lookup.Create(LookupType.PriceListType, description);

            IList<Lookup> lst = ControllerManager.Lookup.List(LookupType.DistributorType);
            Assert.IsNotNull(lst);
            Assert.AreEqual(lst.Count, 3);

            lst = ControllerManager.Lookup.List(LookupType.PriceListType);
            Assert.IsNotNull(lst);
            Assert.AreEqual(lst.Count, 5);
        }
        #endregion


        #region Standard DB Setup Methods

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
            log4net.Config.XmlConfigurator.Configure();
            DatabaseSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseTearDown();

            // Flush the session each test
            ControllerManager.CurrentSession.Flush();
        }

        public void GetMyTestDataXMLFile()
        {
            SaveTestDatabase();
        }

        #endregion
    }
}
