<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.Distributors.items.current._default" Title="Untitled Page" %>
<%@ Register Src="../../../ctrl/PriceMasterList.ascx" TagName="PriceMasterList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:PriceMasterList ID="PriceMasterList1" Type="DistributorCurrentPriceList" runat="server" />
    <asp:Label runat="server" ID="lblNoPriceList" Text="No hay una lista vigente para este distribuidor." Visible="false"></asp:Label>
</asp:Content>
