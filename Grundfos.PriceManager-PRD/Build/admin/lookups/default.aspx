<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.lookups._default" Title="Prices Manager Advanced - Datos Generales" %>
<%@ Register Src="../../ctrl/PriceMasterList.ascx" TagName="PriceMasterList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:PriceMasterList ID="PriceMasterList1" Type="lookupview" AllowMultipleSelection="false" ShowFilters="true" UrlForCreateNew="/admin/lookups/create/default.aspx" runat="server" />
</asp:Content>