<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
   <script language="javascript" type="text/javascript" src="/js/jquery-1.3.1.min.js"></script>

<script language="javascript" type="text/javascript">
var items = new Array();
var allSelected = false;
var total = 0;
var selected = 0;

$(document).ready(function() {
   updateInputHiddenFields();
});

function say(){
    alert('hola');
}

function unMarkAllClick() {
say();
    allSelected = false;
    items = new Array();
    $(".chklist").each(function(i) { this.checked = false; });
    updateInputHiddenFields();
}
        
function updateInputHiddenFields() 
{
    //$("#<% = hidSelChecks.ClientID%>").val(items.join(","));
    $("#<% = hidAllSelected.ClientID%>").val(allSelected);
    $("#<% = hidTotal.ClientID%>").val(items.length);
    
    if(allSelected == false)
        {
            $("#selectedCount").text(items.length);
            selected = items.length;        
        }
    else
        {
            $("#selectedCount").text(total - items.length);
            selected = total - items.length;        
        }
    $("#totalCount").text(total);
}
</script>

    
    
    <form id="form1" runat="server">
        <input id="hidSelChecks" runat="server" name="hidSelChecks" value="1,2,3"  />
        <input id="hidAllSelected" runat="server" value="true" />
        <input id="hidTotal" runat="server" value="3" />
    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="chklist" Checked="true" />
    <asp:CheckBox ID="CheckBox2" runat="server" CssClass="chklist" Checked="true" />
    <asp:CheckBox ID="CheckBox3" runat="server" CssClass="chklist" Checked="true" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <input id="actualizar" onclick="updateInputHiddenFields()" type="button" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
        </ContentTemplate>
        </asp:UpdatePanel>
        
        <span id="selectedCount">0</span> registros marcados de <span id="totalCount">0</span> totales.
        <%--<div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    
    </div>--%>
    </form>
</body>
</html>
