<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteDetailView.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.Viewers.QuoteDetailView" %>
<div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click" >Editar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       
       </h1>

<div style="height:300px;">
<div style="width:45%;float:left;">
    <fieldset>
        <div style="white-space:nowrap"><b><label>Canal de Ventas:</label></b>&nbsp<asp:Label ID="lblDistributor" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Contacto:</label></b>&nbsp<asp:Label ID="lblContact" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Email:</label></b>&nbsp<asp:Label ID="lblMail" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Fecha:</label></b>&nbsp<asp:Label ID="lblDate" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Cotizacion Nro:</label></b>&nbsp<asp:Label ID="lblQuoteNumber" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Descuento:</label></b>&nbsp<asp:Label ID="lblDiscount" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Forma de Pago:</label></b>&nbsp<asp:Label ID="lblPaymentCondition" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Validez:</label></b>&nbsp<asp:Label ID="lblVigency" runat="server"></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Estado:</label></b>&nbsp<asp:Label ID="lblStatus" runat="server" ></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Autor:</label></b>&nbsp<asp:Label ID="lblAutor" runat="server" ></asp:Label></div>
        <div><b><label>Observacion:</label></b>&nbsp<asp:Label ID="lblObservation" runat="server" ></asp:Label></div>
        <div style="white-space:nowrap"><b><label>Incluir Precio de Venta</label></b><asp:CheckBox ID="cbxIncludePriceSell" runat="server" /></div>
    </fieldset>
</div>
<div style="width:45%;line-height: 20px; float:left">
    <fieldset>
        <div><asp:Label ID="Label1" runat="server" Text="Texto Introductorio:" Font-Bold="True"></asp:Label>&nbsp<asp:Label ID="lblIntroText" runat="server"></asp:Label><br /></div>
        <div><asp:Label ID="Label3" runat="server" Text="Condicion:" Font-Bold="True"></asp:Label>&nbsp<asp:Label ID="lblCondition" runat="server"></asp:Label></div>
        
    </fieldset>
</div>
</div>



    
    <div style="clear:both">
    <%--<div ID="litMailSent" class="flash_notice" runat="server" visible="false">La cotización  se ha enviado correctamente al distribuidor.</div>
    <div ID="litNoEmail" class="flash_alert" runat="server" visible="false">No se podra enviar la cotización por correo ya que el distribuidor no tiene correo electronico asignado.</div>--%>
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="maingrid" AutoGenerateColumns="false">
    </asp:GridView>
    </div>
    
    <asp:Button ID="btnGetPDF" runat="server" Text="Generar PDF" CssClass="button" OnClick="btnGetPDF_Click" TabIndex="5" />
    <asp:Button ID="btnSendPDF" runat="server" Text="Enviar Cotización" CssClass="button" OnClick="btnSendPDF_Click" TabIndex="10" />
</div>
