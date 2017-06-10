<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltersView.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.FiltersView" %>
<%@ Import Namespace="PriceManager.Business.Filters"%>

    <div id="filters" class="hideme" style="clear:both">
        <div id="filterForm" class="box">
            <asp:Panel id="pnFiltros" runat="server" DefaultButton="btnSearch" ValidationGroup="Filters">
                <h1>
                Filtros
                <span style="float:right;"><a id="flip" class="flip_filters" style="text-decoration:underline; cursor:pointer;">Mostrar filtros</a></span>
                </h1>
                <fieldset>
                    <asp:UpdatePanel ID="upFilters" ChildrenAsTriggers="true" UpdateMode="Conditional" runat="server">
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lnkCleanFilters" />
                    </Triggers>
                    <ContentTemplate>
                    <asp:PlaceHolder ID="plhFilters" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
                <br />
                <div style="clear:both; text-align:center;">
                    <asp:Button ID="btnSearch" runat="server" Text="Filtrar" ValidationGroup="Filters" Font-Size="13px" CssClass="button" TabIndex="30" OnClick="btnSearch_Click" /> o <asp:LinkButton ID="lnkCleanFilters" Font-Size="13px" Text="Limpiar" OnClick="lnkCleanFilters_Click" runat="server" />                            
                </div>
                    
              </asp:Panel>  
            </div>
    </div>
    
    <div id="filters_data"  style="clear:both">
        <div class="blankBar">
          <span style="float:right;"><a class="flip_filters" style="text-decoration:underline;cursor:pointer;">Mostrar filtros</a></span>
          <p><asp:Label CssClass="big" runat="server" ID="lblFilterText"></asp:Label>
          <asp:PlaceHolder ID="plhCurrentFilters" runat="server"></asp:PlaceHolder>
              &nbsp;
          </p>
        </div>
    </div>
    


