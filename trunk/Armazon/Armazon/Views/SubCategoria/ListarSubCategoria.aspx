<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.SubCategoria>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listar SubCategoria
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Listar SubCategoria</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Nombre
            </th>
            <th>
                Categoria
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Modificar", "Edit", new { id=item.SubCategoriaID }) %> |
                <%= Html.ActionLink("Eliminar", "Delete", new { id = item.SubCategoriaID, categoriaID = item.CategoriaID })%> |
                <%= Html.ActionLink("Asociar Propiedades", "AsociarPropiedades", new { id = item.SubCategoriaID })%> |
                <%= Html.ActionLink("Detalles", "Details", new { id=item.SubCategoriaID })%>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Categoria.Nombre) %>
            </td>
        </tr>
    
    <% } %>

    </table>
    <p>
        <%= Html.ActionLink("Crear Nueva", "Create", new { id = ViewData["CategoriaID"] })%> |
        <%=Html.ActionLink("Ver Categorías", "Index") %> |
    </p>

    

</asp:Content>

