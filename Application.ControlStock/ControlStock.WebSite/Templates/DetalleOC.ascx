<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetalleOC.ascx.cs" Inherits="Grundfos.StockForecast.Templates.DetalleOC" %>
<script language="javascript" type="text/javascript">
<!--


// -->
</script>

<table style="width: 800px; height: 150px">
    <tr>
        <td rowspan="3" style="width: 600px">
        <div style="OVERFLOW: auto; height: 150" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
            <asp:Repeater ID="repItems" runat="server" OnItemCommand="repItems_ItemCommand" OnItemDataBound="repItems_ItemDataBound" >
            <HeaderTemplate>
            <table border="0" cellspacing="1" cellpadding="2">
                <tr bgcolor="#0e4b88" class="text2">
                <td width=75>Codigo</td>
                <td width=250>Descripcion</td>
                <td width=60>Cantidad</td>
                <td width=80>Precio Unit.</td>
                <td width=80>Total</td>
                <td width=50>Stock</td>
                <td width=100></td>
                <td width=60>Cantidad Sugerida</td>
                </tr>
            </table>
            </HeaderTemplate>
            <ItemTemplate>
                    <table border="0" cellspacing="1" cellpadding="2" bgcolor="white">
                        <tr runat="server" id="rowLine" class="paginado">
                        <td width=75><%# DataBinder.Eval(Container, "DataItem.ProductCode") %></td>
                        <td width=250><%# DataBinder.Eval(Container, "DataItem.ProductName") %></td>
                        <td width=60><asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Quantity") %>' Width=50></asp:TextBox></td>
                        <td width=80><%# DataBinder.Eval(Container, "DataItem.Price") %></td>
                        <td width=80><%# DataBinder.Eval(Container, "DataItem.TotalPrice") %></td>
                        <td width=50><%# DataBinder.Eval(Container, "DataItem.Stock") %></td>
                        <td width=100><asp:ImageButton ID="btnGuardarInd" ToolTip='<%# DataBinder.Eval(Container, "DataItem.Id") %>' AlternateText="Save" CommandName="Save" Width="15px" Height="15px" runat="server" ImageUrl="~/Images/3floppy_unmount.ico" /><asp:CheckBox ID="CheckBox1" ToolTip='<%# DataBinder.Eval(Container, "DataItem.Id") %>' runat="server" ></asp:CheckBox><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/3floppy_mount.ico" Width="15px" Height="15px" Visible="false" /></td>
                        <td width=60><%# DataBinder.Eval(Container, "DataItem.QuantitySuggested") %></td>
                        </tr>
                    </table> 
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
            </asp:Repeater>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </td>
        <td rowspan="3" valign="top" style="width: 134px">
            <a style="cursor:pointer" onmouseout="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image1','','../images/btn_imp_oc2.gif',1)"><img src="../images/btn_imp_oc.gif" alt="Imprimir OC" name="Image1" width="131" height="21" border="0"></a><br />
            <a style="cursor:pointer" onmouseout="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image2','','../images/btn_cancelar_oc2.gif',1)"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/btn_cancelar_oc.gif" AlternateText="Cancelar OC" Width="131" Height="21" BorderWidth="0" OnClick="ImageButton1_Click" /></a><br />
            <a style="cursor:pointer" onmouseout="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image3','','../images/btn_exp_oc2.gif',1)">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/btn_exp_oc.gif" AlternateText="Exportar OC" Width="131" Height="21" BorderWidth="0" OnClick="ImageButton2_Click" /></a>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ></asp:Label></td>
            
    </tr>
    <tr>
    </tr>
    <tr>
    </tr>
</table>
