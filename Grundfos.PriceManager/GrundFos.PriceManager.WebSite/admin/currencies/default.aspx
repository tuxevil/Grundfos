<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.currencies._default" Title="Prices Manager Advanced - Monedas" %>
<%@ Register Src="../../ctrl/PriceMasterList.ascx" TagName="PriceMasterList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:PriceMasterList ID="PriceMasterList1" Type="CurrencyView" AllowMultipleSelection="false" ShowFilters="false" UrlForCreateNew="/admin/currencies/create/default.aspx" runat="server" />
</asp:Content>