<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PriceListEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.PriceListEditor" %>

    <div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>

       <fieldset>
          <div><label>Nombre</label><asp:TextBox ID="txtName" MaxLength="50" runat="server" Width="200px" ValidationGroup="form"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvName" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="form"></asp:RequiredFieldValidator></div>
          <div><label>Descripción</label><asp:TextBox ID="txtDescripcion" runat="server" MaxLength="250" Width="200px" TabIndex="5"></asp:TextBox></div>
          <div><label>Tipo de Grupo de Precios</label><asp:DropDownList ID="ddlType" runat="server" Width="205px" TabIndex="10"></asp:DropDownList></div>
          <div><label>Condición de Venta</label><asp:DropDownList ID="ddlIncoterm" Width="205px" runat="server" TabIndex="15"></asp:DropDownList></div>
          <div><label>Frecuencia</label><asp:DropDownList runat="server" ID="ddlFrequency" Width="205px" TabIndex="20"></asp:DropDownList></div>
          <div><label>País</label><asp:DropDownList runat = "server" ID="ddlCountry" Width="205" Visible="false" TabIndex="25"></asp:DropDownList><asp:Label runat="server" id="lblCountry" Visible="false"></asp:Label></div>
          <div><label>Moneda</label>
                <asp:DropDownList runat = "server" ID="ddlCurrency" Width="205" Visible="false" TabIndex="30"></asp:DropDownList>
                <asp:Label runat="server" ID="lblCurrency"></asp:Label>
          </div>
          <div><label runat="server" id="lblTStatus">Estado</label><asp:Label ID="lblStatus" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label runat="server" id="lblTDate">Última Publicación</label><asp:Label ID="lblLastPubDate" runat="server" TabIndex="3" Enabled="false"></asp:Label></div>
          <div><label runat="server" id="lblTDiscount">Descuento</label><asp:Label ID="lblDiscount" runat="server" Enabled="false" TabIndex="3"></asp:Label></div>
        </fieldset>
        
       <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="35" />
        </center>

    </div>
    
    
