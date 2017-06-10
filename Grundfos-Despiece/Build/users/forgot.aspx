<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgot.aspx.cs" Inherits="GrundFos.Despiece.Website.users.forgot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
  <title>[Despiece] Recupero de Contraseña</title>
  <link rel="stylesheet" href="/styles_grundfos.css" type="text/css" />
  <style>html {background: #003366} </style>
</head>
<body class="login">
    <form id="form1" runat="server">
    <div id="LogoBox" class="white"><img src="/images/grundfos_logo.gif" /></div>
    
    <div class="login">
  
        <div class="flash_notice" id="Flash" runat="server"><asp:Literal ID="lblInfo" runat="server" Text="Ingrese su usuario para recibir su nueva contraseña en su correo electronico."></asp:Literal></div>

        <div id="login_dialog" class="login_dialog">

            <div id="user_name_login">
              <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" AnswerLabelText="Respuesta:"
                AnswerRequiredErrorMessage=" " GeneralFailureText=" "
                QuestionFailureText=" "
                QuestionInstructionText=" "
                QuestionLabelText="Pregunta:" QuestionTitleText=" " SubmitButtonText="Continuar"
                SuccessText=" " UserNameFailureText=" "
                UserNameInstructionText=" " UserNameLabelText="Usuario:"
                UserNameRequiredErrorMessage=" " UserNameTitleText=" " OnSendMailError="PasswordRecovery1_SendMailError" OnAnswerLookupError="PasswordRecovery1_AnswerLookupError" OnUserLookupError="PasswordRecovery1_UserLookupError" OnSendingMail="PasswordRecovery1_SendingMail">
                <MailDefinition BodyFileName="~/res/templates/passwordrecovery.htm" IsBodyHtml="True" Priority="High" Subject="Contrase&#241;a"></MailDefinition>
                  <UserNameTemplate>
                    <div><label>Usuario:</label><asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                         ErrorMessage="Usuario requerido." ToolTip="Usuario requerido." ValidationGroup="PasswordRecovery1" Display="Dynamic">*</asp:RequiredFieldValidator></div>
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    <center>
                        <asp:Button ID="SubmitButton" runat="server"  CommandName="Submit" CssClass="button" Text="Enviar" ValidationGroup="PasswordRecovery1" />
                    </center>
                  </UserNameTemplate>
                  <QuestionTemplate>
                      <div style="margin-bottom:10px;">&nbsp<label>Usuario:</label>
                       <asp:Literal ID="UserName" runat="server"></asp:Literal></div>
                       
                       <div style="margin-bottom:10px;">&nbsp<label>Pregunta:</label>
                       <asp:Literal ID="Question" runat="server"></asp:Literal></div>
                       
                       <div style="margin-bottom:10px;">&nbsp<label>Respuesta:</label>
                       <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                            ErrorMessage=" " ToolTip=" " ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator></div>
                            
                       <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                       <center>
                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Continuar" CssClass="button" ValidationGroup="PasswordRecovery1" />
                       </center>
                  </QuestionTemplate>
            </asp:PasswordRecovery>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
