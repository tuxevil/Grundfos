<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteDetailView.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.Viewers.QuoteDetailView" %>
<%@ Register Src="../Notes.ascx" TagName="Notes" TagPrefix="uc2" %>
<%@ Register Src="../editors/QuoteLineEditor.ascx" TagName="QuoteLineEditor" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
var numericPl;
var ctr;
var numericIndex;
var plMin;
var plMax;
var minCtr;
var minIndex;
var oPl;
var saveId;
var numericTp;

function openGetAssistencePopup(ev) {
    $('div#getAssistence').dialog('option','title','Obtener Asistencia').dialog('open').parent().appendTo(jQuery("form:first"));
}
$(document).ready(function() {
    $(".popup").dialog({bgiframe:true, autoOpen:false, resizable:false, width:'550px', modal:true});
    $(".close_popup").click(closePopup).css("cursor", "pointer");
});

function closePopup(ev)
{
    $(".popup").dialog('close');
}
function CalculateSubTotal(qId, pvId, subtId, currencyId, quantityId)
{
    var quantity = parseInt($(qId).val());
    var pv = $(pvId).text();
    var currency = $(currencyId).val();
    var numPv = pv.replace(currency+' ', '');
    numPv = numPv.replace(",", ".");
    numPv = parseFloat(numPv);
    
    if(quantity != 0 && !isNaN(quantity) && numPv != 0 && !isNaN(numPv))
       {
        var fSubt = quantity * numPv;
        fSubt = fSubt.toFixed(2);
        
        //reemplasar el total al cambiar.
        var antSub = $(subtId).text();
        antSub = antSub.replace(currency+' ', '');
        antSub = parseFloat(antSub.replace(",", "."));
        var addToTotal = fSubt - antSub;
        
        var oldTotal = $("#<%=lblTotalCount.ClientID%>").text();
        oldTotal = oldTotal.replace(currency+ ' ', '');
        oldTotal = parseFloat(oldTotal.replace(",", "."));
        
        addToTotal =oldTotal + addToTotal;
        $("#<%=lblTotalCount.ClientID%>").text(currency+ ' '+ addToTotal );
        
        
        fSubt = fSubt.toString();
        fSubt = fSubt.replace(".", ",");
        $(subtId).text(currency+' '+fSubt);
        $(quantityId).text(quantity);
       }
    else
        $(subtId).text(currency+' '+0);
}

function CalculateAdminInfo(pvId, tpId, plId, ctrId, indexId, grpId, currencyId, gridPl, txtQuantity, gSubt, gQuantity, 
                            plMinRange, plMaxRange, ctrMin, indexMin, saveBtnId, originalPl)
{
    var origPl = $(plId).val();
    if(origPl != undefined)
    {
        var pl = parseFloat(origPl.replace(",", "."));
        var discount = $("#<%=lblDiscount.ClientID%>").text();
        var discountNum = parseInt(discount.replace('%', ''));
        var currency = $(currencyId).val();
        if(!isNaN(pl))
        {
            //seteo de PV
            numericPl = pl;
            var pv = pl - ((discountNum*pl)/100);
            var gPv = pv.toFixed(2);
            gPv = gPv.toString();
            gPv = gPv.replace(".", ",");
            $(pvId).text(currency + ' '+gPv);
            
            //seteo de PL
            pl = pl.toFixed(2);
            pl = pl.toString();
            $(gridPl).text(currency + ' ' + pl.replace(".", ","));
            
            //seteo de Ctr
            var tp = parseFloat($(tpId).val());
            numericTp = tp;
             if(tp != 0 && !isNaN(tp))
             {
                ctr = 1 - (tp/pv); 
                var sCtr = ctr.toFixed(2);
                sCtr = sCtr.toString();
                sCtr = sCtr.replace(".", ",");
                $(ctrId).text(sCtr.substr(0,4) + '%');
             }
             else
                $(ctrId).text('0' + '%');
            
            //Index
            var origGrp = $(grpId).val();
            var grp = parseFloat(origGrp.replace(",", "."));
            $(indexId).text("0");
            if(grp != 0 && !isNaN(grp))
              {
                var fIndex = pv/grp;
                numericIndex = fIndex;
                fIndex = fIndex.toFixed(1);
                fIndex = fIndex.toString();
                fIndex = fIndex.replace(".", ",");
                $(indexId).text(fIndex);
              }
         }
        else
           {
            $(pvId).text(currency+ ' ' + 0);
            $(indexId).text(0);
            $(ctrId).text(0+'%');
            $(gridPl).text(currency + ' ' + 0);
           }
           CalculateSubTotal(txtQuantity, pvId, gSubt, currencyId, gQuantity);
           
           plMin = $(plMinRange).val();
           plMin = parseFloat(plMin.replace(",", "."));
           
           plMax = $(plMaxRange).val();
           plMax = parseFloat(plMax.replace(",", "."));
           
           minCtr = $(ctrMin).val();
           minCtr = parseFloat(minCtr.replace(",", "."));
           
           minIndex = $(indexMin).val();
           minIndex = parseFloat(minIndex.replace(",", "."));
           
           oPl = $(originalPl).val();
           oPl = parseFloat(oPl.replace(",", "."));
           saveId = saveBtnId;
           CalculateRange();
    }
    
    function CalculateRange()
    {
        var minPL = ((plMin * oPl)/100)+oPl;
        var maxPL = ((plMax * oPl)/100)+oPl;
        
        //-1 si no es admin
        if(minCtr > -1)
        {
            if(numericPl < minPL || numericPl > maxPL)
            { 
                $(saveId).attr("disabled","true");
                showInfoMessage('El PL ingresado no est� permitido. Por favor, solicite asistencia.');
                //args.IsValid=  false;
            }
            else
            {
                if(numericTp == 0)
                {
                    if(numericIndex < minIndex)
                    {
                        $(saveId).attr("disabled","true");
                        showInfoMessage('El PL ingresado no est� permitido. Por favor, solicite asistencia.');
                    }
                    else
                        $(saveId).removeAttr("disabled");
                }
                else
                {
                    if(ctr < minCtr)
                    {
                        $(saveId).attr("disabled","true");
                        showInfoMessage('El PL ingresado no est� permitido. Por favor, solicite asistencia.');
                    }
                    else
                        $(saveId).removeAttr("disabled");
                }
            }
        }
        else
            $(saveId).removeAttr("disabled");
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
            <table class="maingrid">
                <tr>
                    <th style="width:61px;"></th>
                    <th style="width:200px; text-align:center;">C�digo</th>
                    <th style="width:300px;text-align:center;">Modelo</th>
                    <th style="width:250px; text-align:center;">PL</th>
                    <th style="width:250px; text-align:center;">PV</th>
                    <th style="width:50px; text-align:center;">Cant.</th>
                    <th style="width:150px; text-align:center;">Plazo de Entrega</th>
                    <th style="width:70px; text-align:center;">Incoterm</th>
                    <th style="width:250px; text-align:center;">Subtotal</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
             <uc1:QuoteLineEditor ID="QuoteLineEditor1" runat="server" />
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div style="float:right">
         <label style="font-weight:bold">Total:</label>
         <asp:Label runat="server" ID="lblTotalCount"></asp:Label>
    </div>
    <asp:Button ID="btnGetPDF" runat="server" Text="Generar PDF" CssClass="button" OnClick="btnGetPDF_Click" TabIndex="5" />
    <asp:Button ID="btnSendPDF" runat="server" Text="Enviar Cotizaci�n" CssClass="button" OnClick="btnSendPDF_Click" TabIndex="10" />
    <input class="button" value="Solicitar Asistencia" type="button" id="btnGetAssistence"  onclick="openGetAssistencePopup();" runat="server" />
</div>

<div id="getAssistence" class="popup" >
        <fieldset>
          <div style="text-align:center">
              <asp:UpdatePanel ID="upAssistence" ChildrenAsTriggers="true" UpdateMode="Conditional" runat="server">
              <ContentTemplate>
                    <uc2:Notes ID="ucNotes" MaxRows="1" runat="server" />
              </ContentTemplate>
              </asp:UpdatePanel>
           </div>
        </fieldset>
        
        <div style="text-align:center">
            <asp:Button ID="btnAssistense" runat="server" Text="Solicitar Asistencia" CssClass="button" TabIndex="15" OnClick="btnAssistense_Click" /> o <a class="close_popup" >Cerrar</a>
        </div>  
        
</div>