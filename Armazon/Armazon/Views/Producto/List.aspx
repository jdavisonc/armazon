<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= ViewData["Title"] %></h2>
    
    <div class="nav">
    <img src="<%=ResolveUrl("~/Content/flecha_derecha.png") %>" />
    <%= ViewData["CategoriaNombre"] %>
    <img src="<%=ResolveUrl("~/Content/flecha_derecha.png") %>" />
    <%= ViewData["SubCategoriaNombre"] %></div>
    <br>
    <div>
        <% Html.RenderPartial("ListadoComun",Model); %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

