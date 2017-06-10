<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="Grundfos.StockForecast.productlist" Title="Listado de Productos" %>
<%@ Import namespace="System.ComponentModel"%>
<%@ Register Src="Templates/Pager.ascx" TagName="Pager" TagPrefix="uc2" %>
<%@ Register Src="Templates/Detalle.ascx" TagName="Detalle" TagPrefix="uc1" %>
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
                        <td align="right" class="text1" style="height: 24px">Descripción</td>
                        <td class="text1" style="height: 24px"><asp:TextBox style="Z-INDEX: 102;" id="TextBox1" runat="server" Font-Size="Small" OnDataBinding="TextBox1_DataBinding"></asp:TextBox></td>
                        <td align="right" style="height: 24px"><span class="text1">Categoría</span></td>
                        <td style="height: 24px">
                        <asp:DropDownList style="Z-INDEX: 107;" id="DropDownList2" runat="server" Font-Size="Small" Width="150px">
                            <asp:ListItem Value="N/A">--Grupo--</asp:ListItem>
                        </asp:DropDownList></td>
                        <td width="64" style="height: 24px"></td>
                        <td width="136" style="height: 24px"><p><a style="cursor:pointer" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image11','','images/btn_agregar_sel2.gif',1)" onclick="revealModal('modalAgregarSeleccion')"><img src="images/btn_agregar_sel.gif" alt="Agregar selección" name="Image11" width="131" height="21" border="0"></a></p></td>
                        <td width="131" style="height: 24px"><a style="cursor:pointer" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image13','','images/btn_generar_com2.gif',1)"><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="images/btn_generar_com.gif" AlternateText="Generar orden de compra" Width="131" Height="21" BorderWidth="0" OnClick="ImageButton5_Click" /></a></td>
                    </tr>
                    <tr>
                        <td align="right" class="text1">Estado</td>
                        <td class="text1">
                        <asp:DropDownList style="Z-INDEX: 104;" id="DropDownList1" runat="server" Font-Size="Small" Width="150px">
                            <asp:ListItem Value="0">--Proveedor--</asp:ListItem>
                        </asp:DropDownList></td>
                        <td align="right"><span class="text1">Selección</span></td>
                        <td><span class="text1">
                        <asp:DropDownList style="Z-INDEX: 108;" id="DropDownList3" runat="server" Font-Size="Small" Width="150px">
                            <asp:ListItem Value="0">--Seleccion--</asp:ListItem>
                        </asp:DropDownList>
                        </span></td>
                        <td width="64"><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="images/btn_buscar.gif" AlternateText="Buscar" Width="59" Height="21" BorderWidth="0" OnClick="ImageButton6_Click" /></td>
                        <td width="136"><a style="cursor:pointer" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image12','','images/btn_quitar_selec2.gif',1)" onclick="revealModal('modalQuitarSeleccion')"><img src="images/btn_quitar_selec.gif" alt="Quitar selección" name="Image12" width="131" height="21" border="0"></a></td>
                        <td width="131"><a style="cursor:pointer" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image14','','images/btn_modificar_saf2.gif',1)" onclick="revealModal('modalCambioSafety')"><img src="images/btn_modificar_saf.gif" alt="Modificar safety" name="Image14" width="131" height="21" border="0"></a></td>
                    </tr>
                </table>
            </td>
            </tr>
            <tr>
            <td><img src="images/fin_tabla_busq.gif" width="986" height="6"></td>
            </tr>
        </table>
        <br>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
        <td align="center">
            
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
                <td width=20></td>
                <td width=75>Codigo</td>
                <td width=300>Articulo</td>
                <td width=175>Proveedor</td>
                <td width=50>Stock</td>
                <td width=50>Nivel Rep.</td>
                <td width=50>Modulo Comp.</td>
                <td width=50>Prom. Ventas</td>
                <td width=50>Lead Time</td>
                <td width=60>Safety</td>
                <td width=100><asp:LinkButton ID="LinkButton1" Text="Marcar Todos" OnClick="LinkButton1_Click" runat="server" CssClass="text2"></asp:LinkButton></td>
                </tr>
            </table>
            </HeaderTemplate>
            <ItemTemplate>
            
                    <table border="0" cellspacing="1" cellpadding="2">
                        <tr runat="server" id="rowLine" class="paginado">
                        <td width=20 align="center">
                        <asp:ImageButton CommandName="Expand" ID="Image1" runat="server" imageurl="~/images/whiteExpandIcon.gif" /></td>               
                        <td width=75><%# DataBinder.Eval(Container, "DataItem.ProductCode") %></td>
                        <td width=300><%# DataBinder.Eval(Container, "DataItem.Description") %></td>
                        <td width=175><%# DataBinder.Eval(Container, "DataItem.Provider") %></td>
                        <td width=50><%# DataBinder.Eval(Container, "DataItem.Stock") %></td>
                        <td width=50><%# DataBinder.Eval(Container, "DataItem.RepositionLevel") %></td>
                        <td width=50><asp:TextBox ID="TextBox5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RepositionPoint") %>' Width=40></asp:TextBox></td>
                        <td width=50 align="center"><%# DataBinder.Eval(Container, "DataItem.SaleAverage") %></td>
                        <td width=50 align="center"><asp:TextBox ID="TextBox3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LeadTime") %>' Width=40></asp:TextBox></td>
                        <td width=60><asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Safety") %>' Width=40></asp:TextBox></td>
                        <td width=100><asp:ImageButton ID="btnGuardarInd" ToolTip='<%# DataBinder.Eval(Container, "DataItem.Id") %>' AlternateText="Save" CommandName="Save" Width="15px" Height="15px" runat="server" ImageUrl="~/Images/3floppy_unmount.ico" /><asp:CheckBox ID="CheckBox1" ToolTip='<%# DataBinder.Eval(Container, "DataItem.Id") %>' runat="server"></asp:CheckBox></td>
                        </tr>
                    </table> 
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="conditional" ChildrenAsTriggers="False" runat="server">
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
            
        <div id="modalCambioSafety" style="z-index: 1000">
        <div class="modalBackground">
        </div>
        <div class="modalContainer">
            <div class="modal">
                <div class="modalTop">Cambio de Safety</div>
                <div class="modalBody">
                    Valor:
				    <asp:TextBox ID="txtChangeSafety" runat="server" Columns="5" Rows="1" TextMode="SingleLine"></asp:TextBox><br />
				    <asp:Button runat="server" ID="Button11" Text="Aceptar" OnClick="Button11_Click" />
				    <input id="Button8" type="button" value="Cancelar" onclick="hideModal('modalCambioSafety')" Style="width: 68px;" /></div>
            </div>
        </div>
    </div>
        <div id="modalAgregarSeleccion" style="z-index: 1000">
        <div class="modalBackground">
        </div>
        <div class="modalContainer">
            <div class="modal">
                <div class="modalTop">Agregar a Seleccion</div>
                <div class="modalBody">
                <asp:DropDownList ID="DropDownList4" runat="server" Font-Size="Small" Width="136px" >
                    <asp:ListItem Value="0">--Seleccion--</asp:ListItem>
                </asp:DropDownList><br />
				    <asp:TextBox ID="TextBox6" runat="server" Columns="5" Rows="1" TextMode="SingleLine" Width="94px" ></asp:TextBox>
                    <span style="font-size: 7pt">NUEVA
                    </span><br />
                    <asp:Button runat="server" ID="Button12" Text="Aceptar" OnClick="Button12_Click" />
                    <input id="Button9" type="button" value="Cancelar" onclick="hideModal('modalAgregarSeleccion')" Style="width: 68px;" /></div>
                </div>
            </div>
        </div>
        <div id="modalQuitarSeleccion" style="z-index: 1000">
        <div class="modalBackground">
        </div>
        <div class="modalContainer" style="left: 50%; top: 50%">
            <div class="modal" style="left: -148px; top: -148px">
                <div class="modalTop">Quitar de Seleccion</div>
                <div class="modalBody">
                <asp:DropDownList ID="DropDownList5" runat="server" Font-Size="Small" Width="136px" >
                    <asp:ListItem Value="0">--Seleccion--</asp:ListItem>
                </asp:DropDownList><br />
                    <asp:Button runat="server" ID="btnQuitarSeleccion" Text="Aceptar" CausesValidation="false" OnClick="Button13_Click" />
                    <input id="Button16" type="button" value="Cancelar" onclick="hideModal('modalQuitarSeleccion')" Style="width: 68px;" /></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
