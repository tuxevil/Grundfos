using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using NHibernate.Mapping;
using PartnerNet.Common;
using PartnerNet.Domain;
using ProjectBase.Data;

namespace PartnerNet.Business
{
    public class ForecastController : AbstractNHibernateDao<Forecast, int>
    {
        public ForecastController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public void CalculateForecast(Product prod, int week, int year)
        {
            CleanTable(week, year, prod);

            //VARIABLES
            int cont = 0;
            int cont2 = 0;
            int cont3 = 0;
            int todaysale = 0;
            int processedOn = 0;

            //OBTENCION DE LISTA DE HISTORICOS Y CARGA DE ESTADISTICAS ACTUALES
            IList<TransactionHistoryWeekly> history = ControllerManager.TransactionHistoryWeekly.GetInfo(prod.Id, week, year, 10);
            ProductStatisticWeekly statistics = ControllerManager.ProductStatisticWeekly.GetProductInfo(prod.Id);
            
            //CREACION DE COLECCION DE OBJETOS
            IList<Forecast> lista = new List<Forecast>();

            //INICIO DE CARGA DE TRANSACCIONES PASADAS (10)
            for (cont3=9;cont3>0;cont3--)
            {
                Forecast past = new Forecast();
                past.Product = prod;
                if(week-cont3>0)
                {
                    past.Week = week - cont3;
                    past.Year = year;
                }
                else
                {
                    past.Week = 52+(week - cont3);
                    past.Year = year-1;
                }
                past.Stock = 0;
                past.Purchase = 0;
                past.Sale = 0;
                past.FinalStock = 0;
                past.Safety = 0;
                past.SafetyCoEf = 0;
                past.QuantitySuggested = 0;
                past.ProcessedOn = 0;
                for(int i = 0;i<history.Count;i++)
                {
                    if(history[i].Year == past.Year)
                    {
                        if (history[i].Week == past.Week)
                        {
                            past.FinalStock = history[i].Stock;
                            past.Purchase = history[i].Purchase;
                            past.Sale = history[i].Sale;
                        }    
                    }
                    
                }
                past.Stock = past.FinalStock + past.Sale - past.Purchase;
                
                lista.Add(past);
            }
            
            //CALCULOS INICIALES PARA OBTENER DATOS DE SEMANA ACTUAL
            int stock = history[0].Stock;
            int purchase = history[0].Purchase;
            todaysale = history[0].Sale;
            int finalStock = stock + purchase - todaysale;
            int safety = statistics.Sale * prod.Safety;
            int quantitySuggested = 0;

            //CARGA DE DATOS CALCULADOS AL OBJETO DE LA SEMANA ACTUAL
            Forecast today = new Forecast();
            today.Product = prod;
            today.Week = week;
            today.Year = year;
            today.Stock = stock;
            today.Purchase = purchase;
            today.Sale = todaysale;
            today.FinalStock = finalStock;
            //today.Safety = safety;
            //today.SafetyCoEf = prod.Safety;
            //today.QuantitySuggested = quantitySuggested;
            //today.ProcessedOn = processedOn;

            lista.Add(today);

            //PROCESO DE CALCULO DEL FUTURO (18)
            int saleaverage = statistics.Sale;
            for (cont =1; cont < 18; cont++)
            {
                stock = finalStock;
                purchase = 0;
                
                for (cont2 = 0; cont2 < history.Count ; cont2++ )
                {
                    if (history[cont2].Week + 10 == week + cont)
                        purchase = history[cont2].PurchaseOrders;
                }
                
                finalStock = stock + purchase - saleaverage;
                
                Forecast info = new Forecast();

                info.Product = prod;
                if (week + cont <= 52)
                {
                    info.Week = week + cont;
                    info.Year = year;
                }
                else
                {
                    info.Week = week + cont - 52;
                    info.Year = year+1;
                }
                info.Stock = stock;
                info.Purchase = purchase;
                info.Sale = saleaverage;
                info.FinalStock = finalStock;
                info.Safety = safety;
                info.SafetyCoEf = prod.Safety;
                info.QuantitySuggested = quantitySuggested;
                info.ProcessedOn = processedOn;

                lista.Add(info);
                this.Save(info);
                if (cont>=11 && finalStock<safety)
                {
                    double modulequantity = (lista[cont + 9].Safety - lista[cont + 9].FinalStock + lista[cont + 9].Sale)/prod.RepositionPoint;
                    modulequantity = Convert.ToDouble(modulequantity.ToString() + "." + ((lista[cont + 9].Safety - lista[cont + 9].FinalStock + lista[cont + 9].Sale)%prod.RepositionPoint).ToString());
                    int purchasesuggested = Convert.ToInt32(Math.Ceiling(modulequantity));
                    lista[cont - 1].QuantitySuggested = purchasesuggested * prod.RepositionPoint;
                    lista[cont + 9].Purchase = lista[cont - 1].QuantitySuggested;
                    lista[cont + 9].FinalStock = lista[cont + 9].Stock + lista[cont + 9].Purchase - saleaverage;
                    finalStock = lista[cont + 9].FinalStock;
                }
            }
        }
        public void CleanTable(int week, int year, Product prod)
        {
            foreach (Forecast o in GetAll())
                if((o.Week > week && o.Year == year && o.Product == prod)||(o.Week < week && o.Year > year && o.Product == prod))
                    this.Delete(o);
        }

        public Forecast GetProductInfo(Product product, int week, int year)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new EqExpression("Product", product));
            crit.Add(new EqExpression("Week", week));
            crit.Add(new EqExpression("Year", year));
            return crit.UniqueResult<Forecast>();
        }

        public IList<Forecast> GetPOList(int week, int year)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new GtExpression("QuantitySuggested", 0));
            crit.Add(new EqExpression("Week", week));
            crit.Add(new EqExpression("Year", year));

            return crit.List<Forecast>();
        }

        public IList<Forecast>GetForecast(Product product, int week, int year)
        {
            //VARIABLES
            int cont = 0;
            int cont2 = 0;
            int cont3 = 0;
            int todaysale = 0;
            int processedOn = 0;

            //OBTENCION DE LISTA DE HISTORICOS Y CARGA DE ESTADISTICAS ACTUALES
            IList<TransactionHistoryWeekly> history = ControllerManager.TransactionHistoryWeekly.GetInfo(product.Id, week, year, 10);
            ProductStatisticWeekly statistics = ControllerManager.ProductStatisticWeekly.GetProductInfo(product.Id);

            //CREACION DE COLECCION DE OBJETOS
            IList<Forecast> lista = new List<Forecast>();

            //INICIO DE CARGA DE TRANSACCIONES PASADAS (10)
            for (cont3 = 9; cont3 > 0; cont3--)
            {
                Forecast past = new Forecast();
                past.Product = new Product(product.Id);
                if (week - cont3 > 0)
                {
                    past.Week = week - cont3;
                    past.Year = year;
                }
                else
                {
                    past.Week = 52 + (week - cont3);
                    past.Year = year - 1;
                }
                past.Stock = 0;
                past.Purchase = 0;
                past.Sale = 0;
                past.FinalStock = 0;
                past.Safety = 0;
                past.SafetyCoEf = 0;
                past.QuantitySuggested = 0;
                past.ProcessedOn = 0;
                for (int i = 0; i < history.Count; i++)
                {
                    if (history[i].Year == past.Year)
                    {
                        if (history[i].Week == past.Week)
                        {
                            past.FinalStock = history[i].Stock;
                            past.Purchase = history[i].Purchase;
                            past.Sale = history[i].Sale;
                        }
                    }

                }
                past.Stock = past.FinalStock + past.Sale - past.Purchase;

                lista.Add(past);
            }

            //CALCULOS INICIALES PARA OBTENER DATOS DE SEMANA ACTUAL
            int stock = history[0].Stock;
            int purchase = history[0].Purchase;
            todaysale = history[0].Sale;
            int finalStock = stock + purchase - todaysale;
            int safety = statistics.Sale * product.Safety;
            int quantitySuggested = 0;

            //CARGA DE DATOS CALCULADOS AL OBJETO DE LA SEMANA ACTUAL
            Forecast today = new Forecast();
            today.Product = new Product(product.Id);
            today.Week = week;
            today.Year = year;
            today.Stock = stock;
            today.Purchase = purchase;
            today.Sale = todaysale;
            today.FinalStock = finalStock;
            today.Safety = safety;
            today.SafetyCoEf = product.Safety;
            today.QuantitySuggested = quantitySuggested;
            today.ProcessedOn = processedOn;

            lista.Add(today);

            //OBTENCION DE DATOS FUTUROS PRECALCULADOS
            
            ICriteria crit = GetCriteria();
            crit.Add(new EqExpression("Product", product));
            crit.Add(new OrExpression(new AndExpression(new GtExpression("Week", week), new GeExpression("Year", year)),new GtExpression("Year", year)));
            //crit.Add(new GtExpression("Week", week));
            //crit.Add(new GeExpression("Year", year));

            IList<Forecast> lst = crit.List<Forecast>();

            foreach (Forecast forecast in lst)
            {
                lista.Add(forecast);
            }
            
            return lista;
        }
    }
}
