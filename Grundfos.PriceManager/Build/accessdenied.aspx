<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accessdenied.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.accessdenied" Title="Price Manager Advanced - Acceso Denegado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link rel="stylesheet" href="/css/main.css" type="text/css" />
  <style>html {background: #003366} </style>
</head>
<body class="login">
    <form id="form1" runat="server">
    <div id="LogoBox" class="white"><img src="/img/grundfos_logo.gif" /></div>
    <div class="login" style=" width:440px">
        <div class="flash_alert" id="Flash" runat="server" style=" width: 400px"><asp:Literal ID="lblInfo" runat="server" Text="Usted no cuenta con acceso a esta pagina."></asp:Literal><br />
        </div>
    <a href="javascript:history.back()">Volver</a>
    </div>
    </form>
</body>
</html>
