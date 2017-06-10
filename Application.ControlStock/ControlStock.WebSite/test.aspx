<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Grundfos.StockForecast.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1"
            runat="server" OnClick="Button1_Click" Text="Search by Group" Width="164px" /><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click"
                    Text="Search by Location" Width="164px" />
        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Style="z-index: 102;
            left: 535px; position: absolute; top: 249px" Text="Borrar Estadisticas" Width="127px" />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Style="z-index: 101;
            left: 524px; position: absolute; top: 290px" Text="Transactions" Width="125px" />
        &nbsp;&nbsp;
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="0">Purchases</asp:ListItem>
            <asp:ListItem Value="1">Sales</asp:ListItem>
        </asp:RadioButtonList><asp:Button ID="Button3" runat="server" Text="Search by Month" OnClick="Button3_Click" />
        &nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Search by Week" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Get Orders by Month" /><br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;</div>
    </form>
</body>
</html>
