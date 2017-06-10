<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.PageList.create._default" Title="Untitled Page" %>
<%@ Register Src="~/ctrl/editors/CategoryEditor.ascx" TagName="CategoryEditor" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <uc1:CategoryEditor id="ucCategoryEditor" Mode="Create" IsPageList="true" runat="server"></uc1:CategoryEditor>
</asp:Content>
