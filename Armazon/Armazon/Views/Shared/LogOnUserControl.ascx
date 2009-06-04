<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Bienvenido, <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        | <img style="vertical-align:middle;" src="<%= ResolveUrl("~/Content/cuenta.png") %>"> <%= Html.ActionLink("Cuenta", "Profile", "Account") %>
        
        <% if (Page.User.IsInRole("Administrador")){ %>
            | <img style="vertical-align:middle;" src="<%= ResolveUrl("~/Content/administrador.png") %>"> <%=Html.ActionLink("Administrar", "AdministratorManager", "Home")%>
        <% } %>
        
        | <img style="vertical-align:middle;" src="<%= ResolveUrl("~/Content/salir.png") %>"> <%= Html.ActionLink("Salir", "LogOff", "Account") %>
<%
    }
    else {
%> 
        <img style="vertical-align:middle;" src="<%= ResolveUrl("~/Content/logeo.png") %>"> <%= Html.ActionLink("Ingresar", "LogOn", "Account") %> 
<%
    }
%>
