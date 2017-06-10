<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.Products.PriceLists._default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <div ID="litNoItems" class="flash_empty" runat="server" visible="false">"No hay grupo de precios asociado a este producto."</div>
       <div class="detail_list">
          <asp:Repeater ID="rpterPriceLists" runat="server" OnItemDataBound="rpterPriceLists_ItemDataBound">
                    <ItemTemplate>
                        <div class="item">
                               <h1><asp:HyperLink runat="server" ID="lnkGo"/></h1>
                               <p><label>Description:</label><span><asp:Literal ID="litDescription" runat="server" /></span></p>
                               <p><label>País:</label><span><asp:Literal ID="litCountry" runat="server" /></span></p>
                               <p><label>Incoterm:</label><span><asp:Literal ID="litIncoterm" runat="server" /></span></p>
                               <p><label >Descuento:</label><span><asp:Literal ID="litDiscount" runat="server" /></span></p>
                               <p><label>Estado:</label><span><asp:Literal ID="litStatus" runat="server" /></span></p>
                               <p><label>Última Publicación:</label><span><asp:Literal ID="litLastPublish" runat="server" /></span></p>
                        </div>
                    </ItemTemplate>
          </asp:Repeater>
        </div>
</asp:Content>
