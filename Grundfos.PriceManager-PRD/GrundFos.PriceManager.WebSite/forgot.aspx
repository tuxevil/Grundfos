<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgot.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.forgot" Title="Price Manager - Recuperación de Contraseña"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
  <title>[Price Manager] Ingreso</title>
  <link rel="stylesheet" href="/css/main.css" type="text/css" />
  <style>html {background: #003366} </style>
</head>
<body class="login">
    <form id="form1" runat="server">
    <div id="LogoBox" class="white"><img src="/img/grundfos_logo.gif" /></div>
    
    <div class="login">
  
        <div class="flash_notice" id="Flash" runat="server"><asp:Literal ID="lblInfo" runat="server" Text="Ingrese su usuario para recibir su nueva contraseña en su correo electronico."></asp:Literal></div>

        <div id="login_dialog" class="login_dialog">

            <div id="user_name_login">
            
                <div><label>Usuario:</label><asp:TextBox runat="server" ID="txtUser" ValidationGroup="valFields"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvUser" runat="server" ErrorMessage="*" ControlToValidate="txtUser" ValidationGroup="valFields" Display="Dynamic"></asp:RequiredFieldValidator></div>
                <center>
                    <asp:Button ID="btnSave" runat="server" Text="Enviar" OnClick="btnSend_Click" CssClass="button" ValidationGroup="valFields" TabIndex="45" />
                </center>
                  <div class="extras">
                    <ul>
                      <li><a href="/login.aspx">Inicio de Sesión</a>
                      </li>
                    </ul>
                  </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
