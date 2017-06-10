<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteRangeEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.QuoteRangeEditor" %>
<%@ Register Assembly="ProjectBase.WebControls" Namespace="ProjectBase.WebControls"  TagPrefix="pbc" %>

    <div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>
       <fieldset>
            <pbc:DataField ID="txtTitle" Type="Text" Label="Titulo" MaxLength="50" runat="server" IsRequired="true" TabIndex="0" />
            <pbc:DataField runat="server" ID="txtMinimum" Type="Number" NumberType="Integer" Label="Minimo" MaxLength="4" IsRequired="true" TabIndex="5" ValidationGroup="form"/>
            <pbc:DataField runat="server" ID="txtMaximum" Type="Number" NumberType="Integer" Label="Maximo" MaxLength="4" IsRequired="true" TabIndex="10" ValidationGroup="form"/>
       </fieldset>
       <center>
           <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="15" />
        </center>

    </div>
