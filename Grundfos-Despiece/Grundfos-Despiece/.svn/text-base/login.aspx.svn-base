<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Grundfos_Despiece.login" Title="Inicio de Sesión" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
  <title>[Despiece] Ingreso</title>
  <link rel="stylesheet" href="/styles_grundfos.css" type="text/css" />
  <style>html {background: #003366} </style>
</head>
<body class="login">
    <form id="form1" runat="server">
    
        <div id="LogoBox" class="white"><img src="/images/grundfos_logo.gif" /></div>
        <div class="login">
             <div class="flash_notice" id="Flash" runat="server"><asp:Literal ID="lblInfo" runat="server" Text="Por favor, complete sus datos para ingresar."></asp:Literal></div>
             
             <div id="login_dialog" class="login_dialog">
                <div id="user_name_login">
                     <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" FailureText=" " LoginButtonText="Iniciar Sesión" PasswordLabelText="Contraseña:" PasswordRequiredErrorMessage="Contraseña requerida." RememberMeText="Recordarme la proxima vez." TitleText="Inicio de Sesión" UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="Usuario requerido." OnLoginError="Login1_LoginError1">
                        <LayoutTemplate>
                             <h2>Usuario</h2>
                              <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                ErrorMessage="Usuario requerido." ToolTip="Usuario requerido." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                              <h2>Contraseña</h2>
                              <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="Contraseña requerida." ToolTip="Contraseña requerida." ValidationGroup="Login1">*</asp:RequiredFieldValidator><br />
                              <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                              <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar" ValidationGroup="Login1" CssClass="button" />
                         </LayoutTemplate>
                    </asp:Login>
                    <div class="extras">
                    <ul>
                      <li><a href="/users/forgot.aspx">Olvidé mi contraseña</a>
                      </li>
                      <li><a href="/users/changepassword.aspx">Cambiar contraseña</a>
                      </li>
                    </ul>
                  </div>
                </div>
            </div>
        </div>
    
  </form>
    
</body>
</html>