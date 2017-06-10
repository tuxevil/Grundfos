<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.PageList.childs.view._default" Title="Untitled Page" %>
<%@ Register Src="~/ctrl/editors/CategoryEditor.ascx" TagName="CategoryEditor" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:CategoryEditor id="ucCategoryEditor" Mode="View" IsPageListSon="true" runat="server"></uc1:CategoryEditor>
</asp:Content>
