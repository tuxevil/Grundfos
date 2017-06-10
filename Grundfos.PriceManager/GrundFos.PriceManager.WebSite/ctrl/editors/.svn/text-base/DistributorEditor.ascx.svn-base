<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DistributorEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.DistributorEditor" %>

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
          <div><label>Descuento</label><asp:TextBox runat="server" ID="txtDiscount" Enabled="false" MaxLength="5" Width="200px" ValidationGroup="form" TabIndex="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDiscount" Display="Dynamic" runat="server" ErrorMessage="*" ControlToValidate="txtDiscount" ValidationGroup="form"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revDisc" runat="server" ErrorMessage="Debe ingresar un porcentaje entre 0 y 99,99." ValidationGroup="form" ControlToValidate="txtDiscount" ValidationExpression = "^\d{0,2}(\,\d{1,2})?$"></asp:RegularExpressionValidator></div>
          <div><label>Contacto</label><asp:TextBox ID="txtContact" runat="server" MaxLength="50" Width="200px" TabIndex="10" Enabled="false"></asp:TextBox></div>
         
          <div><label>Grupo de Precios</label>
                <asp:DropDownList ID="ddlPriceList" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddlPriceList_SelectedIndexChange" Width="205px" TabIndex="15"></asp:DropDownList>
                <asp:HyperLink runat="server" ID="lnkPriceList"></asp:HyperLink>
          </div>
          
          <asp:UpdatePanel runat="server" ID="upPriceList" UpdateMode="Conditional">
                <ContentTemplate>
                      
                      <div><label>Fecha de publicación de Grupo de Precios</label><asp:Label ID="lblListPub" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
                      <div><label>Fecha de vigencia de Grupo de Precios</label><asp:Label ID="lblListVigency" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger  ControlID="ddlPriceList" EventName="SelectedIndexChanged" />
                </Triggers>
          </asp:UpdatePanel>
          
          <div><label>Tipo de Canal de Ventas</label><asp:DropDownList ID="ddlType" runat="server" Width="205px" TabIndex="20"></asp:DropDownList></div>
          <div><label>País</label><asp:DropDownList runat="server" ID="ddlCountry" Width="205" Enabled="false" TabIndex="25"></asp:DropDownList></div>
          <div><label>Condición de Venta</label><asp:DropDownList runat="server" ID="ddlSaleConditions" Width="205" Enabled="false" TabIndex="30"></asp:DropDownList></div>
          <div><label>Estado</label><asp:Label ID="lblStatus" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          </fieldset>
          <fieldset>
          <div><label>Teléfono</label><asp:Label ID="lblPhone" runat="server" Enabled="false" TabIndex="3"></asp:Label></div>
          <div><label>Condición de Pago</label><asp:DropDownList runat="server" ID="ddlPaymentTerm" Width="205" Enabled="false" TabIndex="35"></asp:DropDownList></div>
          <div><label>Dirección</label><asp:Label ID="lblAddress" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Fax</label><asp:Label ID="lblFax" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Código de Impuesto de Venta</label><asp:Label ID="lblSalesTaxCode" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Término de Venta de Scala</label><asp:Label ID="lblScalaPaymentTerm" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label runat="server" id="ttlSalePrevYear">Ventas del Año anterior</label><asp:Label ID="lblSalePrevYear" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label runat="server" id="ttlSaleYTD">Ventas de este Año</label><asp:Label ID="lblSaleYTD" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label runat="server" id="ttlProfitYTD">Ganancias de este Año</label><asp:Label ID="lblProfitYTD" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Comentario</label><asp:Label ID="lblComment" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Código de País de Scala</label><asp:Label ID="lblScalaCountryCode" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Nombre Completo</label><asp:Label ID="lblCompleteName" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>Impuesto a Exportación de Cliente</label><asp:Label ID="lblImpExpCustomer" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label>E-Mail Alternativo</label><asp:TextBox runat="server" Width="200px" ID="txtAltMail" Enabled="false" TabIndex="40"></asp:TextBox>
               <asp:RegularExpressionValidator ID="revAltMail" runat="server" ErrorMessage="Ingrese el E-Mail correctamente." ControlToValidate="txtAltMail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ValidationGroup="form"></asp:RegularExpressionValidator></div>
          <div><label>E-Mail</label><asp:Label ID="lblMail" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
        </fieldset>
        
       <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="45" />
        </center>

    </div>
