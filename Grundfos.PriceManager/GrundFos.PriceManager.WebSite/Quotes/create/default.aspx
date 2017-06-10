<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.Quotes.create._default" Title="Untitled Page" %>

<%@ Register Src="../../ctrl/editors/QuoteEditor.ascx" TagName="QuoteEditor" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:QuoteEditor ID="QuoteEditor1" runat="server" Mode="Create" />
</asp:Content>
