<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.currencies.create._default" Title="Untitled Page" %>
<%@ Register Src="~/ctrl/editors/CurrencyEditor.ascx" TagName="CurrencyEditor" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:CurrencyEditor id="ucCurrencyEditor" Mode="Create" runat="server"></uc1:CurrencyEditor>
</asp:Content>
