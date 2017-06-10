<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteView.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.Viewers.QuoteView" %>
<%@ Register Src="QuoteDetailView.ascx" TagName="QuoteDetailView" TagPrefix="uc1" %>
<%@ Register Src="../editors/QuoteEditor.ascx" TagName="QuoteEditor" TagPrefix="uc2" %>
<uc1:QuoteDetailView id="QuoteDetailView1" runat="server" Visible="true" ></uc1:QuoteDetailView>
<uc2:QuoteEditor ID="QuoteEditor1" runat="server" Visible="false" />
