<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Sucursal>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

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
                <%= Html.ActionLink("Edit", "Edit", new { id=item.SucursalID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.SucursalID })%>
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
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

