<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Tienda>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tiendas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Tiendas</h2>

    <table>
        <tr>
            <th></th>
            <th>
                TiendaID
            </th>
            <th>
                Nombre
            </th>
            <th>
                Url
            </th>
            <th>
                TipoAPI
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Modificar", "Edit", new { id = item.TiendaID }).Replace("Modificar", "<img style=\"border:none\" src= \"/Content/pencil.png\" TITLE=\"Modificar\" />")%> |
                <%= Html.ActionLink("Eliminar", "Delete", new { id = item.TiendaID }).Replace("Eliminar", "<img style=\"border:none\" src= \"/Content/remove.png\" TITLE=\"Eliminar\" />")%> |
                <%= Html.ActionLink("Detalles", "Details", new { id = item.TiendaID }).Replace("Detalles", "<img style=\"border:none\" src= \"/Content/detail.png\" TITLE=\"Detalles\" />")%>
            </td>
            <td>
                <%= Html.Encode(item.TiendaID) %>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Url) %>
            </td>
            <td>
                <%= Html.Encode(item.TipoAPI) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Crear Nueva", "Create")%>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

