<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTProduct>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= ViewData["Title"] %></h2>
    
    <font color=blue><%= ViewData["CategoriaNombre"] %></font>
    ->
    <font color=red><%= ViewData["SubCategoriaNombre"] %></font><br><br>

    <div id="listado">
        <%foreach (Armazon.Models.DataTypes.DTProduct p in Model) { %>
        <div class="fltleft prodItem">
            <a href="<%= Url.Action("Details", "Producto", new { id = p.Id })%>" title="Go to <%= p.Nombre %> Details Page">
              <% if (p.Images.Count > 0){ %>
                <img src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = p.Id } ) %>"  width="150" height="150" alt="<%=p.Nombre %>"/>
              <% }else{ %>
                 <img src="/Content/noImageAvailable.jpg" width="150" height="150"/>
              <% } %>
              <p>
              <%=p.Nombre %><br />
                $<%=p.Precio.ToString()%>
              </p>
            </a>
            
        </div>
        <%} %>
    </div>    
    <% if (Page.User.IsInRole("Administrador")) { %>
    <p>        
        <%= Html.ActionLink("Crear Producto", "CrearProducto", "SubCategoria", new { idSubCategoria = ViewData["SubCategoriaID"], idCategoria = ViewData["CategoriaID"] }, null)%>
<!--    <%= Html.ActionLink("Crear Producto", "Create", new { idSubCategoria = ViewData["SubCategoriaID"], idCategoria = ViewData["CategoriaID"] })%>-->
    </p>
    <% } %>   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

