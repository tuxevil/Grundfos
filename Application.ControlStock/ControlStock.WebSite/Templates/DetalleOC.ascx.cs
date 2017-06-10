using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PartnerNet.Business;
using PartnerNet.Common;
using PartnerNet.Domain;

namespace Grundfos.StockForecast.Templates
{
    public partial class DetalleOC : System.Web.UI.UserControl
    {
        public int POId
        {
            get { return (ViewState["POId"] != null) ? (int)ViewState["POId"] : 0; }
            set { ViewState["POId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadInformation()
        {
            LoadInformation(POId);
        }

        private void LoadInformation(int id)
        {
            PurchaseOrder oc = ControllerManager.PurchaseOrder.GetById(id);

            IList<PurchaseOrderItem> ocList = ControllerManager.PurchaseOrderItem.GetPurchaseOrderItemList(oc);

            IList<PurchaseOrderItemInformation> poiinfo = new List<PurchaseOrderItemInformation>();

            foreach (PurchaseOrderItem item in ocList)
            {
                Grundfos.ScalaConnector.Product prodscala = Grundfos.ScalaConnector.ControllerManager.Product.GetProductInfo(item.Product.ProductCode);
                PurchaseOrderItemInformation temp = new PurchaseOrderItemInformation();
                temp.Id = item.Id;
                temp.ProductName = item.Product.Description;
                temp.Quantity = item.Quantity;
                temp.Price = prodscala.PurchasePrice;
                temp.TotalPrice = temp.Price * temp.Quantity;
                temp.Stock = prodscala.StockQ;
                temp.ProductCode = item.Product.ProductCode;
                temp.Status = Convert.ToInt32(item.PurchaseOrderItemStatus);
                temp.QuantitySuggested = item.QuantitySuggested;

                poiinfo.Add(temp);
            }
            Label1.Text = id.ToString();

            repItems.DataSource = poiinfo;
            repItems.DataBind();
            
            //GridView1.DataSource = poiinfo;
            //GridView1.DataBind();
        }

        protected void repItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Save")
            {
                IList<PurchaseOrderItem> selectedpoi = new List<PurchaseOrderItem>();
                PurchaseOrderItem poi = ControllerManager.PurchaseOrderItem.GetById(Convert.ToInt32(((ImageButton)e.Item.FindControl("btnGuardarInd")).ToolTip));
                selectedpoi.Add(poi);

                int quantity = Convert.ToInt32(((TextBox)e.Item.FindControl("TextBox1")).Text);
                CheckBox chkstatus = (CheckBox)e.Item.FindControl("CheckBox1");
                int status = 0;
                if(chkstatus.Checked == false)
                    status = 1;
                ControllerManager.PurchaseOrderItem.UpdatePOI(selectedpoi, quantity, (PurchaseOrderItemStatus)status);
                Image save = (Image) e.Item.FindControl("Image1");
                save.Visible = true;
                LoadInformation(POId);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            IList<PurchaseOrder> selectedpo = new List<PurchaseOrder>();

            PurchaseOrder po = ControllerManager.PurchaseOrder.GetById(Convert.ToInt32(Label1.Text));
            selectedpo.Add(po);
                
            ControllerManager.PurchaseOrder.ChangeStatus(selectedpo, (PurchaseOrderStatus)3);
        }

        protected void repItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            if (((PurchaseOrderItemInformation)e.Item.DataItem).Status == 0)
                ((CheckBox)e.Item.FindControl("CheckBox1")).Checked = true;
            else 
                ((CheckBox) e.Item.FindControl("CheckBox1")).Checked = false;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            IList<PurchaseOrder> selectedpo = new List<PurchaseOrder>();

            PurchaseOrder po = ControllerManager.PurchaseOrder.GetById(Convert.ToInt32(Label1.Text));
            selectedpo.Add(po);

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

    }
}