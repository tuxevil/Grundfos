<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DistributorContactEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.DistributorContactEditor" %>
<%@ Register Assembly="ProjectBase.WebControls" Namespace="ProjectBase.WebControls"  TagPrefix="pbc" %>
<asp:UpdatePanel runat = "server" UpdateMode="Conditional" ChildrenAsTriggers="true" ID="upDce">
    <ContentTemplate>
        <div class="detail_list" runat="server" id="contactSquare">
            <div class="item" style="margin-bottom:auto;">
                <div>
                    <asp:Panel runat="server" ID="pnl" DefaultButton="btnSave">
                        <h2 runat="server" id="barTitle" class="contactOn">
                            <div style="float:right;">
                                <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
                                <pbc:SubmitButton runat="server" ID="btnSave" Text="Guardar" OnClick="btnSave_Click" TabIndex="11" CssClass="button" />
                                <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
                                <asp:ImageButton runat="server" ID="btnStatus" OnClick="btnStatus_Click" ImageUrl="~/img/deactivate.png" />
                            </div>
                                <asp:Label runat="server" ID="lblCompleteName"></asp:Label>
                        </h2>
                        
                        <div class="form">
                            <fieldset>
                                <pbc:DataField ID="txtLastName" Label="Apellido" Type="Text" runat="server"  MaxLength="50" IsRequired="true" Visible="false" TabIndex="1"/>
                                <pbc:DataField runat="server" ID="txtName" Type="Text" Label="Nombre" MaxLength="50" Visible="false" TabIndex="5"/>
                                <pbc:DataField runat="server" ID="txtMail" Type="Email" Label="Email" MaxLength="50" IsRequired="true" TabIndex="8"/>
                            </fieldset>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
