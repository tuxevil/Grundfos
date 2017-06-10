using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using Grundfos.StockForecast.Templates;
using PartnerNet.Business;
using PartnerNet.Common;
using PartnerNet.Domain;

namespace Grundfos.StockForecast
{
    public partial class purchaseorder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
            Label6.Visible = false;
            Pager1.PageChanged += Pager1_PageChanged;
            Pager2.PageChanged += Pager1_PageChanged;
            
            if (!IsPostBack)
            {
                Cargar_Estados();
                Cargar_Proveedores();
                TextBox2.Text = Config.CurrentDate.ToShortDateString();
            }
        }

        protected void repItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            PurchaseOrderInformation po = (PurchaseOrderInformation)e.Item.DataItem;

            DetalleOC det = (DetalleOC)e.Item.FindControl("ucDetalle");
            det.POId = po.Id;
        }

        protected void Cargar_Busqueda()
        {
            DisplayInfo(10, Convert.ToInt32(ViewState["page"]));
        }

        protected void Cargar_Estados()
        {
            IList status = EnumHelper.GetList(typeof(PurchaseOrderStatus));
            for (int cont = 0 ; cont < status.Count ; cont++)
            {
                ListItem LI = new ListItem(EnumHelper.GetDescription((PurchaseOrderStatus)cont), cont.ToString());
                DropDownList3.Items.Add(LI);
            }
        }

        protected void Cargar_Proveedores()
        {
            IList<Provider> providers = ControllerManager.Provider.GetProviderList();
            if (providers != null)
            {

                foreach (Provider prov in providers)
                {
                    ListItem LI = new ListItem(prov.Name, prov.Id.ToString());
                    DropDownList1.Items.Add(LI);
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value != "" || (args.Value == "" && (Convert.ToInt32(DropDownList1.SelectedValue) > 0 || Convert.ToDateTime(TextBox2.Text) != Config.CurrentDate || Convert.ToInt32(DropDownList3.SelectedValue) > 0)));

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rep in repItems.Items)
            {
                ((CheckBox)rep.FindControl("CheckBox1")).Checked = true;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem rep in repItems.Items)
            {
                ((CheckBox)rep.FindControl("CheckBox1")).Checked = false;
            }
        }

        protected void repItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {


            if (e.CommandName == "Expand")
            {
                DetalleOC det = (DetalleOC)e.Item.FindControl("ucDetalle");
                det.Visible = true;
                det.LoadInformation();
            }
        }

        private void Pager1_PageChanged(object sender, Controls_Pager.PageChangedEventArgs e)
        {
            DisplayInfo(10, e.NewPageNumber);
        }

        private void DisplayInfo(int pageSize, int currentPage)
        {
            PagedDataSource pagedItems = new PagedDataSource();

            int cod = 0;
            DateTime date = new DateTime();
            if (TextBox1.Text != "")
                cod = Convert.ToInt32(TextBox1.Text);
            if (TextBox2.Text != "")
                date = Convert.ToDateTime(TextBox2.Text);
            else date = Convert.ToDateTime("01/01/1900");

            IList<PurchaseOrderInformation> poinfo = ControllerManager.PurchaseOrder.GetPurchaseOrders(cod, date, Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList3.SelectedValue), 0, 0);
            
            foreach (PurchaseOrderInformation information in poinfo)
            {
                IList<PurchaseOrderItem> poi = ControllerManager.PurchaseOrderItem.GetPurchaseOrderItemList(ControllerManager.PurchaseOrder.GetById(information.Id));
                information.Amount = 0;
                information.Totalcount = 0;
                foreach (PurchaseOrderItem item in poi)
                {
                    Grundfos.ScalaConnector.Product prodscala = Grundfos.ScalaConnector.ControllerManager.Product.GetProductInfo(item.Product.ProductCode);
                    information.Amount = information.Amount + (item.Quantity * prodscala.PurchasePrice);
                    information.Totalcount = information.Totalcount + item.Quantity;
                    information.Arrivaldate = information.Orderdate.AddDays(item.Product.LeadTime);
                }
            }

            pagedItems.DataSource = poinfo;
            pagedItems.AllowPaging = true;
            pagedItems.PageSize = pageSize;
            pagedItems.CurrentPageIndex = currentPage - 1;
            Pager1.PageCount = pagedItems.PageCount;
            Pager2.PageCount = Pager1.PageCount;
            Pager1.CurrentPage = currentPage;
            Pager2.CurrentPage = Pager1.CurrentPage;
            repItems.DataSource = pagedItems;
            repItems.DataBind();
            if (pagedItems.PageCount < 1)
            {
                Pager1.Visible = false;
                Pager2.Visible = false;
            }

            Pager1.Step = 4;
            Pager2.Step = 4;
            Pager1.DataBind();
            Pager2.DataBind();

        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsValid)
                return;

            ViewState["page"] = "1";
            Cargar_Busqueda();
        }

        protected void Image14_Click(object sender, ImageClickEventArgs e)
        {
            IList<PurchaseOrder> selectedpo = new List<PurchaseOrder>();

            foreach (RepeaterItem rep in repItems.Items)
            {
                if (((CheckBox)rep.FindControl("CheckBox1")).Checked)
                {
                    PurchaseOrder po = ControllerManager.PurchaseOrder.GetById(Convert.ToInt32(((CheckBox)rep.FindControl("CheckBox1")).ToolTip));
                    selectedpo.Add(po);
                }
            }
            if (selectedpo.Count > 0)
            {
                ControllerManager.PurchaseOrder.ChangeStatus(selectedpo, (PurchaseOrderStatus)3);
                Cargar_Busqueda();
            }
            else
            {
                Label6.Visible = true;
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            IList<PurchaseOrder> selectedpo = new List<PurchaseOrder>();

            foreach (RepeaterItem rep in repItems.Items)
            {
                if (((CheckBox)rep.FindControl("CheckBox1")).Checked)
                {
                    PurchaseOrder po = ControllerManager.PurchaseOrder.GetById(Convert.ToInt32(((CheckBox)rep.FindControl("CheckBox1")).ToolTip));
                    selectedpo.Add(po);
                }
            }
            if (selectedpo.Count > 0)
            {
                foreach (PurchaseOrder order in selectedpo)
                {
                    foreach (PurchaseOrderItem poi in order.PurchaseOrderItems)
                    {
                        if (poi.PurchaseOrderItemStatus == (PurchaseOrderItemStatus)0)
                        {
                            FileStream objFile = new FileStream(@"C:\genocompra.prn", FileMode.Append);

                            StreamWriter objWriter = new StreamWriter(objFile, Encoding.Default);

                            objWriter.WriteLine("00000166191000005" + poi.Product.ProductCode +
                                                Right("                                  ",
                                                      34 - poi.Product.ProductCode.ToString().Length) +
                                                Left("00000000000", 11 - poi.Quantity.ToString().Length) + poi.Quantity +
                                                Left(".20000000000000",
                                                     15 - poi.PurchaseOrder.Provider.ProviderCode.ToString().Length) +
                                                poi.PurchaseOrder.Provider.ProviderCode + "    " +
                                                DateTime.Today.ToString("ddMMyyyy") + DateTime.Today.ToString("ddMMyyyy") +
                                                "0101                                                                                                                                                                                                           ");

                            objWriter.Flush();
                            objWriter.Close();
                            objFile.Close();
                        }       
                    }
                }
                
                Cargar_Busqueda();
            }
            else
            {
                Label6.Visible = true;
            }
        }

        public static String Left(String strParam, int iLen)
        {
            if (iLen > 0)
                return strParam.Substring(0, iLen);
            else
                return strParam;
        }

        public static String Right(String strParam, int iLen)
        {
            if (iLen > 0)
                return strParam.Substring(strParam.Length - iLen, iLen);
            else
                return strParam;
        }

        protected void Image12_Click(object sender, ImageClickEventArgs e)
        {
            IList<PurchaseOrderInformation> poinfo = new List<PurchaseOrderInformation>();
            
            //IList<PurchaseOrder> selectedpo = new List<PurchaseOrder>();

            foreach (RepeaterItem rep in repItems.Items)
            {
                if (((CheckBox)rep.FindControl("CheckBox1")).Checked)
                {
                    //PurchaseOrder po = ControllerManager.PurchaseOrder.GetById(Convert.ToInt32(((CheckBox)rep.FindControl("CheckBox1")).ToolTip));
                    IList<PurchaseOrderInformation> poii = ControllerManager.PurchaseOrder.GetPurchaseOrders(Convert.ToInt32(((CheckBox)rep.FindControl("CheckBox1")).ToolTip), Convert.ToDateTime("01/01/1900"), Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList3.SelectedValue), 0, 0);
                    
                    poinfo.Add(poii[0]);
                }
            }
            if (poinfo.Count > 0)
            {
                foreach (PurchaseOrderInformation information in poinfo)
                {
                    IList<PurchaseOrderItem> poi = ControllerManager.PurchaseOrderItem.GetPurchaseOrderItemList(ControllerManager.PurchaseOrder.GetById(information.Id));
                    information.Amount = 0;
                    information.Totalcount = 0;
                    foreach (PurchaseOrderItem item in poi)
                    {
                        Grundfos.ScalaConnector.Product prodscala = Grundfos.ScalaConnector.ControllerManager.Product.GetProductInfo(item.Product.ProductCode);
                        information.Amount = information.Amount + (item.Quantity * prodscala.PurchasePrice);
                        information.Totalcount = information.Totalcount + item.Quantity;
                        information.Arrivaldate = information.Orderdate.AddDays(item.Product.LeadTime);
                    }
                }

                DataSet objDataSet = new DataSet();
                DataTable objTable = new DataTable("rptPO");

                objTable.Columns.Add("Codigo");
                objTable.Columns.Add("FechaPedido");
                objTable.Columns.Add("Proveedor");
                objTable.Columns.Add("CantArt");
                objTable.Columns.Add("Importe");
                objTable.Columns.Add("FechaArribo");
                objTable.Columns.Add("Origen");

                DataRow myRow;
                foreach (PurchaseOrderInformation po in poinfo)
                {
                    myRow = objTable.NewRow();
                    myRow[0] = po.Id;
                    myRow[1] = po.Orderdate.ToShortDateString();
                    myRow[2] = po.Provider;
                    myRow[3] = po.Totalcount;
                    myRow[4] = po.Amount;
                    myRow[5] = po.Arrivaldate.ToShortDateString();
                    myRow[6] = po.Type;
                    
                    objTable.Rows.Add(myRow);
                }
                objDataSet.Tables.Add(objTable);


                //DataSet objDataSet=new DataSet();
                //DataTable objTable=new DataTable("rptPO");
                
                //objTable.Columns.Add("POCode");
                //objTable.Columns.Add("PODate");
                //objTable.Columns.Add("Provider");
                //objTable.Columns.Add("dDate");
                
                //DataRow myRow;
                //foreach (PurchaseOrder po in selectedpo)
                //{
                //    myRow=objTable.NewRow();
                //    myRow[0] = po.Id;
                //    myRow[1] = po.Date;
                //    myRow[2] = po.Provider.Name;
                    
                //    objTable.Rows.Add(myRow);
                //}
                //objDataSet.Tables.Add(objTable);
                //objDataSet.WriteXmlSchema("c:/esquema.xsd");
                //objDataSet.WriteXml("c:/dataset.xml");
                Session["dsOrdCompras"] = objDataSet;
                Response.Redirect("reportesordcompras.aspx");
            }
            else
            {
                Label6.Visible = true;
            }
        }
    }
}
