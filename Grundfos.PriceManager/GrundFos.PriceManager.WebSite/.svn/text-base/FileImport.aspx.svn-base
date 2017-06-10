<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="FileImport.aspx.cs" Inherits="GrundFos.PriceManager.WebSite.FileImport" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMain" runat="server">
    <table style="width: 845px">
        <tr>
            <td>
    <asp:Label ID="Label1" runat="server" Text="Seleccione Archivo:"></asp:Label></td>
            <td style="width: 377px">
    <asp:FileUpload ID="fuArchImp" runat="server" /></td>
            <td rowspan="4" style="width: 168px">
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                <br />
                <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                </td>
            <td style="width: 377px">
                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="Tiene Encabezado?" /></td>
        </tr>
        <tr>
            <td>
                Caracter separador:
            </td>
            <td style="width: 377px">
                <asp:TextBox ID="TextBox4" runat="server" MaxLength="1" Width="12px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
    Descripcion de Importacion:
            </td>
            <td style="width: 377px">
    <asp:TextBox ID="TextBox2" runat="server" MaxLength="50" Width="256px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 377px">
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Subir" /></td>
            <td style="width: 168px">
                <asp:Button ID="Button1"
        runat="server" OnClick="Button1_Click" Text="Importar" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 377px">
            </td>
            <td style="width: 168px">
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Ver Resultados" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 377px">
            </td>
            <td style="width: 168px">
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Exportar Errores" /></td>
        </tr>
    </table>
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label><br />
    <asp:Label ID="Label3" runat="server"></asp:Label><br />
    <asp:Label ID="Label4" runat="server"></asp:Label><br />
    &nbsp;Agregar<asp:GridView ID="GridView1" runat="server" BackColor="#80FF80">
    </asp:GridView>
    Modificar
    &nbsp; &nbsp;
    <br />
    <asp:GridView ID="GridView2" runat="server" BackColor="#FFFF80">
    </asp:GridView>
    Error<br />
    <asp:GridView ID="GridView3" runat="server" BackColor="#FF8080">
    </asp:GridView>
    &nbsp;<br />
</asp:Content>
