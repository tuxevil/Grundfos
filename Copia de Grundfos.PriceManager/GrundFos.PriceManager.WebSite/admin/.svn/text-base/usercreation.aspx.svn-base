<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="usercreation.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.usercreation" Title="Price Manager - Creación de Usuarios"%>

<asp:Content ContentPlaceHolderID="cplMain" ID="content1" runat="server">
    
    <div class="create" >
  
        <div class="flash_notice" id="Flash" runat="server"><asp:Literal ID="lblConfirmacion" runat="server" Text="Por favor complete los datos del nuevo usuario." ></asp:Literal></div>

        <div id="login_dialog" class="login_dialog">

            <div id="user_name_login">
                  <h2>Usuario</h2>
                  <asp:TextBox ID="txtUsername" runat="server" ValidationGroup="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtUsername" ValidationGroup="Username"></asp:RequiredFieldValidator><h2>Contraseña</h2>
                  <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="Password" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" ValidationGroup="Password"></asp:RequiredFieldValidator><br />
                  <h2>Confirmar Contraseña</h2>
                <asp:TextBox ID="txtPassword2" runat="server" ValidationGroup="Password" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtPassword2" ValidationGroup="Password"></asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="valPassword" runat="server" 
   ControlToValidate="txtPassword"
   ErrorMessage="La contraseña debe ser de 4 caracteres como mínimo"
   ValidationExpression=".{4}.*" Font-Size="Small" /><br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword2"
                    ControlToValidate="txtPassword" ErrorMessage="La confirmación no coincide con la contraseña" ValidationGroup="Password" Font-Size="Small"></asp:CompareValidator>
                <br />
                  <h2>E-Mail</h2>
                  <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="Email" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="Email"></asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Ingrese un E-Mail válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="Email" Font-Size="Small"></asp:RegularExpressionValidator>
                <br />
                
                  <asp:Button ID="btnSubmit" runat="server" Text="Crear" CssClass="button" OnClick="btnSubmit_Click" />&nbsp&nbsp&nbsp<a href="/admin/">Cerrar</a>
            </div>

        </div>
    </div>
</asp:Content>