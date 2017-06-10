<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurrencyEditor.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.editors.CurrencyEditor" %>
<%@ Register Assembly="ProjectBase.WebControls" Namespace="ProjectBase.WebControls" TagPrefix="pbc" %>
 
    <div class="form box">
       <h1>
       <div class="page_header_links">
         <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">Editar</asp:LinkButton>
         <asp:LinkButton ID="lnkDetails" runat="server" Visible="false" OnClick="lnkDetails_Click">Cancelar</asp:LinkButton>
       </div>
       <asp:Literal ID="lblTitle" runat="server" Text="Detalle"></asp:Literal> 
       </h1>
            <div style="float:right; width:50%;">
               <fieldset>         
                    <asp:GridView ID="grvHistory" runat="server" CssClass="maingrid" AutoGenerateColumns="False" Width="300px" HorizontalAlign="Center" >
                        <Columns>
                            <asp:BoundField DataField="Date" HeaderText="Fecha" />
                            <asp:BoundField DataField="Rate" HeaderText="Cotizaci&#243;n" />
                        </Columns>
                    </asp:GridView>
               </fieldset>
            </div>       
            <div style="width:50%">
                <fieldset>
                    <%--<pbc:DataField ID="txtCurrency" Label="Simbolo" Type="Text" IsRequired="true" MaxLength="3" runat="server" />
                    <pbc:DataField ID="txtValue" Label="Valor" Type="Number" NumberType="Decimal" IsRequired="true" MaxLength="8" runat="server" />
                        <asp:CompareValidator ID="cvValueMin" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un número mayor a 0." Operator="GreaterThanEqual" ControlToValidate="txtValue" ValueToCompare="0" ValidationGroup="form" Type="Double"></asp:CompareValidator>
                        <asp:CompareValidator ID="cvDiferente" runat="server" Display="Dynamic" ErrorMessage="Debe ingresar un número diferente a 1." Operator="NotEqual" ControlToValidate="txtValue" ValueToCompare="1" ValidationGroup="form" Type="Double"></asp:CompareValidator>
                        <pbc:DataField ID="ddlCodes" Label="Código" Type="DropdownList" Enabled="false" IsRequired="True" TabIndex="0" runat="server" />--%>
                    <div><label>Simbolo</label><asp:TextBox ID="txtCurrency" runat="server" MaxLength="3" Width="200px" Enabled="false"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="rfvCurrency" Display="Dynamic" runat="server" ErrorMessage="*" ControlToValidate="txtCurrency" ValidationGroup="form"></asp:RequiredFieldValidator></div>
                    <div><label>Valor</label><asp:TextBox ID="txtValue" runat="server" MaxLength="8" Width="200px" CssClass="input pricefield currency" TabIndex="5" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvValue" Display="Dynamic" runat="server" ErrorMessage="*" ControlToValidate="txtValue" ValidationGroup="valFields"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvValueMin" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar un número mayor a 0." Operator="GreaterThan" ControlToValidate="txtValue" ValueToCompare="0" ValidationGroup="form" Type="Double"></asp:CompareValidator>
                        <asp:CompareValidator ID="cvDiferente" runat="server" Display="Dynamic" ErrorMessage="Debe ingresar un número diferente a 1." Operator="NotEqual" ControlToValidate="txtValue" ValueToCompare="1" ValidationGroup="form" Type="Double"></asp:CompareValidator></div>
                    <div><label>Código</label><asp:DropDownList runat="server" ID="ddlCodes" Width="205px" Enabled="false" TabIndex="10"></asp:DropDownList></div>
                </fieldset>
            </div>
            <div style="clear:both">
            <center>
                <asp:Button ID="btnSave" runat="server" Text="Guardar Cambios" OnClick="btnSave_Click" CssClass="button" ValidationGroup="form" TabIndex="15" />
            </center>
           </div>
    </div>
