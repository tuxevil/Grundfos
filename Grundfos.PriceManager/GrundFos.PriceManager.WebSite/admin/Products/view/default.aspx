<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.Products.view.deafult" Title="Untitled Page" %>
<%@ Register Src="../../../ctrl/editors/ProductsEditor.ascx" TagName="ProductsEditor" TagPrefix="uc1" %>
<%@ Register Src="~/ctrl/Notes.ascx" TagName="Notes" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:ProductsEditor ID="ProductsEditor1" IsEdit="true" runat="server" IsAdminProduct="true" Mode="View" />
    <uc2:Notes id="ucNotes" MaxRows="10" runat="server"></uc2:Notes>
</asp:Content>
