<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.CategoryEditor" %>
<%@ Register Assembly="ProjectBase.WebControls" Namespace="ProjectBase.WebControls" TagPrefix="pbc" %>

    <div class="box">
    
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>
    
        <div style="float:right; width:30%">
            <asp:Image runat="server" ID="imgImage" ImageUrl="/img/" Visible="false" />
        </div>
    
        <div class="form">
           <fieldset>
              <pbc:DataField ID="ddlType" Label="Tipo" Type="DropdownList" OnValueChanged="ddlType_SelectedIndexChange" AutoPostBack="true" Enabled="false" IsRequired="True" TabIndex="0" runat="server" />
              <pbc:DataField ID="txtName" Label="Nombre" Type="Text" MaxLength="50" Enabled="false" TabIndex="5" runat="server" IsRequired="true" />
              <pbc:DataField ID="txtDescripcion" Label="Descripción" Type="Text" MaxLength="250" Enabled="false" TabIndex="10" runat="server" />
              
                <asp:UpdatePanel runat="server" ID="upParent" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                      <pbc:DataField ID="ddlParent" Label="Padre" Type="DropdownList" Enabled="false" TabIndex="15" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger  ControlID="ddlType" EventName="ValueChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <pbc:DataField ID="txtNameEnglish" Label="Nombre Ingles" Type="Text" MaxLength="64" Enabled="false" TabIndex="20" runat="server" />
                <pbc:DataField ID="txtDescriptionEnglish" Label="Descripción Ingles" Type="Text" MaxLength="256" Enabled="false" TabIndex="25" runat="server" />              

                <pbc:DataField ID="txtObservations" Type="HtmlEditor" Label="Observación" TabIndex="30" runat="server"  />  
            </fieldset>
        </div>
        
        <div style="width:100%;clear:both">
        <center>
               <asp:UpdatePanel runat="server" ID="upButtons" UpdateMode="Conditional" ChildrenAsTriggers="false">
                 <ContentTemplate>
                    <pbc:SubmitButton ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="35" />
                 </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger  ControlID="ddlParent" EventName="ValueChanged" />
                 </Triggers>
                </asp:UpdatePanel>
            </center>
        </div>
        
    </div>
