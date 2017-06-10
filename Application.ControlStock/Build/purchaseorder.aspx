<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="purchaseorder.aspx.cs" Inherits="Grundfos.StockForecast.purchaseorder" Title="Ordenes de Compras Generadas" %>
<%@ Register Src="Templates/Pager.ascx" TagName="Pager" TagPrefix="uc2" %>
<%@ Register Src="Templates/DetalleOC.ascx" TagName="Detalle" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div style="text-align: center">
    <table width="100%" border="0" cellspacing="7" cellpadding="0">
        <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr class="fdo_tit">
                <td><img src="images/tit_listado_articulos.gif" alt="Listado de artículos" width="172" height="27"></td>
                </tr>
                <tr bgcolor="#e3e3e3">
                <td align="center" valign="middle">
                <br>
                <table width="90%" border="0" cellspacing="3" cellpadding="0">
                    <tr>
                        <td align="right" class="text1" style="height: 24px">
                            Código OC.</td>
                        <td class="text1" style="height: 24px"><asp:TextBox style="Z-INDEX: 102;" id="TextBox1" runat="server" Font-Size="Small"></asp:TextBox></td>
                        <td align="right" style="height: 24px"><span class="text1">Fecha de OC.&nbsp;</span></td>
                        <td style="height: 24px"><asp:TextBox ID="TextBox2" runat="server" Width="80px"></asp:TextBox></td>
                        <td width="64" style="height: 24px"></td>
                        <td width="136" style="height: 24px"><p><a style="cursor:pointer" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image11','','images/btn_op_filt2.gif',1)"><img src="Images/btn_op_filt.gif" alt="Opciones de Filtrado" name="Image11" width="131" height="21" border="0"></a></p></td>
                        <td width="131" style="height: 24px"><a style="cursor:pointer" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image13','','images/btn_imp_oc_s2-07.gif',1)"><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="images/btn_imp_oc_s-07.gif" AlternateText="Generar orden de compra" Width="131" Height="21" BorderWidth="0" /></a></td>
                    </tr>
                    <tr>
                        <td align="right" class="text1">
                            Proveedor</td>
                        <td class="text1">
                        <asp:DropDownList style="Z-INDEX: 104;" id="DropDownList1" runat="server" Font-Size="Small" Width="150px">
                            <asp:ListItem Value="0">--Proveedor--</asp:ListItem>
                        </asp:DropDownList></td>
                        <td align="right"><span class="text1">Estado</span></td>
                        <td><span class="text1">
                        <asp:DropDownList style="Z-INDEX: 108;" id="DropDownList3" runat="server" Font-Size="Small" Width="80px">
                            <asp:ListItem Value="0">--Estado--</asp:ListItem>
                        </asp:DropDownList>
                        </span></td>
                        <td width="64"><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="images/btn_buscar.gif" AlternateText="Buscar" Width="59" Height="21" BorderWidth="0" OnClick="ImageButton6_Click" /></td>
                        <td width="136"><a style="cursor:pointer" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image12','','images/btn_imp_oc_s2.gif',1)"><img src="images/btn_imp_oc_s.gif" alt="Imprimir OC sel" name="Image12" width="131" height="21" border="0"></a></td>
                        <td width="131"><a style="cursor:pointer" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image14','','images/btn_canc_oc_s2.gif',1)"><asp:ImageButton ID="Image14" runat="server" ImageUrl="images/btn_canc_oc_s.gif" AlternateText="Cancelar orden de compra" Width="131" Height="21" BorderWidth="0" OnClick="Image14_Click" /></a></td>
                    </tr>
                </table>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
            </td>
            </tr>
            <tr>
            <td><img src="images/fin_tabla_busq.gif" width="986" height="6"></td>
            </tr>
        </table>
        <br>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
        <td class="none" align="center">
            
            <uc2:Pager ID="Pager2" runat="server" />
            
        </td>
        </tr>
        <tr>
        <td align="center"><img src="images/linea_arriba.gif" width="819" height="5"><br>
            <br>
        </td>
        </tr>
        <tr>
        <td><asp:ScriptManager ID="ScriptManager1" runat="server" />            &nbsp;
            <asp:Repeater ID="repItems" runat="server" OnItemCommand="repItems_ItemCommand" OnItemDataBound="repItems_ItemDataBound"  >
            <HeaderTemplate>
            <table border="0" cellspacing="1" cellpadding="2">
                <tr bgcolor="#0e4b88" class="text2">
                <td width=30></td>
                <td width=50>Codigo</td>
                <td width=180>Fecha de OC</td>
                <td width=300>Proveedor</td>
                <td width=70>Cant. Art</td>
                <td width=70>Importe</td>
                <td width=180>Fecha Arribo</td>
                <td width=70>Origen</td>
                <td width=100><asp:LinkButton ID="LinkButton1" Text="Marcar Todos" OnClick="LinkButton1_Click" runat="server" CssClass="text2"></asp:LinkButton></td>
                </tr>
            </table>
            </HeaderTemplate>
            <ItemTemplate>
                    <table border="0" cellspacing="1" cellpadding="2">
                        <tr runat="server" id="rowLine" class="paginado">
                        <td width=30 align="center">
                        <asp:ImageButton CommandName="Expand" ID="Image1" runat="server" imageurl="~/images/whiteExpandIcon.gif" /></td>               
                        <td width=50><%# DataBinder.Eval(Container, "DataItem.Id") %></td>
                        <td width=180><%# DataBinder.Eval(Container, "DataItem.Orderdate") %></td>
                        <td width=300><%# DataBinder.Eval(Container, "DataItem.Provider") %></td>
                        <td width=70><%# DataBinder.Eval(Container, "DataItem.Totalcount") %></td>
                        <td width=70><%# DataBinder.Eval(Container, "DataItem.Amount") %></td>
                        <td width=180><%# DataBinder.Eval(Container, "DataItem.Arrivaldate")%></td>
                        <td width=70><%# DataBinder.Eval(Container, "DataItem.Type") %></td>
                        <td width=100><asp:CheckBox ID="CheckBox1" ToolTip='<%# DataBinder.Eval(Container, "DataItem.Id") %>' runat="server"></asp:CheckBox></td>
                        </tr>
                    </table> 
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="False" runat="server">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Image1" />
                </Triggers>
                    <ContentTemplate>
                        <asp:Panel ID="C" runat="server" BackColor="#c7dbe9" >
                            <uc1:Detalle ID="ucDetalle" Visible="false" runat="server" />
                        </asp:Panel>
                        <ajaxToolkit:CollapsiblePanelExtender ID="CPE" runat="server" TargetControlID="C"
                            ExpandControlID="Image1" CollapseControlID="Image1" Collapsed="True" ImageControlID="Image1"
                            ExpandedImage="~/Images/whiteCollapseIcon.gif"
                            CollapsedImage="~/Images/whiteExpandIcon.gif"
                        />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ItemTemplate>
            <FooterTemplate>
            <table>
                <tr>
                <td width=30></td>
                <td width=80></td>
                <td width=300></td>
                <td width=175></td>
                <td width=70></td>
                <td width=70></td>
                <td width=70></td>
                <td width=50></td>
                <td width=50></td>
                <td width=70></td>
                <td width=100 class="text2"><asp:LinkButton ID="LinkButton2" Text="Desmarcar Todos" OnClick="LinkButton2_Click" runat="server" CssClass="text2" ForeColor="blue"></asp:LinkButton></td>
                </tr>
            </table>
            </FooterTemplate>
            </asp:Repeater>
        </td>
        </tr>
        <tr>
        <td align="center"><br>
            <img src="images/linea_abajo.gif" width="819" height="5">
        </td>
        </tr>
        <tr>
        <td align="center">
            
        <uc2:Pager ID="Pager1" runat="server" Visible="true" />
        </td>
        </tr>
        </table>
    <p>&nbsp;</p></td>
    </tr>
    </table>
<%---------------------------------------------------------------------------%>
        
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="Seleccione un Filtro!" Font-Bold="True" Font-Size="Small" OnServerValidate="CustomValidator1_ServerValidate"
            Style="z-index: 110; left: 241px; position: absolute; top: 170px"></asp:CustomValidator>
       <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
            Style="z-index: 116; left: 751px; position: absolute; top: 240px" Text="Por favor seleccione al menos 1 producto!"
            Visible="False"></asp:Label>
            
        <div id="modalQuitarSeleccion" style="z-index: 1000">
        <div class="modalBackground">
        </div>
        <div class="modalContainer" style="left: 50%; top: 50%">
            <div class="modal" style="left: -148px; top: -148px">
                <div class="modalTop">Cancelar Orden de Compra</div>
                <div class="modalBody">
                    <asp:Button runat="server" ID="btnCancelarOC" Text="Si" CausesValidation="false" Width="68px" />
                    <input id="Button16" type="button" value="No" onclick="hideModal('modalQuitarSeleccion')" Style="width: 68px;" /></div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
