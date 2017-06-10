<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteDetailView.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.Viewers.QuoteDetailView" %>
<%@ Register Src="../editors/QuoteLineEditor.ascx" TagName="QuoteLineEditor" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">


function CalculateSubTotal(qId, pvId, subtId, currencyId, quantityId)
{
    var quantity = parseInt($(qId).val());
    var pv = $(pvId).text();
    var currency = $(currencyId).val();
    var numPv = parseFloat(pv.replace(currency+' ', ''));
    
    if(quantity != 0 && !isNaN(quantity) && numPv != 0 && !isNaN(numPv))
       {
        $(subtId).text(currency+' '+(quantity * numPv));
        $(quantityId).text(quantity);
       }
}

function CalculateAdminInfo(pvId, tpId, plId, ctrId, indexId, grpId, currencyId)
{
    var origPl = $(plId).val();
    var pl = parseFloat(origPl.replace(",", "."));
    var discount = $("#<%=lblDiscount.ClientID%>").text();
    var discountNum = parseInt(discount.replace('%', ''));
    var pv = pl - ((discountNum*pl)/100);
    var currency = $(currencyId).val();
    $(pvId).text(currency + ' '+pv);
    
    var origGrp = $(grpId).val();
    var grp = parseFloat(origGrp.replace(",", "."));
    $(indexId).text("0");
    if(grp != 0 && !isNaN(grp))
        $(indexId).text(pv/grp);
     
     var tp = parseFloat($(tpId).val());
     if(tp != 0 && !isNaN(tp))
     {
        var ctr = 1 - ( tp/pv); 
        var sCtr = ctr.toString(); 
         $(ctrId).text(sCtr.substr(0,4));
     }
        
}

</script>
<div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click" >Editar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       
       </h1>

<div>
    
<div style="width:55%;float:left;">
    <fieldset>
        <div style="white-space:nowrap"><b><label>Canal de Ventas:</label></b>&nbsp<asp:Label ID="lblDistributor" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Fecha:</label></b>&nbsp<asp:Label ID="lblDate" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Cotizacion Nro:</label></b>&nbsp<asp:Label ID="lblQuoteNumber" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Descuento:</label></b>&nbsp<asp:Label ID="lblDiscount" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Forma de Pago:</label></b>&nbsp<asp:Label ID="lblPaymentCondition" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Validez:</label></b>&nbsp<asp:Label ID="lblVigency" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Estado:</label></b>&nbsp<asp:Label ID="lblStatus" runat="server" ></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Autor:</label></b>&nbsp<asp:Label ID="lblAutor" runat="server" ></asp:Label></div>
        <div><b><label>Observacion:</label></b>&nbsp<asp:Label ID="lblObservation" runat="server" ></asp:Label></div>
        <div><b><label>Moneda:</label></b>&nbsp<asp:Label ID="lblCurrency" runat="server" ></asp:Label></div>
        
        <div style="white-space:nowrap"><b><label>Incluir Precio de Venta</label></b><asp:CheckBox ID="cbxIncludePriceSell" runat="server" /></div>
    </fieldset>
</div>
<div style="width:45%;line-height: 20px; float:left">
    <fieldset>
        <div><asp:Label ID="Label1" runat="server" Text="Texto Introductorio:" Font-Bold="True"></asp:Label>&nbsp<asp:Label ID="lblIntroText" runat="server"></asp:Label><br /></div>
        <div><asp:Label ID="Label3" runat="server" Text="Condicion:" Font-Bold="True"></asp:Label>&nbsp<asp:Label ID="lblCondition" runat="server"></asp:Label></div>
        
    </fieldset>
</div><br />
<div style="clear:both">
    <fieldset>
          <div><b><label>Contacto:</label></b>&nbsp<asp:Label ID="lblContact" runat="server"></asp:Label></div>  
    </fieldset>
</div>
</div>

    <asp:Repeater runat="server" ID="rptQuoteLine" OnItemDataBound="rptQuoteLine_ItemDataBound">
        <HeaderTemplate>
            <table border="1" class="maingrid" style="margin-bottom:0px;">
                <tr>
                    <th style="width:60px;"></th>
                    <th style="width:241px; text-align:center;">Codigo</th>
                    <th style="width:539px;text-align:center;">Descripción</th>
                    <th style="width:90px; padding-right:2px; text-align:center;">PL</th>
                    <th style="width:90px; padding-right:2px; text-align:center;">PV</th>
                    <th style="width:50px; padding-right:2px; text-align:center;">Cant.</th>
                    <th style="width:150px; padding-right:2px; text-align:center;">Plazo de Entrega</th>
                    <th style="width:70px; padding-right:2px; text-align:center;">Incoterm</th>
                    <th style="width:60px; padding-right:2px; text-align:center;">Subtotal</th>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
             <uc1:QuoteLineEditor ID="QuoteLineEditor1" runat="server" />
        </ItemTemplate>
    </asp:Repeater>
    
    <%--<div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" CssClass="maingrid" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
            </asp:GridView>    
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>--%>
    
    <asp:Button ID="btnGetPDF" runat="server" Text="Generar PDF" CssClass="button" OnClick="btnGetPDF_Click" TabIndex="5" />
    <asp:Button ID="btnSendPDF" runat="server" Text="Enviar Cotización" CssClass="button" OnClick="btnSendPDF_Click" TabIndex="10" />
</div>
