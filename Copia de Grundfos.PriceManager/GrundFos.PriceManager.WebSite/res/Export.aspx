<%@ Page Language="C#" EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.res.Export" Title="Untitled Page" %>
<html>
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:GridView ID="grdProductList" runat="server" AllowPaging="false" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="Both" BorderColor="Black">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BorderColor="Black" BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="Code" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="95px" HeaderText="Código" />
                <asp:BoundField DataField="Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="600px" HeaderText="Descripción"/>
                <asp:BoundField DataField="PriceCurrency" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" HeaderText="Moneda"/>
                <asp:BoundField DataField="Price" ItemStyle-Width="110px" DataFormatString="{0:0.00}" HtmlEncode="false" ItemStyle-HorizontalAlign="Right" HeaderText="Precio de Lista"/>
            </Columns>
            <PagerStyle BorderColor="Black" BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BorderColor="Black" BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BorderColor="Black" BackColor="#e1e0e0" Font-Bold="True" ForeColor="#666666" />
            <EditRowStyle BorderColor="Black" BackColor="#999999" />
            <AlternatingRowStyle BorderColor="Black" BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </form>
</body>
</html>
