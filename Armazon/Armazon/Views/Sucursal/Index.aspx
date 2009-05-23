<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTSucursal>>" %>

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

    <% foreach (Armazon.Models.DataTypes.DTSucursal item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Modificar", "Edit", new { id = item.Id }).Replace("Modificar", "<img style=\"border:none\" src= \"/Content/pencil.png\" TITLE=\"Modificar\" />")%> |
                <%= Html.ActionLink("Eliminar", "Delete", new { id = item.Id }).Replace("Eliminar", "<img style=\"border:none\" src= \"/Content/remove.png\" TITLE=\"Eliminar\" />")%> |
                <%= Html.ActionLink("Detalles", "Details", new { id = item.Id }).Replace("Detalles", "<img style=\"border:none\" src= \"/Content/detail.png\" TITLE=\"Detalles\" />")%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
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

