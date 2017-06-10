using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PartnerNet.Business;
using PartnerNet.Common;
using PartnerNet.Domain;
using ChartDirector;

namespace Grundfos.StockForecast.forecast
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    Generate_Forecast(Convert.ToInt32(Request.QueryString["Id"]));
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 10)
            {
                e.Row.Font.Bold = true;
                e.Row.BackColor = System.Drawing.Color.DarkGray;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            if (e.Row.RowIndex == 20)
            {
                e.Row.Cells[3].Font.Bold = true;
                e.Row.Cells[3].ForeColor = System.Drawing.Color.Black;
            }
        }

        protected void Generate_Forecast(int productid)
        {
            Product info = ControllerManager.Product.GetById(productid);
            IList<TransactionHistoryWeekly> history = ControllerManager.TransactionHistoryWeekly.GetInfo(info.Id, Config.CurrentWeek, Config.CurrentDate.Year, 1);
            this.Label12.Text = info.ProductCode.ToString();
            this.Label3.Text = info.Description.ToString();
            this.Label5.Text = info.Provider.Name;
            this.Label7.Text = (history[0].Stock + history[0].Purchase - history[0].Sale).ToString();
            this.Label9.Text = info.RepositionLevel.ToString();
            this.Label11.Text = info.RepositionPoint.ToString();
            this.Label16.Text = info.LeadTime.ToString();
            this.Label1.Text = info.Safety.ToString();

            IList<Forecast> forecast = ControllerManager.Forecast.GetForecast(info, Config.CurrentWeek, Config.CurrentDate.Year);
            this.GridView1.DataSource = forecast;
            this.GridView1.DataBind();

            //------GRAFICO-------------------------------------------
            if (forecast.Count > 0)
            {
                string[] Titulos = new string[forecast.Count];
                double[] Stock = new double[forecast.Count];
                double[] Ventas = new double[forecast.Count];
                double[] Compras = new double[forecast.Count];
                for (int cont = 0; cont < forecast.Count; cont++)
                {
                    Stock.SetValue(forecast[cont].FinalStock, cont);
                    Ventas.SetValue(forecast[cont].Sale, cont);
                    Compras.SetValue(forecast[cont].Purchase, cont);
                    Titulos.SetValue(forecast[cont].Week.ToString(), cont);
                }

                XYChart c = new XYChart(480, 300, 0xeeeeff, 0x000000, 3);
                c.setPlotArea(50, 70, 410, 180, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
                c.addLegend(50, 50, false, "Arial Bold", 8).setBackground(Chart.Transparent);
                c.addTitle("Graficos Estadisticos", "Verdana Bold", 12).setBackground(0xccccff, 0x000000, Chart.glassEffect());
                c.xAxis().setTitle("Semanas");
                c.yAxis().setTitle("Cantidad");

                Mark actual = c.xAxis().addMark(10, 0x000000, "SEMANA ACTUAL");
                actual.setLineWidth(1);
                actual.setAlignment(Chart.TopRight);
                actual.setFontAngle(90);
                Mark actual0 = c.xAxis().addMark(10 + info.LeadTime, 0x000000, "LEADTIME");
                actual0.setLineWidth(1);
                actual0.setAlignment(Chart.TopLeft);
                actual0.setFontAngle(90);
                LineLayer linea = c.addLineLayer();
                linea.setLineWidth(3);
                linea.addDataSet(Stock, 0x000000, "Stock Final");
                linea.addDataSet(Ventas, 0x00ff00, "Ventas");
                linea.addDataSet(Compras, 0x0000FF, "Compras");
                c.addAreaLayer(Stock, c.yZoneColor(forecast[10].Safety, unchecked((int)0x50ff3c3c), unchecked((int)0x500080c0)));
                c.xAxis().addZone(10, 10 + info.LeadTime, 0xdcdcdc);
                c.xAxis().setLabels(Titulos);
                c.xAxis().setLabelStep(2);
                WebChartViewer1.Image = c.makeWebImage(Chart.PNG);
                WebChartViewer1.ImageMap = c.getHTMLImageMap("", "", "title='Semana {xLabel}: {value}'");
                WebChartViewer1.Visible = true;

            }
        }
    }
}
