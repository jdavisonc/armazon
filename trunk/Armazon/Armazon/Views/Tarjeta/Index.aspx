<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.MetodoDePago>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Metodo de Pago
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Metodo de Pago</h2>

    <table>
        <tr>
            <th></th>
            <th>
                MetodoDePagoID
            </th>
            <th>
                MetodoDePagoType
            </th>
            <th>
                Numero
            </th>
            <th>
                Usuario
            </th>
            <th>
                Password
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.MetodoDePagoID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.MetodoDePagoID })%>
                <%= Html.ActionLink("Delete", "Delete", new { id=item.MetodoDePagoID })%>
            </td>
            <td>
                <%= Html.Encode(item.MetodoDePagoID) %>
            </td>
            <td>
                <%= Html.Encode(item.MetodoDePagoType) %>
            </td>
            <td>
                <%= Html.Encode(item.Numero) %>
            </td>
            <td>
                <%= Html.Encode(item.Usuario) %>
            </td>
            <td>
                <%= Html.Encode(item.Password) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

