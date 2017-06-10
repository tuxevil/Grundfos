<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteLineEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.QuoteLineEditor" %>
<%@ Register Assembly="ProjectBase.WebControls" Namespace="ProjectBase.WebControls"  TagPrefix="pbc" %>
<script language="javascript" type="text/javascript">
$(document).ready(function() {
     $("#<%=txtQuantity.ClientID%>_txtFrom").keyup(
        function() 
        { 
            CalculateSubTotal("#<%=txtQuantity.ClientID%>_txtFrom", 
                "#<%=lblPV.ClientID%>", 
                "#<%=lblSubtotal.ClientID%>", 
                "#<%=lblcurrency.ClientID%>",
                "#<%=lblQuantity.ClientID%>");
        });
        
    $("#<%=txtListPrice.ClientID%>_txtFrom").keyup(
        function() {
            CalculateAdminInfo("#<%=lblPV.ClientID%>", 
                "#<%=lblTpNum.ClientID%>", 
                "#<%=txtListPrice.ClientID%>_txtFrom", 
                "#<%=lblCtr.ClientID%>_lblFirst",  
                "#<%=lblIndex.ClientID%>_lblFirst", 
                "#<%=lblGrpNum.ClientID%>", 
                "#<%=lblcurrency.ClientID%>");
        });
});
/*
    $("#<%=txtListPrice.ClientID%>_txtFrom").keyup(function() 
        {
        $("#<%=txtListPrice.ClientID%>_txtFrom").keyup(CalculateAdminInfo($("#<%=lblPV.ClientID%>"), $("#<%=lblTpNum.ClientID%>"), $("#<%=txtListPrice.ClientID%>_txtFrom"), $("#<%=lblCtr.ClientID%>_lblFirst"),  $("#<%=lblIndex.ClientID%>_lblFirst"), $("#<%=lblGrpNum.ClientID%>"), $("#<%=lblcurrency.ClientID%>") ));
        
        });
    });*/

</script>
        <input id="lblcurrency" runat="server" type="hidden" value="false" />
        <input id="lblTpNum" runat="server" type="hidden" value="false" />
        <input id="lblGrpNum" runat="server" type="hidden" value="false" />
        <div>
            <table border="1" class="maingrid" style="margin-bottom:0px;">
                <tr>
                    <td style="width:60px; text-align:center;"><asp:LinkButton runat="server" ID="lnkEdit" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
                    <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton></td>
                    <td style="width:239px; text-align:right; padding-right:2px;"><asp:Label runat="server" ID="lblCode" ></asp:Label></td>
                    <td style="width:537px; padding-left:2px"><asp:Label runat="server" ID="lblDescription"></asp:Label></td>
                    <td style="width:90px; padding-right:2px; text-align:right;"><asp:Label runat="server" ID="lblPL"></asp:Label></td>
                    <td style="width:90px; padding-right:2px; text-align:right;"><asp:Label runat="server" ID="lblPV"></asp:Label></td>
                    <td style="width:50px; padding-right:2px; text-align:right;"><asp:Label runat="server" ID="lblQuantity"></asp:Label></td>
                    <td style="width:150px; padding-right:2px; text-align:right;"><asp:Label runat="server" ID="lblDeliveryTime"></asp:Label></td>
                    <td style="width:70px; padding-right:2px; text-align:right;"><asp:Label runat="server" ID="lblIncoterm"></asp:Label></td>
                    <td style="width:60px; padding-right:2px; text-align:right;"><asp:Label runat="server" ID="lblSubtotal"></asp:Label></td>
                </tr>
            </table>
            <div class="form">
                <fieldset>
                    <pbc:SubmitButton runat="server" ID="btnSave" Text="Guardar" OnClick="btnSave_Click" CssClass="button" />
                    <pbc:DataField ID="txtListPrice" Label="PL" Type="Number" NumberType="Decimal" runat="server"  MaxLength="10" IsRequired="true" Visible="false" TabIndex="1"/>
                    <pbc:DataField runat="server" ID="txtQuantity" Type="Number" NumberType="Integer" Label="Cantidad" MaxLength="50" Visible="false" IsRequired="true" TabIndex="5"/>
                    <pbc:DataField runat="server" ID="ddlIncoterm" Type="DropdownList" Label="Incoterm" Visible ="false" IsRequired="true" />
                    <pbc:DataField runat="server" ID="lblCtr" Type="label" Label="CTR" Visible="false" />
                    <pbc:DataField runat="server" ID="lblIndex" Type="label" Label="Index" Visible="false" />
                    <pbc:DataField runat="server" ID="lblTP" Type="Label" Label="TP" Visible="false" />
                    <pbc:DataField runat="server" ID="lblGrp" Type="label" Label="Grp" Visible="false" />
                    <pbc:DataField runat="server" ID="ddlDeliveryTime" Type="DropdownList" Label="Plazo de Entrega" Visible ="false" IsRequired="true" />
                    <pbc:DataField runat="server" ID="ddlDeliveryTerm" Type="DropdownList" Visible ="false" IsRequired="true" />
                    
                </fieldset>
            </div>
        </div>
