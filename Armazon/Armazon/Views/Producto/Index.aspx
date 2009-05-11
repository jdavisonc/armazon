<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Producto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listar Productos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Listar Productos</h2>

    <table>
        <tr>
            <th></th>
            <th>
                ProductoID
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Modificar", "Edit", new { id = item.ProductoID })%> |
                <%= Html.ActionLink("Eliminar", "Delete", new { id = item.ProductoID })%> |
                <%= Html.ActionLink("Detalles", "Details", new { id = item.ProductoID })%>
            </td>
            <td>
                <%= Html.Encode(item.ProductoID) %>
            </td>
        </tr>
    
    <% } %>

    </table>
    <p>
        <%= Html.ActionLink("Crear Nueva", "Create")%>
    </p>

</asp:Content>

