<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Grundfos_Despiece.login" Title="Inicio de Sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    &nbsp;<asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" CssClass="text1" Font-Names="Verdana"
        Font-Size="Small" ForeColor="#333333" DisplayRememberMe="False" FailureText="Su intento de inicio de sesion no fue completado. Por favor intente de nuevo." LoginButtonText="Iniciar Sesión" PasswordLabelText="Contraseña:" PasswordRequiredErrorMessage="Contraseña requerida." RememberMeText="Recordarme la proxima vez." TitleText="Inicio de Sesión" UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="Usuario requerido.">
        <TextBoxStyle Font-Size="0.8em" />
        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
    </asp:Login>
</center>
</asp:Content>
