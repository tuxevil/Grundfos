<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.PriceLists.Categories.ModifiedCategorys._default" Title="Untitled Page" %>
<%@ Register Src="~/ctrl/viewers/PriceListCategorysView.ascx" TagName="CategoryView" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:CategoryView ID="CategoryView1" isPriceList="true" runat="server" />
</asp:Content>
