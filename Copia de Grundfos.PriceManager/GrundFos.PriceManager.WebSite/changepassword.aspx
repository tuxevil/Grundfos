<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.changepassword" Title="Price Manager - Cambiar Contraseña"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

 <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
  <title>[Price Manager] Cambio de Contraseña</title>
  <link rel="stylesheet" href="/css/main.css" type="text/css" />
  <style>html {background: #003366} </style>

<script language="javascript" type="text/javascript" src="/js/jquery-1.3.1.min.js"></script>
<script language="javascript" type="text/javascript">
        $(document).ready(function() { });
     </script> 
</head>
<body class="login">
    
    <form id="form1" runat="server">
    <div id="LogoBox" class="white"><img src="/img/grundfos_logo.gif" /></div>
    
    <div class="login">
  
        <div class="flash_notice" id="Flash" runat="server"><asp:Literal ID="lblInfo" runat="server" Text="Por favor ingrese su antigua y nueva contraseña."></asp:Literal></div>

        <div id="login_dialog" class="login_dialog">

            <div id="user_name_login">
                &nbsp;<asp:ChangePassword ID="ChangePassword1" runat="server" OnChangePasswordError="ChangePassword1_ChangePasswordError" CancelDestinationPageUrl="~/login.aspx" ContinueDestinationPageUrl="~/Default.aspx" DisplayUserName="True" ChangePasswordFailureText="Contraseña incorrecta o confirmacion de contraseña incorrecta. Tamaño minimo de nueva contraseña: {0}. Caracteres no alfanumericos requeridos: {1}." OnChangedPassword="ChangePassword1_ChangedPassword" >
                    <ChangePasswordTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0">
                                        <tr>
                                                      <td align="right">
                                                          <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label></td>
                                                      <td>
                                                          <asp:TextBox ID="UserName" runat="server" Width="150px"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                              ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ChangePassword2">*</asp:RequiredFieldValidator>
                                                      </td>
                                                  </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Antigua Contraseña:</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                    ErrorMessage="Contraseña requerida." ToolTip="Contraseña requerida." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva Contraseña:</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                    ErrorMessage="Nueva contraseña requerida." ToolTip="Nueva contraseña requerida."
                                                    ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar Nueva Contraseña:</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                    ErrorMessage="Confirmación de nueva contraseña requerida." ToolTip="Confirmación de nueva contraseña requerida."
                                                    ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                    ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="La nueva contraseña y su confirmación no coinciden."
                                                    ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: red">
                                                <asp:Literal ID="FailureText" runat="server" Visible="false" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                    Text="Cambiar Contraseña" ValidationGroup="ChangePassword1" CssClass="button" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="CancelLinkButton" runat="server" CausesValidation="False" CommandName="Cancel">Cancelar</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ChangePasswordTemplate>
                    <SuccessTemplate>
                                  <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                                      <tr>
                                          <td>
                                              <table border="0" cellpadding="0">
                                                  <tr>
                                                      <td align="right" colspan="2">
                                                          <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CommandName="Continue"
                                                              Text="Continuar" CssClass="button" />
                                                      </td>
                                                  </tr>
                                              </table>
                                          </td>
                                      </tr>
                                  </table>
                              </SuccessTemplate>
                </asp:ChangePassword>
                  <div class="extras">
                    <ul>
                      <li><strong>Ayuda:</strong>&nbsp;<a href="../forgot.aspx">Olvidé mi contraseña</a>
                      </li>
                    </ul>
                  </div>

            </div>

        </div>
    </div>
    </form>
</body>
</html>
