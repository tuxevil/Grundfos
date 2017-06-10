<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PricePoliticsEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.PricePoliticsEditor" %>
<%@ Register Assembly="PriceManager.Business" Namespace="PriceManager.Business.Controls"  TagPrefix="pmc" %>
<script type="text/javascript">

    function CheckCodes(src, args)
    {
        var grund = document.getElementById('<%=txtFormula1.ClientID%>');
        var prov = document.getElementById('<%=txtFormula2.ClientID%>');
        if ((grund.value == null || grund.value == '') && (prov.value == null || prov.value == ''))
        {
          args.IsValid=  false;
        }  
        else
        {
          args.IsValid = true;
        }
    }
    
    $(document).ready(function() {
        $(".formula").focus(showFormula);
        $(".formula").click(showFormula);
        
        $(".formula").parent().mouseleave(
        function() 
        {
            $("#formula").hide();
        }
        );
        
        $(".button").click(
            function() {
                var $input = $(this).parent().prev();
                $input.val($input.val() + $(this).text());
                $input.focus().val($input.val());
            } 
        );
    });
    
    function showFormula() 
    {
       $(this).after($("#formula").show());
    }
    
    
    
</script> 

<div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>

       <fieldset>
          <div><label>Categoria</label><pmc:LinkedDropDown ID="ddlCategoryLinked" runat="server"  /></div>
          <div><label>Proveedor</label><asp:DropDownList ID="ddlProvider" runat="server" Width="205px" TabIndex="5"></asp:DropDownList></div>
          <div><label>Fórmula</label><asp:TextBox ID="txtFormula1" CssClass="formula" AutoCompleteType="Disabled" MaxLength="50" runat="server" Width="200px" TabIndex="10" ValidationGroup="form"></asp:TextBox>    <span id="formula">
    <span class="button">GRP</span> <span class="button">TP</span> <span class="button">/</span> <span class="button">*</span> <span class="button">-</span> <span class="button">+</span>
          </span>&nbsp </div>
          <div><label runat="server" id="lblform2" visible="false">Fórmula Secundaria</label><asp:TextBox ID="txtFormula2" MaxLength="50" CssClass="formula" AutoCompleteType="Disabled" runat="server" Width="200px" TabIndex="15" ValidationGroup="form" Visible="false"></asp:TextBox>&nbsp</div>
       </fieldset>
        <asp:CustomValidator ID="cv1of2" runat="server" ValidationGroup="form" Display="Dynamic" ErrorMessage="Por favor, ingrese una formula." ClientValidationFunction="CheckCodes" />
       <asp:Label runat="server" ID="lblError" Text="Por favor, ingrese una formula." ForeColor="red" Visible="false"></asp:Label>
       <br />
       <center>
       <%--<div ID="litError" class="flash_alert" runat="server" visible="false"><asp:Label ID="lblErrorDetail" runat="server" ></asp:Label></div>--%>
       <br />
           <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="20" />
        </center>

    </div>


 