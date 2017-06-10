<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Grundfos.StockForecast.forecast._default" Title="Forecast" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<%@ Register Assembly="dotnetCHARTING" Namespace="dotnetCHARTING" TagPrefix="dotnetCHARTING" %>
<%@ Import namespace="PartnerNet.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
        <table width="100%" border="0" cellspacing="7" cellpadding="0">
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="28" valign="top"><a href="javascript:history.back()" onmouseout="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image9','','../images/btn_volver2.gif',1)"><img src="../images/btn_volver.gif" alt="Volver" name="Image9" width="60" height="21" hspace="5" border="0"></a></td>
              </tr>
              <tr class="fdo_tit">
                <td><img src="../images/tit_listado_articulos.gif" alt="Listado de artículos" width="172" height="27"></td>
              </tr>
              <tr>
                <td><p><br>
                </p>
                  <table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="50%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td style="width: 460px">
                          <asp:GridView ID="GridView1" runat="server" Width="460px" PageSize="12" AutoGenerateColumns="False" CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                                <FooterStyle BackColor="#0E4B88" CssClass="text2" />
                                <RowStyle BackColor="#ECEBEB" ForeColor="#333333" CssClass="paginado"/>
                                <Columns>
                                    <asp:BoundField DataField="Year" HeaderText="A&#241;o" />
                                    <asp:BoundField DataField="Week" HeaderText="Semana" />
                                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                    <asp:BoundField DataField="Purchase" HeaderText="Compras" />
                                    <asp:BoundField DataField="Sale" HeaderText="Ventas" />
                                    <asp:BoundField DataField="FinalStock" HeaderText="Stock Final" />
                                    <asp:BoundField DataField="Safety" HeaderText="Safety" />
                                    <asp:BoundField DataField="SafetyCoEf" HeaderText="Safety CoEf" />
                                    <asp:BoundField DataField="QuantitySuggested" HeaderText="Cantidad Sugerida" />
                                </Columns>
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#0E4B88" CssClass="text2" Font-Size="X-Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="#E3E3E3" ForeColor="#284775" />
                        </asp:GridView>
                        </td>
                        </tr>
                      </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr class="fdo_controles">
                            <td height="45" align="center"></td>
                          </tr>
                        </table>                        </td>
                      <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                          <td><table width="100%" border="0" cellpadding="8" cellspacing="0">
                            <tr>
                                <td align="center" bgcolor="#4b7fa6" colspan="6">
                                    <span class="text2">Información del Producto</span></td>
                            </tr>
                            <tr>
                                <td bgcolor="#e3e3e3" colspan="1">
                                    <span class="text4">Cod: </span>
                                    <span class="text3"><asp:Label ID="Label12" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label></span>          
                                </td>
                                <td bgcolor="#e3e3e3" colspan="1">
                                   <span class="text4">Articulo:</span>
                                    <span class="text3"><asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label> </span>
                                </td>
                                <td bgcolor="#e3e3e3" colspan="1">
                                   <span class="text4">Proveedor: </span>
                                    <span class="text3"><asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label></span>          
                                </td>
                                <td colspan="3" bgcolor="e3e3e3">
                                <span class="text4">Stock Actual:</span>
                                <span class="text3"><asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label></span> <br>
                                </td>
                              </tr>
                              <tr>
                                  <td bgcolor="#e3e3e3" colspan="1">
                                      <span class="text4">Nivel Rep: </span>
                                      <span class="text3"><asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label></span>
                                  </td>
                                  <td bgcolor="#e3e3e3" colspan="1">
                                     <span class="text4">Punto Ped.:</span>
                                      <span class="text3"><asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label></span>          
                                  </td>
                                  <td bgcolor="#e3e3e3" colspan="1">
                                     <span class="text4">Lead Time: </span>
                                      <span class="text3"><asp:Label ID="Label16" runat="server" Font-Bold="False" Font-Size="Small" ></asp:Label></span>          <span class="text4">
                              </span>
                                  </td>
                                  <td bgcolor="#e3e3e3" colspan="3">
                                      <span class="text4">Safety: </span><span class="text3"><asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="Small" ></asp:Label></span></td>
                              </tr>
                            
                          </table></td>
                        </tr>
                        <tr>
                          <td><table width="100%" border="0" cellpadding="8" cellspacing="1">
                            <tr>
                              <td colspan="6" align="center" bgcolor="#4b7fa6"><span class="text2">Promedios de Ventas<br>
                              </span></td>
                            </tr>
                            <tr>
                              <td align="center" bgcolor="0e4b88" class="text2">Enero</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Febrero</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Marzo</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Abril</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Mayo</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Junio</td>
                            </tr>
                            <tr>
                              <td align="center" bgcolor="e3e3e3" class="paginado">100</td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                            </tr>
                            <tr>
                              <td align="center" bgcolor="0e4b88" class="text2">Julio</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Agosto</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Septiembre</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Octubre</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Noviembre</td>
                              <td align="center" bgcolor="0e4b88" class="text2">Diciembre</td>
                            </tr>
                            <tr>
                              <td align="center" bgcolor="e3e3e3" class="paginado">100</td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                              <td align="center" bgcolor="e3e3e3"><span class="paginado">100</span></td>
                            </tr>
                          </table></td>
                        </tr>
                        <tr>
                          <td style="height: 171px"><chart:webchartviewer id="WebChartViewer1" runat="server" Visible="False" />
                              </td>
                          
                        </tr>
                      </table></td>
                    </tr>
                  </table>
                  </td>
              </tr>

            </table></td>
          </tr>
          
        </table>
</asp:Content>