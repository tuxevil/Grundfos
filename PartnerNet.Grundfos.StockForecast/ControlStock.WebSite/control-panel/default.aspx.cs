using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ChartDirector;
using PartnerNet.Business;
using PartnerNet.Domain;

namespace Grundfos.StockForecast.control_panel
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(UserType.Administradores.ToString()))
                lnbAdministrarMails.Visible = true;
            else
                lnbAdministrarMails.Visible = false;
            if (!IsPostBack)
            {
                AngularMeter m = GenerateChart(1);

                WebChartViewer1.Image = m.makeWebImage(Chart.PNG);

                AngularMeter m3 = GenerateChart(3);

                WebChartViewer3.Image = m3.makeWebImage(Chart.PNG);

                AngularMeter m4 = GenerateChart(4);

                WebChartViewer4.Image = m4.makeWebImage(Chart.PNG);

                AngularMeter m6 = GenerateChart(6);

                WebChartViewer6.Image = m6.makeWebImage(Chart.PNG);
            }

        }

        protected void lnbAdministrarMails_Click(object sender, EventArgs e)
        {
            Response.Redirect("../administration/usersmail.aspx");
        }

        private AngularMeter GenerateChart(int alert)
        {
            double value = 0;

            AngularMeter m = new AngularMeter(180, 180, Chart.silverColor(), 0x000000, -2);
            m.setMeter(155, 165, 130, 270, 360);

            switch (alert)
            {
                case 1:
                    {

                        m.addText(90, 10, "Seguimiento de", "Verdana", 12, Chart.TextColor, Chart.Center);
                        m.addText(90, 25, "Ordenes de Compra", "Verdana", 12, Chart.TextColor, Chart.Center);
                        value = ControllerManager.AlertTotal.GetTotalForAlert(alert);

                        GetRange(m, alert, value);

                        break;
                    }
                case 3:
                    {
                        m.addText(90, 10, "Productos con", "Verdana", 12, Chart.TextColor, Chart.Center);
                        m.addText(90, 25, "Stock Negativo", "Verdana", 12, Chart.TextColor, Chart.Center);
                        value = ControllerManager.AlertProduct.ShowAlert3().Count;

                        GetRange(m, alert, value);

                        break;
                    }
                case 4:
                    {
                        m.addText(90, 10, "Seguimiento de", "Verdana", 12, Chart.TextColor, Chart.Center);
                        m.addText(90, 25, "Entregas", "Verdana", 12, Chart.TextColor, Chart.Center);
                        value = ControllerManager.AlertTotal.GetTotalForAlert(alert);

                        GetRange(m, alert, value);

                        break;
                    }
                case 6:
                    {
                        m.addText(90, 10, "Nivel de Reposición", "Verdana", 12, Chart.TextColor, Chart.Center);
                        //TODO: Verificar con que filtros quieren ver
                        value = ControllerManager.AlertReposition.ShowAlert6(false, false, null, null, true).Count;

                        GetRange(m, alert, value);

                        break;
                    }
            }

            return m;
        }

        private AngularMeter GetRange(AngularMeter m, int alert, double value)
        {
            m.addText(7, 35, value.ToString("0.##"), "Verdana", 8, 0xffffff, Chart.TopLeft).setBackground(0, 0, -1);
            int total = ControllerManager.AlertTotal.GetTotalForAlert(alert);
            if (alert == 1 || alert == 4)
                total = 45;

            m.setScale(0, total, total / 3, Convert.ToDouble(total) / 6);

            m.addZone((total / 3) * 2, total, 0xffcccc, 0x808080);
            m.addZone(total / 3, (total / 3) * 2, 0xffff66, 0x808080);
            m.addZone(0, total / 3, 0x99ff99, 0x808080);

            if ((alert == 1 || alert == 4) && value > total)
                m.addPointer(total, unchecked((int)0x80000000));
            else if ((alert == 1 || alert == 4) && value < 0)
                m.addPointer(0, unchecked((int) 0x80000000));
            else m.addPointer(value, unchecked((int)0x80000000));

            return m;
        }
    }
}
