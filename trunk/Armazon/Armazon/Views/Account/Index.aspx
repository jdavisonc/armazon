<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Security.MembershipUserCollection>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listar de Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Listar de Usuarios</h2>

    <%= Html.Encode(ViewData["Error"])%><br>
    <table>
        <tr>
            <th></th>
            <th>
                Nombre
            </th>
            <th>
                EMail
            </th>
            <th>
                Administrador
            </th>            
            <th>
                Ultimo Logeo
            </th>       
        </tr>

    <% foreach (MembershipUser item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Eliminar", "Delete", new { userName=item.UserName }) %> |
                <%= Html.ActionLink("Convertir en Administrador", "SetToAdministrator", new { userName=item.UserName }) %>
            </td>
            <td>
                <%= Html.Encode(item.UserName) %>
            </td>
            <td>
                <%= Html.Encode(item.Email) %>
            </td>
            <td>
                <% if (Roles.IsUserInRole(item.UserName, "Administrador")) { Response.Write("Si"); } else { Response.Write("No"); } %>
            </td>            
            <td>
                <%= Html.Encode(item.LastLoginDate) %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

