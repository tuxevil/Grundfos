<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.PriceLists.pagelist._default" Title="Untitled Page" %>

<%@ Register Src="../../ctrl/Viewers/CategoryTreeView.ascx" TagName="CategoryTreeView"
    TagPrefix="uc2" %>
<%@ Register Src="/ctrl/ListTransfer.ascx" TagName="ListTransfer" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
<div class="form box">
       <h1>Asignación de Listas de Precios a Grupo de Precios</h1>
       <fieldset>
             <div>
                <table cellspacing=0 cellpadding=0 border=0 width="100%">
                    <tr>
                        
                    </tr>
                </table>
            </div>
       </fieldset>
    &nbsp;
       <uc2:CategoryTreeView ID="CategoryTreeView1" runat="server" />                    
       <center>
           <div><asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" TabIndex="15" />&nbsp<a href="/pricelists/default.aspx">Volver</a></div>
        </center>
    </div>
</asp:Content>
