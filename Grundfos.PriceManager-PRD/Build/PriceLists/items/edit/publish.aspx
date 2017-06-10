<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="publish.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.PriceLists.items.edit.publish" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">

<div class="flash_notice" id="Flash" visible="false" runat="server">Por favor, complete la fecha desde cual sera valida la publicación.</div>
<div runat="server" id="formPub" visible="false" class="form formcalendar">
    <div runat="server" id="distributorsbox" class="box" style="float:right"> 
        <h1>Canales de Ventas</h1>
          <asp:Repeater ID="rpterMails" OnItemDataBound="ItemDataBound" runat="server">
                    <ItemTemplate>
                        <div class="note">
                              <p>
                                <%# DataBinder.Eval(Container, "DataItem.Name")%>&nbsp&nbsp
                                <img id="imgPicture" runat="server" />                             
                              </p> 
                               
                        </div>
                    </ItemTemplate>
          </asp:Repeater>
    </div>
    <div style="width:70%;">
        <fieldset style="margin-bottom:5px;">
            <p><label>Grupo de Precios</label><span ID="litPriceList" runat="server"></span></p>
            <p><label>Cambios a publicar</label><span ID="litChangesCount" runat="server"></span></p>
            <p><label>Pendientes de Aprobación</label><span ID="litPendingApprove" runat="server"></span></p>
            <p><label>Condiciones Comerciales</label><asp:TextBox runat="server" ID="txtComercialConditions" TextMode="MultiLine" Width="500px" Height="150px" MaxLength="2048"></asp:TextBox></p>
            <p><label>Cuerpo del Mail</label><asp:TextBox runat="server" ID="txtBodyMail"  TextMode="MultiLine" Width="500px" Height="150px"></asp:TextBox></p>
        </fieldset>
        
        <div style="position:relative;margin-left:10px;">
            <label style="margin-right:197px;">Válida desde</label><asp:TextBox runat="server" ID="txtDate" /><asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDate" Text="*" />
        </div>
            <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtDate"></cc1:calendarextender>
    </div>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Fecha inválida"
            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtDate"></asp:CompareValidator>
        <asp:RangeValidator ID="rvDate" runat="server" ControlToValidate="txtDate" ErrorMessage="La fecha de vigencia debe ser mayor a hoy." Type="Date">
        </asp:RangeValidator>
        

        <div style="text-align:center; margin-top:10px;">
            <asp:Button runat="server" ID="btnPublish" OnClick="btnPublish_Click" Text="Publicar y Enviar Minuta" class="button" Visible="false"/>
        </div>
   

</div>

</asp:Content>