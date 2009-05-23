<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTProduct>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= ViewData["Title"] %></h2>
    <% if (Page.User.IsInRole("Administrador")) { %>
    <p>
        <%= Html.ActionLink("Create New", "Create","Producto",null,null)%>
    </p>
    <% } %>
    <div id="listado">
        <%foreach (Armazon.Models.DataTypes.DTProduct p in Model) { %>
        <div class="fltleft prodItem">
            <a href="<%= Url.Action("Details", "Producto", new { id = p.Id })%>" title="Go to <%= p.Nombre %> Details Page">
              <% if (p.Images.Count > 0){ %>
                <img src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = p.Id } ) %>" alt="<%=p.Nombre %>"/>
              <% }else{ %>
                 <img src="/Content/noImageAvailable.jpg" width="150" height="150"/>
              <% } %>
              <p>
              <%=p.Nombre %><br />
                <%=p.Precio.ToString("C")%>
                <% if (Page.User.IsInRole("Administrador")) { %>
                    <br><%= Html.ActionLink("Edit","Edit","Producto", new { id=p.Id, idSubCategoria=p.SubcaterogiaID },null) %>
                <% } %>
              </p>
            </a>
            
        </div>
        <%} %>
    </div>
    <p>        <%= Html.ActionLink("Crear Producto","CrearProducto","SubCategoria",new { idSubCategoria = item.SubCategoriaID, idCategoria = ViewData["CategoriaID"] },null)%> |                            <%= Html.ActionLink("Crear Producto","Create",new{idSubCategoria=item.SubCategoriaID,idCategoria=ViewData["CategoriaID"]})%>|    </p></asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

