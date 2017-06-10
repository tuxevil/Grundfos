<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculo.aspx.cs" Inherits="Grundfos_Despiece.Calculo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="generar" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        <asp:GridView ID="GridView1" runat="server" PageSize="50">
        </asp:GridView>
        &nbsp;
    </div>
    </form>
</body>
</html>
