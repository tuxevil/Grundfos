using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using PriceManager.Core.State;

namespace PriceManager.Business
{
    /// <summary>
    /// Allows to calculate the new list price for any out of list record
    /// </summary>
    public class PriceCalculator
    {
        private List<PriceCalculation> priceCalculations;
        private List<CurrencyRateView> currencyRateViews;
        private IList<PriceBase> priceBases = new List<PriceBase>();
        private List<IDIDView> lstProductByCategories;

        private object loObject;
        private bool createHistory;
        private Guid? userId;

        /// <summary>
        /// Initialize the calculator with the information needed to update the prices.
        /// </summary>
        /// <param name="createHistory">Indicates if the history record should be created.</param>
        public PriceCalculator(bool createHistory, Guid userId)
        {
            Initialize(createHistory, userId);
        }

        private void Initialize(bool createHistory, Guid? userId) 
        {
            this.createHistory = createHistory;

            if (userId.HasValue)
                this.userId = userId;
        }

        public void Run(MasterPriceSearchParameters mpsp, GridState gs, int categoryId, bool addCategory)
        {
            CategoryBase tempcb = null;
            if(addCategory)
                tempcb = new CategoryBase(categoryId);
            IList<PriceBase> temppblist = ControllerManager.PriceBase.GetPriceBases(
                mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, string.Empty, string.Empty, gs.MarkedAll, gs.Items, false, mpsp.Currency, null, tempcb, null, mpsp.Provider, mpsp.SearchDate, PriceBaseStatus.NotVerified, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);

            if (temppblist.Count > 0)
            {
                priceBases = temppblist;
                Execute();
            }
        }

        public void Run(MasterPriceSearchParameters mpsp, GridState gs, Currency currency, PriceBaseStatus priceBaseStatus)
        {
            if (mpsp.ProductStatus == null)
                mpsp.ProductStatus = ProductStatus.Active;

            IQuery q = ControllerManager.PriceBase.GetProductListQuery("DISTINCT PB", mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, currency, 0, 0, string.Empty, string.Empty, gs.MarkedAll, gs.Items, false, null, null, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, priceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);
            List<PriceBase> pricebaselist = q.List<PriceBase>() as List<PriceBase>;

            if (pricebaselist.Count > 0)
            {
                priceBases = pricebaselist;
                Execute();
            }
        }


        public void Run(int? providerId, int? categoryId)
        {
            Provider p = null;
            CategoryBase c = null;

            if (providerId.HasValue)
                p = new Provider(providerId.Value);

            if (categoryId.HasValue)
                c = new CategoryBase(categoryId.Value);
            
            IList<PriceBase> lst = ControllerManager.PriceBase.Get(p, c, PriceBaseStatus.NotVerified);

            if (lst.Count > 0)
            {
                priceBases = lst;
                Execute();
            }
        }

        public void Run()
        {
            ICriteria crit = ControllerManager.CurrentSession.CreateCriteria(typeof(PriceBase));
            crit.Add(Expression.Eq("Status", PriceBaseStatus.NotVerified));
            IList<PriceBase> lst = crit.List<PriceBase>();

            if (lst.Count > 0)
            {
                priceBases = lst;
                Execute();
            }
        }
        /// <summary>
        /// Execute the calculation for the PriceBase record
        /// </summary>
        /// <param name="priceBase">Record to update</param>
        public void Run(int priceBaseId)
        {
            PriceBase priceBase = ControllerManager.PriceBase.GetById(priceBaseId);
            if (priceBase == null)
                return;

            priceBases.Add(priceBase);
            Execute();
        }

        /// <summary>
        /// Execute the calculator for a list of records
        /// </summary>
        /// <param name="priceBases">List of records to be updated</param>
        public void Run(IList<PriceBase> priceBases)
        {
            if (priceBases == null)
                return;

            this.priceBases = priceBases;
            Execute();
        }

        private void Execute()
        {
            priceCalculations = ControllerManager.PriceCalculation.GetAllSorted() as List<PriceCalculation>;

            if (priceCalculations == null || priceBases.Count == 0)
                return;

            currencyRateViews = ControllerManager.CurrencyRate.GetAllRates() as List<CurrencyRateView>;
            lstProductByCategories = ControllerManager.CategoryBase.GetCategoriesIds();
            loObject = ControllerManager.PriceCalculation.CheckFormula(priceCalculations);

            Utils.GetLogger().Debug("Executing data for Price Calculator");
            ITransaction trans = ControllerManager.CurrentSession.BeginTransaction();

            try
            {
                ProcessRecords();
                trans.Commit();
            }
            catch (Exception ex)
            {
                Utils.GetLogger().Debug(ex);
                trans.Rollback();
                throw ex;
            }

            Utils.GetLogger().Debug("Finish executing data for Price Calculator");
        }

        private void ProcessRecords()
        {
            Utils.GetLogger().Debug("Processing Records");
            foreach (PriceBase priceBase in priceBases)
            {
                // Ignore
                if ((priceBase.PricePurchase == 0 && priceBase.PriceSuggest == 0) || priceBase.Status != PriceBaseStatus.NotVerified)
                    continue;

                List<PriceCalculation> lstPriceCalculationCopy = new List<PriceCalculation>(priceCalculations);

                // Remove formulas with TP
                if (priceBase.PricePurchase == 0)
                    lstPriceCalculationCopy = priceCalculations.FindAll(delegate(PriceCalculation record)
                                             {
                                                 if (!record.Formula.Contains("TP"))
                                                 {
                                                     return true;
                                                 }
                                                 return false;
                                             });
                // Remove formulas with GRP
                else if (priceBase.PriceSuggest == 0)
                    lstPriceCalculationCopy = priceCalculations.FindAll(delegate(PriceCalculation record)
                                             {
                                                 if (!record.Formula.Contains("GRP"))
                                                 {
                                                     return true;
                                                 }
                                                 return false;
                                             });

                // Find default formula
                PriceCalculation defaultPriceCalculation = lstPriceCalculationCopy.Find(delegate(PriceCalculation record)
                                             {
                                                 if (record.Priority == PriceCalculationPriority.Default)
                                                 {
                                                     return true;
                                                 }
                                                 return false;
                                             });

                int providerId = priceBase.Provider.ID;
                List<IDIDView> productCategories = lstProductByCategories.FindAll(delegate(IDIDView record)
                                                {
                                                    if (record.Id1 == priceBase.Product.ID)
                                                        return true;
                                                    return false;
                                                }
                                            );

                if (lstPriceCalculationCopy.Count > 0)
                    lstPriceCalculationCopy = lstPriceCalculationCopy.FindAll(delegate(PriceCalculation record)
                                                    {
                                                        if (record.Provider != null && record.Provider.ID == providerId && record.CategoryBase != null && productCategories.Count > 0)
                                                        {
                                                            if (productCategories.Exists(delegate(IDIDView record2)
                                                                                             {
                                                                                                 if (record2.Id2 == record.CategoryBase.ID) 
                                                                                                    return true;
                                                                                                 return false;
                                                                                             }))
                                                                return true;
                                                        }

                                                        if (record.Provider != null && record.Provider.ID == providerId && record.CategoryBase == null)
                                                            return true;

                                                        if (record.Provider == null && record.CategoryBase != null && productCategories.Count > 0)
                                                        {
                                                            if (productCategories.Exists(delegate(IDIDView record2)
                                                                                             {
                                                                                                 if (record2.Id2 == record.CategoryBase.ID)
                                                                                                     return true;
                                                                                                 return false;
                                                                                             }))
                                                                return true;
                                                        }

                                                        return false;
                                                    });


                // If there is a better formula than Default, set it.
                PriceCalculation selectedPriceCalculation = lstPriceCalculationCopy.Count > 0 ? lstPriceCalculationCopy[0] : defaultPriceCalculation;

                // If no formula found, return;
                if (selectedPriceCalculation == null)
                    continue;

                Utils.GetLogger().Debug(string.Format("Selected formula {0} for PriceBase [{1}/{2}]", selectedPriceCalculation.Formula, priceBase.Product.ID, priceBase.Provider.ID));

                // Find current rate for PriceSuggest
                CurrencyRateView currentRate = currencyRateViews.Find(delegate(CurrencyRateView record)
                                                             {
                                                                 if (record.FromCurrency.ID == priceBase.PriceSuggestCurrency.ID &&
                                                                     record.ToCurrency.ID == priceBase.PriceListCurrency.ID)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });


                object[] loCodeParms = new object[2];
                loCodeParms[0] = priceBase.PriceSuggest * currentRate.Rate;

                // Find current rate for PricePurchase
                currentRate = currencyRateViews.Find(delegate(CurrencyRateView record)
                                                             {
                                                                 if (record.FromCurrency.ID == priceBase.PricePurchaseCurrency.ID &&
                                                                     record.ToCurrency.ID == priceBase.PriceListCurrency.ID)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
                loCodeParms[1] = priceBase.PricePurchase * currentRate.Rate;

                Utils.GetLogger().Debug(string.Format("Executing formula {0} for PriceBase [{1}/{2}]", selectedPriceCalculation.Formula, priceBase.Product.ID, priceBase.Provider.ID));

                // Calculate with the specified formula
                decimal finalPriceList = Convert.ToDecimal(loObject.GetType().InvokeMember("Formula" + selectedPriceCalculation.ID.ToString(),
                BindingFlags.InvokeMethod, null, loObject, loCodeParms));

                // Ignore if same price
                if (finalPriceList == priceBase.PriceList)
                    continue;

                //// Create the Price Base history record if needed.
                //if (createHistory)
                //    ControllerManager.PriceBaseHistory.SaveAudit(priceBase, HistoryStatus.ModificationPolitics, userId);

                // Assign new price
                priceBase.PriceList = finalPriceList;
                priceBase.TimeStamp.ModifiedOn = DateTime.Now;
                if (userId.HasValue)
                    priceBase.TimeStamp.ModifiedBy = userId;

                Utils.GetLogger().Debug(string.Format("Setting price of {0} for PriceBase [{1}/{2}]", finalPriceList, priceBase.Product.ID, priceBase.Provider.ID));
            }

            priceBases.Clear();

            Utils.GetLogger().Debug("Finish executing data for Price Calculator");
        }
    }

}
