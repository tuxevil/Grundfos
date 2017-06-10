<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addfamily.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.addfamily" Title="Price Manager - Agregar/Modificar Categoría" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
   <div class="page_header"> 
       <h1>Agregar/Modificar Categoría</h1> 
   </div>
                
<div class="content">
     <div id="familyForm" style="height:220px;">
         
         <div id="modifyForm" style="float:left; width:45%;" class="box">
         <%--<h1>Modificar</h1>--%>
         <fieldset style="float:left; width:50%;">
            <p><label >Categoría</label>&nbsp&nbsp&nbsp<asp:DropDownList id="ddlFamilia" runat="server"  OnSelectedIndexChanged="ddlFamilia_SelectedIndexChange" AutoPostBack="true" Font-Size="Small" Width="205px" TabIndex="11" >
            </asp:DropDownList></p>
            <p><label >Nombre</label>&nbsp&nbsp&nbsp<asp:TextBox ID="txtModifyName" Enabled="false" MaxLength="250" runat="server" Width="200px" TabIndex="5"></asp:TextBox></p>
            <p><label >Descripción</label>&nbsp&nbsp&nbsp<asp:TextBox ID="txtModifyDescription" Enabled="false" MaxLength="250" runat="server" Width="200px" Height="30px" TabIndex="10"></asp:TextBox></p>
            <p><asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="btnAdd_Click" CssClass="button" TabIndex="35" />&nbsp&nbsp&nbsp
               <asp:Button ID="btnModify" runat="server" Text="Modificar" OnClick="btnModify_Click" CssClass="button" Enabled="false" TabIndex="15" />&nbsp&nbsp&nbsp
               <asp:Button ID="btnErase" runat="server" Text="Borrar" OnClick="btnErase_Click" CssClass="button" Enabled="false" TabIndex="35" /></p>
            <p><label style="color:Red;width:170px;" visible="false" runat="server" id="lblError">No se puede borrar.</label></p>
        </fieldset>
        </div>
        <div id="addForm" style="float:right; width:45%;" class="box" runat="server" visible="false">
            <%--<h1>Agregar</h1>--%>
            <fieldset>
              <p><label >Nombre</label>&nbsp&nbsp&nbsp<asp:TextBox ID="txtName" runat="server" MaxLength="250" Width="200px" TabIndex="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvName" runat="server" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator></p>
                <p><label >Descripción</label>&nbsp&nbsp&nbsp<asp:TextBox ID="txtDescription" runat="server" MaxLength="250" Width="200px" Height="30px" TabIndex="25"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvDesc" runat="server" ControlToValidate="txtDescription" ErrorMessage="*"></asp:RequiredFieldValidator></p>
              <p><asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" CssClass="button" TabIndex="30" /></p>
            </fieldset>
        </div>
    </div>
</div>
</asp:Content>
