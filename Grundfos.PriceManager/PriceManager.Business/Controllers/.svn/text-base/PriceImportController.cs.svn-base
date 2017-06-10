using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FileHelpers;
using FileHelpers.RunTime;
using iTextSharp.text.pdf;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;
using ProjectBase.Utils.FileImport;
using System.Web;
using Iesi.Collections.Generic;
using ProjectBase.OfflineProcessor;
using ProjectBase.OfflineProcessor.Remoting;
using System.Threading;
using System.Reflection;
using NybbleMembership;
using ProjectBase.Utils.Email;
using PriceManager.Core.State;

namespace PriceManager.Business
{
    public class PriceImportController : AbstractNHibernateDao<PriceImport, Guid>
    {
        public PriceImportController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        #region Search

        public IList<PriceImport> Search(string info, DateTime? fromDate, out int totalRecords, GridState gridState, DateTime? toDate, ImportStatus? status)
        {
            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;

            ICriteria crit = SearchCriteria(info, fromDate, toDate, status);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("Number")));

           
            totalRecords =crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<PriceImport>();

            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = SearchCriteria(info, fromDate, toDate, status);

            crit.SetMaxResults(pageSize);
            if (pageNumber == 1)
                crit.SetFirstResult(0);
            else
                crit.SetFirstResult((pageNumber - 1) * pageSize);

            string[] sort = gridState.SortField.Split('.');
            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.GetCriteriaByPath(sort[0]);
                if (critSort == null)
                    critSort = crit.CreateCriteria(sort[0]);
                sortField = sort[1];
            }
            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            return crit.List<PriceImport>();

        }

        public ICriteria SearchCriteria(string info, DateTime? fromDate, DateTime? toDate, ImportStatus? status)
        {
            ICriteria crit = GetCriteria();

            if (!string.IsNullOrEmpty(info))
            {
                Disjunction d = new Disjunction();
                d.Add(Restrictions.InsensitiveLike("Description", info, MatchMode.Anywhere));
                d.Add(Restrictions.InsensitiveLike("File", info, MatchMode.Anywhere));
                crit.Add(d);
            }

            if (fromDate != null)
                crit.Add(Expression.Ge("DateImported", fromDate));

            if (toDate != null)
                crit.Add(Expression.Le("DateImported", toDate));

            if (status != null)
                crit.Add(Expression.Eq("ImportStatus", status));

            return crit;
        }
       
        #endregion

        #region Import Creation & Upload

        #region Internal PriceBaseFound Class
        internal class PriceBaseFound
        {
            public string Code;
            public string CodeProvider;
            public int ProviderId;
            public int PriceBaseId;

            public PriceBaseFound(string code, string codeProvider, int providerId, int priceBaseId)
            {
                this.Code = code;
                this.CodeProvider = codeProvider;
                this.ProviderId = providerId;
                this.PriceBaseId = priceBaseId;
            }
        }

        #endregion

        #region Private properties

        private List<Provider> provlist;
        private List<CategoryBase> catlist;
        private List<Currency> currlist;
        private List<PriceBase> pblist;

        #endregion

        /// <summary>
        /// Create  a new PriceImport object based on the input file.
        /// </summary>
        /// <param name="filename">File with the CSV to import</param>
        /// <param name="description">Description for the new import process</param>
        /// <param name="haveHeader">Indicates if the file has header line</param>
        /// <param name="separationChar">Indicates the separation character in the CSV file</param>
        /// <param name="path">Indicates the path of the CSV file</param>
        /// <returns></returns>
        public PriceImport Create(string newfilename, string description, bool haveHeader, char separationChar, string path, string originalfilename)
        {
            Utils.GetLogger().Debug(string.Format("[[Product Import]] Start {0}", description));

            DelimitedClassBuilder cb = CreateClassBuilder(separationChar, haveHeader);
            FileHelperEngine engine = new FileHelperEngine(cb.CreateRecordClass());
            object[] items = engine.ReadFile(path + newfilename);

            if (items.Length <= 0)
                throw new EmptyImportationFileException("No se encontraron registros para ingresar.");

            Utils.GetLogger().Debug(string.Format("[[Product Import]] Starting to get database data {0}", description));

            // TODO: We should only get the necessary fields for each object and not the whole object.
            provlist = ControllerManager.Provider.GetActives() as List<Provider>;
            catlist = ControllerManager.CategoryBase.GetAll() as List<CategoryBase>;
            currlist = ControllerManager.Currency.GetAll() as List<Currency>;

            // Get Needed PriceBase Data
            IQuery q = NHibernateSession.CreateQuery("select lower(trim(P.Code)), lower(trim(PB.ProviderCode)), PB.Provider.ID, PB.ID FROM PriceBase PB JOIN PB.Product P");
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PriceBaseFound).GetConstructors()[0]));
            List<PriceBaseFound> lst = q.List<PriceBaseFound>() as List<PriceBaseFound>;

            // Clear the memory
            NHibernateSession.Flush();
            NHibernateSession.Clear();

            Utils.GetLogger().Info(string.Format("[[Product Import]] Ready {0}", description));

            List<PriceImportLog> lstDuplicates = new List<PriceImportLog>(items.Length);

            // Start the transaction
            this.BeginTransaction();

            // Create the PriceImport item
            PriceImport pi = new PriceImport();
            pi.ImportStatus = ImportStatus.Invalid;
            pi.File = originalfilename;
            pi.Description = description;
            pi.DateImported = DateTime.Now;
            pi.HaveHeader = haveHeader;
            pi.SeparationChar = separationChar;
            Save(pi);

            bool error = false;
            bool atLeastOneValid = false;

            for (int i = 0; i < items.Length; i++) 
            {
                string originalline = "";

                // Create the item
                PriceImportLog lr = new PriceImportLog();
                lr.CodGrundfos = GetValue("CodGrundfos", items[i]).ToString();
                lr.CodProvider = GetValue("CodProv", items[i]).ToString();
                lr.Model = GetValue("Modelo", items[i]).ToString();
                lr.Description = GetValue("Descripcion", items[i]).ToString();
                lr.Provider = GetValue("Proveedor", items[i]).ToString();
                lr.Frequency = GetValue("Frecuencia", items[i]).ToString();
                lr.TP = (decimal?)GetValue("TP", items[i]);
                lr.TPCurrency = GetValue("MonedaTP", items[i]).ToString();
                lr.GRP = (decimal?)GetValue("GRP", items[i]);
                lr.GRPCurrency = GetValue("MonedaGRP", items[i]).ToString();
                lr.PL = (decimal?)GetValue("PL", items[i]);
                lr.PLCurrency = GetValue("MonedaPL", items[i]).ToString();
                lr.Cat1 = GetValue("Familia", items[i]).ToString();
                lr.Cat2 = GetValue("Tipo", items[i]).ToString();
                lr.Cat3 = GetValue("Linea", items[i]).ToString();
                lr.OriginalLine = originalline;
                lr.FileIndex = i;

                // Check if at least the required fields are completed, otherwise ignore.
                if (string.IsNullOrEmpty(lr.Provider) || (string.IsNullOrEmpty(lr.CodGrundfos) && string.IsNullOrEmpty(lr.CodProvider)))
                {
                    NHibernateSession.Evict(lr);
                    error = true;
                    continue;
                }

                // Check the whole item data
                CheckLogResultItem(lr);

                if (lr.CodGrundfos == string.Empty || lr.CodProvider == string.Empty)
                {
                    if (lstDuplicates.Exists(delegate(PriceImportLog record)
                                             {
                                                 if ((record.CodGrundfos != string.Empty && record.CodGrundfos == lr.CodGrundfos && record.Provider == lr.Provider) || (record.CodProvider != string.Empty && record.CodProvider == lr.CodProvider && record.Provider == lr.Provider))
                                                 {
                                                     return true;
                                                 }
                                                 return false;
                                             }))
                    {
                        SetErrorOnItem(lr, Resource.Business.GetString("DuplicatedProduct"));
                    }
                }

                lstDuplicates.Add(lr);

                if (lr.Status != PriceImportLogStatus.Error)
                {
                    string codGrundFos = lr.CodGrundfos.Trim();
                    string codProvider = lr.CodProvider.Trim();

                    Provider prov = FindInMemory(provlist, lr.Provider);
                    PriceBaseFound pb;

                    if (!string.IsNullOrEmpty(codGrundFos))
                    {
                        codGrundFos = codGrundFos.ToLower();
                        pb = lst.Find(delegate(PriceBaseFound record)
                                            {
                                                if (record.Code == codGrundFos && record.ProviderId == prov.ID)
                                                    return true;
                                                return false;
                                            });
                    }
                    else
                    {
                        codProvider = codProvider.ToLower();
                        pb = lst.Find(delegate(PriceBaseFound record)
                                        {
                                            if (record.CodeProvider == codProvider && record.ProviderId == prov.ID)
                                                return true;
                                            return false;
                                        });
                    }
                    if (pb != null)
                    {
                        lr.Status = PriceImportLogStatus.Modify;
                        lr.ParsedPriceBase = new PriceBase(pb.PriceBaseId);
                        if (string.IsNullOrEmpty(GetValue("Frecuencia", items[i]).ToString()))
                        {
                            lr.Frequency = string.Empty;
                            lr.ParsedFrequency = null;
                        }
                        if (string.IsNullOrEmpty(GetValue("MonedaTP", items[i]).ToString()))
                            lr.TPCurrency = string.Empty;
                        if (string.IsNullOrEmpty(GetValue("MonedaGRP", items[i]).ToString()))
                            lr.GRPCurrency = string.Empty;
                        if (string.IsNullOrEmpty(GetValue("MonedaPL", items[i]).ToString()))
                            lr.PLCurrency = string.Empty;
                    }
                }

                // Save the item
                lr.PriceImport = pi;
                NHibernateSession.Save(lr);

                if (lr.Status != PriceImportLogStatus.Error)
                    atLeastOneValid = true;
                else
                    error = true;
            }

            // Update the status of the PriceImport item
            if (error)
                pi.ImportStatus = (atLeastOneValid) ? ImportStatus.VerifiedSomeInvalid : ImportStatus.Invalid;
            else
                pi.ImportStatus = ImportStatus.Verified;

           // Commit Changes
            CommitChanges();

            Utils.GetLogger().Info(string.Format("[[Product Import]] Finished with Identifier {0} and status {1}", pi.ID, pi.ImportStatus));
            File.Move(@path + newfilename, @path + pi.ID + ".csv");

            return pi;
        }

        private DelimitedClassBuilder CreateClassBuilder(char separationChar, bool haveHeader)
        {
            DelimitedClassBuilder cb = new DelimitedClassBuilder("TmpPriceImport", separationChar.ToString());
            if(haveHeader)
                cb.IgnoreFirstLines = 1;
            cb.AddField("CodGrundfos", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("CodProv", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("Modelo", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("Descripcion", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("Proveedor", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("Frecuencia", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("TP");
            cb.LastField.FieldType = "Nullable < System.Decimal >";
            cb.LastField.FieldNullValue = null;
            cb.LastField.FieldOptional = true;
            cb.LastField.Converter.Kind = ConverterKind.AnyDecimal;
            cb.AddField("MonedaTP", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("GRP");
            cb.LastField.FieldType = "Nullable < System.Decimal >";
            cb.LastField.FieldNullValue = null;
            cb.LastField.FieldOptional = true;
            cb.LastField.Converter.Kind = ConverterKind.AnyDecimal;
            cb.AddField("MonedaGRP", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("PL");
            cb.LastField.FieldType = "Nullable < System.Decimal >";
            cb.LastField.FieldNullValue = null;
            cb.LastField.FieldOptional = true;
            cb.LastField.Converter.Kind = ConverterKind.AnyDecimal;
            cb.AddField("MonedaPL", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("Familia", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("Tipo", typeof(string));
            cb.LastField.FieldOptional = true;
            cb.AddField("Linea", typeof(string));
            cb.LastField.FieldOptional = true;

            cb.IgnoreEmptyLines = true;

            return cb;
            
        }

        private void CheckLogResultItem(PriceImportLog lr)
        {
            if ((string.IsNullOrEmpty(lr.CodGrundfos) || string.IsNullOrEmpty(lr.CodProvider)) &&
                string.IsNullOrEmpty(lr.Provider))
            {
                SetErrorOnItem(lr, Resource.Business.GetString("ObligatoryData"));
            }

            lr.Detail = "";
            lr.Status = PriceImportLogStatus.Add;
            if (lr.CodGrundfos == string.Empty && lr.CodProvider == string.Empty)
                SetErrorOnItem(lr, Resource.Business.GetString("CodeError"));

            if(!string.IsNullOrEmpty(lr.CodGrundfos))
                lr.CodGrundfos = lr.CodGrundfos.PadLeft(8, '0');

            if (!string.IsNullOrEmpty(lr.Provider))
                lr.Provider = CheckLogResultField(lr.Provider, typeof(Provider), lr, Resource.Business.GetString("Provider")).ToString();
            else 
                SetErrorOnItem(lr, Resource.Business.GetString("Provider"));

            if (lr.Model.Length > 64) 
            {
                SetErrorOnItem(lr, Resource.Business.GetString("Text64Characters"));
                lr.Model = "";
            }

            if (lr.Description.Length > 512)
            {
                SetErrorOnItem(lr, Resource.Business.GetString("Text512Characters"));
                lr.Description = "";
            }
            
            if(!string.IsNullOrEmpty(lr.Frequency))
                lr.Frequency = CheckLogResultField(lr.Frequency, typeof(Frequency), lr, Resource.Business.GetString("Frecuency")).ToString();
            else if (lr.Status == PriceImportLogStatus.Add)
            {
                lr.Frequency = "50/60";
                lr.ParsedFrequency = null;
            }

            if (lr.TP == 0)
                lr.TP = null;
            if (!string.IsNullOrEmpty(lr.TPCurrency))
                lr.TPCurrency = CheckLogResultField(lr.TPCurrency, typeof(Currency), lr, Resource.Business.GetString("TPCurrency")).ToString();
            else if (lr.Status == PriceImportLogStatus.Add)
                lr.TPCurrency = Resource.Business.GetString("DefaultCurrency");
            
            if(lr.GRP == 0)
                lr.GRP = null;
            if (!string.IsNullOrEmpty(lr.GRPCurrency))
                lr.GRPCurrency = CheckLogResultField(lr.GRPCurrency, typeof(Currency), lr, Resource.Business.GetString("GRPCurrency")).ToString();
            else if (lr.Status == PriceImportLogStatus.Add)
                lr.GRPCurrency = Resource.Business.GetString("DefaultCurrency");

            if(lr.PL == 0)
                lr.PL = null;
            if (!string.IsNullOrEmpty(lr.PLCurrency))
                lr.PLCurrency = CheckLogResultField(lr.PLCurrency, typeof(Currency), lr, Resource.Business.GetString("PLCurrency")).ToString();
            else if (lr.Status == PriceImportLogStatus.Add)
                lr.PLCurrency = Resource.Business.GetString("DefaultCurrency");

            if (!string.IsNullOrEmpty(lr.Cat1.Trim()))
                lr.Cat1 = CheckLogResultField(lr.Cat1, typeof(CategoryBase), lr, Resource.Business.GetString("CategoryType1")).ToString();
            if (!string.IsNullOrEmpty(lr.Cat2.Trim()))
                lr.Cat2 = CheckLogResultField(lr.Cat2, typeof(CategoryBase), lr, Resource.Business.GetString("CategoryType3")).ToString();
            if (!string.IsNullOrEmpty(lr.Cat3.Trim()))
                lr.Cat3 = CheckLogResultField(lr.Cat3, typeof(CategoryBase), lr, Resource.Business.GetString("CategoryType5")).ToString();
        }

        private object CheckLogResultField(object o, Type t, PriceImportLog logResult, string property)
        {
            if (o == null)
                return string.Empty;

            if (t == typeof(Provider))
            {
                IList<Provider> lstProv = provlist.FindAll(delegate(Provider record)
                                             {
                                                 if ((!string.IsNullOrEmpty(record.Name) && record.Name.ToLower() == o.ToString().ToLower()) || (!string.IsNullOrEmpty(record.Code) && record.Code.ToLower() == o.ToString().ToLower()))
                                                 {
                                                     return true;
                                                 }
                                                 return false;
                                             });

                if (lstProv.Count == 1)
                {
                    logResult.ParsedProvider = lstProv[0];
                    return o;
                }
                else if (lstProv.Count > 1)
                {
                    property += " no es único";
                }
            }
            else if (t == typeof(Currency))
            {
                if (currlist.Exists(delegate(Currency record)
                                             {
                                                 if ((!string.IsNullOrEmpty(record.Description) && record.Description.ToLower() == o.ToString().ToLower()))
                                                 {
                                                     return true;
                                                 }
                                                 return false;
                                             }))
                    return o;
                property += "(";
                foreach (Currency currency in currlist)
                {
                    property += currency.Description + ",";
                }
                property = property.TrimEnd(',');
                property += ")";
            }
            else if (t == typeof(Frequency))
            {
                if (o.ToString() == "50" || o.ToString() == "60" || o.ToString() == "50/60")
                {
                    Frequency? pt = null;
                    switch (o.ToString())
                    {
                        case "50":
                            pt = Frequency.Hz50;
                            break;
                        case "60":
                            pt = Frequency.Hz60;
                            break;
                        case "50/60":
                            pt = Frequency.All;
                            break;
                    }

                    logResult.ParsedFrequency = pt;

                    return o;
                }
                property += "(50,60,50/60)";
            }
            else if (t == typeof(CategoryBase))
            {

                IList<CategoryBase> lstCat = catlist.FindAll(delegate(CategoryBase record)
                                             {
                                                 if ((!string.IsNullOrEmpty(record.Description) && (record.Description.ToLower() == o.ToString().ToLower())) || (!string.IsNullOrEmpty(record.Name) && record.Name.ToLower() == o.ToString().ToLower()))
                                                 {
                                                     return true;
                                                 }
                                                 return false;
                                             });
                if (lstCat.Count == 1)
                {
                    logResult.ParsedCategories.Add(lstCat[0]);
                    return o;
                }
                else if (lstCat.Count > 0)
                {
                    property += " no es única";
                }
            }

            SetErrorOnItem(logResult, property);
            return o;
        }

        private static void SetErrorOnItem(PriceImportLog logResult, string error)
        {
            if (string.IsNullOrEmpty(logResult.Detail))
                logResult.Detail = Resource.Business.GetString("ErrorIn");
            logResult.Detail += error + ", ";
            logResult.Detail = logResult.Detail.TrimEnd(',');
            logResult.Status = PriceImportLogStatus.Error;
        }

        private object GetValue(string property, object o)
        {
            return o.GetType().GetField(property).GetValue(o);
        }
        
        #endregion

        #region Import Process

        public void ImportOffLine(Guid id)
        {
            // Change the status to indicate we are processing this import file
            PriceImport pi = GetById(id);

            // Indicates which method to execute
            ProcessItem processItem = new ProcessItem(id.ToString());
            processItem.AssemblyName = typeof(PriceImportController).Assembly.FullName;
            processItem.ClassName = typeof(PriceImportController).FullName;
            processItem.ConstructorParameters = new object[] { this.SessionFactoryConfigPath.Replace("~/","") };
            processItem.MethodName = "Import";
            processItem.MethodParameters = new object[] { id, MembershipHelper.GetUser().UserId };

            // Add the task for processing whenever possible
            DynamicProcessorRemoting processor = (DynamicProcessorRemoting)Activator.GetObject(typeof(DynamicProcessorRemoting), Config.RemotingProcessor);
            if (processor.AddTask(processItem))
            {
                pi.ImportStatus = ImportStatus.SendToExecute;
                Save(pi);
            }
        }

        /// <summary>
        /// Imports an existing PriceImport into the final tables.
        /// </summary>
        /// <param name="id">Id of the PriceImport to process</param>
        /// <returns>True if import was successfully, otherwise false.</returns>
        /// 

        public bool Import(Guid id, Guid userId)
        {
            List<CategoryBase> lstcat = new List<CategoryBase>();
            PriceImport pi = GetById(id);
            if (pi == null)
                return false;
#if !DEBUG
            if (pi.ImportStatus != ImportStatus.SendToExecute)
            {
                Utils.GetLogger().Info(string.Format("[[PRODUCT IMPORT PROCESS]] Invalid Status: {0}", pi.ImportStatus));
                return false;
            }

            pi.ImportStatus = ImportStatus.Executing;
            Save(pi);

            NHibernateSession.Flush();
#endif
            Utils.GetLogger().Info(string.Format("[[PRODUCT IMPORT PROCESS]] Starting ID: {0}", id));

            List<Currency> currlist = ControllerManager.Currency.GetAll() as List<Currency>;
            Currency baseCurrency = ControllerManager.Currency.GetByDescription("€");
            List<CurrencyRate> currencyRates = ControllerManager.CurrencyRate.GetLastList();

            // Todo make sure to free memory
            NHibernateSession.Flush();
            NHibernateSession.Clear();

            DetachedCriteria groupPermissionCriteria = DetachedCriteria.For<CategoryBase>()
                .SetProjection(Projections.Property("ID"))
                .CreateCriteria("PriceImportLogs").Add(Expression.Eq("PriceImport", pi));

            ICriterion groupSubquery = Subqueries.PropertyIn("ID", groupPermissionCriteria);

            ICriteria critCategories = NHibernateSession.CreateCriteria(typeof(CategoryBase));
            critCategories.SetFetchMode("Products", FetchMode.Join);
            critCategories.Add(groupSubquery);
            critCategories.SetResultTransformer(new NHibernate.Transform.DistinctRootEntityResultTransformer());
            List<CategoryBase> catlist = critCategories.List<CategoryBase>() as List<CategoryBase>;

            pi = this.GetById(id);

            // Save temporal priceBases changes
            IList<PriceBase> priceBasesAdd = new List<PriceBase>();
            IList<PriceBase> priceBasesModify = new List<PriceBase>();

            ICriteria critLogResults = NHibernateSession.CreateCriteria(typeof(PriceImportLog)).
                SetFetchMode("ParsedCategories", FetchMode.Join).
                SetFetchMode("ParsedPriceBase", FetchMode.Join).
                SetFetchMode("ParsedPriceBase.PriceImports", FetchMode.Join).
                SetFetchMode("ParsedProvider", FetchMode.Join).
                Add(Expression.Eq("PriceImport", pi)).
                Add(Expression.Not(Expression.Eq("Status", PriceImportLogStatus.Error)));
            

            IList<PriceImportLog> pilList = critLogResults.List<PriceImportLog>();

            this.BeginTransaction();

            Utils.GetLogger().Info("[[PRODUCT IMPORT PROCESS]] Starting.");

            try
            {
                foreach (PriceImportLog logResult in pilList)
                {
                    PriceBase currentPriceBase = null;

                    switch (logResult.Status)
                    {
                        case PriceImportLogStatus.Add:

                            Product p = new Product();
                            p.Status = ProductStatus.Active;
                            currentPriceBase = ControllerManager.PriceBase.Create(pi, logResult.CodGrundfos, logResult.CodProvider,
                                logResult.Model, logResult.Description, logResult.ParsedProvider, logResult.ParsedFrequency, 
                                logResult.TP, FindInMemory(currlist, logResult.TPCurrency), 
                                logResult.GRP, FindInMemory(currlist, logResult.GRPCurrency), 
                                logResult.PL, FindInMemory(currlist, logResult.PLCurrency), 
                                logResult.ParsedCategories,
                                p,
                                baseCurrency, 
                                currencyRates);

                            priceBasesAdd.Add(currentPriceBase);
                            break;
                        case PriceImportLogStatus.Modify:
                            currentPriceBase = logResult.ParsedPriceBase;
                            //ControllerManager.PriceBaseHistory.SaveAudit(currentPriceBase, HistoryStatus.ModificationImport, userId);

                            currentPriceBase = ControllerManager.PriceBase.Modify(pi, logResult.CodGrundfos, logResult.CodProvider, 
                                logResult.Model, logResult.Description, logResult.ParsedProvider, logResult.ParsedFrequency, 
                                logResult.TP, FindInMemory(currlist, logResult.TPCurrency), 
                                logResult.GRP, FindInMemory(currlist, logResult.GRPCurrency), 
                                logResult.PL, FindInMemory(currlist, logResult.PLCurrency), 
                                logResult.ParsedCategories, currentPriceBase, baseCurrency, HistoryStatus.PriceChange, currencyRates);

                            priceBasesModify.Add(currentPriceBase);
                            break;
                    }

                    if (currentPriceBase!=null)
                        foreach (CategoryBase cb in logResult.ParsedCategories)
                        {
                            catlist[catlist.IndexOf(cb)].Products.Add(currentPriceBase.Product);
                            if (!lstcat.Exists(delegate(CategoryBase record){if ((record.ID == cb.ID)){return true;}return false;}))
                                lstcat.Add(cb);
                        }

                    if (logResult.FileIndex % 500 == 0)
                        Utils.GetLogger().Debug(string.Format("[[PRODUCT IMPORT PROCESS]] Processing line: {0}", logResult.FileIndex));
                }
#if !DEBUG
                pi.ImportStatus = ImportStatus.Processed;
                pi.TimeStamp.ModifiedBy = userId;
                pi.TimeStamp.ModifiedOn = DateTime.Now;
                Save(pi);
#endif
                // Make sure to process insert & updates in order.
                foreach (PriceBase pb in priceBasesAdd)
                {
                    pb.Product.TimeStamp.CreatedBy = userId;
                    pb.Product.TimeStamp.CreatedOn = DateTime.Now;
                    NHibernateSession.Save(pb.Product);
                }

                foreach (PriceBase pb in priceBasesAdd)
                {
                    pb.TimeStamp.CreatedBy = userId;
                    pb.TimeStamp.CreatedOn = DateTime.Now;
                    NHibernateSession.Save(pb);
                }

                foreach (PriceBase pb in priceBasesModify)
                {
                    pb.TimeStamp.ModifiedBy = userId;
                    pb.TimeStamp.ModifiedOn = DateTime.Now;
                    NHibernateSession.Save(pb);
                }

                foreach (PriceBase pb in priceBasesModify)
                {
                    pb.Product.TimeStamp.ModifiedBy = userId;
                    pb.Product.TimeStamp.ModifiedOn = DateTime.Now;
                    NHibernateSession.Save(pb.Product);
                }

                // Commit changes to DB
                CommitChanges();

                IQuery q = NHibernateSession.GetNamedQuery("CategoryCountUpdate");
                foreach (CategoryBase categoryBase in lstcat)
                {
                    q.SetInt32("CategoryId", categoryBase.ID);
                    q.UniqueResult();                    
                }

                IList<PriceBase> pbList = ControllerManager.PriceBase.Get(pi, PriceBaseStatus.NotVerified);
                PriceCalculator pc = new PriceCalculator(false, userId);
                pc.Run(pbList);

                // TODO: Send email to creator looking for the userId.
                // TODO: This process is run out of the web server, so it should look for it.

                Utils.GetLogger().Info("[[PRODUCT IMPORT PROCESS]] Finished Processing");
            }
            catch (Exception ex)
            {
                Utils.GetLogger().Error(ex);

                this.RollbackChanges();

                pi = GetById(id);
                pi.ImportStatus = ImportStatus.Failed;
                Save(pi);
                CommitChanges();

                throw ex;
            }

            return true;
        }

        #region FindInMemory

        private PriceBase FindInMemory(List<PriceBase> list, string codGrundfos, string codProvider, Provider prov)
        {
            if (!string.IsNullOrEmpty(codGrundfos.Trim()))
                return list.Find(delegate(PriceBase record)
                                    {
                                        if(!string.IsNullOrEmpty(record.Product.Code))
                                            if (record.Product.Code.ToLower() == codGrundfos.ToLower() && record.Provider.ID == prov.ID)
                                            {
                                                return true;
                                            }
                                        return false;
                                    });
            return list.Find(delegate(PriceBase record)
                                {
                                    if (!string.IsNullOrEmpty(record.ProviderCode))
                                        if (record.ProviderCode.ToLower() == codProvider.ToLower() && record.Provider.ID == prov.ID)
                                        {
                                            return true;
                                        }
                                    return false;
                                });
        }

        private Product FindInMemory(List<CodeProvView> list, string codgrundfos, string codprov, Provider prov, List<Product> prodlist)
        {
            CodeProvView codeProvView = list.Find(delegate(CodeProvView record)
                                    {
                                        if (record.CodeGrundfos != null)
                                        {
                                            if (record.CodeGrundfos.ToLower() == codgrundfos.ToLower() && record.ProviderId == prov.ID)
                                            {
                                                return true;
                                            }
                                        }
                                        else if (record.CodeProvider != null)
                                            if (record.CodeProvider.ToLower() == codprov.ToLower() && record.ProviderId == prov.ID)
                                            {
                                                return true;
                                            }
                                        return false;
                                    });
            Product prod;
            if (codeProvView == null)
            {
                prod = new Product(); 
                prod.Status = ProductStatus.Active;
            }
            else
            {
                prod = prodlist.Find(delegate(Product record)
                                    {
                                        if (record.ID == codeProvView.ProductId)
                                        {
                                            return true;
                                        }
                                        return false;
                                    });
            }
            
            return prod;
        }

        private CategoryBase FindInMemory(List<CategoryBase> list, string info)
        {
            if(info == null)
                return null;
            return list.Find(delegate(CategoryBase record)
                                    {
                                        if ((!string.IsNullOrEmpty(record.Description) && (record.Description.ToLower() == info.ToLower())) || (!string.IsNullOrEmpty(record.Name) && record.Name.ToLower() == info.ToLower()))
                                        {
                                            return true;
                                        }
                                        return false;
                                    });
        }

        private Currency FindInMemory(List<Currency> list, string info)
        {
            return list.Find(delegate(Currency record)
                                    {
                                        if (!string.IsNullOrEmpty(record.Description) && record.Description == info)
                                        {
                                            return true;
                                        }
                                        return false;
                                    });
        }

        private Provider FindInMemory(List<Provider> list, string info)
        {
            return list.Find(delegate(Provider record)
                                    {
                                        if ((!string.IsNullOrEmpty(record.Name) && record.Name.ToLower() == info.ToLower()) || (!string.IsNullOrEmpty(record.Code) && record.Code.ToLower() == info.ToLower()))
                                        {
                                            return true;
                                        }
                                        return false;
                                    });
        }

        #endregion

        #endregion

        #region Export Erroneus CSV File
        //public bool Export(Guid id, PriceImportLogStatus pilStatus, string path)
        //{
        //    DeleteExportFile(path);
        //    PriceImport pi = GetById(id);
            
        //    // TODO: Convert to MemoryStream.
        //    // TODO: Move hardcoded to translation file
        //    List<int> lst = GetIndexsForExport(id, pilStatus);
            
        //    DelimitedClassBuilder cb = CreateClassBuilder(pi.SeparationChar, pi.HaveHeader);
        //    FileHelperEngine engine = new FileHelperEngine(cb.CreateRecordClass());
        //    object[] items = engine.ReadFile(path + pi.ID + ".csv");
        //    object[] erroritems = new object[lst.Count];
        //    int i = 0;
        //    foreach (int error in lst)
        //    {
        //        erroritems[i] = items[error];
        //        i++;
        //    }
        //    engine.WriteFile(path + Resource.Business.GetString("ExportFile"), erroritems);
          

        //    return true;
        //}

        public MemoryStream Export(Guid id, PriceImportLogStatus pilStatus, string path)
        {
            PriceImport pi = GetById(id);

            List<int> lst = GetIndexsForExport(id, pilStatus);

            DelimitedClassBuilder cb = CreateClassBuilder(pi.SeparationChar, pi.HaveHeader);
            FileHelperEngine engine = new FileHelperEngine(cb.CreateRecordClass());
            object[] items = engine.ReadFile(path + pi.ID + ".csv");
            object[] erroritems = new object[lst.Count];
            int i = 0;
            foreach (int error in lst)
            {
                erroritems[i] = items[error];
                i++;
            }

            MemoryStream stream = new MemoryStream();
            StreamWriter sw = new StreamWriter(stream);
            
            engine.WriteStream(sw, erroritems);

            return stream;
        }

        #endregion

        #region Listing Methods

        public IList<PriceImportLogView> GetList(Guid id, PriceImportLogStatus piLogStatus, int pageSize, int pageNumber, out int totalcount)
        {
            string hql = "SELECT COUNT(PI.Description) FROM PriceImport PI JOIN PI.LogResults PIL WHERE PI.ID = :Id AND PIL.Status = :Status";

            IQuery qcount = NHibernateSession.CreateQuery(hql).SetGuid("Id", id).SetEnum("Status", piLogStatus);

            totalcount = Convert.ToInt32(qcount.UniqueResult());

            hql = "SELECT PIL FROM PriceImport PI JOIN PI.LogResults PIL WHERE PI.ID = :Id AND PIL.Status = :Status";

            IQuery q = NHibernateSession.CreateQuery(hql);

            q.SetGuid("Id", id);
            q.SetEnum("Status", piLogStatus);

            if(pageNumber != 0 && pageSize != 0)
            {
                q.SetFirstResult((pageNumber * pageSize) - pageSize);
                q.SetMaxResults(pageSize);
            }

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PriceImportLogView).GetConstructors()[1]));

            IList<PriceImportLogView> pil = q.List<PriceImportLogView>();

            if(pil.Count > 0)
                return pil;

            return new List<PriceImportLogView>();
        }

        public List<PriceImportLog> GetListForExport(Guid id, PriceImportLogStatus piLogStatus)
        {
            string hql = "SELECT PIL FROM PriceImport PI JOIN PI.LogResults PIL WHERE PI.ID = :Id AND PIL.Status = :Status";

            IQuery q = NHibernateSession.CreateQuery(hql);

            q.SetGuid("Id", id);
            q.SetEnum("Status", piLogStatus);

            List<PriceImportLog> pil = q.List<PriceImportLog>() as List<PriceImportLog>;

            if (pil.Count > 0)
                return pil;

            return new List<PriceImportLog>();
        }
        
        public List<int> GetIndexsForExport(Guid id, PriceImportLogStatus piLogStatus)
        {
            string hql = "SELECT PIL.FileIndex FROM PriceImport PI JOIN PI.LogResults PIL WHERE PI.ID = :Id AND PIL.Status = :Status";

            IQuery q = NHibernateSession.CreateQuery(hql);

            q.SetGuid("Id", id);
            q.SetEnum("Status", piLogStatus);

            List<int> pil = q.List<int>() as List<int>;

            if (pil.Count > 0)
                return pil;

            return new List<int>();
        }

        public IList<PriceImport> GetByStatus(ImportStatus status, string orderBy)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ImportStatus", status));

            ICriteria critSort = crit;
            if(string.IsNullOrEmpty(orderBy))
            {
                string[] sort = orderBy.Split('.');
                string sortField = orderBy;
                if (!sortField.Contains("TimeStamp") && sort.Length > 1)
                {
                    critSort = crit.GetCriteriaByPath(sort[0]);
                    if (critSort == null)
                        critSort = crit.CreateCriteria(sort[0]);
                    sortField = sort[1];
                }
                critSort.AddOrder(new Order(sortField, true));
            }
            
            return crit.List<PriceImport>();
        }

        #endregion
    }
}