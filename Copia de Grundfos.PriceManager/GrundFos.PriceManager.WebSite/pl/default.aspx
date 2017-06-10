<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.pl._default" Title="Price Manager - Listado de Productos" %>
<%@ Register Src="../ctrl/PagerSelections.ascx" TagName="PagerSelections" TagPrefix="uc2" %>
<%@ Register Src="../ctrl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
<script language="javascript" type="text/javascript" src="/js/jquery.bgiframe.pack.js"></script>
<script language="javascript" type="text/javascript" src="/js/pricelist.js"></script>
<script language="javascript" type="text/javascript">

/**************************************************
JQUERY EVENTS TO LOAD JUST THE FIRST TIME PAGE LOAD
**************************************************/
function loadPage()
{
    $("#<%=addToSelection.ClientID %>").click(function(){$("#<%=txtNewSelection.ClientID %>").focus();});
    <% if (!(User.IsInRole("User")||User.IsInRole("Administrator"))) Response.Write("UnbindROUserClicks();"); %>
}

function UnbindROUserClicks()
{
    $(".maingrid td :image").unbind('click');
    $(".maingrid td").not('.action').unbind('click');
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

function cleanAllFilters ()
{
    $(":text").val("");
    
    $("#<%=ddlRange.ClientID%>").val("0");
    $("#<%=ddlFamilia.ClientID%>").val("0");
    $("#<%=ddlCurrency.ClientID%>").val("0");
    $("#<%=ddlCategory.ClientID%>").val("0");
    $(".rblHz input").removeAttr("checked");
    $(".rblHz input").attr("checked","checked");
}

function openChangePricePopupTotal(ev) {
    $('div#price_change_mark').dialog('option','title','Modificación Masiva').dialog('open').parent().appendTo(jQuery("form:first"));
    $("#<% = txtModValor.ClientID%>").val("");
    $("#<% = txtModCTR.ClientID%>").val("");
    $("#<% = txtModValor.ClientID%>").focus();
}

function openAddSelectionPopup(ev) {
    $('div#add_selection').dialog('option','title','Elija Selección').dialog('open').parent().appendTo(jQuery("form:first"));
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

function closePopup(ev)
{
    $(".popup").dialog('close');
    
    $(":text","#price_change").val("");
    $("#final_val").text("");
    $("#<%=txtNewSelection.ClientID%>").val("");
    $("#<%=ddlSelecciones.ClientID%>").val("0");
}

</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <div class="page_header"> 
        <div class="page_header_links"> 
            <a id="flip_filters" class="linkButton">Ocultar Filtros</a>
        </div> 
      <h1>&nbsp</h1> 
    </div>
                
    <div class="content">
                    
                <div id="filters">
                    <div id="selections" class="box">
                               <h1>Selecciones</h1>
                                <asp:UpdatePanel ID="upSelections" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="PagerSelections1" />
                                </Triggers>
                                <ContentTemplate>
                                <asp:Repeater ID="rptSelection" runat="server" OnItemDataBound="rptSelection_ItemDataBound">
                                <HeaderTemplate>
                                <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                <li runat="server" id="listitem"><a href="?s=<%# DataBinder.Eval(Container, "DataItem.Id") %>" ><%# DataBinder.Eval(Container, "DataItem.Description") %></a></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                </ul>
                                </FooterTemplate>
                                </asp:Repeater>
                                <div class="rcorner"><uc2:PagerSelections ID="PagerSelections1" runat="server" /></div>
                                </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
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
                        <div id="filterForm" class="box">
                        <asp:Panel id="pnFiltros" runat="server" DefaultButton="btnSearch">
                            <h1>Filtros</h1>
                            <fieldset style="float:left; width:315px;">
                                <p><label >
                                    Buscar</label>&nbsp<asp:TextBox ID="txtDescripcion" runat="server" autocomplete="off" Width="190px" TabIndex="1" MaxLength="1024"></asp:TextBox></p>
                                <p></p>
                                <p><label>Frequencia</label>
                                   <asp:RadioButtonList ID="rblProductType" runat="server" CssClass="rblHz" AutoPostBack="false" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">50 Hz</asp:ListItem>
                                        <asp:ListItem Value="2">60 Hz</asp:ListItem>
                                        <asp:ListItem Value="3" Selected="True">Ambos</asp:ListItem>
                                    </asp:RadioButtonList>
                                </p>
                            </fieldset>
                            
                            <fieldset>
                                <p><label >Familia</label><asp:DropDownList id="ddlFamilia" runat="server" Font-Size="Small" Width="180px" TabIndex="15" >
                                </asp:DropDownList></p>
                                <p><label >Rango</label><asp:DropDownList id="ddlRange" runat="server" Font-Size="Small" Width="180px" TabIndex="25" >
                                </asp:DropDownList></p>
                                <p><label >Moneda</label><asp:DropDownList id="ddlCurrency" runat="server" Font-Size="Small" Width="180px" TabIndex="35" >
                                </asp:DropDownList></p>
                             </fieldset>
                            
                            <fieldset>
                               <p><label >Categoría</label>
                               &nbsp<asp:DropDownList id="ddlCategory" runat="server" Font-Size="Small" Width="491px" TabIndex="45" >
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
                <asp:AsyncPostBackTrigger ControlID="rptSelection" />
                <asp:AsyncPostBackTrigger ControlID="ddlPageSize" />
                </Triggers>
                <ContentTemplate>
                    <div class="blankBar">
                      <p><span class="big"><asp:Literal runat="server" ID="litSeleccion" Text="No hay ningún filtro activo." ></asp:Literal> <asp:LinkButton ToolTip="Tipo" ID="btnCancelSelection" runat="server" Visible="false" OnClick="btnCancelSelection_Click">[x]</asp:LinkButton></span>
                      <asp:Label ID="lblFilterDescription" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ToolTip="Tipo" ID="btnCancelFilterDescription" runat="server" Visible="false" OnClick="btnCancelFilterDescription_Click">[x]</asp:LinkButton> <asp:Label ID="lblFilterType" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ToolTip="Tipo" ID="btnCancelFilterType" runat="server" Visible="false" OnClick="btnCancelFilterType_Click">[x]</asp:LinkButton> <asp:Label ID="lblFilterFamily" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ID="btnCancelFilterFamily" runat="server" Visible="false" ToolTip="Familia" OnClick="btnCancelFilterFamily_Click" >[x]</asp:LinkButton> <asp:Label ID="lblFilterCategory" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ID="btnCancelFilterCategory" runat="server" Visible="false" ToolTip="Categoría" OnClick="btnCancelFilterCategory_Click" >[x]</asp:LinkButton> <asp:Label ID="lblFilterCTR" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ID="btnCancelFilterCTR" runat="server" Visible="false" ToolTip="CTR" OnClick="btnCancelFilterCTR_Click" >[x]</asp:LinkButton> <asp:Label ID="lblFilterCurrency" runat="server" Visible="false" ></asp:Label> <asp:LinkButton ID="btnCancelFilterCurrency" runat="server" Visible="false" ToolTip="CTR" OnClick="btnCancelFilterCurrency_Click" >[x]</asp:LinkButton></p>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
               
                </div>
                
                <div id="grid">

                <div class="actions">
                    <span style="float:right">
                    Registros por página:&nbsp;<asp:DropDownList id="ddlPageSize" runat="server" Font-Size="Small" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" >
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="25">25</asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>
                        </asp:DropDownList>
                    </span>
                    
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional" >
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="rpterProductList" />
                    </Triggers>
                    <ContentTemplate>
                        <ul>
                        <li runat="server" id="MarkedAll" ><asp:LinkButton ID="lnkCheckAll" runat="server" Text="Marcar todos" OnClick="lnkCheckAll_Click"></asp:LinkButton></li>
                        <li>|</li>
                        <li runat="server" id="UnMarkedAll" ><asp:LinkButton ID="lnkUnCheckAll" runat="server" Text="Desmarcar todos" OnClick="lnkUnCheckAll_Click" Enabled="false"></asp:LinkButton></li>
                        </ul>                    
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional" >
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterType" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterFamily" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCTR" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCurrency" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterDescription" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCategory" />
                <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                <asp:AsyncPostBackTrigger ControlID="btnUpdateChecked" />
                <asp:AsyncPostBackTrigger ControlID="lnkTakeOutOfSelection" />
                <asp:AsyncPostBackTrigger ControlID="Pager1" />
                <asp:AsyncPostBackTrigger ControlID="lnkCheckAll" />
                <asp:AsyncPostBackTrigger ControlID="lnkUnCheckAll" />
                <asp:AsyncPostBackTrigger ControlID="ddlPageSize" />
                </Triggers>
                    <ContentTemplate>
                    
                <asp:Repeater ID="rpterProductList" runat="server" OnItemDataBound="rpterProductList_ItemDataBound" OnItemCommand="rpterProductList_ItemCommand">
                    <HeaderTemplate>                
                    <table class="maingrid">
                    <thead>
                        <tr>
                            <th class="action"><asp:LinkButton ID="btnCheckUncheck" OnClick="btnCheckUncheck_Click" visible="false" runat="server" ValidationGroup="true">+/-</asp:LinkButton></th>
                            <th><asp:LinkButton ID="lnkCode" CommandName="Order" CommandArgument="Code" Text="C&oacute;digo" runat="server"></asp:LinkButton></th>
                            <th class="description"><asp:LinkButton ID="lnkDescription" CommandName="Order" CommandArgument="P.Description" Text="Descripci&oacute;n" runat="server"></asp:LinkButton></th>
                            <th>Hz</th>
                            <th>Index</th>
                            <th class="price" title="Precio de Venta"><asp:LinkButton ID="lnkPriceSell" CommandName="Order" CommandArgument="PriceSell" Text="PV" runat="server"></asp:LinkButton></th>
                            <th class="price" title="Precio Sugerido"><asp:LinkButton ID="lnkPriceSuggest" CommandName="Order" CommandArgument="PriceSuggest" Text="GRP" runat="server"></asp:LinkButton></th>
                            <th class="price" title="Precio de Compra"><asp:LinkButton ID="lnkPricePurchase" CommandName="Order" CommandArgument="PricePurchase" Text="TP" runat="server"></asp:LinkButton></th>
                            <th class="price" title="Precio de Lista"><asp:LinkButton ID="lnkPrice" CommandName="Order" CommandArgument="PP.Price" Text="PL" runat="server"></asp:LinkButton></th>
                            <th class="price"><asp:LinkButton ID="lnkCTM" CommandName="Order" CommandArgument="CTM" Text="CTM" runat="server"></asp:LinkButton></th>
                            <th class="price"><asp:LinkButton ID="lnkCTR" CommandName="Order" CommandArgument="CTR" Text="CTR" runat="server"></asp:LinkButton></th>
                            <th class="price"><asp:LinkButton ID="lnkPCR" CommandName="Order" CommandArgument="LPPA.PCR" Text="PCR" runat="server"></asp:LinkButton></th>
                        </tr>
                    </thead><tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id='<%# "pp" + DataBinder.Eval(Container, "DataItem.Id").ToString() %>'>
                            <td class="action"><asp:CheckBox ID="chbSelected" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_CheckedChanged" ValidationGroup='<%# DataBinder.Eval(Container, "DataItem.Id") %>' /></td>
                            <td><%# DataBinder.Eval(Container, "DataItem.Code") %></td>
                            <td class="description"><%# DataBinder.Eval(Container, "DataItem.Description") %></td>
                            <td id="tdType" runat="server" class="image"><%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Type")).Remove(0,2)%></td>
                            <td><%# Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.Index")).ToString("#0.00")%></td>
                            <td><%# DataBinder.Eval(Container, "DataItem.PriceSellCurrency").ToString() + " " + Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.PriceSell")).ToString("#,##0.00")%></td>
                            <td><%# DataBinder.Eval(Container, "DataItem.PriceSuggestCurrency").ToString() + " " + Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.PriceSuggest")).ToString("#,##0.00")%></td>
                            <td><%# DataBinder.Eval(Container, "DataItem.PricePurchaseCurrency").ToString() + " " + Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.PricePurchase")).ToString("#,##0.00")%></td>
                            <td id="tdPrice" runat="server" class="image"><asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PriceCurrency").ToString() + " " + Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.Price")).ToString("#,##0.00")%>'></asp:Label></td>
                            <td><asp:Label id="lblBaseCurrency" runat="server" ></asp:Label><%# Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.CTM")).ToString("#,##0.00")%></td>
                            <td><%# Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.CTR")).ToString("#,##0.00") + "%"%></td>
                            <td><%# Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.PCR")).ToString("#,##0.00") + "%"%></td>
                        </tr>
                    
                    </ItemTemplate>
                    <FooterTemplate>
                    </tbody></table>
                    </FooterTemplate>
                </asp:Repeater>
                
                </ContentTemplate>
                </asp:UpdatePanel>

                <div class="actions">
                <asp:UpdatePanel runat="server" ID="UpdatePanel4" ChildrenAsTriggers="True" UpdateMode="Conditional">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterType" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterFamily" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCTR" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCurrency" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterDescription" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCategory" />
                <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                <asp:AsyncPostBackTrigger ControlID="lnkTakeOutOfSelection" />
                <asp:AsyncPostBackTrigger ControlID="ddlPageSize" />              
                </Triggers>
                <ContentTemplate>                    
                    <span style="float: right" class="pager"><uc1:Pager ID="Pager1" runat="server" /></span>
                </ContentTemplate>
                </asp:UpdatePanel>
                
                <asp:UpdatePanel runat="server" ID="UpdatePanel3" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkCheckAll" />
                <asp:AsyncPostBackTrigger ControlID="lnkUnCheckAll" />
                <asp:AsyncPostBackTrigger ControlID="rpterProductList" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterType" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterFamily" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCTR" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCurrency" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterDescription" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelFilterCategory" />
                <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                <asp:AsyncPostBackTrigger ControlID="lnkTakeOutOfSelection" />                
                </Triggers>
                <ContentTemplate>                    
                    <span><strong><asp:Label ID="lblMarkedCount" runat="server" Text="0"></asp:Label></strong> registros marcados de <strong><asp:Label ID="lblSelectedCount" runat="server" Text="0"></asp:Label></strong> listados.<br /><asp:Label ID="lblError" runat="server" Visible="false" ForeColor="red"></asp:Label><br /></span>
                </ContentTemplate>
                </asp:UpdatePanel>
                </div>
                
                <asp:UpdatePanel runat="server" ID="pnlBar" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkCheckAll" />
                <asp:AsyncPostBackTrigger ControlID="lnkUnCheckAll" />
                <asp:AsyncPostBackTrigger ControlID="rpterProductList" />
                </Triggers>
                <ContentTemplate>
                
                <div class="actions">
                    <asp:LinkButton ID="do_change_price_selection" runat="server" Text="Modificar Precio" Enabled="false" visible="false"></asp:LinkButton> | <asp:ImageButton ID="btnExportExcel" runat="server" OnClick="btnExportExcel_Click" AlternateText="Exportar a Excel" ImageUrl="~/img/Excel Icon.edited.JPG" Enabled="false" ></asp:ImageButton> | <asp:ImageButton ID="btnExportPDF" runat="server" OnClick="btnExportPDF_Click" AlternateText="Exportar a PDF" ImageUrl="~/img/adobe-acrobat-pdf-icon.edited.JPG" Enabled="false" ></asp:ImageButton> | <asp:LinkButton ID="addToSelection"  runat="server" Text="Agregar a Selecci&oacute;n" Enabled="False"></asp:LinkButton> | <asp:LinkButton ID="lnkTakeOutOfSelection" runat="server" Text="Quitar de Selecci&oacute;n [ ]" OnClick="lnkTakeOutOfSelection_Click" Visible="False" Enabled="False" ></asp:LinkButton>
                </div>
                
                </ContentTemplate>
                </asp:UpdatePanel>
                
                </div>
                </div>
    
    <div id="price_change" class="popup">
            <fieldset>
              <div id="group_val">
                <label for="price">Valor:</label>
                <input type="text" name="price_val" maxlength="12" autocomplete="off" id="price_val" tabindex="1" class="input pricefield" />
                <span id="usd_val" class="message"></span>
               
              </div>

              <div>
                <label for="price_pct">Valor (%)</label>
                <input type="text" name="price_pct" id="price_pct" autocomplete="off" maxlength="7" tabindex="2" class="input pricefield"/>
              </div>

              <div>
                <label for="ctr">CTR (%)</label>
                <input type="text" name="price_ctr" id="price_ctr" autocomplete="off" maxlength="7" tabindex="3" class="input pricefield"/>
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
    
    <div id="price_change_mark" class="popup">
            <fieldset>
            <asp:Panel ID="panModMasivo" runat="server" DefaultButton="btnUpdateChecked">
              <div>
                <label for="price_pct">Valor (%)</label>
                <asp:TextBox ID="txtModValor" runat="server" MaxLength="7" autocomplete="off" CssClass="input pricefield" ></asp:TextBox>
              </div>
              
              <div>
                <label for="ctr">CTR (%)</label>
                      <asp:TextBox ID="txtModCTR" runat="server" MaxLength="7" autocomplete="off" TabIndex="1" CssClass="input pricefield" ></asp:TextBox>
              </div>
              <div style="text-align:center">
                  <asp:Button ID="btnUpdateChecked" runat="server" CssClass="button" Enabled="true" OnClick="btnUpdateChecked_Click" Text="Actualizar Marcados" TabIndex="2" Width="138px" />
                  &nbsp<a tabindex="3" class="close_popup">Cerrar</a>
              </div></asp:Panel>
           </fieldset>
    </div>
    
    <div id="add_selection" class="popup">
     <asp:UpdatePanel runat="server" ID="upSelection" ChildrenAsTriggers="true" UpdateMode="Conditional"><ContentTemplate>
        <fieldset id="choose_selection">
          <div>
            <label for="selection">Selecci&oacute;n:</label>
              <asp:DropDownList ID="ddlSelecciones" runat="server">
                  <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
              </asp:DropDownList>&nbsp<b><a id="do_new_selection">O cree una nueva...</a></b>
          </div>
        </fieldset>

        <fieldset id="new_selection" style="display:none">
          <div>
            <label for="description">Descripci&oacute;n:</label>
            <asp:TextBox ID="txtNewSelection" autocomplete="off" runat="server" ></asp:TextBox>&nbsp<b><a id="do_choose_selection">Seleccionar...</a></b>
          </div>
        </fieldset>
        <div style="text-align:center;margin-top:5px;">
            <asp:Button ID="btnAddToSelection" runat="server" Text="Actualizar" CausesValidation="false" CssClass="button" OnClick="btnAddToSelection_Click"/> &nbsp <a class="close_popup">Cerrar</a>
        </div> 
        </ContentTemplate></asp:UpdatePanel>      
   </div>  

    <script language="javascript" type="text/javascript" src="/js/pricelist-netajax.js"></script>
</asp:Content>
