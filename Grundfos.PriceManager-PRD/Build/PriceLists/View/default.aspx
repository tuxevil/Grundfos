<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.PriceLists.View._default" Title="Untitled Page" %>
<%@ Register Src="~/ctrl/Notes.ascx" TagName="Notes" TagPrefix="uc1" %>
<%@ Register Src="~/ctrl/editors/PriceListEditor.ascx" TagName="PriceListEditor" TagPrefix="uc2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cplMain" runat="server">

    <uc2:PriceListEditor id="ucPriceListEditor" Mode="View" runat="server"></uc2:PriceListEditor>
    <uc1:Notes id="ucNotes" MaxRows="10" runat="server"></uc1:Notes>
</asp:Content>



