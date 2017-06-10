<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.Products.Provider._default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <div ID="litNoItems" class="flash_empty" runat="server" visible="false">"No hay proveedores asignados para este producto."</div>
        <div class="detail_list">
          <asp:Repeater ID="rpterProvider" runat="server" OnItemDataBound="rpterProvider_ItemDataBound">
                    <ItemTemplate>
                        <div class="item">
                               <h1><asp:HyperLink runat="server" ID="lnkGo"/></h1>
                               <p><label>Codigo:</label><span><asp:Literal ID="litCode" runat="server" /></span></p>
                               <p><label>Telefono:</label><span><asp:Literal ID="litPhone" runat="server" /></span></p>
                               <p><label>Fax:</label><span><asp:Literal ID="litFax" runat="server" /></span></p>
                               <p><label>E-Mail:</label><span><asp:Literal ID="litMail" runat="server" /></span></p>
                               <p><label>Contacto:</label><span><asp:Literal ID="litContact" runat="server" /></span></p>
                               <p><label>Dirección:</label><span><asp:Literal ID="litAdress" runat="server" /></span></p>
                               <p><label>Ciudad:</label><span><asp:Literal ID="litCity" runat="server" /></span></p>
                               <p><label>País:</label><span><asp:Literal ID="litCountry" runat="server" /></span></p>
                               <p><label>Descuento:</label><span><asp:Literal ID="litDiscount" runat="server" /></span></p>
                        </div>
                    </ItemTemplate>
          </asp:Repeater>
        </div>
</asp:Content>
