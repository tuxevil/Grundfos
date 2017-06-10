<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.Distributors.contacts._default" Title="Untitled Page" %>
<%@ Register Src="../../ctrl/editors/DistributorContactEditor.ascx" TagName="DistributorContactEditor"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {
     $("#createSquare").hide();
     
     $("#<%=btnNew.ClientID%>").click(showCreate).css("cursor", "pointer");
});

function showCreate()
{
    $("#createSquare").animate({
              "opacity": "show"
            }, "slow");
        
}

function hideCreate()
{
    $("#createSquare").hide();
    
}
</script>
    <div style="height:40px">
        <div style="float:left;">
            <a runat="server" id="btnNew" class="lbutton">Crear</a>
        </div>
        <div style="float:right;  ">
             <label style="margin-right:20px">Todos los Contactos</label><asp:CheckBox runat="server" ID="chkAll" OnCheckedChanged="chkAll_Check" AutoPostBack="true" />
        </div>
    
    </div>
    <div id="createSquare">
        <uc1:DistributorContactEditor ID="dceCreate" runat="server" />
    </div>
   
        <asp:Repeater runat="server" ID="rptDistributorContacts" OnItemDataBound="rptDistributorContacts_ItemDataBound">
            <ItemTemplate>
                    <uc1:DistributorContactEditor ID="DistributorContactEditor1" OnSaveCreation="dceCreate_SaveCreation" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
        
</asp:Content>
