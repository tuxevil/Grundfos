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
  
        <div class="flash_notice" id="Flash" runat="server"><asp:Literal ID="lblInfo" runat="server" Text="Ingrese su usuario para recibir su contraseña."></asp:Literal></div>

        <div id="login_dialog" class="login_dialog">

            <div id="user_name_login">
                <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" OnUserLookupError="PasswordRecovery1_UserLookupError" GeneralFailureText="Su intento por recuperar su contraseña no fue satisfactoria. Por favor intentelo de nuevo." QuestionFailureText="Su respuesta no se pudo verificar. Por favor intentelo de nuevo." UserNameFailureText="No pudismos acceder a su información. Por favor intentelo de nuevo." OnSendingMail="PasswordRecovery1_SendingMail">
                    <UserNameTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0">
                                        
                                        <tr>
                                            <td align="right">
                                                <h2><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label></h2></td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="Usuario requerido." ToolTip="Usuario requerido." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: red">
                                                <asp:Literal ID="FailureText" runat="server" Visible="false" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Enviar" CssClass="button" ValidationGroup="PasswordRecovery1" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </UserNameTemplate>
                    <SuccessTemplate>
                                  <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                      <tr>
                                          <td>
                                              <table border="0" cellpadding="0">
                                                  <tr>
                                                      <td>
                                                      </td>
                                                  </tr>
                                              </table>
                                          </td>
                                      </tr>
                                  </table>
                              </SuccessTemplate>
                </asp:PasswordRecovery>
                
                  <div class="extras">
                    <ul>
                      <li><strong>Ayuda:</strong>&nbsp;<a href="/login.aspx">Inicio de Sesión</a>
                      </li>
                    </ul>
                  </div>

            </div>

        </div>
    </div>
    </form>
</body>
</html>
