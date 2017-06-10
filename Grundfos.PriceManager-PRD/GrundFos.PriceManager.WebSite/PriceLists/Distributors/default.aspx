<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.PriceLists.Distributors._default" Title="Untitled Page" %>
<%@ Register Assembly="PriceManager.Business" Namespace="PriceManager.Business.Controls"  TagPrefix="pmc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
  <script language="javascript" type="text/javascript">
    
    var postBackElement = null;
    
    function GetDistributor(elem)
    {
        // Validate the page, make sure if a Validation Group is needed.
        Page_ClientValidate();
        if (Page_IsValid) {
            postBackElement = elem;
            var distributor = $("#<%=txtDistributor.ClientID%>").val();
            PageMethods.HavePriceList(distributor, OnSuccess);
        }
        
        // Always return false to avoid calling the default postback
        return false;
    }

    function OnSuccess(result)
    {
        if(result == true && !confirm("Canal de Venta con Lista de Precio asignada, ¿desea sobreescribir?"))
            return;
            
        __doPostBack(postBackElement.name, "");
    }
 </script>
    <div ID="litNoItems" class="flash_empty" runat="server" visible="false">"No hay Canales de Venta asignados para este Grupo de Precios."</div>
    <div class="detail_list">
          <asp:Repeater ID="rpterDistributors" OnItemDataBound="rpterDistributors_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <div class="item">
                               <h1><asp:HyperLink runat="server" ID="lnkGo" /></h1>
                               <p><label>Codigo</label><span><asp:Literal ID="litCode" runat="server" /></span></p>
                               <p><label>Descuento</label><span><asp:Literal ID="litDiscount" runat="server" /></span></p>
                               <p><label>País</label><span><asp:Literal ID="litCountry" runat="server" /></span></p>
                        </div>
                    </ItemTemplate>
          </asp:Repeater>
    </div>
    <fieldset>
        <div runat="server" id="addDistributor">
            <label>Canal de Venta</label><pmc:AutoCompleteTextbox runat="server" ID="txtDistributor" ValidationGroup="form" ServicePath="~/api/SearchAutoComplete.asmx" ServiceMethod="GetCompletionList" AutoCompleteType="Disabled" Width="200px" />&nbsp
            <asp:RequiredFieldValidator ID="rfvDistributor" runat="server" ControlToValidate="txtDistributor" ValidationGroup="form" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:Button ID="btnSave" runat="server" Text="Guardar Canal de Venta" OnClientClick="return GetDistributor(this);" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="35" />
        </div>
    </fieldset>
</asp:Content>
