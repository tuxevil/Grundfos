<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.PriceLists.PriceLists.AddUsers._default" Title="Untitled Page" %>
<%@ Register Src="/ctrl/ListTransfer.ascx" TagName="ListTransfer" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <div class="form box">
       <h1>Asignación de Usuarios a Grupo de Precio</h1>
       <fieldset>
             <div><label>Grupo de Precio</label><asp:Label runat="server" ID="lblPriceList" ></asp:Label></div>
             
             <div>
                <table cellspacing=0 cellpadding=0 border=0 width="100%">
                    <tr>
                        <td width="10%"><label>Usuarios</label></td>
                        <td><uc1:ListTransfer id="ltUsers" runat="server"></uc1:ListTransfer></td>
                    </tr>
                </table>
            </div>
       </fieldset>
       <center>
           <div><asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" TabIndex="15" />&nbsp<a href="/pricelists/default.aspx">Volver</a></div>
        </center>
    </div>
</asp:Content>
