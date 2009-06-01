<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.MetodoDePago>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            
            <th>
                MetodoDePagoType
            </th>
            <th>
                Numero
            </th>
            
            <th>
                Titular
            </th>
            <th>
                Vencimiento
            </th>
            <th>
                Tipo
            </th>
            <th>
                Validada
            </th>
        </tr>

    <% foreach (var item in Model) { %>
     <% if(item.MetodoDePagoType == "Tarjeta") { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.MetodoDePagoID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.MetodoDePagoID })%>
            </td>
            
            <td>
                <%= Html.Encode(item.MetodoDePagoType) %>
            </td>
            <td>
                <%= Html.Encode(item.Numero) %>
            </td>
            
            <td>
                <%= Html.Encode(item.Titular) %>
            </td>
            <td>
                <%= Html.Encode(item.Vencimiento) %>
            </td>
            <td>
                <%= Html.Encode(item.Tipo) %>
            </td>
            <td>
                <%= Html.Encode(item.Validada) %>
            </td>
        </tr>
    <%  }%>
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

