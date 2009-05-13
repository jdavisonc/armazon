<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Sucursal>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Sucursales
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Sucursales</h2>

    <table>
        <tr>
            <th></th>
            <th>
                SucursalID
            </th>
            <th>
                Nombre
            </th>
            <th>
                Direccion
            </th>
            <th>
                Latitud
            </th>
            <th>
                Longitud
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Modificar", "Edit", new { id = item.SucursalID }).Replace("Modificar", "<img style=\"border:none\" src= \"/Content/modificar.gif\" TITLE=\"Modificar\" />")%> |
                <%= Html.ActionLink("Eliminar", "Delete", new { id = item.SucursalID }).Replace("Eliminar", "<img style=\"border:none\" src= \"/Content/eliminar.gif\" TITLE=\"Eliminar\" />")%> |
                <%= Html.ActionLink("Detalles", "Details", new { id = item.SucursalID }).Replace("Detalles", "<img style=\"border:none\" src= \"/Content/detalles.gif\" TITLE=\"Detalles\" />")%>
            </td>
            <td>
                <%= Html.Encode(item.SucursalID) %>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Direccion) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Latitud)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Longitud)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Crear Sucursal", "Create") %> | <%= Html.ActionLink("Ver Mapa de Sucursales", "ViewMap") %>
    </p>

</asp:Content>

