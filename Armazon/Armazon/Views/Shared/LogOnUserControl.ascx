<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Bienvenido, <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        | <%= Html.ActionLink("Cuenta", "Profile", "Account") %>
        
        <% if (Page.User.IsInRole("Administrador")){ %>
            | <%=Html.ActionLink("Administrar", "AdministratorManager", "Home")%>
        <% } %>
        
        | <%= Html.ActionLink("Salir", "LogOff", "Account") %>
<%
    }
    else {
%> 
         <%= Html.ActionLink("Ingresar", "LogOn", "Account") %> 
<%
    }
%>
