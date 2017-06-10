<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.login" Title="Price Manager - Inicio de Sesión"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
  <title>[Price Manager] Ingreso</title>
  <link rel="stylesheet" href="/css/main.css" type="text/css" />
  <style>html {background: #003366} </style>
</head>
<body class="login">
    <form id="form1" runat="server">
    <div id="LogoBox" class="white"><img src="/img/grundfos_logo.gif" /></div>
    
    <div class="login">
  
        <div class="flash_notice" id="Flash" runat="server"><asp:Literal ID="lblInfo" runat="server" Text="Por favor, complete sus datos para ingresar."></asp:Literal></div>

        <div id="login_dialog" class="login_dialog">

            <div id="user_name_login">
                <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx" OnLoginError="Login1_LoginError" >
                  <LayoutTemplate>
                      <h2>Usuario</h2>
                      <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                          ErrorMessage="Usuario Requerido" ToolTip="Usuario Requerido" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                      <h2>Contraseña</h2>
                      <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                          ErrorMessage="Contraseña Requerida" ToolTip="Contraseña Requerida" ValidationGroup="Login1">*</asp:RequiredFieldValidator><br />
                      <label><asp:CheckBox ID="RememberMe" runat="server" CssClass="auto" />Recordarme en este equipo</label><br />
                      <asp:Literal ID="FailureText" runat="server" EnableViewState="False" Visible="false"></asp:Literal>
                      <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar" ValidationGroup="Login1" CssClass="button" />
                  </LayoutTemplate>
                </asp:Login>
                  <div class="extras">
                    <ul>
                      <li><strong>Ayuda:</strong>&nbsp;<a href="/forgot.aspx">Olvidé mi contraseña</a>
                      </li>
                      <li><strong>Ayuda:</strong>&nbsp;<a href="/changepassword.aspx">Cambiar contraseña</a>
                      </li>
                    </ul>
                  </div>

            </div>

        </div>
    </div>
    </form>
    
</body>
</html>
