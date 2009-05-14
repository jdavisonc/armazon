<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Producto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de Productos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Productos</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Nombre
            </th>
            <th>
                SubCategoria
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%=Html.ActionLink("Modificar", "Edit", new { id = item.ProductoID, idSubCategoria = item.SubCategoriaID }).Replace("Modificar", "<img style=\"border:none\" src= \"/Content/modificar.gif\" TITLE=\"Modificar\" />")%> |
                <%=Html.ActionLink("Eliminar", "Delete", new { id = item.ProductoID }).Replace("Eliminar", "<img style=\"border:none\" src= \"/Content/eliminar.gif\" TITLE=\"Eliminar\" />")%> |
                <%=Html.ActionLink("Detalles", "Details", new { id = item.ProductoID }).Replace("Detalles", "<img style=\"border:none\" src= \"/Content/detalles.gif\" TITLE=\"Detalles\" />")%>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.SubCategoria.Nombre) %>
            </td>
        </tr>
    
    <% } %>

    </table>
</asp:Content>

