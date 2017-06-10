<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.addproduct" Title="Price Manager - Agregar Producto" %>
<%@ Register Src="../ctrl/PagerSelections.ascx" TagName="PagerSelections" TagPrefix="uc2" %>
<%@ Register Src="../ctrl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
   <div class="page_header"> 
       <h1>Agregar Producto</h1> 
   </div>
                
   <div class="content" >
     <div id="prodcut" runat="server" style="height:200px;"> 
        <div id="productForm" class="box" style="width:44%; float:left; height:150px;">
           <h1>Producto</h1>
               <div>
                 <fieldset style="float:left; width:40%;">
                  <p><label >Código</label>&nbsp&nbsp&nbsp<asp:TextBox ID="txtCode" MaxLength="50" runat="server" Width="200px" TabIndex="1"></asp:TextBox></p>
                  <p><label >Descripción</label>&nbsp&nbsp&nbsp<asp:TextBox ID="txtDescripcion" runat="server" MaxLength="1024" Width="201px" TabIndex="2"></asp:TextBox></p>
                  </fieldset>
               </div>
               <div>
               <fieldset style="float:right;">
                  <p><asp:RadioButtonList ID="rblProductType" runat="server" AutoPostBack="false" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">50 Hz</asp:ListItem>
                        <asp:ListItem Value="2">60 Hz</asp:ListItem>
                    </asp:RadioButtonList>&nbsp;</p>
               </fieldset>
               </div>
            <fieldset>
              <asp:Label ID="lblError" runat="server" Visible="false"  ForeColor="Red" ></asp:Label>
            </fieldset>
     </div>
     <div id="priceForm" class="box" style="height:150px; width:55%; float:right;">
                      <h1>Precio:</h1>
                      <div >
                         <fieldset style="float:right; width:50%;">
                          <p><label >Compra(TP)</label>&nbsp&nbsp<asp:TextBox ID="txtPricePurchase" Height="18px" runat="server" Width="50px" MaxLength="12" TabIndex="7"></asp:TextBox>&nbsp&nbsp<asp:DropDownList id="ddlPurchaseCurrency" runat="server" Font-Size="Small" Width="50px" TabIndex="8"></asp:DropDownList></p>
                          <asp:RegularExpressionValidator ID="revTP" runat="server" ErrorMessage="Ingrese un número válido."  ControlToValidate="txtPricePurchase" ValidationExpression="[0-9]+(\.(([0-9][0-9][0-9])|([0-9][0-9])|([0-9]))?)|[0-9]+(\,(([0-9][0-9][0-9])|([0-9][0-9])|([0-9]))?)?" display="dynamic"></asp:RegularExpressionValidator>
                         </fieldset>
                       </div>
                       <div> 
                           <fieldset>
                             <p><label >Lista(PL)</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtPriceList" Height="18px" runat="server" Width="50px" MaxLength="12" TabIndex="9"></asp:TextBox>&nbsp&nbsp<asp:DropDownList id="ddlListCurrency" runat="server" Font-Size="Small" Width="50px" TabIndex="10"></asp:DropDownList></p>
                             <asp:RegularExpressionValidator ID="revPL" runat="server" ErrorMessage="Ingrese un número válido."  ControlToValidate="txtPriceList" ValidationExpression="[0-9]+(\.(([0-9][0-9][0-9])|([0-9][0-9])|([0-9]))?)|[0-9]+(\,(([0-9][0-9][0-9])|([0-9][0-9])|([0-9]))?)?" display="dynamic"></asp:RegularExpressionValidator>
                             <p><label >Sugerido(GRP)</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtPriceSuggested" Height="18px" runat="server" Width="50px" MaxLength="12" TabIndex="5"></asp:TextBox>&nbsp&nbsp<asp:DropDownList id="ddlSuggestedCurrency" runat="server" Font-Size="Small" Width="50px" TabIndex="6"></asp:DropDownList></p>
                             <asp:RegularExpressionValidator ID="revGRP" runat="server" ErrorMessage="Ingrese un número válido."  ControlToValidate="txtPriceSuggested" ValidationExpression="[0-9]+(\.(([0-9][0-9][0-9])|([0-9][0-9])|([0-9]))?)|[0-9]+(\,(([0-9][0-9][0-9])|([0-9][0-9])|([0-9]))?)?" display="dynamic"></asp:RegularExpressionValidator>
                          </fieldset>
                      </div>
           <asp:Label ID="lblErrorPrice" runat="server" Visible="false"  ForeColor="Red" ></asp:Label>
      </div>
      <div style="width:100%;">
        <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" CssClass="button" TabIndex="15" />&nbsp&nbsp&nbsp<a href="modifyProduct.aspx">Cerrar</a>
        </center>
      </div>
   
   </div>
</div>
      
</asp:Content>
