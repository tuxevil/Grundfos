<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.QuoteEditor" %>
<%@ Register Src="../PriceMasterList.ascx" TagName="PriceMasterList" TagPrefix="uc1" %>
<%@ Register Assembly="PriceManager.Business" Namespace="PriceManager.Business.Controls"  TagPrefix="pmc" %>
<div >
<div style="width:20%;float:right;">
	<div id="quotelist" class="box dropzone"> 
		<h1>Cotizar Productos</h1>
		<div class="container">
		<ul id="productlist" runat="server" >
        </ul>
		</div>
	
    <asp:UpdatePanel ID="upControls" runat="server"  UpdateMode="Always">
    <ContentTemplate>
        <center>
           <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" runat="server" CssClass="validations" ErrorMessage="No se encontro el Canal de Venta en la base." ControlToValidate="txtDistributor" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="form"></asp:CustomValidator><br />
           <asp:CustomValidator ID="CustomValidator2" Display="Dynamic" runat="server" CssClass="validations" ErrorMessage="Seleccione al menos 1 Canal de Venta." OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="form" ></asp:CustomValidator><br />
           <asp:CustomValidator ID="CustomValidator3" Display="Dynamic" runat="server" CssClass="validations" ErrorMessage="Asegurese de haber seleccionado un texto introductorio y una condición." ValidationGroup="form" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator><br />
           <asp:Button ID="btnSave" runat="server" Text="Continuar" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="99" /><br />
           <div style="font-size:smaller; font-weight:bold"> Cant:&nbsp<span id="selectedItemsCount">0</span>/100</div>
        </center>
    </ContentTemplate>
    </asp:UpdatePanel>
		
	</div>
</div>
<div style="width:79%">
    <div class="form box">
       <h1>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>

        <fieldset>
          <div><label>Canal de Ventas</label><pmc:AutoCompleteTextbox runat="server" ID="txtDistributor" ValidationGroup="form" ServicePath="~/api/SearchAutoComplete.asmx" ServiceMethod="GetCompletionList" AutoCompleteType="Disabled" Width="200px" />
              <asp:RequiredFieldValidator ID="rfvDistributor" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtDistributor" ValidationGroup="form"></asp:RequiredFieldValidator>
          </div>
          <div><label>Texto Introductorio</label><asp:DropDownList ID="ddlQuoteIntroText" runat="server" TabIndex="5"></asp:DropDownList></div>
          <div><label>Condición</label><asp:DropDownList ID="ddlQuoteCondition" runat="server" TabIndex="10"></asp:DropDownList></div>
          <div><label>Descripción</label><asp:TextBox ID="txtDescripcion" runat="server" MaxLength="50" Width="200px" TabIndex="15"></asp:TextBox></div>
          <div><label>Observaciones</label><asp:TextBox ID="txtObservations" runat="server" MaxLength="500" onKeyDown="Count(this, 512)" onChange="Count(this, 512)" Width="220px" TabIndex="20" TextMode="MultiLine" Height="55px" ></asp:TextBox></div>
          <div><label>Vigencia (días)</label><asp:DropDownList ID="ddlQuoteVigency" runat="server" ValidationGroup="VigencyCheck" TabIndex="25"></asp:DropDownList><br /></div>
          <div><label>Email</label><asp:TextBox ID="txtEmail" runat="server" TabIndex="30" MaxLength="50"></asp:TextBox><asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="Ingrese un Email valido" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br /></div>
          <div><label>Contacto</label><asp:TextBox ID="txtContact" runat="server" TabIndex="35" MaxLength="50"></asp:TextBox><br /></div>
        </fieldset>
    </div>
    
    <uc1:PriceMasterList ID="PriceMasterList1" Type="QuoteProductsCreate" runat="server" SaveSelectedItems="true" />
    
    <div style="clear:both"></div>
</div>
</div>
<script type="text/javascript" language="javascript">
$(document).ready(function() {
    // Because the items are updated inside an update panel when we change the amount of records and the pages we use the live event that keeps the checkboxes clickeable.
    $(".chklist").click(quoteClick);
    $(".removeItem").click(removeItem);
});

function Count(text, cant) 
{
	var maxlength = cant;
	if (text.value.length > maxlength)
		text.value = text.value.substring(0,maxlength);
}

function removeItem() {
    var id = $(this).parent().attr("id");
    checkbox_state_remove(id);
    $(this).parent().hide('slow', function() { $(this).remove() });
}

function quoteClick() {
    var value = $(this).val();
    
    var $grid = $(".maingrid tr#pp"+ value + " td").not(".action");
    var code = $grid.eq(0).text();
    var model = $grid.eq(1).text();
    var desc = $grid.eq(2).text();
    
    if ($(this).is(":checked")) {
            var $li = $("<li></li>").attr("id", value);
            $li.append($("<a></a>").text("[x]").addClass("removeItem").click(removeItem));
            $li.append($("<h3></h3>").text(code));
            $li.append($("<p></p>").text(model));
            $li.hide();
            
            $("#<%=productlist.ClientID%>").append($li);
            $li.show('slow');
    }
    else {
        $("li[id='" + value + "']").hide('slow', function() { $(this).remove() });
    }
    
}

Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
function EndRequest(sender, args) 
{
  $(".chklist").click(quoteClick);
  $(".removeItem").click(removeItem);
}
</script>