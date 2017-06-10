<%@ Page Language="C#" MasterPageFile="~/Base.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.Importation.create._default" Title="Prices Manager Advanced - Importación: Nueva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">

    <div class="form">
        <fieldset>
              <div>
                <label>Seleccione Archivo:</label>
                <asp:FileUpload ID="fuArchImp" ValidationGroup="form" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form" runat="server" ControlToValidate="fuArchImp"
                    ErrorMessage="El archivo es obligatorio" Text="*"></asp:RequiredFieldValidator>
              </div>
              <div>
                <label>Caracter separador:</label>
                <asp:DropDownList ID="ddlCharacter" runat="server">
                        <asp:ListItem>;</asp:ListItem>
                        <asp:ListItem>,</asp:ListItem>
                        <asp:ListItem>.</asp:ListItem>
                        <asp:ListItem>:</asp:ListItem>
                        <asp:ListItem>?</asp:ListItem>
                        <asp:ListItem>/</asp:ListItem>
                        <asp:ListItem>|</asp:ListItem>
                    </asp:DropDownList> 
              </div> 
                                 
              <div>
              <label>Tiene Encabezado?</label>
              <asp:CheckBox ID="chkHeader" runat="server" Checked="True" />
              </div>
              
              <div>
              <label>Descripción:</label>
              <asp:TextBox ID="txtDescription" runat="server" MaxLength="50" ValidationGroup="form" Width="256px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="form" ControlToValidate="txtDescription"
                    ErrorMessage="La descripcion es obligatoria" Text="*"></asp:RequiredFieldValidator>
              </div>
            
              <div style="text-align:center">
                  <asp:Button ID="btnUpload" runat="server" Text="Subir" CssClass="button" ValidationGroup="form" OnClick="btnUpload_Click" /> o <a class="close_popup" href="../default.aspx">Volver</a>
              </div>            
              
        </fieldset>
    </div>


</asp:Content>
