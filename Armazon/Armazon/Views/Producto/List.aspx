<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= ViewData["Title"] %></h2>
    
    <font color=blue><%= ViewData["CategoriaNombre"] %></font>
    ->
    <font color=red><%= ViewData["SubCategoriaNombre"] %></font><br><br>
    
    <% Html.RenderPartial("ListadoComun",Model); %>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

