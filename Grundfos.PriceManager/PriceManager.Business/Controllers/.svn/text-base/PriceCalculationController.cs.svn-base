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
using ProjectBase.OfflineProcessor;
using ProjectBase.OfflineProcessor.Remoting;
using PriceManager.Common;
using System.Threading;
using NybbleMembership;
using PriceManager.Core.State;

namespace PriceManager.Business
{
    public class PriceCalculationController : AbstractNHibernateDao<PriceCalculation, int>
    {
        public PriceCalculationController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public List<PriceCalculation> Get(Provider provider, CategoryBase categoryBase)
        {
            if (provider == null && categoryBase == null)
                return new List<PriceCalculation>();

            ICriteria crit = GetCriteria();
            if (provider != null)
                crit.Add(Expression.Eq("Provider", provider));
            else
                crit.Add(Expression.IsNull("Provider"));

            if (categoryBase != null)
                crit.Add(Expression.Eq("CategoryBase", categoryBase));
            else
                crit.Add(Expression.IsNull("CategoryBase"));
            
            return crit.List<PriceCalculation>() as List<PriceCalculation>;
        }

        public PriceCalculation Get(Provider provider, CategoryBase categoryBase, int level)
        {
            ICriteria crit = GetCriteria();
            if (provider != null)
                crit.Add(Expression.Eq("Provider", provider));
            else
                crit.Add(Expression.IsNull("Provider"));

            if (categoryBase != null)
                crit.Add(Expression.Eq("CategoryBase", categoryBase));
            else
                crit.Add(Expression.IsNull("CategoryBase"));

            //if(level > -1)
                crit.Add(Expression.Eq("Level", level));

            return crit.UniqueResult<PriceCalculation>();
        }

        public PriceCalculation FindOrCreate(int id, Provider provider, CategoryBase categoryBase, string formula, int level)
        {
            PriceCalculation priceCalculation = Get(provider, categoryBase, level);

            if (priceCalculation == null && id > 0)
                priceCalculation = GetById(id);
                
            if(priceCalculation == null)
                priceCalculation = new PriceCalculation();
                
            priceCalculation.CategoryBase = categoryBase;
            priceCalculation.Provider = provider;
            if (provider != null && categoryBase != null)
                priceCalculation.Priority = PriceCalculationPriority.ProvCat;
            else if (provider == null && categoryBase == null)
                priceCalculation.Priority = PriceCalculationPriority.Default;
            else if (provider != null)
                priceCalculation.Priority = PriceCalculationPriority.Prov;
            else if (categoryBase.Type == "4")
                priceCalculation.Priority = PriceCalculationPriority.ProdType;
            else
                priceCalculation.Priority = PriceCalculationPriority.Cat;

            Modify(priceCalculation, formula, level);

            return priceCalculation;
        }

        private PriceCalculation Modify(PriceCalculation priceCalculation, string formula, int level)
        {
            priceCalculation.Formula = formula;
            priceCalculation.Level = level;

            string errors;
            bool valid;
            object loObject = CheckFormula(formula, out errors, out valid);

            object[] loCodeParms = new object[2];
            loCodeParms[0] = Convert.ToDecimal(100);
            loCodeParms[1] = Convert.ToDecimal(50);
            
            priceCalculation.Weighing = Convert.ToDecimal(loObject.GetType().InvokeMember("DynamicCode",
            BindingFlags.InvokeMethod, null, loObject, loCodeParms));

            Save(priceCalculation);
            CommitChanges();

            return priceCalculation;
        }

        public void Delete(int id)
        {
            PriceCalculation pc = GetById(id);
            PriceCalculation pc2 = Get(pc.Provider, pc.CategoryBase, 2);
            Delete(pc);
            if(pc2 != null)
                Delete(pc2);
        }

        public bool HaveCategory(CategoryBase cb)
        {
            ICriteria crit = GetCriteria();

            if (cb != null)
                crit.Add(Expression.Eq("CategoryBase", cb));

            if (crit.List<PriceCalculation>().Count > 0)
                return true;
            else
                return false;
        }
                
        public override void Delete(PriceCalculation priceCalculation)
        {
            Provider p = priceCalculation.Provider;
            CategoryBase c = priceCalculation.CategoryBase;

            NHibernateSession.Delete(priceCalculation);
            CommitChanges();

            Run(p, c);
        }

        //Used when testing and creating new PriceCalculation
        public object CheckFormula(string formulaIn, out string errors, out bool valid)
        {
            valid = false;

            char space = ' ';

            formulaIn = formulaIn.Trim(space);

            object o = CheckFormula(formulaIn, null, out errors);

            object[] loCodeParms = new object[2];
            loCodeParms[0] = Convert.ToDecimal(100);
            loCodeParms[1] = Convert.ToDecimal(50);

            decimal weighing = Convert.ToDecimal(o.GetType().InvokeMember("DynamicCode",
            BindingFlags.InvokeMethod, null, o, loCodeParms));

            if(string.IsNullOrEmpty(errors) && o != null)
                valid = true;

            if (!formulaIn.Contains("TP") && !formulaIn.Contains("GRP"))
                valid = false;

            return o;
        }

        //Used by Run method
        public object CheckFormula(List<PriceCalculation> priceCalculations)
        {
            string errors;
            return CheckFormula("", priceCalculations, out errors);
        }

        //Main method
        private object CheckFormula(string formulaIn, List<PriceCalculation> priceCalculations, out string errors)
        {
            errors = "";
            
            PriceCalculation temppc = new PriceCalculation();
            temppc.Formula = formulaIn;

            // *** Must create a fully functional assembly
            string lcCode;
            lcCode = @"
                using System;

                namespace PriceManager {
                public class Formula {";

            if (priceCalculations == null)
            {
                lcCode += @"public decimal DynamicCode(decimal GRP, decimal TP) {
                return " + temppc.CodeFormula + "; }   }    }";
            }
            else
            {
                foreach (PriceCalculation calculation in priceCalculations)
                {
                    lcCode += "public decimal Formula" + calculation.ID + @" (decimal GRP, decimal TP) {
                    return " + calculation.CodeFormula + "; }";
                }
                lcCode += @"} }";
            }

            ICodeCompiler loCompiler = new CSharpCodeProvider().CreateCompiler();
            CompilerParameters loParameters = new CompilerParameters();

            // *** Start by adding any referenced assemblies
            loParameters.ReferencedAssemblies.Add("System.dll");

            // *** Load the resulting assembly into memory
            loParameters.GenerateInMemory = true;

            // *** Now compile the whole thing
            CompilerResults loCompiled = loCompiler.CompileAssemblyFromSource(loParameters, lcCode);

            if (loCompiled.Errors.HasErrors)
            {
                // *** Create Error String
                errors = loCompiled.Errors.Count.ToString() + " Errors:";
                for (int x = 0; x < loCompiled.Errors.Count; x++)
                    errors = errors + "\r\nLine: " + loCompiled.Errors[x].Line.ToString() + " - " +
                        loCompiled.Errors[x].ErrorText;
                return false;
            }

            Assembly loAssembly = loCompiled.CompiledAssembly;

            // *** Retrieve an object reference - since this object is 'dynamic' we can't explicitly
            // *** type it so it's of type Object
            object loObject = loAssembly.CreateInstance("PriceManager.Formula");
            if (loObject == null)
            {
                errors = "Couldn't load class.";
                return null;
            }

            return loObject;
        }

        public void Run(MasterPriceSearchParameters mpsp, GridState gs, int newCategoryId, bool addCategory)
        {
#if !DEBUG
            // Indicates which method to execute
            string id = Guid.NewGuid().ToString();
            ProcessItem processItem = new ProcessItem(id);
            processItem.AssemblyName = typeof(PriceCalculator).Assembly.FullName;
            processItem.ClassName = typeof(PriceCalculator).FullName;
            processItem.ConstructorParameters = new object[] { true, MembershipHelper.GetUser().UserId };
            processItem.MethodName = "Run";
            processItem.MethodParameters = new object[] { mpsp, gs, newCategoryId, addCategory};

            // Add the task for processing whenever possible
            DynamicProcessorRemoting processor = (DynamicProcessorRemoting)Activator.GetObject(typeof(DynamicProcessorRemoting), Config.RemotingProcessor);
            processor.AddTask(processItem);
#else
            new PriceCalculator(true, MembershipHelper.GetUser().UserId).Run(mpsp, gs, newCategoryId, addCategory);
#endif

        }

        public void Run(int priceBaseId)
        {
#if !DEBUG
            // Indicates which method to execute
            string id = Guid.NewGuid().ToString();
            ProcessItem processItem = new ProcessItem(id);
            processItem.AssemblyName = typeof(PriceCalculator).Assembly.FullName;
            processItem.ClassName = typeof(PriceCalculator).FullName;
            processItem.ConstructorParameters = new object[] { true, MembershipHelper.GetUser().UserId };
            processItem.MethodName = "Run";
            processItem.MethodParameters = new object[] { priceBaseId };

            // Add the task for processing whenever possible
            DynamicProcessorRemoting processor = (DynamicProcessorRemoting)Activator.GetObject(typeof(DynamicProcessorRemoting), Config.RemotingProcessor);
            processor.AddTask(processItem);
#else
            new PriceCalculator(true, MembershipHelper.GetUser().UserId).Run(priceBaseId);
#endif
        }

        private void RunOffline(bool trackChanges, object[] parameters)
        {
            // Indicates which method to execute
            string id = Guid.NewGuid().ToString();
            ProcessItem processItem = new ProcessItem(id);
            processItem.AssemblyName = typeof(PriceCalculator).Assembly.FullName;
            processItem.ClassName = typeof(PriceCalculator).FullName;
            processItem.ConstructorParameters = new object[] { trackChanges, MembershipHelper.GetUser().UserId };
            processItem.MethodName = "Run";
            processItem.MethodParameters = parameters;

            // Add the task for processing whenever possible
            DynamicProcessorRemoting processor = (DynamicProcessorRemoting)Activator.GetObject(typeof(DynamicProcessorRemoting), Config.RemotingProcessor);
            processor.AddTask(processItem);
        }

        public void Run(MasterPriceSearchParameters mpsp, GridState gs, Currency currency, PriceBaseStatus status)
        {
#if !DEBUG
            // Indicates which method to execute
            string id = Guid.NewGuid().ToString();
            ProcessItem processItem = new ProcessItem(id);
            processItem.AssemblyName = typeof(PriceCalculator).Assembly.FullName;
            processItem.ClassName = typeof(PriceCalculator).FullName;
            processItem.ConstructorParameters = new object[] { true, MembershipHelper.GetUser().UserId };
            processItem.MethodName = "Run";
            processItem.MethodParameters = new object[] { mpsp, gs, currency, status};

            // Add the task for processing whenever possible
            DynamicProcessorRemoting processor = (DynamicProcessorRemoting)Activator.GetObject(typeof(DynamicProcessorRemoting), Config.RemotingProcessor);
            processor.AddTask(processItem);
#else
            new PriceCalculator(true, MembershipHelper.GetUser().UserId).Run(mpsp, gs, currency, status);
#endif
        }

        public void Run(Provider provider, CategoryBase category)
        {
            int? providerId = null;
            int? categoryId = null;

            if (provider != null)
                providerId = provider.ID;

            if (category != null)
                categoryId = category.ID;

#if !DEBUG
            // Indicates which method to execute
            ProcessItem processItem = new ProcessItem(Guid.NewGuid().ToString());
            processItem.AssemblyName = typeof(PriceCalculator).Assembly.FullName;
            processItem.ClassName = typeof(PriceCalculator).FullName;
            processItem.ConstructorParameters = new object[] { true, MembershipHelper.GetUser().UserId };
            processItem.MethodName = "Run";
            processItem.MethodParameters = new object[] { providerId, categoryId };

            // Add the task for processing whenever possible
            DynamicProcessorRemoting processor = (DynamicProcessorRemoting)Activator.GetObject(typeof(DynamicProcessorRemoting), Config.RemotingProcessor);
            processor.AddTask(processItem);
#else
            new PriceCalculator(true, MembershipHelper.GetUser().UserId).Run(providerId, categoryId);
#endif
        }

        //Used to get all price calculations sorted by 1.Priority, 2.Level, 3.Weighing
        public IList<PriceCalculation> GetAllSorted()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Priority", true));
            crit.AddOrder(new Order("Level", true));
            crit.AddOrder(new Order("Weighing", false));

            crit.SetFetchMode("Provider", FetchMode.Join);
            crit.SetFetchMode("CategoryBase", FetchMode.Join);

            return crit.List<PriceCalculation>();
        }

        public IList<PriceCalculationListView> List(string search, CategoryBase[] category, Provider provider, PriceCalculationPriority? priority, GridState gridState, out int totalRecords)
        {
            ICriteria crit = ListCriteria(search, category, provider, priority);
            
            crit.AddOrder(new Order("Priority", true));
            crit.AddOrder(new Order("Provider", true));
            crit.AddOrder(new Order("CategoryBase", true));
            crit.AddOrder(new Order("TimeStamp.ModifiedOn", false));

            IList<PriceCalculationListView> tmp = ConvertToView(crit.List<PriceCalculation>());
            IList<PriceCalculationListView> lstFinal = new List<PriceCalculationListView>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, tmp.Count);

            for (int i = (pageNumber - 1) * gridState.PageSize; i < ((pageNumber - 1) * gridState.PageSize) + gridState.PageSize; i++)
            {
                if(i < tmp.Count)
                    lstFinal.Add(tmp[i]);
            }
            totalRecords = tmp.Count;
            if (totalRecords == 0)
                    return new List<PriceCalculationListView>();

            return lstFinal;
        }

        private IList<PriceCalculationListView> ConvertToView(IList<PriceCalculation> lstPriceCalculations)
        {
            List<PriceCalculation> tmplstPriceCalculations = new List<PriceCalculation>(lstPriceCalculations);
            IList<PriceCalculationListView> lst = new List<PriceCalculationListView>();
            foreach (PriceCalculation priceCalculation in lstPriceCalculations)
            {
                if(priceCalculation.Level == 1)
                {
                    PriceCalculationListView tmp = new PriceCalculationListView();
                    tmp.ID = priceCalculation.ID;
                    if (priceCalculation.CategoryBase != null)
                        tmp.CategoryName = priceCalculation.CategoryBase.Name;
                    if (priceCalculation.Provider != null)
                        tmp.ProviderName = priceCalculation.Provider.Name;
                    tmp.MainFormula = priceCalculation.Formula;
                    PriceCalculation tmpPC = tmplstPriceCalculations.Find(delegate(PriceCalculation record){if (record.CategoryBase == priceCalculation.CategoryBase && record.Provider == priceCalculation.Provider && record.Level == 2){return true;}return false;});
                    if(tmpPC != null)
                        tmp.SecFormula = tmpPC.Formula;
                    tmp.Priority = EnumHelper.GetDescription(priceCalculation.Priority);
                    lst.Add(tmp);
                }
            }

            return lst;
        }

        private ICriteria ListCriteria(string search, CategoryBase[] category, Provider provider, PriceCalculationPriority? priority)
        {
            ICriteria crit = GetCriteria();

            if (!string.IsNullOrEmpty(search))
               crit.Add(Restrictions.InsensitiveLike("Formula", search, MatchMode.Anywhere));

           //Look for categories in the category array
           List<CategoryBase> categories = new List<CategoryBase>();
           if (category != null)
               foreach (CategoryBase categoryBase in category)
               {
                   if (categoryBase == null)
                       continue;
                   List<CategoryBase> tempCB = new CategoryBaseController(this.SessionFactoryConfigPath).FindChildrensOrSelf(categoryBase);
                   categories.AddRange(tempCB);
               }
           List<int> categoriesids = new List<int>();
           foreach (CategoryBase cat in categories)
               categoriesids.Add(cat.ID);

           if (categoriesids.Count > 0)
           {
               ICriteria critCategory = crit.CreateCriteria("CategoryBase");
               critCategory.Add(Expression.In("ID", categoriesids));
           }

           if (provider != null)
           {
               crit.Add(Expression.Eq("Provider", provider));
           }

           if(priority != null)
               crit.Add(Expression.Eq("Priority", priority));

            return crit;
        }

        public bool HaveAnyProvider(Provider p)
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("Provider", p));

            return (crit.List<PriceCalculation>().Count > 0);
        }
    }
}
