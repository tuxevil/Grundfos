<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Grundfos_Despiece._Default" Title="Despiece de Productos Ensamblados" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="box">
                    <h1>Búsqueda de stock del Producto</h1>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="BotonBuscar">
                        <table style="width: 550px;margin-top:10px; margin-bottom:10px;">
                           <tr valign="top">
                                <td style="height: 41px" colspan="2">
                                    <label>Producto</label>&nbsp</td>
                                <td style="width: 121px; height: 41px;">
                                    <asp:TextBox ID="TextBox1" runat="server" Width="200px" TabIndex="1" ValidationGroup="busqueda" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><br />&nbsp
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" TabIndex="3">
                                        <asp:ListItem Selected="True" Value="1">&nbsp Descripci&#243;n &nbsp&nbsp</asp:ListItem>
                                        <asp:ListItem Value="2">&nbsp C&#243;digo</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="TextBox1" ErrorMessage="No se realizó la búsqueda por falta de datos." ValidationGroup="busqueda"></asp:RequiredFieldValidator>
                                    
                                </td>
                                
                                <td style="width: 163px; text-align: left; height: 41px;">
                                &nbsp<asp:Button ID="BotonBuscar" runat="server" OnClick="BotonBuscar_Click" CssClass="button" ValidationGroup="busqueda" Text="Búsqueda de Productos" />
                                    
                                </td>
                           </tr>
                        </table>
                    </asp:Panel>
                    
                    <div class="form">
                <fieldset>
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="BotonSeleccionar">
                        <div>
                            <asp:ListBox ID="ListBox2" runat="server" CssClass="text4" Rows="5" Width="500px" TabIndex="4" Height="120px"></asp:ListBox>
                        </div>
                        <asp:Button ID="BotonSeleccionar" Text="Consultar Stock" runat="server" CssClass="button" OnClick="BotonSeleccionar_Click" />
                    
                    
                    </asp:Panel>
                    
                </fieldset>
             </div>
                    </div>
                </asp:View>
                
                <asp:View ID="View2" runat="server">
                        <div class="box">
                            <div>
                            <fieldset style="float:right; margin: 10px 10px 0px 0px;">
                                <asp:LinkButton ID="ImageButton1" runat="server" Text="Volver" OnClick="ImageButton1_Click" />
                            </fieldset>
                            <h1>
                                <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
                            </h1>
                            </div>
                     <asp:Panel ID="pnlView2" runat="server" DefaultButton="BotonConsultarStock">
                            <%--<div style="margin-top:10px; margin-bottom:10px; margin-left:10px;">
                                <asp:Button ID="ImageButton1" runat="server" Text="Volver" CssClass="button" OnClick="ImageButton1_Click" />
                            </div>--%>
                            
                            <tr>
                                &nbsp<td align="right" style="text-align: right"><label ID="Label2" runat="server" >Fecha:</label></td>
                                <td align="right" style="text-align: left;" ><asp:TextBox ID="TextBox2" runat="server" TabIndex="6" ValidationGroup="Consulta" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp</td>
                            
                                <td align="left" style="text-align: right;"><label ID="Label3" runat="server">Cantidad:</label></td>
                                <td style="text-align: left; width: 147px;"><asp:TextBox ID="TextBox3" runat="server" TabIndex="7" ValidationGroup="Consulta" MaxLength="5" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp</td>
                            
                                <td style="width: 7px; text-align: left"><asp:Button ID="BotonConsultarStock" runat="server" OnClick="BotonConsultarStock_Click" ValidationGroup="Consulta" CssClass="button" Text="Consultar Stock" /></td>
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Ingrese la fecha de hoy o posterior." Type="Date" ValidationGroup="Consulta"></asp:RangeValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Ingrese un número mayor a 0" MaximumValue="99999" MinimumValue="1" Type="Integer" ValidationGroup="Consulta"></asp:RangeValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="TextBox3" ErrorMessage="Ingrese una cantidad." ValidationGroup="Consulta"></asp:RequiredFieldValidator>
                            </tr>
                    </asp:Panel>
                    
    <div class="form" style="margin-top:15px;">   
        <fieldset>
            <asp:GridView ID="GridView1" CssClass="maingrid" runat="server" Width="350px" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="Fecha" ApplyFormatInEditMode="True" DataField="Fecha" DataFormatString="{0:d}" HeaderText="Fecha" HtmlEncode="False" />
                    <asp:BoundField AccessibleHeaderText="Cantidad" DataField="Cantidad" HeaderText="Cantidad" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="Label7" runat="server" Text="Plazo de Entrega: Mínimo 10 días" Visible="False"></asp:Label>
        </fieldset>
    </div>

                    
                    </div>
                    


                </asp:View>
            
            </asp:MultiView>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday" TargetControlID="TextBox2" Format="dd/MM/yyyy" ></cc1:CalendarExtender>

</asp:Content>
