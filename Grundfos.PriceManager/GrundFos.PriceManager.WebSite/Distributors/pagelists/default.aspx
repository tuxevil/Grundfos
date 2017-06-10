<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.Distributors.pagelists._default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
<div ID="litNoItems" class="flash_empty" runat="server" visible="false">"No hay Listas de Precios asignados para este Distribuidor."</div>
    
    <div class="detail_list">
          <asp:Repeater ID="rpterDistributors" OnItemDataBound="rpterPages_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <div class="item">
                               <h1><asp:HyperLink runat="server" ID="lnkGo" /></h1>
                               <p><label>Padre</label><span><asp:Literal ID="litParent" runat="server" /></span></p>
                               <p><label>Descripción</label><span><asp:Literal ID="litDescription" runat="server" /></span></p>
                        </div>
                    </ItemTemplate>
          </asp:Repeater>
    </div>
</asp:Content>
