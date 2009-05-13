<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Producto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	VerProductosXSubCategoria
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Productos de la SubCategoria: <font color="Red">  <%=ViewData["SubCategoriaNombre"]%> </font></h2>

    <table>
        <tr>
            <th></th>
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
                <%= Html.ActionLink("Edit", "Edit", new { id=item.ProductoID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.ProductoID })%>
            </td>
            <td>
                <%= Html.Encode(item.ProductoID) %>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
        </tr>
    
    <% } %>

    </table>


    <p>
        <%= Html.ActionLink("Crear Producto", "CrearProducto", new { idSubCategoria = ViewData["SubCategoriaID"], idCategoria = ViewData["CategoriaID"] })%> |
    </p>


</asp:Content>

