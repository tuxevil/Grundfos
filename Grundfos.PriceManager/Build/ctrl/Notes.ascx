<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notes.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.Notes" %>

<div class="box">
    
    <h1>
    <div class="page_header_links">
    <asp:LinkButton runat="server" ID="lnkSeeAll" OnClick="lnkSeeAll_Click">Mostrar todas</asp:LinkButton>
    </div>
    Notas</h1>

    <div ID="litNoItems" class="flash_notice" runat="server">Ingrese la primer nota para éste ítem.</div>
    
    <asp:Repeater ID="rpterNotes" runat="server" OnItemDataBound="rpterNotes_ItemDataBound" OnItemCommand="rpterNotes_ItemCommand">
            <ItemTemplate>
                <div class="note">
                    <h2>
                    <span style="float:right;"><asp:ImageButton ID="lnkErase" runat="server" ToolTip="Eliminar" ImageUrl="/img/trash.gif" CommandName="Erase" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.Id") %>'/></span>
                    <asp:Literal ID="litDate" runat="server"></asp:Literal></h2>
                    <strong><asp:Literal ID="litUser" runat="server"></asp:Literal></strong>
                    
                    <p><%# DataBinder.Eval(Container, "DataItem.Description")%></p>
                </div>
            </ItemTemplate>
    </asp:Repeater>
               <br />
    <div class="form noteform box">
        <fieldset>
             <div><label>Comentario</label><asp:TextBox runat="server" ID="txtDescription" onKeyDown="Count(this, 1024)" onChange="Count(this,1024)"  TextMode="MultiLine" CssClass="textarea" Rows="5" Columns="30" ValidationGroup="savenote"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ErrorMessage="*" ValidationGroup="savenote" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
             </div>
        </fieldset>
        <center>
        <div><asp:CustomValidator ID="cvHtmlTags" runat="server" ValidationGroup="savenote" Display="Dynamic" ErrorMessage="Por favor, no ingrese código malicioso." ClientValidationFunction="ContainsHtml"/></div>
        <asp:LinkButton runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Agregar Nota" ValidationGroup="savenote" />
        </center>
    </div>
</div>
<script language="javascript">

function ContainsHtml(src, args)
{
    var comment = document.getElementById('<%=txtDescription.ClientID%>');
	var htmlRegex = new RegExp(/<\/?\w+((\s+\w+(\s*=\s*(?:".*?"|'.*?'|[^'">\s]+))?)+\s*|\s*)\/?>/gim);
	var matches = comment.value.match(htmlRegex);
	
	if(matches != null)
	{   
	    args.IsValid =  false;
	}
	else
	{
	    args.IsValid =  true;
	}
}

function Count(text, cant) 
{
	var maxlength = cant;
	
	if (text.value.length > maxlength)
	{
		text.value = text.value.substring(0,maxlength);
	}

}
</Script>