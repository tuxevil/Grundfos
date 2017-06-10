var globalPrice;
var globalRowId;

$(document).ready(function() {
    jqueryEvents();
    netAjaxEvents();
    loadPage();
});

/**************************************************
JQUERY EVENTS TO RELOAD ON AJAX NET LOAD
**************************************************/
function netAjaxEvents()
{
    $(".maingrid tr").hover(markOverRow, markOverRow);
    $(".maingrid td").not(".action").click(openChangePricePopup).css("cursor", "pointer");
    $(".maingrid td :image").click(openChangePricePopup);
    $("#do_new_selection").click(ShowNewSelection);
    $("#do_choose_selection").click(ShowChooseSelection);
    $(".close_popup").click(closePopup).css("cursor", "pointer");
    $("#clean_all_filters").click(cleanAllFilters);
}

/**************************************************
JQUERY ONLY EVENTS
**************************************************/
function jqueryEvents() {
    $("#flip_filters").click(flip_filters);
    $("#save_val").live("click", saveData);
    $(":text", "#price_change").change(showUpdatedInfo);
    
    $(".pricefield").keypress(price_keypress);
    $('.pricefield').keydown(function(e){
        if (!(e.keyCode == 27 || e.keyCode == 109 || e.keyCode == 189 || e.keyCode == 110 || e.keyCode == 188 || e.keyCode == 46 || e.keyCode == 190 || e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 13 || (e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 37 && e.keyCode <= 40)))
            return false;
    });
    
    $("#clean_all_filters").click(cleanAllFilters);
    // Initialize any popup dialog.
    $(".popup").dialog({bgiframe:true, autoOpen:false, resizable:false, width:'400px', modal:true});
}

/***************************************************************************************
CHANGE INDIVIDUAL PRICE
***************************************************************************************/

function showUpdatedInfo() {
    var id = $(this).attr("id");
    var value = $(this).val();
    
    if (value == "")
        return;
     if(value == 0) 
     {
      $("#final_val").text("Ingrese un valor diferente a 0.").css("color", "red").show();
      return;
     }
     if(parseFloat($("#price_ctr").val()) <= -100 || parseFloat($("#price_ctr").val()) >= 100)
     {
         $("#final_val").text("Ingrese un valor menor a 100 y mayor a -100.").css("color", "red").show();
     return;
     }
        
    calculatePrices(value, getType(id));
}

function getType(id)
{
    var type ="3";
    if(id == "price_val")
      type = "1";
    else if(id== "price_ctr")
      type = "2";
      
    return type;
}

function calculatePrices(value, type)
{  
    $.ajax({
        type: "POST",
        url: "/api/prices.asmx/getPrice",
        data: "{'id':'" + globalRowId + "','value':'" + value + "','type':'" + type +"'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
        { 
            $("#final_val").text(data.NewPrice).css("color", "green");
            $("#ctr_val").text(data.NewCtr);
        }
    });
}

function saveData()
{
    var value = "";
    var id = "";

    $(":text", "#price_change").each( 
    function(){
        if ($(this).val() != "") {
            value = $(this).val();
            id = $(this).attr("id");
        }
    });
    
    if (value != "" || value != 0) {
        $.ajax({
            type: "POST",
            url: "/api/prices.asmx/getPrice",
            data: "{'id':'" + globalRowId + "','value':'" + value + "','type':'" + getType(id) +"'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(data)
            { 
                if( data.OriginalPrice != $("#usd_val").text())
                {
                   $("#usd_val").text(data.OriginalPrice);
                   $(".maingrid tr#pp"+ globalRowId + " td").not(".action").eq(7).text(data.OriginalPrice);
                   $("#final_val").html("El precio de lista ha cambiado desde la &uacute;ltima consulta.").css("color", "red"); 
                   return;
                }
                
                if(id == "price_val" && value == data.OriginalPriceWF)
                {
                  $("#final_val").text("El precio ingresado es igual al precio de lista.").css("color", "red");
                  return;
                }
                
                saveValue();
            }
        });
    }
    else
       $("#final_val").html("Ingrese alg&uacute;n dato.").css("color", "red"); 
    
}

function saveValue()
{
    var value = "";
    var id = "";

    $(":text", "#price_change").each( 
    function(){
        if ($(this).val() != "") {
            value = $(this).val();
            id = $(this).attr("id");
        }
    });

    if (value != "")
    {
        $.ajax({
            type: "POST",
            url: "/api/prices.asmx/ChangePrice",
            data: "{'id':'" + globalRowId + "','value':'" + value + "','type':'" + getType(id) +"'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(data)
            { 
               var $grid = $(".maingrid tr#pp"+ globalRowId + " td").not(".action");
               
               $grid.eq(7).removeClass();
               $grid.eq(4).text(data.PriceSell);                
               $grid.eq(7).attr("title", data.LastPrice); 
               $grid.eq(7).text(data.Price).addClass(data.Arrow);
               $grid.eq(3).text(data.Index);
               $grid.eq(8).text(data.CTM);
               $grid.eq(9).text(data.CTR);
               $grid.eq(10).text(data.PCR);
               
               closePopup();
               
               $(":text","#price_change").val("");
               $("#final_val").text("");
            }
        });    
    }
   
}

/***************************************************************************************
FLIP EVENTS
***************************************************************************************/
function flip_filters()
{
    if ($("#flip_filters").text() == "Ocultar Filtros")
    {
        $("#filters").hide();
        $("#filters_data").animate({
              "opacity": "show"
            }, "slow");
        $("#flip_filters").text("Mostrar Filtros");
    }
    else 
    {
        $("#filters").animate({
              "opacity": "show"
            }, "slow");
        $("#filters_data").hide();
        $("#flip_filters").text("Ocultar Filtros");
    }
}

function flipChecks()
{
    $(".maingrid :check").each(
    function() {
        var isChecked = $(this).is(":checked");
        $(this).attr("checked",!isChecked);

        if (!isChecked)
            if (!$(this).hasClass("selected")) $(this).addClass("selected");
        else 
            $(this).removeClass("selected");
    }
    );
}

/***************************************************************************************
GRID ROW EVENTS
***************************************************************************************/

function changeRow(ev) 
{
    if ($(this).hasClass("selected"))
        $(this).removeClass("selected");
    else
        $(this).addClass("selected");
}

function markOverRow(ev) 
{
    if ($(this).hasClass("over"))
        $(this).removeClass("over");
    else
        $(this).addClass("over");
}

function openChangePricePopup(ev)
{
    var id = $(this).parents("tr").eq(0).attr("id").replace(/pp/,"");
    globalRowId = id;
    
    //Getting data from repeater 
    var ps = $(this).parents("tr").eq(0).find("td").not(".action").eq(7).text();
    var porc = $(this).parents("tr").eq(0).find("td").not(".action").eq(9).text();
    
    $("#usd_val").text(ps);
    $("#ctr_val").text(porc);
    
    $('div#price_change').dialog('option','title','Modificaci&oacute;n Individual').dialog('open').parent().appendTo(jQuery("form:first"));
    
    $("#price_val").focus();
}