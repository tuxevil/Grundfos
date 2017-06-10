<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.PricesPolitics.create._default" Title="Untitled Page" %>
<%@ Register Src="../../../ctrl/editors/PricePoliticsEditor.ascx" TagName="PricePoliticsEditor"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:PricePoliticsEditor ID="PricePoliticsEditor1" Mode="Create" runat="server" />
    
</asp:Content>
