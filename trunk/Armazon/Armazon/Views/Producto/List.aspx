<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTProduct>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= ViewData["Title"] %></h2>

    <div id="listado">
        <%foreach (Armazon.Models.DataTypes.DTProduct p in Model) { %>
        <div class="fltleft prodItem">
            <a href="<%= Url.Action("Details", "Producto", new { id = p.Id })%>" title="Go to <%= p.Nombre %> Details Page">
              <% if (p.Images.Count > 0){ %>
                <img src="<%= Url.Action( "ShowThumbnail", "Imagen", new { id = p.Images[0].Id } ) %>" alt="<%=p.Nombre %>"/>
              <% }else{ %>
                 <img src="/Content/noImageAvailable.jpg" width="150" height="150"/>
              <% } %>
              <p>
              <%=p.Nombre %><br />
                <%=p.Precio.ToString("C")%>
                <% if (Page.User.IsInRole("Administrador")) { %>
                    <br><%= Html.ActionLink("Edit","Edit", new { id=p.Id }) %>
                <% } %>
              </p>
            </a>
            
        </div>
        <%} %>
    </div>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

