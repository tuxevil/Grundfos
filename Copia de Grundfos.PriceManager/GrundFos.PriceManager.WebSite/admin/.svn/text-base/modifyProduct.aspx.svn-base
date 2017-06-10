<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="modifyProduct.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.admin.modifyProduct" Title="Price Manager - Administración de Productos" %>
<%@ Register Src="../ctrl/PagerSelections.ascx" TagName="PagerSelections" TagPrefix="uc2" %>
<%@ Register Src="../ctrl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
<script language="javascript" type="text/javascript" src="/js/jquery.bgiframe.pack.js"></script>
<script language="javascript" type="text/javascript">
$(document).ready(function() {
    $(".maingrid tr").hover(markOverRow, markOverRow);
    $("#flip_filters").click(flip_filters);
    $("#clean_all_filters").click(cleanAllFilters);
    $(".close_popup").click(closePopup).css("cursor", "pointer");
    $(".popup").dialog({bgiframe:true, autoOpen:false, resizable:false, width:'650px', modal:true});
    
    if (!jQuery.support.leadingWhitespace) {
        $("#<% = ddlCategory.ClientID %>").mouseover(function(){
            $(this)
                .data("origWidth", $(this).css("width"))
                .css("width", "auto");
        }).blur(function(){
            $(this).css("width", $(this).data("origWidth"));
        });
    }    
});

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

function markOverRow(ev) 
{
    if ($(this).hasClass("over"))
        $(this).removeClass("over");
    else
        $(this).addClass("over");
}

function cleanAllFilters ()
{
    $(":text").val("");
    
    $("#<%=ddlRange.ClientID%>").val("0");
    $("#<%=ddlFamilia.ClientID%>").val("0");
    $("#<%=ddlCurrency.ClientID%>").val("0");
    $("#<%=ddlCategoryPage.ClientID%>").val("0");
    $(".rblHz input").removeAttr("checked");
    $(".rblHz input").attr("checked","checked");
}

function openAddCategoryPopup(ev) {
    $('div#add_category').dialog('option','title','Elija Categoría').dialog('open').parent().appendTo(jQuery("form:first"));
}


function openRemoveCategoryPopup(ev) {
    $('div#remove_from_category').dialog('option','title','Elija Categoría').dialog('open').parent().appendTo(jQuery("form:first"));
}

function closePopup(ev)
{
    $(".popup").dialog('close');
}

</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
<script language="javascript" type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);

    function EndRequest(sender, args) 
    {
        $(".maingrid tr").hover(markOverRow, markOverRow);
        $("#clean_all_filters").click(cleanAllFilters);
     }
</script>
    <div class="page_header"> 
                  
                    <div class="page_header_links"> 
                        <a id="flip_filters" class="linkButton">Ocultar Filtros</a>
                    </div> 
                  
                  <h1>Administraci&oacute;n de Productos</h1> 
                </div>
                
    <div class="content">
                    
                <div id="filters">
                    <asp:UpdatePanel ID="upFilters" ChildrenAsTriggers="true" runat="server" UpdateMode="conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnCancelFilterType" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancelFilterFamily" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCTR" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCurrency" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancelFilterDescription" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCategory" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="filterForm" class="box" style="width:66%">
                        <asp:Panel id="pnFiltros" runat="server" DefaultButton="btnSearch">
                            <h1>Filtros</h1>
                            <fieldset style="float:left; width:315px;">
                                <p><label >
                                    Buscar</label>&nbsp<asp:TextBox ID="txtDescripcion" runat="server" Width="190px" TabIndex="1" MaxLength="1024"></asp:TextBox></p>
                                <p></p>
                                <p><label>Frequencia</label>
                                   <asp:RadioButtonList ID="rblProductType" runat="server" CssClass="rblHz" AutoPostBack="false" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">50 Hz</asp:ListItem>
                                        <asp:ListItem Value="2">60 Hz</asp:ListItem>
                                        <asp:ListItem Value="3" Selected="True">Ambos</asp:ListItem>
                                    </asp:RadioButtonList>
                                </p>
                            </fieldset>
                            
                            <fieldset >
                                <p><label >Familia</label><asp:DropDownList id="ddlFamilia" runat="server" Font-Size="Small" Width="180px" TabIndex="15" >
                                </asp:DropDownList></p>
                                <p><label >Rango</label><asp:DropDownList id="ddlRange" runat="server" Font-Size="Small" Width="180px" TabIndex="25" >
                                </asp:DropDownList></p>
                                <p><label >Moneda</label><asp:DropDownList id="ddlCurrency" runat="server" Font-Size="Small" Width="180px" TabIndex="25" >
                                </asp:DropDownList></p>
                            </fieldset>
                            
                            <fieldset>
                               <p><label >Categoría</label>
                               &nbsp<asp:DropDownList id="ddlCategoryPage" runat="server" Font-Size="Small" Width="491px" TabIndex="25" >
                                </asp:DropDownList></p>
                            </fieldset>
                            
                            <div style="text-align:center; margin-top:10px; width:630px;">
                                <asp:Button ID="btnSearch" runat="server" Text="Filtrar" OnClick="btnSearch_Click" CssClass="button" TabIndex="30" /> o <a id="clean_all_filters" class="linkButton">Limpiar</a>                            
                            </div>
                            
                          </asp:Panel>  
                        </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                
                <div id="filters_data" class="hideme">
                <asp:UpdatePanel ID="upFilters_Data" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                <asp:AsyncPostBackTrigger ControlID="ddlPageSize" />
                </Triggers>
                <ContentTemplate>
                    <div class="blankBar">
                      <p><span class="big"><asp:Literal runat="server" ID="litSeleccion" Text="No hay ningún filtro activo." ></asp:Literal></span>
                      <asp:Label ID="lblFilterDescription" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ToolTip="Tipo" ID="btnCancelFilterDescription" runat="server" Visible="false" OnClick="btnCancelFilterDescription_Click">[x]</asp:LinkButton> <asp:Label ID="lblFilterType" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ToolTip="Tipo" ID="btnCancelFilterType" runat="server" Visible="false" OnClick="btnCancelFilterType_Click">[x]</asp:LinkButton> <asp:Label ID="lblFilterFamily" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ID="btnCancelFilterFamily" runat="server" Visible="false" ToolTip="Familia" OnClick="btnCancelFilterFamily_Click" >[x]</asp:LinkButton> <asp:Label ID="lblFilterCategory" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ID="btnCancelFilterCategory" runat="server" Visible="false" ToolTip="Categoría" OnClick="btnCancelFilterCategory_Click" >[x]</asp:LinkButton>  <asp:Label ID="lblFilterCTR" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ID="btnCancelFilterCTR" runat="server" Visible="false" ToolTip="CTR" OnClick="btnCancelFilterCTR_Click" >[x]</asp:LinkButton> <asp:Label ID="lblFilterCurrency" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ID="btnCancelFilterCurrency" runat="server" Visible="false" ToolTip="CTR" OnClick="btnCancelFilterCurrency_Click" >[x]</asp:LinkButton></p>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
               
                </div>
                 
                <div id="grid">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterType" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterFamily" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCTR" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCurrency" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterDescription" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCategory" />
                <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                <asp:AsyncPostBackTrigger ControlID="btnAddToCategory" />
                </Triggers>
                    <ContentTemplate>
                <div class="actions">
                    <span style="float:right">
                    Registros por página:&nbsp;<asp:DropDownList id="ddlPageSize" runat="server" Font-Size="Small" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" >
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="25">25</asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>

                        </asp:DropDownList>
                    </span>
                    <ul>
                    <li runat="server" id="MarkedAll" ><asp:LinkButton ID="lnkCheckAll" runat="server" Text="Marcar todos" OnClick="lnkCheckAll_Click"></asp:LinkButton></li>
                    <li>|</li>
                    <li runat="server" id="UnMarkedAll" ><asp:LinkButton ID="lnkUnCheckAll" runat="server" Text="Desmarcar todos" OnClick="lnkUnCheckAll_Click"></asp:LinkButton></li>
                    </ul>
                </div>
                
                    
                <asp:Repeater ID="rpterProductList" runat="server" OnItemDataBound="rpterProductList_ItemDataBound" OnItemCommand="rpterProductList_ItemCommand">
                    <HeaderTemplate>                
                    <table class="maingrid">
                    <thead>
                        <tr>
                            <th class="action" rowspan="2"></th>
                            <th rowspan="2" style="text-align:center;"><asp:LinkButton ID="lnkCode" CommandName="Order" CommandArgument="Code" Text="Código" runat="server"></asp:LinkButton></th>
                            <th class="description" rowspan="2"><asp:LinkButton ID="lnkDescription" CommandName="Order" CommandArgument="P.Description" Text="Descripción" runat="server"></asp:LinkButton></th>
                            <th rowspan="2" style="text-align:center;">Hz</th>
                            <th colspan="4" class="colspan" style="text-align:center;">Precios</th>
                        </tr>
                        <tr>
                            <th class="price" style="text-align:left;"><asp:LinkButton ID="lnkPriceSell" CommandName="Order" CommandArgument="PriceSell" Text="Venta (PV)" runat="server"></asp:LinkButton></th>
                            <th class="price" style="text-align:left;"><asp:LinkButton ID="lnkPriceSuggest" CommandName="Order" CommandArgument="PriceSuggest" Text="Sugerido (GRP)" runat="server"></asp:LinkButton></th>
                            <th class="price" style="text-align:left;"><asp:LinkButton ID="lnkPricePurchase" CommandName="Order" CommandArgument="PricePurchase" Text="Compra (TP)" runat="server"></asp:LinkButton></th>
                            <th class="price" style="text-align:left;"><asp:LinkButton ID="lnkPrice" CommandName="Order" CommandArgument="PP.Price" Text="Lista (PL)" runat="server"></asp:LinkButton></th>
                        </tr>
                    </thead><tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id='<%# "pp" + DataBinder.Eval(Container, "DataItem.Id").ToString() %>' >
                            <td class="action"><asp:CheckBox ID="chbSelected" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_CheckedChanged" ValidationGroup='<%# DataBinder.Eval(Container, "DataItem.Id") %>' /></td>
                            <td style="width:77px;text-align:right; white-space: nowrap;"  onclick="<%# "location.href = 'addProduct.aspx?id=" + DataBinder.Eval(Container, "DataItem.Id").ToString() + "';"%>"><%# DataBinder.Eval(Container, "DataItem.Code") %></td>
                            <td style="text-align:left;" onclick="<%# "location.href = 'addProduct.aspx?id=" + DataBinder.Eval(Container, "DataItem.Id").ToString() + "';"%>"><%# DataBinder.Eval(Container, "DataItem.Description") %></td>
                            <td id="tdType" runat="server" style="text-align:right;white-space: nowrap;" ><%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Type")).Remove(0,2)%></td>
                            <td style="white-space: nowrap; text-align:right;" ><%# DataBinder.Eval(Container, "DataItem.PriceSellCurrency").ToString() + " " + Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.PriceSell")).ToString("#,##0.00")%></td>
                            <td style="white-space: nowrap; text-align:right;" onclick="<%# "location.href = 'addProduct.aspx?id=" + DataBinder.Eval(Container, "DataItem.Id").ToString() + "';"%>"><%# DataBinder.Eval(Container, "DataItem.PriceSuggestCurrency").ToString() + " " + Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.PriceSuggest")).ToString("#,##0.00")%></td>
                            <td style="white-space: nowrap; text-align:right;" onclick="<%# "location.href = 'addProduct.aspx?id=" + DataBinder.Eval(Container, "DataItem.Id").ToString() + "';"%>"><%# DataBinder.Eval(Container, "DataItem.PricePurchaseCurrency").ToString() + " " + Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.PricePurchase")).ToString("#,##0.00")%></td>
                            <td id="tdPrice" runat="server" style="white-space: nowrap; text-align:right;" ><asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PriceCurrency").ToString() + " " + Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.Price")).ToString("#,##0.00")%>'></asp:Label></td>
                        </tr>
                    
                    </ItemTemplate>
                    <FooterTemplate>
                    </tbody></table>
                    </FooterTemplate>
                </asp:Repeater>
                
                
                <div class="actions">
                    <span style="float: right" class="pager"><uc1:Pager ID="Pager1" runat="server" /></span>
                    <span><strong><asp:Label ID="lblMarkedCount" runat="server" Text="0"></asp:Label></strong> registros marcados de <strong><asp:Label ID="lblSelectedCount" runat="server" Text="0"></asp:Label></strong> listados.<br /></span>
                </div>
                
                <div class="actions">
                                  <a href="addproduct.aspx" >Nuevo Producto</a></li> | <asp:LinkButton id="addToCategory" Text="Agregar a Categoría" Enabled ="true" runat="server"></asp:LinkButton> | <asp:LinkButton id="removeFromCategory" Enabled="false" Text="Quitar de Categoría" runat="server"></asp:LinkButton>
                </div>
                
                </ContentTemplate>
                </asp:UpdatePanel>
                
                </div>
                </div>

    <div id="add_category" style="width:600px;" class="popup">
        <fieldset id="choose_category">
          <div>
            <label for="category"></label>
              <asp:DropDownList ID="ddlCategory" runat="server">
                  <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
              </asp:DropDownList><br />
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
              <asp:DropDownList ID="ddlCategoryRemove" runat="server">
                  <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
              </asp:DropDownList><br />
           </div>
        </fieldset>
        
        <div style="text-align:center">
            <asp:Button ID="btnRemoveFromCategory" runat="server" Text="Borrar" CausesValidation="false" CssClass="button" OnClick="btnRemoveFromCategory_Click" /> o <a class="close_popup" >Cerrar</a>
        </div>  
        
    </div>
    
</asp:Content>
