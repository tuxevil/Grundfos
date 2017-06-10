<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newuser.aspx.cs" Inherits="Grundfos_Despiece.newuser" Title="Creacion de Cuentas" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

 <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
  <title>[Price Manager] Cambio de Contraseña</title>
  <link rel="stylesheet" href="/styles_grundfos.css" type="text/css" />
  <style>html {background: #003366} </style>

<script language="javascript" type="text/javascript" src="/js/jquery-1.3.1.min.js"></script>
<script language="javascript" type="text/javascript">
        $(document).ready(function() { });
     </script> 
</head>

 <body class="login">
    <form id="form1" runat="server">
        <div id="LogoBox" class="white"><img src="/images/grundfos_logo.gif" /></div>
    
    <div class="login">
                <div class="flash_notice" id="Flash" runat="server"><asp:Literal ID="lblInfo" runat="server" Text="Creación de Cuenta"></asp:Literal></div>

        <div id="login_dialog" class="login_dialog">
            <div id="user_name_login">
            
           <asp:CreateUserWizard ID="CreateUserWizard" runat="server" AnswerLabelText="Respuesta de Seguridad:"
            AnswerRequiredErrorMessage="Respuesta de Seguridad requerida." CancelButtonText="Cancelar"
            CompleteSuccessText="La cuenta ha sido creada exitosamente." ConfirmPasswordCompareErrorMessage="La contraseña y la confirmacion deben coincidir."
            ConfirmPasswordLabelText="Confirmar Contraseña:" ConfirmPasswordRequiredErrorMessage="Confirmación de Contraseña requerida."
            ContinueButtonText="Continuar" ContinueDestinationPageUrl="~/administration/default.aspx"
            CreateUserButtonText="Crear Usuario" DuplicateEmailErrorMessage="El e-mail ingresado ya se encuentra en uso, ingrese uno diferente."
            DuplicateUserNameErrorMessage="Ingrese un usuario diferente." EmailRegularExpressionErrorMessage="Ingrese un e-mail diferente."
            EmailRequiredErrorMessage="E-mail requerido." FinishCompleteButtonText="Finalizar"
            FinishDestinationPageUrl="~/despiece/Default.aspx" FinishPreviousButtonText="Anterior"
            InvalidAnswerErrorMessage="Ingrese una respuesta de seguridad diferente."
            InvalidEmailErrorMessage="Ingrese un e-mail válido." InvalidPasswordErrorMessage="Longitud máxima de contraseña: {0}."
            InvalidQuestionErrorMessage="Ingrese una pregunta de seguridad diferente." PasswordLabelText="Contraseña:"
            PasswordRegularExpressionErrorMessage="Ingrese una contraseña diferente." PasswordRequiredErrorMessage="Contraseña requerida."
            QuestionLabelText="Pregunta de Seguridad:" QuestionRequiredErrorMessage="Pregunta de Seguridad requerida."
            StartNextButtonText="Siguiente" StepNextButtonText="Siguiente" StepPreviousButtonText="Anterior"
            UnknownErrorMessage="Su cuenta no ha sido creada, reinténtelo." UserNameLabelText="Usuario:"
            UserNameRequiredErrorMessage="Usuario requerido." CancelDestinationPageUrl="~/administration/default.aspx" DisplayCancelButton="True" OnCreatedUser="CreateUserWizard_CreatedUser" OnCreateUserError="CreateUserWizard_CreateUserError">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" Title="Creaci&#243;n de Cuentas">
                    <ContentTemplate>
                        <h2>Usuario</h2>
                       <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            ErrorMessage="Usuario requerido." ToolTip="Usuario requerido." ValidationGroup="CreateUserWizard2">*</asp:RequiredFieldValidator>
                                <h2>Contraseña</h2>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Contraseña requerida." ToolTip="Contraseña requerida." ValidationGroup="CreateUserWizard2">*</asp:RequiredFieldValidator>
                           <h2>Confirmar Contraseña</h2>
                           <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                           ErrorMessage="Confirmación de Contraseña requerida." ToolTip="Confirmación de Contraseña requerida."
                           ValidationGroup="CreateUserWizard2">*</asp:RequiredFieldValidator>
                           <h2>E-mail</h2>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="E-mail requerido." ToolTip="E-mail requerido." ValidationGroup="CreateUserWizard2">*</asp:RequiredFieldValidator>
                            <h2>Pregunta de Seguridad</h2>
                            <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                        ErrorMessage="Pregunta de Seguridad requerida." ToolTip="Pregunta de Seguridad requerida."
                                        ValidationGroup="CreateUserWizard2">*</asp:RequiredFieldValidator>
                            <h2>Respuesta de Seguridad</h2>
                             <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                        ErrorMessage="Respuesta de Seguridad requerida." ToolTip="Respuesta de Seguridad requerida."
                                        ValidationGroup="CreateUserWizard2">*</asp:RequiredFieldValidator>
                                
                            
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="La contraseña y la confirmacion deben coincidir."
                                        ValidationGroup="CreateUserWizard2"></asp:CompareValidator>
                        
                    </ContentTemplate><CustomNavigationTemplate>
<table cellspacing="5" border="0"">
	<tr align="right">
		<td align="center" colspan="0"><asp:Button runat="server" CommandName="MoveNext" Text="Crear Usuario" CssClass="button" ValidationGroup="CreateUserWizard" ID="StepNextButton"></asp:Button>
</td><td align="center" colspan="0"><asp:Button runat="server" CausesValidation="False" CommandName="Cancel" CssClass="button" Text="Cancelar" ValidationGroup="CreateUserWizard" ID="CancelButton"></asp:Button>
</td>
	</tr>
</table>
</CustomNavigationTemplate>
                </asp:CreateUserWizardStep><asp:CompleteWizardStep runat="server"><ContentTemplate>
                <TABLE border=0><TR><TD align=center colSpan=2></TD></TR><TR><TD></TD></TR><TR><TD align=right colSpan=2><asp:Button id="ContinueButton" runat="server" Text="Continuar" ValidationGroup="CreateUserWizard" CommandName="Continue" CssClass="button" CausesValidation="False"></asp:Button> </TD></TR></TABLE>
</ContentTemplate></asp:CompleteWizardStep>
                
            </WizardSteps>
            <NavigationStyle HorizontalAlign="Center" />
        </asp:CreateUserWizard>
        </div>
    </div>
    </div>
</form>
</body>
</html>
