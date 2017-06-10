<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LookupEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.LookupEditor" %>

    <div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>
    
       <fieldset>
          <div><label>Tipo</label><asp:DropDownList runat ="server" ID="ddlType" Width="205" Enabled="false"></asp:DropDownList></div>
          <div><label>Titulo</label><asp:TextBox ID="txtTitle" runat="server" MaxLength="50" Width="200px" Enabled="false" TabIndex="4"></asp:TextBox></div>
          <div><label>Descripción</label><asp:TextBox ID="txtDescription" runat="server" MaxLength="128" Width="200px" Enabled="false" TabIndex="5"></asp:TextBox>
               <asp:RequiredFieldValidator ID="rfvCurrency" Display="Dynamic" runat="server" ErrorMessage="*" ControlToValidate="txtDescription" ValidationGroup="form"></asp:RequiredFieldValidator></div>
          <div><label>Predeterminado</label><asp:CheckBox ID="chbDefault" runat="server" /></div>
       </fieldset>
        
       <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="15" />
        </center>

    </div>
