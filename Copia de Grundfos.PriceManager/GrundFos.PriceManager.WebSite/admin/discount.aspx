<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="discount.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.discount" Title="Price Manager - Modificar Descuentos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
   <div class="page_header"> 
       <h1>
           Modificar Descuentos</h1> 
   </div>
                
<div class="content">
     <div id="discountForm" style="height:220px;">
     <div id="modifyForm" style="float:left; width:45%; height:129px;" class="box">
     <fieldset style="float:left; width:50%;">
        <p><label >Descuento</label>&nbsp&nbsp&nbsp<asp:DropDownList id="ddlDiscount" runat="server"  OnSelectedIndexChanged="ddlDiscount_SelectedIndexChange" AutoPostBack="true" Font-Size="Small" Width="200px" TabIndex="11" >
        </asp:DropDownList></p>
        <p><label >Descripción</label>&nbsp&nbsp&nbsp<asp:TextBox ID="txtModifyDiscount" runat="server" Width="200px" Height="30px" TabIndex="10" MaxLength="7"></asp:TextBox></p>
         <asp:RequiredFieldValidator ID="ReqMD" ControlToValidate="txtModifyDiscount" runat="server" ErrorMessage="Ingrese un número." Display="Dynamic"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="revMD" runat="server" ErrorMessage="Ingrese un número válido."  ControlToValidate="txtModifyDiscount" ValidationExpression="[0-9]+(\.(([0-9][0-9][0-9])|([0-9][0-9])|([0-9]))?)|[0-9]+(\,(([0-9][0-9][0-9])|([0-9][0-9])|([0-9]))?)?" display="dynamic"></asp:RegularExpressionValidator>
        <p><asp:Button ID="btnModify" runat="server" Text="Modificar" OnClick="btnModify_Click" CssClass="button" TabIndex="15" />&nbsp&nbsp&nbsp
         <asp:Label id="lblError" runat="server" visible="false" style="color:Red;"></asp:Label></p>
         <asp:Label ID="lblModification" runat="server" Text="Modificación realizada con éxito!" ForeColor="red" Visible="false"></asp:Label>
     </fieldset>
         </div>
     </div>
  </div>
               

            

</asp:Content>
