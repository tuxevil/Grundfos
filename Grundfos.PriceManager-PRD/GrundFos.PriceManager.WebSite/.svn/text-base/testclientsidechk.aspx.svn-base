<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testclientsidechk.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.testclientsidechk" Title="Untitled Page" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
  <title>[Price Manager] Ingreso</title>
   <script language="javascript" type="text/javascript" src="/js/jquery-1.3.1.min.js"></script>
    <!--[if IE]><script language="javascript" type="text/javascript" src="/js/flot/excanvas.pack.js"></script><![endif]-->
   <script language="javascript" type="text/javascript" src="/js/flot/jquery.flot.pack.js"></script>
   <script language="javascript" type="text/javascript">
var items = new Array();
var allSelected = false;

$(document).ready(function() {
    // 11006
/*    $.ajax({
        type: "POST",
        url: "/api/prices.asmx/GetAttributeHistoricPrices",
        data: "{'priceBaseId':8754}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
        { 
            var series = new Array();
            
            for(j=0;j<data.length;j++)
            {
                var arrFinal = new Array();
                for(i=0;i<data[j].Second.length;i++)
                    arrFinal.push([data[j].Second[i].DateTicks, data[j].Second[i].PriceList]);
                
                series.push({
                    label: data[j].First,
                    data: arrFinal
                });
            }
           
            $.plot($("#placeholder"), series, { xaxis: { mode: "time" } });
        }
    });
*/
    $(".buttons").css("display","none");
    
    if ($("#hidAllSelected").val() != "false")
        allSelected = true;
        
    if ($("#hidSelChecks").val() != "") 
        items = $("#hidSelChecks").val().split(",");
    
    if (allSelected || items.length > 0)    
        showActions();
    
    $("#markAll").click(function() {
        allSelected = true;
        items = new Array();
        $(".chklist").each(function(i) { this.checked = true; });
        
        updateInputHiddenFields();
    });

    $("#unmarkAll").click(function() {
        allSelected = false;
        items = new Array();
        $(".chklist").each(function(i) { this.checked = false; });
        
        updateInputHiddenFields();
    });
    
    // Because the items are updated inside an update panel when we change the amount of records and the pages we use the live event that keeps the checkboxes clickeable.
    $(".chklist").live("click",checkboxClick);
});

function checkboxClick() {
    var value = $(this).val();
    var itemIndex = jQuery.inArray(value, items);
    
    if (allSelected) {
        // When allSelected is marked, the items list include the excluded items.
        if (!($(this).is(":checked")) && itemIndex == -1) 
            items.push(value);
        else if ($(this).is(":checked") && itemIndex != -1) 
        {
           items = jQuery.grep(items, function(currentItem) {
                return currentItem != value;
            });
        }
    }
    else {
        // Otherwise works as expected, we maintain the list of items selected.
        if ($(this).is(":checked") && itemIndex == -1) 
            items.push(value);
        else if (!($(this).is(":checked")) && itemIndex != -1) 
        {
           items = jQuery.grep(items, function(currentItem) {
                return currentItem != value;
            });
        }
    }
    
    updateInputHiddenFields();
}

function updateInputHiddenFields() 
{
    $("#hidSelChecks").val(items.join(","));
    $("#hidAllSelected").val(allSelected);
    showActions();
}

function showActions() {
    if (allSelected || items.length > 0)
    {
        $("#noitems").hide();
        $(".buttons").show("slow");
    }
    else {
        $(".buttons").hide();
        $("#noitems").show("slow");
    }
}

</script>
</head>
<body class="login">
    <form id="form1" runat="server">

    <div id="placeholder" style="width:600px;height:300px;"></div>

    <asp:ScriptManager ID="ScriptManager1" AsyncPostBackTimeout="1800" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True">
    </asp:ScriptManager>
    
<a id="markAll">MARK ALL</a> | <a id="unmarkAll">UNMARK ALL</a>
<asp:UpdatePanel runat="server" ID="upnGrid" UpdateMode="Conditional" ChildrenAsTriggers="false">
<Triggers>
<asp:AsyncPostBackTrigger ControlID="lnkChangePage" />
</Triggers>
<ContentTemplate>
<input id="hidSelChecks" type="hidden" name="hidSelChecks" runat="server" />
<input id="hidAllSelected" type="hidden" value="false" runat="server" />
<asp:GridView ID="grdItems" EnableViewState="True" runat="server" OnRowCommand="grdItems_RowCommand">
<Columns>
<asp:TemplateField>
<ItemTemplate>
<input type="checkbox" class="chklist" value="1" runat="server" />
</ItemTemplate>
</asp:TemplateField>
    <asp:ButtonField ButtonType="Image" ImageUrl="~/img/edit.jpg" Text="Button" />
</Columns>
</asp:GridView>
</ContentTemplate>
</asp:UpdatePanel>

<asp:LinkButton ID="lnkChangePage" runat="Server" Text="Change Page" OnClick="lnkChangePage_Click" />

<div class="buttons" style="height:30px;background:#eee;display:none;">
<asp:LinkButton ID="lnkAAA" runat="server" Text="AAAA" OnClick="lnkAAA_Click"></asp:LinkButton>
</div>

<div id="noitems" style="height:30px;background:#eee;">
Seleccione algun registro para realizar acciones sobre los mismos.
</div>

</form>
</body>
</html>