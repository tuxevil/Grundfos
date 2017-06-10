<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.PricesPolitics.view._default" Title="Untitled Page" %>

<%@ Register Src="../../../ctrl/editors/PricePoliticsEditor.ascx" TagName="PricePoliticsEditor"
    TagPrefix="uc1" %>
<%@ Register Src="~/ctrl/Notes.ascx" TagName="Notes" TagPrefix="uc2" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:PricePoliticsEditor ID="PricePoliticsEditor1" runat="server" />
    <uc2:Notes id="ucNotes" MaxRows="10" runat="server"></uc2:Notes>

</asp:Content>