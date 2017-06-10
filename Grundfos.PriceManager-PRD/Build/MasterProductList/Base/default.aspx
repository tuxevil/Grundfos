<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.MasterProductList.Base._default" Title="Prices Manager Advanced - Maestro de Precios: Base" %>
<%@ Register Src="~/ctrl/PriceMasterList.ascx" TagName="PriceMasterList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:PriceMasterList id="PriceMasterList1" Type="4" runat="server"></uc1:PriceMasterList>
</asp:Content>
