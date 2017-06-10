<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProviderEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.ProviderEditor" %>

    <div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>

       <fieldset style="float:left; width:48%;">
          <div><label>Código</label><asp:Label ID="lblCode" runat="server" Enabled="false"></asp:Label></div>
          <div><label>Nombre</label><asp:Label ID="lblName" runat="server" Enabled="false"></asp:Label></div>
          <div><label>Descripción</label><asp:TextBox ID="txtDescripcion" runat="server" MaxLength="50" Width="200px" Enabled="false"></asp:TextBox></div>
          <div><label>Ciudad</label><asp:TextBox ID="txtCity" runat="server" MaxLength="50" TabIndex="10" Enabled="false"></asp:TextBox></div>
          <div><label>País</label><asp:DropDownList runat="server" ID="ddlCountry" Width="205" Enabled="false" TabIndex="15"></asp:DropDownList></div>
          <div><label>Condición de Venta</label><asp:DropDownList runat="server" ID="ddlSaleConditions" Width="205" Enabled="false" TabIndex="20"></asp:DropDownList></div>
          <div><label>E-Mail</label><asp:TextBox ID="txtMail" runat="server" MaxLength="50" TabIndex="25" Enabled="false"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revMail" Display="Dynamic" runat="server" ErrorMessage="Ingrese correctamente el mail." ControlToValidate="txtMail" ValidationGroup="form" ValidationExpression="[\w-]+@([\w-]+\.)+[\w-]+"></asp:RegularExpressionValidator></div>
          <%--<div><label>Condición de Compra</label><asp:TextBox ID="txtPurchaseCondition" MaxLength="50" runat="server" TabIndex="3" Enabled="false"></asp:TextBox></div>--%>
          <div><label>Condición de Compra</label><asp:DropDownList runat="server" ID="ddlPurchaseCondition" Width="205" Enabled="false" TabIndex="30"></asp:DropDownList> </div>
          <div><label>Lead Time</label><asp:TextBox ID="txtLeadTime" runat="server" TabIndex="35" MaxLength="15" Enabled="false"></asp:TextBox>
            <asp:CompareValidator ID="cvLeadTime" runat="server" Display="Dynamic" ControlToValidate="txtLeadTime" ValidationGroup="form" ErrorMessage="Ingrese numeros." Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator></div>
          </fieldset>
          <fieldset>
          <div><label>Contacto</label><asp:Label ID="lblContact" runat="server" Width="200px" TabIndex="2" Enabled="false"></asp:Label></div>
          <div><label>Estado</label><asp:Label ID="lblStatus" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Teléfono</label><asp:Label ID="lblPhone" runat="server" Enabled="false" TabIndex="3"></asp:Label></div>
          <div><label>Dirección</label><asp:Label ID="lblAddress" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Fax</label><asp:Label ID="lblFax" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label runat="server" id="ttlPurchPrevYear">Compras del Año anterior</label><asp:Label ID="lblPurchPrevYear" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label runat="server" id="ttlPurchaseYTD">Compras de este Año</label><asp:Label ID="lblPurchaseYTD" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Comentario</label><asp:Label ID="lblComment" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Fecha Último Pedido</label><asp:Label ID="lblLastInvDate" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Código de País de Scala</label><asp:Label ID="lblScalaCountryCode" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Nombre Completo</label><asp:Label ID="lblCompleteName" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Código de Impuesto</label><asp:Label ID="lblTaxCode" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
        </fieldset>
        
       <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="40" />
        </center>

    </div>
