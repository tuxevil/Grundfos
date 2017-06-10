<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PriceMasterList.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.PriceMasterList" %>
<%@ Import Namespace="PriceManager.Core"%>
<%@ Register Src="FiltersView.ascx" TagName="FiltersView" TagPrefix="uc1" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc2" %>
<%@ Register Assembly="PriceManager.Business" Namespace="PriceManager.Business.Controls"  TagPrefix="pmc" %>
 
    <div class="vigency" runat="server" ID="divVigency">
    <label>Vigente desde:</label>
    <asp:Label runat="server" ID="lblVigency"></asp:Label>
    </div>
    
    <uc1:FiltersView id="ucFilters" runat="server"></uc1:FiltersView>
       
    <div style="float:right"><asp:PlaceHolder ID="phUpdate" runat="server"></asp:PlaceHolder></div>
    <div><asp:PlaceHolder ID="phCreation" runat="server"></asp:PlaceHolder></div>

    <div id="grid">
    
    <br />
     <div ID="divMarked" runat="server" class="actions">
            <span style="float:right">
            <asp:Label ID="lblToCurrency" runat="server" Text="Ver moneda en: " Visible="false"></asp:Label><asp:DropDownList id="ddlToCurrency" runat="server" Font-Size="Small" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddlToCurrency_SelectedIndexChanged" ></asp:DropDownList>
            Registros por página:&nbsp;<asp:DropDownList id="ddlPageSize" runat="server" Font-Size="Small" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"></asp:DropDownList>
            </span>
            <asp:UpdatePanel ID="upMarked" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional" >
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="grdItems" />
            </Triggers>
            <ContentTemplate>  
                       
            <ul runat="server" id="ulCheck">
                <li id="MarkedAll"><a id="markAll" class="link" >Marcar todos</a></li>
                <li> | </li>
                <li id="UnMarkedAll"><a id="unmarkAll" class="link" >Desmarcar todos</a></li>
            </ul>&nbsp;
            </ContentTemplate>
            </asp:UpdatePanel>
     </div>
<center>
    <asp:UpdatePanel ID="upGrid" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional" >
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="Pager1" />
    <asp:AsyncPostBackTrigger ControlID="ddlPageSize" />
    </Triggers>
        <ContentTemplate>
        <input id="hidSelChecks" runat="server" type="hidden" name="hidSelChecks" />
        <input id="hidAllSelected" runat="server" type="hidden" value="false" />
        <input id="hidTotal" runat="server" type="hidden" value="0" />
        <asp:GridView AllowPaging="false" CssClass="maingrid" AutoGenerateColumns="false" AllowSorting="true" ID="grdItems" runat="server">
        </asp:GridView>
      </ContentTemplate>
     </asp:UpdatePanel>
     </center>
     <div ID="litNoItems" class="flash_empty" runat="server" visible="false">No se encontraron registros.</div>

     <div ID="divPaging" runat="server" class="actions">      
     <span style="float: right" class="pager">
    <asp:UpdatePanel runat="server" ID="upPager" ChildrenAsTriggers="True" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlPageSize" />              
    </Triggers>
    <ContentTemplate>                    
     <uc2:Pager ID="Pager1" runat="server" />
     </ContentTemplate>
     </asp:UpdatePanel>
     </span>
    
<div id="selectedAndTotalCount" runat="server" >
     <span id="selectedCount">0</span> registros marcados de <span id="totalCount">0</span> totales.          </div>
     </div>

     <div ID="divActions" runat="server" class="actions gridactions" style="height:30px;background:#eee;display:none">
    <asp:UpdatePanel runat="server" ID="upActions" ChildrenAsTriggers="True" UpdateMode="Conditional">
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="grdItems" />
    </Triggers>
    <ContentTemplate>     
     <asp:PlaceHolder ID="plhActions" runat="server"></asp:PlaceHolder>
     </ContentTemplate>
     </asp:UpdatePanel>
     </div>
     
     <div id="noitems" style="height:30px;background:#eee;display:none">
        Seleccione algun registro para realizar acciones sobre los mismos.
    </div>
     
  </div>
    
    <script language="javascript" type="text/javascript" src="/js/jquery.bgiframe.pack.js"></script>
    <script language="javascript" type="text/javascript" src="/js/UControlpricelist.js"></script>
    <script language="javascript" type="text/javascript" src="/js/pricelist-netajax.js"></script>
    <script language="javascript" type="text/javascript">

var items = new Array();
var allSelected = false;
var total = 0;
var selected = 0;

/**************************************************
JQUERY EVENTS TO LOAD JUST THE FIRST TIME PAGE LOAD
**************************************************/
var globalListType;
var globalToCurrency;

function loadPage()
{
    globalListType = <% = ((int)Type).ToString() %>;
    globalToCurrency =  $("#<%=ddlToCurrency.ClientID%>").val();
    
    $("#ddlGroup").hide();
    switch("<% = Type %>") 
    {
        case "Import":
            $(".maingrid td").not(".action").click(ImportModifyRedirect).css("cursor", "pointer");
            break;
        case "AdminView":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "PriceList":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "Distributors":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            $("#do_new_pricelist").hide();
            break;
        case "ProductsView":
            $(".maingrid td").not(".action").click(ProductDetails).css("cursor", "pointer");
            break;
        case "PriceGroupView":
            $(".maingrid td img.change_price").click(openChangePricePopup).css("cursor", "pointer");
            $(".maingrid td").not(".action").click(PriceBaseDetails).css("cursor", "pointer");
            break;
        case "PriceListProducts":
            $(".maingrid td img.change_price").click(openChangePricePopup).css("cursor", "pointer");  
            $(".maingrid td").not(".action").click(PriceBaseDetails).css("cursor", "pointer");
            break;
        case "MasterPriceView":
            $(".maingrid td img.change_price").click(openChangePricePopup).css("cursor", "pointer");
            $(".maingrid td").not(".action").click(PriceBaseDetails).css("cursor", "pointer");
            break;
        case "ProvidersView":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "ProviderAssignedProducts":
            $(".maingrid td").not(".action").click(ProductsViewRedirect).css("cursor", "pointer");
            break;
        case "OutOfGroupView":
            $(".maingrid td").not(".action").click(PriceBaseDetails).css("cursor", "pointer");
            break;
        case "PublishListProducts":
            $(".maingrid td").not(".action").click(PriceBaseDetails).css("cursor", "pointer");
            break;
        case "CategoryView":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "CurrencyView":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "LookupView":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "PriceCalculation":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "PriceGroupDetailsView":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "QuoteProductsCreate":
            $("#<%=ulCheck.ClientID%>").hide();
            $("#<%=selectedAndTotalCount.ClientID%>").hide();
            break;
        case "QuoteView":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
        case "PageList":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            $("#ddlGroup").show();
            break;
        case "PageListProducts":
            $(".maingrid td").not(".action").click(ProductDetails).css("cursor", "pointer");
            break;
        case "PageListChilds":
            $(".maingrid td").not(".action").click(GeneralRedirect).css("cursor", "pointer");
            break;
    }
    
    $(".flip_filters").click(flip_filters);
    
    $(".pricefield").keypress(price_keypress);  
    
    $(".buttons").css("display","none");
    
    if ($("#<% = hidAllSelected.ClientID%>").val() != undefined)
        if ($("#<% = hidAllSelected.ClientID%>").val() != "false")
            allSelected = true;
        
    if ($("#<% = hidSelChecks.ClientID%>").val() != undefined)
        if ($("#<% = hidSelChecks.ClientID%>").val() != "") 
            items = $("#<% = hidSelChecks.ClientID%>").val().split(",");

    if ($("#<% = hidTotal.ClientID%>").val() != undefined)
        if ($("#<% = hidTotal.ClientID%>").val() != "") 
            total = parseInt($("#<% = hidTotal.ClientID%>").val());
    
    if (allSelected || items.length > 0)    
        showActions();
    
    $("#markAll").click(function() {
        allSelected = true;
        items = new Array();
        $(".chklist").each(function(i) { this.checked = true; });
        
        updateInputHiddenFields();
    });

    $("#unmarkAll").click(unMarkAllClick);
    
    updateInputHiddenFields();
    
    // Because the items are updated inside an update panel when we change the amount of records and the pages we use the live event that keeps the checkboxes clickeable.
    $(".chklist").live("click",checkboxClick); 
    
    if("<% = AllowMultipleSelection %>" == 'False' || "<% = Type %>" == "QuoteProductsCreate")
    {
        $("#noitems").hide();
        $("#<%=selectedAndTotalCount.ClientID%>").hide();
    }
}

//**Grid Redirections**

function ProductDetails()
{
    var productid = $(this).parents("tr").eq(0).attr("id").replace(/pp/,"");
    window.location = "/products/view/default.aspx?Id=" + productid;
}

function PriceBaseDetails()
{
    var pricebaseid = $(this).parents("tr").eq(0).attr("pricebaseid").replace(/pp/,"");
    var productid = $(this).parents("tr").eq(0).attr("productid").replace(/pp/,"");
    window.location = "/products/view/default.aspx?Id=" + productid + "&PriceBaseId=" + pricebaseid;
}

function ProductsViewRedirect()
{
    var Id = $(this).parents("tr").eq(0).attr("id").replace(/pp/,"");
    window.location = "/products/view/default.aspx?Id=" + Id;
}
//function ImportModifyRedirect()
//{
//    var id = $(this).parents("tr").eq(0).attr("id").replace(/pp/,"");
//    window.location = "details.aspx?Id=" + id;
//}

function GeneralRedirect()
{
    var id = $(this).parents("tr").eq(0).attr("id").replace(/pp/,"");
    window.location = "view/?Id=" + id;
}

function ImportModifyRedirect()
{
    var id = $(this).parents("tr").eq(0).attr("id").replace(/pp/,"");
    window.location = "view/default.aspx?id=" + id;
}

//**End Grid Redirections**

//** Checkboxs functions and Items Count**
function unMarkAllClick() {
        allSelected = false;
        items = new Array();
        $(".chklist").each(function(i) { this.checked = false; });
        updateInputHiddenFields();
        }

function checkbox_state_add(id) 
{
    checkbox_state(id, true);
    $(".chklist[value='" + id + "']").attr("checked",true);
}

function checkbox_state_remove(id) 
{
    checkbox_state(id, false);
    $(".chklist[value='" + id + "']").attr("checked",false);
}

function checkbox_state(id, add) 
{
    var value = id;
    var itemIndex = jQuery.inArray(value, items);
    
    if (allSelected) {
        // When allSelected is marked, the items list include the excluded items.
        if (!(add) && itemIndex == -1) 
            items.push(value);
        else if (add && itemIndex != -1) 
        {
            items = jQuery.grep(items, function(currentItem) {
            return currentItem != value;
            });
        }
    }
    else {
        // Otherwise works as expected, we maintain the list of items selected.
        if (add && itemIndex == -1) 
            items.push(value);
        else if (!(add) && itemIndex != -1) 
        {
           items = jQuery.grep(items, function(currentItem) {
                return currentItem != value;
            });
        }
    }
    
    updateInputHiddenFields();
}

function checkboxClick() {
    
   if("<% = Type %>" == 'QuoteProductsCreate' && $(this).is(":checked") && selected >= 100) {
      $(this).attr('checked', false);
      return;
   }

    checkbox_state($(this).val(),$(this).is(":checked"));
}

function updateInputHiddenFields() 
{
    $("#<% = hidSelChecks.ClientID%>").val(items.join(","));
    $("#<% = hidAllSelected.ClientID%>").val(allSelected);
    //$("#<% = hidTotal.ClientID%>").val(items.length);
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
    
    PressUnpress();
    
    showActions();
    $("#selectedItemsCount").text(items.length);
}

function PressUnpress() {
    if (selected > 0)
    {
        $("#MarkedAll").removeClass();
        $("#UnMarkedAll").removeClass();
    }
    else
    {
        $("#MarkedAll").removeClass();
        $("#UnMarkedAll").addClass("pressed");
    }

    if (selected == total)
    {
        $("#MarkedAll").addClass("pressed");
        $("#UnMarkedAll").removeClass();
    }
}

function showActions() {
    if("<% = AllowMultipleSelection %>" != 'False' && "<% = Type %>" != "QuoteProductsCreate")
    {
        if (allSelected || items.length > 0)
        {
            $("#noitems").hide();
            $(".gridactions").show("slow");
        }
        else {
            $(".gridactions").hide();
            $("#noitems").show("slow");
        } 
    }
}
//** Checkboxs functions and Items Count**

//**POP-UPS**
function openChangePricePopupTotal(ev) {
    $('div#price_change_mark').dialog('option','title','Modificación Masiva').dialog('open').parent().appendTo(jQuery("form:first"));
    $("#<% = txtModValor.ClientID%>").val("");
    $("#<% = txtModCTR.ClientID%>").val("");
    $("#<% = txtModValor.ClientID%>").focus();
    
}

function openAddToPriceListPopup(ev) {
    $('div#add_pricelist').dialog('option','title','Elija Grupo de Precio').dialog('open').parent().appendTo(jQuery("form:first"));
   if( $("#<%=ddlPriceList.ClientID%>")[0].length == 1)
        ShowNewPricelist();
}

function openAddSelectionPopup(ev) {
    $('div#add_selection').dialog('option','title','Elija Selección').dialog('open').parent().appendTo(jQuery("form:first"));
   if( $("#<%=ddlSelecciones.ClientID%>")[0].length == 1)
        ShowNewSelection();
}

function UnbindROUserClicks()
{
    $(".maingrid td :image").unbind('click');
    $(".maingrid td").not('.action').unbind('click');
}

function ShowNewPricelist()
{
    $("#<%=ddlPriceList.ClientID%>").val("0"); $("#new_pricelist").show();
    $("#choose_pricelist").hide();
    $("#<% = txtNewPriceList.ClientID %>").focus(); 
}

function ShowChoosePriceList()
{
    $("#<%=txtNewPriceList.ClientID%>").val("");
    $("#choose_pricelist").show(); 
    $("#new_pricelist").hide();
}

function ShowNewSelection()
{
    $("#<%=ddlSelecciones.ClientID%>").val("0"); $("#new_selection").show();
    $("#choose_selection").hide();
    $("#<% = txtNewSelection.ClientID %>").focus(); 
}

function ShowChooseSelection()
{
    $("#<%=txtNewSelection.ClientID%>").val("");
    $("#choose_selection").show(); 
    $("#new_selection").hide();
}

function openAddCategoryPopup(ev) {
    $('div#add_category').dialog('option','title','Elija Categoría').dialog('open').parent().appendTo(jQuery("form:first"));
}

function openRemoveCategoryPopup(ev) {
    $('div#remove_from_category').dialog('option','title','Elija Categoría').dialog('open').parent().appendTo(jQuery("form:first"));
}

function openAddPricegoupPopup(ev) {
    $('div#add_to_pricegroup').dialog('option','title','Elija País').dialog('open').parent().appendTo(jQuery("form:first"));
}

function openAddPageListPopup(ev) {
    $('div#add_to_PageList').dialog('option','title','Elija Lista de Precios').dialog('open').parent().appendTo(jQuery("form:first"));
}


function closePopup(ev)
{
    $(".popup").dialog('close');
    
    $(":text","#price_change").val("");
    $("#final_val").text("");
    $("#<%=txtNewSelection.ClientID%>").val("");
    $("#<%=ddlSelecciones.ClientID%>").val("0");
    $("#<%=txtNewPriceList.ClientID%>").val("");
    $("#<%=ddlPriceList.ClientID%>").val("0");
 }
//**END POP-UPS**

//**General Functions**
function getURLParam(strParamName)
{
  var strReturn = "";
  var strHref = window.location.href;
  if ( strHref.indexOf("?") > -1 ){
    var strQueryString = strHref.substr(strHref.indexOf("?")).toLowerCase();
    var aQueryString = strQueryString.split("&");
    for ( var iParam = 0; iParam < aQueryString.length; iParam++ ){
      if (aQueryString[iParam].indexOf(strParamName.toLowerCase() + "=") > -1 )
      {
        var aParam = aQueryString[iParam].split("=");
        strReturn = aParam[1];
        break;
      }
    }
  }
  return unescape(strReturn);
} 

function price_keypress(e)
{
    if (e.which == 46 || e.which == 190 || (e.which >= 48 && e.which <= 57)) 
    {
        if ($(this).attr("id") != "price_val")
            $("#price_val").val("");
            
        if ($(this).attr("id") != "price_pct")
            $("#price_pct").val("")
            
        if ($(this).attr("id") != "price_ctr")
            $("#price_ctr").val("");
            
        if ($(this).attr("id") != "<% = txtModValor.ClientID%>")
            $("#<% = txtModValor.ClientID%>").val("");
            
        if ($(this).attr("id") != "<% = txtModCTR.ClientID%>")
            $("#<% = txtModCTR.ClientID%>").val("");
    }
    else 
    {
        if (e.which == 13)
          {
            e.preventDefault();
            
            if($("#price_val").val()!="" || $("#price_pct").val() != "" || $("#price_ctr").val() != "" )
                saveData();
            else
               {
               $("#final_val").html("Ingrese alg&uacute;n valor.").css("color", "red"); 
               }
           }
    }
}

function ContainsHtml(src, args)
{
   	var htmlRegex = new RegExp(/<\/?\w+((\s+\w+(\s*=\s*(?:".*?"|'.*?'|[^'">\s]+))?)+\s*|\s*)\/?>/gim);
	var matches = args.Value.match(htmlRegex);
	
	if(matches != null)
	{   
	    args.IsValid =  false;
	}
	else
	{
	    args.IsValid =  true;
	}
}
//**End General Functions**

</script>

    <div id="price_change_mark" class="popup">
            <fieldset>
              <div>
                <label for="price_pct">Valor (%)</label>
                <asp:TextBox ID="txtModValor" runat="server" MaxLength="7" autocomplete="off" CssClass="input pricefield currency" ></asp:TextBox>
              </div>
              <div>
                <label for="ctr">CTR (%)</label>
                      <asp:TextBox ID="txtModCTR" runat="server" MaxLength="7" autocomplete="off" TabIndex="1" CssClass="input pricefield currency" ></asp:TextBox>
              </div>
           <asp:CompareValidator ID="cvValMax" runat="server" Display="Dynamic" ErrorMessage="Ingrese un valor menor o igual a 500." Operator="LessThanEqual" ControlToValidate="txtModValor" ValueToCompare="500" ValidationGroup="valFields" Type="Double"></asp:CompareValidator>
           <asp:CompareValidator ID="cvValMin" runat="server" Display="Dynamic" ErrorMessage="Ingrese un valor mayor o igual a -100." Operator="GreaterThan" ControlToValidate="txtModValor" ValueToCompare="-100" ValidationGroup="valFields" Type="Double"></asp:CompareValidator>
           <asp:CompareValidator ID="cvValNotEq" runat="server" Display="Dynamic" ErrorMessage="Ingrese un valor diferente 0." Operator="notequal" ControlToValidate="txtModValor" ValueToCompare="0" ValidationGroup="valFields" Type="Double"></asp:CompareValidator>
           <asp:CompareValidator ID="cvCTRMax" runat="server" Display="Dynamic" ErrorMessage="Ingrese un CTR menor a 100." Operator="LessThanEqual" ControlToValidate="txtModCTR" ValueToCompare="100" ValidationGroup="valFields" Type="Double"></asp:CompareValidator>
           <asp:CompareValidator ID="cvCTRMin" runat="server" Display="Dynamic" ErrorMessage="Ingrese un CTR mayor a 0." Operator="GreaterThan" ControlToValidate="txtModCTR" ValueToCompare="0" ValidationGroup="valFields" Type="Double"></asp:CompareValidator>
           <div style="text-align:center">
                  <asp:Button ID="btnUpdateChecked" ValidationGroup="valFields" runat="server" CssClass="button" Enabled="true" OnClick="btnUpdateChecked_Click" Text="Actualizar Marcados" TabIndex="2" Width="138px" />
                  &nbsp<a tabindex="3" class="close_popup">Cerrar</a>
              </div>   
           </fieldset>
    </div>

    <div id="price_change" class="popup">
            <fieldset>
              <div id="group_val">
                <label for="price">Valor:</label>
                <input type="text" name="price_val" maxlength="12" autocomplete="off" id="price_val" tabindex="1" class="input pricefield currency" />
                <span id="usd_val" class="message"></span>
               
              </div>

              <div>
                <label for="price_pct">Valor (%)</label>
                <input type="text" name="price_pct" id="price_pct" autocomplete="off" maxlength="7" tabindex="2" class="input pricefield currency"/>
              </div>

              <div>
                <label for="ctr">CTR (%)</label>
                <input type="text" name="price_ctr" id="price_ctr" autocomplete="off" maxlength="7" tabindex="3" class="input pricefield currency"/>
                <span id="ctr_val" class="message"></span>
              </div>
              
              <div id="group_result">
                <label>Precio Final:</label>
                <span id="final_val" class="result"></span>
            
              </div>

              <div style="text-align:center">
                  <input id="save_val" class="button" type="button" tabindex="4" value="Actualizar"/>&nbsp<a tabindex="5" class="close_popup">Cerrar</a>

              </div>
           
           </fieldset>
    </div>
    
    <div id="add_pricelist" class="popup">
        <fieldset id="choose_pricelist">
          <div>
            <label for="pricelist">Grupo de Precios</label>
              <asp:DropDownList ID="ddlPriceList" runat="server" Width="250px">
                  <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
              </asp:DropDownList>&nbsp<br /><b><a id="do_new_pricelist">O cree uno nuevo...</a></b>
          </div>
        </fieldset>

        <fieldset id="new_pricelist" style="display:none">
          <div>
            <label for="description">Descripci&oacute;n:</label>
            <asp:TextBox ID="txtNewPriceList" MaxLength="50" autocomplete="off" runat="server" ></asp:TextBox>
          </div>
          <div id="ddlGroup">   
              <label for="pricegroup">País:</label>
              <asp:DropDownList Width="133px" ID="ddlPriceGroupForPage" runat="server"></asp:DropDownList>
          </div>
          <div>
              <label for="currency">Moneda:</label>
              <asp:DropDownList ID="ddlCurrencies" Width="133px" runat="server"></asp:DropDownList><br />
          &nbsp<br /><b><a id="do_choose_pricelist">Seleccionar...</a></b>
           </div>
           
        </fieldset>
        
        <div style="text-align:center;margin-top:5px;">
            <asp:Button ID="btnAddToPriceList" runat="server" Text="Actualizar" CausesValidation="false" CssClass="button" OnClick="btnAddToPriceList_Click"/> &nbsp <a class="close_popup">Cerrar</a>
        </div> 

</div>  
 
    <div id="add_selection" class="popup" style="width:400px; height:300px;">
        <fieldset id="choose_selection">
          <div>
            <label for="selection">Selecci&oacute;n:</label>
              <asp:DropDownList ID="ddlSelecciones" runat="server">
                  <asp:ListItem Value="0">--Seleccionar--</asp:ListItem></asp:DropDownList><br />
              <a id="do_new_selection" class="linkstyle">O cree una nueva...</a>
          </div>
        </fieldset>

        <fieldset id="new_selection" style="display:none">
          <div>
            <label for="description">Descripci&oacute;n:</label>
            <asp:TextBox ID="txtNewSelection" autocomplete="off" MaxLength="50" runat="server" ></asp:TextBox><br />
            <a id="do_choose_selection" class="linkstyle">O elija una existente...</a>
          </div>
        </fieldset>
        <div style="text-align:center;margin-top:5px;">
            <asp:Button ID="btnAddToSelection" runat="server" Text="Actualizar" CausesValidation="false" CssClass="button" OnClick="btnAddToSelection_Click"/> &nbsp <a class="close_popup">Cerrar</a>
        </div> 

</div>  

<div id="add_category" style="width:600px;" class="popup">
    <fieldset id="choose_category">
      <div>
        <label for="category"></label>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
          <ContentTemplate>
          <pmc:LinkedDropDown ID="ddlCategoryLinked" IsPopUp="true" runat="server"  />
          </ContentTemplate>
          </asp:UpdatePanel>
       </div>
    </fieldset>
    
    <div style="text-align:center">
        <asp:Button ID="btnAddToCategory" runat="server" Text="Actualizar" CausesValidation="false" CssClass="button" OnClick="btnAddToCategory_Click" /> o <a class="close_popup" >Cerrar</a>
    </div>  
        
</div>

    <div id="remove_from_category" style="width:600px;" class="popup">
        <fieldset id="Fieldset1">
          <div>
            <label for="category"></label>
              <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
              <ContentTemplate>
              <pmc:LinkedDropDown ID="ddlCategoryLinkedRemove" IsPopUp="true" runat="server"  />
              </ContentTemplate>
              </asp:UpdatePanel>
           </div>
        </fieldset>
        
        <div style="text-align:center">
            <asp:Button ID="btnRemoveFromCategory" runat="server" Text="Borrar" CausesValidation="false" CssClass="button" OnClick="btnRemoveFromCategory_Click" /> o <a class="close_popup" >Cerrar</a>
        </div>  
    </div>
    
    <div id="add_to_PageList" style="width:600px;" class="popup">
    <fieldset id="choose_pagelist">
      <div>
        <label for="pagelist"></label>
          <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
          <ContentTemplate>
          <asp:DropDownList ID="ddlPageLists" Width="300px" runat="server"></asp:DropDownList>
          </ContentTemplate>
          </asp:UpdatePanel>
       </div>
    </fieldset>
    
    <div style="text-align:center">
        <asp:Button ID="Button1" runat="server" Text="Actualizar" CausesValidation="false" CssClass="button" OnClick="btnAddToPageList_Click" /> o <a class="close_popup" >Cerrar</a>
    </div>  
        
</div>
    
    <div id="add_to_pricegroup" class="popup">
        <fieldset id="choose_pricegroup">
          <div style="text-align:center">
              <asp:DropDownList ID="ddlPricegroup" Width="300px" runat="server">
                  <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
              </asp:DropDownList>
           </div>
        </fieldset>
        
        <div style="text-align:center">
            <asp:Button ID="btnAddToPricegroup" runat="server" Text="Actualizar" CausesValidation="false" CssClass="button" OnClick="btnAddToPriceGroup_Click" /> o <a class="close_popup" >Cerrar</a>
        </div>  
        
</div>


