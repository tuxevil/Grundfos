<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PriceGroupEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.PriceGroupEditor" %>
<%--<script language="javascript" type="text/javascript" src="/js/UControlpricelist.js"></script>
--%>
    <div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>
    
       <fieldset>
          <div><label>Nombre</label><asp:TextBox runat="server" ID="txtName" Width="200" Enabled="false"></asp:TextBox></div>
          <div><label>Descripción</label><asp:TextBox runat="server" ID="txtDescription" Width="200" Enabled="false" TabIndex="5"></asp:TextBox></div>
          <div><label runat="server" id="ttlDiscount">Descuento</label><asp:TextBox runat="server" CssClass="input pricefield currency" ID="txtDiscount" Enabled="false" MaxLength="8" TabIndex="10"></asp:TextBox>
              <asp:CompareValidator ID="cvdisGt" runat="server" Display="Dynamic" Type="Double" Operator="GreaterThanEqual" ControlToValidate="txtDiscount" ValueToCompare="0" ErrorMessage="Debe ingresar un porcentaje mayor o igual a 0. "></asp:CompareValidator>
              <asp:CompareValidator ID="cvdisLess" runat="server" Display="Dynamic" Type="Double" Operator="LessThan" ControlToValidate="txtDiscount" ValueToCompare="100" ErrorMessage="Debe ingresar un porcentaje menor a 100. "></asp:CompareValidator>
              <asp:RegularExpressionValidator ID="revDisc" runat="server" ErrorMessage="El porcentaje ingresado solo puede tener 2 decimales." ValidationGroup="form" ControlToValidate="txtDiscount" ValidationExpression = "\d+(\,\d{1,2})?"></asp:RegularExpressionValidator>
          </div>
                
          
          <div><label>Moneda</label><asp:Label runat ="server" ID="lblCurrency"></asp:Label>
                <asp:DropDownList runat ="server" ID="ddlCurrency" Width="205" TabIndex="15"></asp:DropDownList></div>
          <div><label>Ajuste de Política (división)</label><asp:TextBox runat="server" ID="txtAdjust" CssClass="input pricefield currency" MaxLength="6" Width="200" TabIndex="20"></asp:TextBox>
               <asp:CompareValidator ID="cvadjustGrt" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un número mayor a 0." Operator="GreaterThan" ControlToValidate="txtAdjust" ValueToCompare="0" ValidationGroup="form" Type="Double"></asp:CompareValidator>
               <asp:CompareValidator ID="cvAdjustLes" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un número menor o igual a 100." Operator="LessThanEqual" ControlToValidate="txtAdjust" ValueToCompare="100" ValidationGroup="form" Type="Double"></asp:CompareValidator>
 
          <div><label>Ajuste de GRP (multiplicación)</label><asp:TextBox ID="txtGRP" runat="server" CssClass="input pricefield currency" MaxLength="6" Width="200px" TabIndex="25"></asp:TextBox>
               <asp:CompareValidator ID="cvgrpgrt" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un número mayor a 0." Operator="GreaterThan" ControlToValidate="txtGRP" ValueToCompare="0" ValidationGroup="form" Type="Double"></asp:CompareValidator>
               <asp:CompareValidator ID="cvGRPless" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un número menor o igual a 100." Operator="LessThanEqual" ControlToValidate="txtGRP" ValueToCompare="100" ValidationGroup="form" Type="Double"></asp:CompareValidator>
              <asp:RequiredFieldValidator ID="rfvPG" Display="Dynamic" runat="server" ErrorMessage="*" ControlToValidate="txtGRP" ValidationGroup="form"></asp:RequiredFieldValidator></div>
       </fieldset>
        
       <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="30" />
        </center>

    </div>
