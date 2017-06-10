<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="Grundfos.StockForecast.control_panel.details" Title="Detalle de Alertas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <table width="99%" border="0" cellspacing="0" cellpadding="0">
        <tr class="fdo_tit">
            <td colspan=2><asp:Label ID="lblAlertName" runat="server" CssClass="text2" Font-Bold="true" Font-Size="Medium" ></asp:Label></td>
        </tr>
        <tr>
            <td align="center"><a href="/control-panel" onmouseout="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image9','','../images/btn_volver2.gif',1)"><img src="../images/btn_volver.gif" alt="Volver" name="Image9" width="60" height="21" hspace="5" border="0"></a></td>
            <td align="center"><asp:LinkButton runat="server" ID="btnExportToExcel" CssClass="text4" Text="Exportar" OnClick="btnExportToExcel_Click" Visible ="true" /></td>
        </tr>
    </table>
    <asp:Panel ID="pnSeguimientoOc" runat="server" Visible="False">
        <table width="99%" cellspacing=0>
            <tr bgcolor="#e3e3e3">
                <td style="width:100px;"></td>
                <td>
                    <asp:Label ID="Label6" CssClass="text1" runat="server" Text="Status"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAlert1Status" runat="server" Width="100px">
                        <asp:ListItem Value="0">Todas</asp:ListItem>
                        <asp:ListItem Value="1">No Confirmadas</asp:ListItem>
                        <asp:ListItem Value="2">Confirmadas</asp:ListItem>
                        <asp:ListItem Value="3">En Tránsito</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label7" CssClass="text1" runat="server" Text="Cod. Proveedor"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProvider" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label11" CssClass="text1" runat="server" Text="Producto"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProduct" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
                </td>
                <td style="width:100px;"></td>
            </tr>
            <tr bgcolor="#e3e3e3">
                <td></td>
                <td>
                    <asp:Label ID="Label13" CssClass="text1" runat="server" Text="Licencia"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAlert1Licence" runat="server" Width="100px">
                        <asp:ListItem Value="0">Todas</asp:ListItem>
                        <asp:ListItem Value="1">Sí</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label9" CssClass="text1" runat="server" Text="Desde"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtAlert1From" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAlert1From"
                    ErrorMessage="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$"></asp:RegularExpressionValidator></td>
                <td>
                    <asp:Label ID="Label12" CssClass="text1" runat="server" Text="Ord. Compra"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPurchaseOrder" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr bgcolor="#e3e3e3">
                <td></td>
                <td>
                    <asp:Label ID="Label8" CssClass="text1" runat="server" Text="Modo de Envío"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlWayOfDelivery" runat="server" Width="100px">
                        <asp:ListItem Value="-1">Todas</asp:ListItem>
                        <asp:ListItem Value="0">N/D</asp:ListItem>
                        <asp:ListItem Value="1">Marítimo</asp:ListItem>
                        <asp:ListItem Value="2">Aéreo</asp:ListItem>
                        <asp:ListItem Value="3">Courrier</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;<asp:Label ID="Label10" CssClass="text1" runat="server" Text="Hasta"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAlert1Until" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAlert1Until"
                    ErrorMessage="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$"></asp:RegularExpressionValidator></td>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="btnAlert1Search" runat="server" ImageUrl="../images/btn_buscar.gif" AlternateText="Buscar" Width="59" Height="21" BorderWidth="0" OnClick="btnAlert1Search_Click" />
                </td>
                <td></td>
            </tr>
        </table>
        <ajaxToolkit:CalendarExtender ID="CalendarAlert1Desde" runat="server" TargetControlID="txtAlert1From" Format="dd/MM/yyyy">
        </ajaxToolkit:CalendarExtender>
        <ajaxToolkit:CalendarExtender ID="CalendarAlert1Hasta" runat="server" TargetControlID="txtAlert1Until" Format="dd/MM/yyyy">
        </ajaxToolkit:CalendarExtender>
    <div style="position: relative;">
    <asp:GridView ID="GVSeguimientoOc" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" CssClass="text1" ForeColor="#333333" GridLines="None"
        PageSize="25" OnPageIndexChanging="GVOcConfirmadasNoEntregadas_PageIndexChanging" AllowSorting="True" OnSorting="GVOcConfirmadasNoEntregadas_Sorting" OnRowDataBound="GVOcConfirmadasNoEntregadas_RowDataBound" Width="99%">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="PurchaseOrderCode" SortExpression="PurchaseOrderCode" HeaderText="OC" />
            <asp:BoundField DataField="PurchaseOrderProviderCode" HeaderText="Cod. Prov" SortExpression="PurchaseOrderProviderCode" />
            <asp:HyperLinkField DataNavigateUrlFields="ProductCode" DataNavigateUrlFormatString="~/product-list/default.aspx?productcode={0}"
                DataTextField="ProductCode" SortExpression="Product.ProductCode" HeaderText="Producto" />
            <asp:BoundField DataField="ProductDescription" HeaderText="Descripci&#243;n" SortExpression="Product.Description"/>
            <asp:BoundField DataField="Quantity" SortExpression="Quantity" HeaderText="Cantidad" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="ArrivalDate" SortExpression="ArrivalDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Confirmaci&#243;n" />
            <asp:BoundField DataField="PurchaseOrderDate" SortExpression="PurchaseOrderDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Creada" />
            <asp:BoundField DataField="GAP" SortExpression="GAP" HeaderText="GAP" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="WayOfDelivery" SortExpression="WayOfDelivery" HeaderText="Modo Env&#237;o" />
            <asp:BoundField DataField="Type" SortExpression="Type" HeaderText="Status" />
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
        <asp:Label ID="lblTotalCountAlert1" runat="server" CssClass="TotalCount" Text="testing"></asp:Label>
        </div>
        </asp:Panel>
    <asp:Panel ID="pnStockNegativo" runat="server" Visible="False">
    <div style="position: relative;">
    <asp:GridView ID="GVStockNegativo" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" CssClass="text1" ForeColor="#333333" GridLines="None"
        PageSize="25" OnPageIndexChanging="GVStockNegativo_PageIndexChanging" AllowSorting="True" OnSorting="GVStockNegativo_Sorting" Width="99%">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ProductCode" DataNavigateUrlFormatString="~/product-list/default.aspx?productcode={0}"
                DataTextField="ProductCode" SortExpression="Product.ProductCode" HeaderText="Producto" />
            <asp:BoundField DataField="ProductDescription" SortExpression="Product.Description" HeaderText="Descripci&#243;n" />
            <asp:BoundField DataField="Quantity" SortExpression="Quantity" HeaderText="Cantidad" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="SubTotal" SortExpression="SubTotal" HeaderText="SubTotal" DataFormatString="{0:$ #,##0.000}" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Location" SortExpression="Location" HeaderText="Dep&#243;sito" />
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:Label ID="lblTotalCountAlert3" runat="server" CssClass="TotalCount" Text="testing"></asp:Label>
    </div>
    </asp:Panel>
    <asp:Panel ID="pnSeguimientoOv" runat="server" Visible="False">
    <table width="99%" cellspacing=0>
        <tr bgcolor="#e3e3e3">
            <td style="width:100px;"></td>
            <td>
                <asp:Label ID="Label1" CssClass="text1" runat="server" Text="Status"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlAlert4Status" runat="server" Width="100px">
                    <asp:ListItem Value="0">Todas</asp:ListItem>
                    <asp:ListItem Value="1">Disponible</asp:ListItem>
                    <asp:ListItem Value="2">No Disponible</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label4" CssClass="text1" runat="server" Text="Desde"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtAlert4From" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAlert4From"
                    ErrorMessage="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$"></asp:RegularExpressionValidator>
            </td>
            <td style="width: 59px">
                <asp:Label ID="Label5" CssClass="text1" runat="server" Text="Hasta"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtAlert4Until" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAlert4Until"
                    ErrorMessage="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$"></asp:RegularExpressionValidator>
            </td>
            <td align="center">
                <asp:ImageButton ID="btnAlert4Search" runat="server" ImageUrl="../images/btn_buscar.gif" AlternateText="Buscar" Width="59" Height="21" BorderWidth="0" OnClick="btnAlert4Search_Click" />
            </td>
            <td style="width:100px;"></td>
        </tr>
        <tr bgcolor="#e3e3e3">
            <td></td>
            <td>
                <asp:Label ID="Label14" CssClass="text1" runat="server" Text="Ordenes"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlOVType" runat="server" Width="100px">
                    <asp:ListItem Selected="True" Value="000">Todas</asp:ListItem>
                    <asp:ListItem Value="000018">Ventas</asp:ListItem>
                    <asp:ListItem Value="000051">Ensamblado</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label3" CssClass="text1" runat="server" Text="Producto"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtAlert4Product" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label2" CssClass="text1" runat="server" Text="Cliente"></asp:Label>
            </td>
            <td colspan="2" align="left">
                <asp:DropDownList ID="ddlClient" runat="server" Width="250px">
                </asp:DropDownList>
            </td>
            <td style="width:100px;"></td>
        </tr>
    </table>
    <ajaxToolkit:CalendarExtender ID="CalendarAlert4Desde" runat="server" TargetControlID="txtAlert4From" Format="dd/MM/yyyy">
    </ajaxToolkit:CalendarExtender>
    <ajaxToolkit:CalendarExtender ID="CalendarAlert4Hasta" runat="server" TargetControlID="txtAlert4Until" Format="dd/MM/yyyy">
    </ajaxToolkit:CalendarExtender>
    <div style="position: relative;">
    <asp:GridView ID="GVSeguimientoOV" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" CssClass="text1" ForeColor="#333333" GridLines="None"
        PageSize="25" OnPageIndexChanging="GVNoCumplimentadas_PageIndexChanging" AllowSorting="True" OnSorting="GVNoCumplimentadas_Sorting" OnRowDataBound="GVNoCumplimentadas_RowDataBound" Width="99%">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="SaleOrderCode" SortExpression="SaleOrderCode" HeaderText="OV" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="ProductCode" DataNavigateUrlFormatString="~/product-list/default.aspx?productcode={0}"
                DataTextField="ProductCode" SortExpression="Product.ProductCode" HeaderText="Producto" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="CustomerCode" SortExpression="CustomerCode" HeaderText="Cliente" />
            <asp:BoundField DataField="ProductDescription" SortExpression="Product.Description" HeaderText="Descripci&#243;n" />
            <asp:BoundField DataField="Quantity" SortExpression="Quantity" HeaderText="Cantidad" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="SaleOrderDeliveryDate" SortExpression="SaleOrderDeliveryDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Requerida" />
            <asp:BoundField DataField="PurchaseOrderArrivalDate" SortExpression="PurchaseOrderArrivalDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Confirmaci&#243;n" />
            <asp:BoundField DataField="GAP" SortExpression="GAP" HeaderText="GAP" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Type" SortExpression="Type" HeaderText="Status" />
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:Label ID="lblTotalCountAlert4" runat="server" CssClass="TotalCount" Text="testing"></asp:Label>
    </div>
    </asp:Panel>
    &nbsp;
    <asp:Panel ID="pnReposicionDiferente" runat="server" Visible="False">
        <center>
            <asp:CheckBoxList ID="cblFilters" runat="server" CssClass="text1" RepeatDirection="Horizontal" Width="750px" AutoPostBack="True" OnSelectedIndexChanged="cblFilters_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True">Mostrar Normales</asp:ListItem>
                <asp:ListItem Value="1">Articulos Ocultos</asp:ListItem>
                <asp:ListItem Value="2">Bajo Costo</asp:ListItem>
                <asp:ListItem Value="3">Nivel de rep scala = 0</asp:ListItem>
                <asp:ListItem Value="4">Con Licencia</asp:ListItem>
            </asp:CheckBoxList>
        </center>
        <div style="position: relative;">
        <asp:GridView ID="GVReposicionDiferente" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" CssClass="text1" ForeColor="#333333" GridLines="None"
        PageSize="25" AllowSorting="True" OnPageIndexChanging="GVReposicionDiferente_PageIndexChanging" OnSorting="GVReposicionDiferente_Sorting" OnRowDataBound="GVReposicionDiferente_RowDataBound" OnRowCommand="GVReposicionDiferente_RowCommand" Width="99%" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ProductCode" DataNavigateUrlFormatString="~/product-list/default.aspx?productcode={0}"
                DataTextField="ProductCode" SortExpression="Product.ProductCode" HeaderText="Producto" />
            <asp:BoundField DataField="ProductName" HeaderText="Descripci&#243;n" SortExpression="Product.Description" />
            <asp:BoundField DataField="Group" HeaderText="Grupo" SortExpression="Product.Group" />
            <asp:BoundField DataField="Sales" HeaderText="VTA. 12M" SortExpression="Sales" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="CuatrimestralSales" HeaderText="Niv. Prop" AccessibleHeaderText="Nivel de Reposici&#243;n Propuesto" SortExpression="Sales" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="SaleMonths" HeaderText="Vida del Producto(Meses)" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="RepositionLevel" HeaderText="Niv. Repos."
                SortExpression="Product.RepositionLevel" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Result" HeaderText="Diferencia %" SortExpression="Result" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Precio" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Provider" HeaderText="Proveedor" />
            <asp:BoundField DataField="OrderInfo" HeaderText="Info OV (Cant. Ordenes/%/N. Orden)" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" CommandName="Show/Hide" DataTextField="Id" Text="Cambiar" />
            <asp:ButtonField ButtonType="Button" CommandName="LowCost" DataTextField="Id" Text="Bajo Costo" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:Label ID="lblTotalCountAlert6" runat="server" CssClass="TotalCount" Text="testing"></asp:Label>
    </div>
    </asp:Panel>
    <br />
    &nbsp;
</asp:Content>
