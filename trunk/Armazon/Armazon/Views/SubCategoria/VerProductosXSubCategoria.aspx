<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Producto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	VerProductosXSubCategoria
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Productos de la SubCategoria: <font color="Red">  <%=ViewData["SubCategoriaNombre"]%> </font></h2>

    <table>
        <tr>

            <th>
                ProductoID
            </th>
            <th>
                Nombre
            </th>
        </tr>
    
    <% foreach (var item in Model) { %>
    
        <tr>

            <td>
                <%= Html.Encode(item.ProductoID) %>
            </td>
            <td>
                <%= Html.ActionLink(Html.Encode(item.Nombre), "Details", "Producto", new { id = item.ProductoID }, null)%>
            </td>
        </tr>
    
    <% } %>

    </table>
    <p>
    <% if (Page.User.IsInRole("Administrador")){ %>
        <%= Html.ActionLink("Crear Producto", "CrearProducto", new { idSubCategoria = ViewData["SubCategoriaID"], idCategoria = ViewData["CategoriaID"] })%> |
    <% } %>
        <%= Html.ActionLink("Ver SubCategoría", "ListarSubCategoria", new { id = ViewData["CategoriaID"] })%>
    </p>
</asp:Content>

