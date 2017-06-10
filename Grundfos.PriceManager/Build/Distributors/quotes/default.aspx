<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.Distributors.quotes._default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <div ID="litNoItems" class="flash_notice" runat="server" visible="false">"No hay cotizaciones asignados para esta distribuidor."</div>
        <div class="detail_list">
              <asp:Repeater ID="rpterQuotes" runat="server" OnItemDataBound="rpterQuotes_ItemDataBound">
                <ItemTemplate>
                    <div class="item">
                           <h1><asp:HyperLink runat="server" ID="lnkGo" /></h1>
                           <p><label>Descripción:</label><span><asp:Literal ID="litDescription" runat="server" /></span></p>
                           <p><label>Observaciones:</label><span><asp:Literal ID="litObservations" runat="server" /></span></p>
                    </div>
                </ItemTemplate>
              </asp:Repeater>
          </div>
</asp:Content>
