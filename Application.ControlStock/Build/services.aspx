<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="services.aspx.cs" Inherits="Grundfos.StockForecast.services" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Generar Forecast" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:Button runat="server" ID="btnTest" OnClick="btnTest_Click" Text="Generar OC Automaticas" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Limpiar OC Automaticas"
            Visible="False" />
        <asp:Calendar ID="Calendar1" runat="server" Font-Size="X-Small"></asp:Calendar>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Actualizar Listado de Productos"
            Width="250px" /><br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Actualizar Listado de Proveedores"
            Width="250px" /><br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Generar Transacciones"
            Width="250px" /></div>
    </form>
</body>
</html>
