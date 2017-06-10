<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.lookups.view._default" Title="Untitled Page" %>
<%@ Register Src="~/ctrl/editors/LookupEditor.ascx" TagName="LookupEditor" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:LookupEditor id="ucLookupEditor" Mode="View" runat="server"></uc1:LookupEditor>
</asp:Content>
