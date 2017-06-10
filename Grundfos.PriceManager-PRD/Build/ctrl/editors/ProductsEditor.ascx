<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.ProductsEditor" %>
<%@ Register Assembly="ProjectBase.WebControls" Namespace="ProjectBase.WebControls"  TagPrefix="pbc" %>

<script type="text/javascript">

//    function CheckCodes(src, args)
//    {
//        var grund = document.getElementById('<%=txtCode.ClientID%>');
//        var prov = document.getElementById('<%=txtProvider.ClientID%>');
//        if ((grund.value == null || grund.value == '') && (prov.value == null || prov.value == ''))
//        {
//          args.IsValid=  false;
//        }  
//        else
//        {
//          args.IsValid = true;
//        }
//    }
    
    function CheckCodes(src, args)
    {
        var prov = $("#<%=txtProvider.ClientID%>_txtFrom").val();
        var grund =  $("#<%=txtCode.ClientID%>_txtFrom").val();
        if ((grund == null || grund == '') && (prov == null || prov == ''))
        {
          args.IsValid=  false;
        }  
        else
        {
          args.IsValid = true;
        }
    }
    
    
    </script> 

<div class="box">
    <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
   </h1>
    
    <div style="float:right; width:30%">
        <asp:Image runat="server" ID="imgImage" ImageUrl="/img/" />
    </div>
    
    <div class="form">
            <fieldset>
              <pbc:DataField ID="ddlFrequency" Type="DropdownList" runat="server" Label="Frequencia" Enabled="false" IsRequired="True" TabIndex="0" />  
              <pbc:DataField ID="txtCode" Type="Text" Label="Código" MaxLength="50" runat="server" />
              <pbc:DataField ID="txtModel" Type="Text" Label="Modelo" MaxLength="50" runat="server" />
              <pbc:DataField ID="txtDescripcion" Type="Text" Label="Descripción" MaxLength="50" runat="server" />
              <pbc:DataField ID="txtEAN" Type="Text" Label="EAN" MaxLength="50" runat="server" />
              <pbc:DataField ID="txtDescriptionAlternative" Type="Text" Label="Descripción Alternativa" MaxLength="50" runat="server" />
              <pbc:DataField ID="txtAlternativeModel" Type="Text" Label="Modelo Alternativo" MaxLength="50" runat="server" />
            </fieldset>

           <fieldset id="pricesForm" runat="server">
              <pbc:DataField ID="txtProvider" Type="Text" Label="Código Producto en Proveedor" MaxLength="50" runat="server" />
              <pbc:DataField runat="server" ID="ddlProvider" Type="DropdownList" IsRequired="true" Label="Proveedor" TabIndex="0"  />  
              <div class="item"><label>Compra(TP)</label><asp:DropDownList ID="ddlPurchase" runat="server" TabIndex="45"></asp:DropDownList>&nbsp
                   <asp:TextBox ID="txtPricePurchase" runat="server" MaxLength="12" TabIndex="50" ></asp:TextBox>
                   <asp:CompareValidator ID="cvPurchaseMin" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero mayor a 0." Operator="GreaterThanEqual" ControlToValidate="txtPricePurchase" ValueToCompare="0" ValidationGroup="form" Type="Double"></asp:CompareValidator>
                   <asp:CompareValidator ID="cvPurchase" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero." ValidationGroup="form" Operator="DataTypeCheck" ControlToValidate="txtPricePurchase" Type="Double"></asp:CompareValidator></div>
              <div class="item"><label>Sugerido(GRP)</label><asp:DropDownList ID="ddlSuggested" runat="server" TabIndex="55"></asp:DropDownList>&nbsp
                   <asp:TextBox ID="txtPriceSuggested" runat="server" ValidationGroup="form" MaxLength="12" TabIndex="60"></asp:TextBox>
                   <asp:CompareValidator ID="cvSuggestMin" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero mayor a 0." Operator="GreaterThanEqual" ControlToValidate="txtPriceSuggested" ValueToCompare="0" ValidationGroup="form" Type="Double"></asp:CompareValidator>
                   <asp:CompareValidator ID="cvSuggested" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero." Operator="DataTypeCheck" ControlToValidate="txtPriceSuggested" ValidationGroup="form" Type="Double"></asp:CompareValidator></div>
              <div class="item"><label >Lista(PL)</label><asp:DropDownList ID="ddlList" runat="server" TabIndex="65"></asp:DropDownList>&nbsp
                   <asp:TextBox ID="txtPriceList" runat="server" MaxLength="12" ValidationGroup="form" TabIndex="70"></asp:TextBox>
                   <asp:CompareValidator ID="cvListMin" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un numero mayor a 0." Operator="GreaterThanEqual" ControlToValidate="txtPriceList" ValueToCompare="0" ValidationGroup="form" Type="Double"></asp:CompareValidator>
                   <asp:CompareValidator ID="cvList" runat="server" Display="Dynamic" ErrorMessage="Debe ingresar un numero." ValidationGroup="form" Operator="DataTypeCheck" ControlToValidate="txtPriceList" Type="Double"></asp:CompareValidator></div>
              
              <div class="item"><label >Index</label><asp:Label ID="lblIndex" runat="server" ></asp:Label></div>
              <div class="item"><label >Venta (PV)</label><asp:Label ID="lblPv" runat="server" ></asp:Label></div>
              <div class="item"><label >CTM</label><asp:Label ID="lblCtm" runat="server" ></asp:Label></div>
              <div class="item"><label >CTR</label><asp:Label ID="lblCtr" runat="server" ></asp:Label></div>
              <%--<pbc:DataField ID="txtIndex" Type="Number" Label="Index" NumberType="Decimal" ReadOnly="true" runat="server" />
              <pbc:DataField ID="txtPriceSell" Type="Number" Label="Venta (PV)" NumberType="Currency" ReadOnly="true" runat="server" />
              <pbc:DataField ID="txtCTM"  Type="Number" Label="CTM" NumberType="Currency" ReadOnly="true" runat="server" />
              <pbc:DataField ID="txtCTR" Type="Number" Label="CTR" NumberType="Percentage" ReadOnly="true" runat="server" />--%>
         </fieldset>
         
          <fieldset>
             <pbc:DataField ID="txtObservations" Type="HtmlEditor" Label="Observaciones" runat="server" />
          </fieldset>
    </div>
    
    <div style="width:100%;clear:both">
        <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar" ValidationGroup="form" OnClick="btnSave_Click" CssClass="button" TabIndex="80" />
        </center>
    </div>

</div>
    