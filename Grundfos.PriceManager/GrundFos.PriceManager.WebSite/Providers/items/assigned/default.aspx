<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.Providers.items.assigned._default" Title="Untitled Page" %>
<%@ Register Src="../../../ctrl/PriceMasterList.ascx" TagName="PriceMasterList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:PriceMasterList ID="PriceMasterList1" Type="ProviderAssignedProducts" AllowMultipleSelection="false" runat="server" />
</asp:Content>
