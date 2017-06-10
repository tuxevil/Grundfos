<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteLineEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.QuoteLineEditor" %>
<%@ Register Assembly="ProjectBase.WebControls" Namespace="ProjectBase.WebControls"  TagPrefix="pbc" %>
<asp:UpdatePanel runat = "server" UpdateMode="Conditional" ChildrenAsTriggers="true" ID="upDce">
    <ContentTemplate>

    <tr>
        <td style="width:80px; text-align:center;"><asp:LinkButton runat="server" ID="lnkEdit" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton></td>
        <td style="width:200px;"><asp:Label runat="server" ID="lblCode" ></asp:Label></td>
        <td style="width:300px; text-align:left;"><asp:Label runat="server" ID="lblDescription"></asp:Label></td>
        <td style="width:250px;"><asp:Label runat="server" ID="lblPL"></asp:Label></td>
        <td style="width:250px;"><asp:Label runat="server" ID="lblPV"></asp:Label></td>
        <td style="width:50px;"><asp:Label runat="server" ID="lblQuantity"></asp:Label></td>
        <td style="width:150px;"><asp:Label runat="server" ID="lblDeliveryTime"></asp:Label></td>
        <td style="width:70px; text-align:left;"><asp:Label runat="server" ID="lblIncoterm"></asp:Label></td>
        <td style="width:250px;"><asp:Label runat="server" ID="lblSubtotal"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="9" style="padding:0px" >
            <script language="javascript" type="text/javascript">
            $(document).ready(function() {
                 
                 $("#<%=txtQuantity.ClientID%>_txtFrom").blur(
                    function() 
                    { 
                        CalculateSubTotal("#<%=txtQuantity.ClientID%>_txtFrom", 
                            "#<%=lblPV.ClientID%>", 
                            "#<%=lblSubtotal.ClientID%>", 
                            "#<%=lblcurrency.ClientID%>",
                            "#<%=lblQuantity.ClientID%>");
                    });
                    
                $("#<%=txtListPrice.ClientID%>_txtFrom").blur(
                    function() {
                        CalculateAdminInfo("#<%=lblPV.ClientID%>", 
                            "#<%=lblTpNum.ClientID%>", 
                            "#<%=txtListPrice.ClientID%>_txtFrom", 
                            "#<%=lblCtr.ClientID%>_lblFirst",  
                            "#<%=lblIndex.ClientID%>_lblFirst", 
                            "#<%=lblGrpNum.ClientID%>", 
                            "#<%=lblcurrency.ClientID%>",
                            "#<%=lblPL.ClientID%>",
                            "#<%=txtQuantity.ClientID%>_txtFrom",
                            "#<%=lblSubtotal.ClientID%>",
                            "#<%=lblQuantity.ClientID%>",
                            "#<%=hidMinPL.ClientID%>",
                            "#<%=hidMaxPL.ClientID%>",
                            "#<%=hidMinCtr.ClientID%>",
                            "#<%=hidMinIndex.ClientID%>",
                            "#<%=btnSave.ClientID%>",
                            "#<%=hidOriginalPl.ClientID%>");
                    });
                    
                    CalculateAdminInfo("#<%=lblPV.ClientID%>", 
                            "#<%=lblTpNum.ClientID%>", 
                            "#<%=txtListPrice.ClientID%>_txtFrom", 
                            "#<%=lblCtr.ClientID%>_lblFirst",  
                            "#<%=lblIndex.ClientID%>_lblFirst", 
                            "#<%=lblGrpNum.ClientID%>", 
                            "#<%=lblcurrency.ClientID%>",
                            "#<%=lblPL.ClientID%>",
                            "#<%=txtQuantity.ClientID%>_txtFrom",
                            "#<%=lblSubtotal.ClientID%>",
                            "#<%=lblQuantity.ClientID%>",
                            "#<%=hidMinPL.ClientID%>",
                            "#<%=hidMaxPL.ClientID%>",
                            "#<%=hidMinCtr.ClientID%>",
                            "#<%=hidMinIndex.ClientID%>",
                            "#<%=btnSave.ClientID%>",
                            "#<%=hidOriginalPl.ClientID%>");
            });
            
            </script>
            <input id="lblcurrency" runat="server" type="hidden" value="false" />
            <input id="lblTpNum" runat="server" type="hidden" value="false" />
            <input id="lblGrpNum" runat="server" type="hidden" value="false" />
            <input id="hidMinPL" runat="server" type="hidden" value="false" />
            <input id="hidMaxPL" runat="server" type="hidden" value="false" />
            <input id="hidMinCtr" runat="server" type="hidden" value="false" />
            <input id="hidMinIndex" runat="server" type="hidden" value="false" />
            <input id="hidOriginalPl" runat="server" type="hidden" value="false" />
            <div runat="server" id="divInsideFields" class="hideme">
                <fieldset style="margin-left:0px;">
                    <table>
                        <tr>
                            <td style="border:0;"><pbc:SubmitButton runat="server" ID="btnSave" Text="Guardar" OnClick="btnSave_Click" CssClass="button" /></td>
                            <td style="border:0;">
                                <div>
                                    <div class="grideditor"><label style="width:auto;" runat="server" id="lblIPL">PL</label> <pbc:LightDataField ID="txtListPrice" Label="PL" Type="Number" NumberType="Decimal" runat="server"  Width="10px" MaxLength="10" IsRequired="true" TabIndex="1" /></div>
                                    <div class="grideditor"><label style="width:auto;" runat="server" id="lblIQuantity" >Cantidad</label><pbc:LightDataField runat="server" ID="txtQuantity" Type="Number" NumberType="Integer" Label="Cantidad" MaxLength="4"  IsRequired="true" TabIndex="5" /></div>
                                    <div class="grideditor"><label style="width:auto; font-weight:bold;" runat="server" id="lblICtr" >CTR:</label><pbc:LightDataField runat="server" ID="lblCtr" Type="label" Label="CTR"   /></div>
                                    <div class="grideditor"><label style="width:auto;font-weight:bold;" runat="server" id="lblIIndex" >Index:</label><pbc:LightDataField runat="server" ID="lblIndex" Type="label" Label="Index" /></div>
                                    <div class="grideditor""><label style="width:auto;font-weight:bold;" runat="server" id="lblITp" >TP:</label><pbc:LightDataField runat="server" ID="lblTP" Type="Label" Label="TP"  /></div>
                                    <div class="grideditor"><label style="width:auto;font-weight:bold;" runat="server" id="lblIGrp" >GRP:</label><pbc:LightDataField runat="server" ID="lblGrp" Type="label" Label="Grp" /></div>
                                </div>
                                <div>
                                    <div class="grideditor"><label style="width:auto;" runat="server" id="lblIIncoterm">Incoterm</label><pbc:LightDataField runat="server" ID="ddlIncoterm" Type="DropdownList" Label="Incoterm" IsRequired="true" /></div>
                                    <div class="grideditor"><label style="width:auto;" runat="server" id="lblIDeliveryTime" >Plazo de Entrega</label><pbc:LightDataField runat="server" ID="ddlDeliveryTime" Type="DropdownList" Label="Plazo de Entrega" IsRequired="true" /></div>
                                    <div class="grideditor"><pbc:LightDataField runat="server" ID="ddlDeliveryTerm" Type="DropdownList"  IsRequired="true"/></div>
                               </div>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </td>
    </tr>
    </ContentTemplate>
</asp:UpdatePanel>