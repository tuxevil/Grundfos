<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.Products.addproduct" Title="Price Manager - Agregar Producto" %>
<%@ Register Src="~/ctrl/PagerSelections.ascx" TagName="PagerSelections" TagPrefix="uc2" %>
<%@ Register Src="~/ctrl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">

</asp:Content>
     
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
   <script type="text/javascript">

    function CheckCodes(src, args)
    {
        var grund = document.getElementById('<%=txtCode.ClientID%>');
        var prov = document.getElementById('<%=txtProvider.ClientID%>');
        if ((grund.value == null || grund.value == '') && (prov.value == null || prov.value == ''))
        {
          args.IsValid=  false;
        }  
        else
        {
          args.IsValid = true;
        }
    }
    </script> 

        <div id="priceForm" class="box" style="float:right; width:50%">
                  <h1>Precios</h1>
                  <div class="form">
                     <fieldset>
                      <div><label>Compra(TP)</label><asp:DropDownList ID="ddlPurchase" runat="server"></asp:DropDownList>&nbsp
                           <asp:TextBox ID="txtPricePurchase" runat="server" MaxLength="12" TabIndex="7" Enabled="true"></asp:TextBox>
                           <asp:CompareValidator ID="cvPurchaseMin" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero mayor a 0." Operator="GreaterThanEqual" ControlToValidate="txtPricePurchase" ValueToCompare="0" ValidationGroup="valFields" Type="Double"></asp:CompareValidator>
                           <asp:CompareValidator ID="cvPurchase" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero." ValidationGroup="valFields" Operator="DataTypeCheck" ControlToValidate="txtPricePurchase" Type="Double"></asp:CompareValidator></div>
                      <div><label >Sugerido(GRP)</label><asp:DropDownList ID="ddlSuggested" runat="server"></asp:DropDownList>&nbsp
                           <asp:TextBox ID="txtPriceSuggested" runat="server" Enabled="true" ValidationGroup="valFields" MaxLength="12" TabIndex="5"></asp:TextBox>
                           <asp:CompareValidator ID="cvSuggestMin" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero mayor a 0." Operator="GreaterThanEqual" ControlToValidate="txtPriceSuggested" ValueToCompare="0" ValidationGroup="valFields" Type="Double"></asp:CompareValidator>
                           <asp:CompareValidator ID="cvSuggested" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero." Operator="DataTypeCheck" ControlToValidate="txtPriceSuggested" ValidationGroup="valFields" Type="Double"></asp:CompareValidator></div>
                      <div><label >Lista(PL)</label><asp:DropDownList ID="ddlList" runat="server"></asp:DropDownList>&nbsp
                           <asp:TextBox ID="txtPriceList" runat="server" MaxLength="12" ValidationGroup="valFields" Enabled="true" TabIndex="9"></asp:TextBox>
                           <asp:CompareValidator ID="cvListMin" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero mayor a 0." Operator="GreaterThanEqual" ControlToValidate="txtPriceList" ValueToCompare="0" ValidationGroup="valFields" Type="Double"></asp:CompareValidator>
                           <asp:CompareValidator ID="cvList" runat="server" Display="Dynamic" ErrorMessage="Debe ingresar un numero." ValidationGroup="valFields" Operator="DataTypeCheck" ControlToValidate="txtPriceList" Type="Double"></asp:CompareValidator></div>
                      <div><label>Index</label><asp:Label ID="txtIndex" runat="server" Enabled="false"></asp:Label></div>
                      <div><label>Venta(PV)</label><asp:Label ID="txtPriceSell" runat="server"  MaxLength="12" TabIndex="7" Enabled="false"></asp:Label></div>
                      <div><label>CTM</label><asp:Label ID="txtCTM" runat="server" Enabled="false"></asp:Label></div>
                      <div><label>CTR</label><asp:Label ID="txtCTR" runat="server" Enabled="false" ></asp:Label></div>
                     </fieldset>
                  </div>
          </div>

        <div id="productForm" class="box" style="width:48%;">
           <h1>Producto</h1>
               <div class="form">
                <fieldset>
                  <div><label>Código</label><asp:TextBox ID="txtCode" MaxLength="50" ValidationGroup="valFields" runat="server" Width="200px" TabIndex="1"></asp:TextBox></div>
                  <div><label>Código Producto en Proveedor</label><asp:TextBox ID="txtProvider" MaxLength="50" ValidationGroup="valFields" runat="server" Width="201px" TabIndex="2"></asp:TextBox></div>
                  <div><label>Modelo</label><asp:TextBox ID="txtModel" runat="server" MaxLength="50" Width="201px" TabIndex="2"></asp:TextBox></div>
                  <div><label>Descripción</label><asp:TextBox ID="txtDescripcion" runat="server" MaxLength="256" Width="201px" TabIndex="2"></asp:TextBox></div>
                  <div><label>Proveedor</label><asp:DropDownList runat="server" ID="ddlProvider" Visible="false"></asp:DropDownList>
                  <asp:ListBox ID="lstProviders" Enabled="false" runat="server"></asp:ListBox></div>
                 <div><label>Frequencia</label><asp:RadioButtonList ID="rblProductType" runat="server" CssClass="radio" AutoPostBack="false">
                        <asp:ListItem Value="Hz50">50 Hz</asp:ListItem>
                        <asp:ListItem Value="Hz60">60 Hz</asp:ListItem>
                        <asp:ListItem Selected="True" Value="All">50/60 Hz</asp:ListItem>
                    </asp:RadioButtonList></div>
                </fieldset>
                <asp:CustomValidator ID="cv1of2" runat="server" ValidationGroup="valFields" Display="Dynamic" ErrorMessage="Por favor, ingrese Código o Código de Proveedor." ClientValidationFunction="CheckCodes" />
                <asp:Label runat= "server" ID="lblError" ForeColor="red" Text="El código ingresado ya existes para ese proveedor." Visible="false"></asp:Label>
            </div>
        </div>
      <div style="width:100%;clear:both">
        <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar" ValidationGroup="valFields" OnClick="btnSave_Click" CssClass="button" TabIndex="15" />&nbsp&nbsp&nbsp<a href="default.aspx">Cerrar</a>
        </center>
      </div>
      <br />
    
</asp:Content>
