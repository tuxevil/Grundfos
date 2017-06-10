<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.Products.create._default" Title="Untitled Page" %>

<%@ Register Src="../../../ctrl/editors/ProductsEditor.ascx" TagName="ProductsEditor"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:ProductsEditor ID="ProductsEditor1" Mode="Create" IsEdit="true" IsAdminProduct="true" runat="server" />
</asp:Content>
