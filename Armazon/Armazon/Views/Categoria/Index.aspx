<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Categoria>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de Categorķas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Categorķas</h2>

    <table>
        <tr>
            <th></th>
            <th>
                CategoriaID
            </th>
            <th>
                Nombre
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Modificar", "Edit", new { id = item.CategoriaID }).Replace("Modificar", "<img style=\"border:none\" src= \"/Content/pencil.png\" TITLE=\"Modificar\" />")%> |
                <%= Html.ActionLink("Eliminar", "Delete", new { id = item.CategoriaID }).Replace("Eliminar", "<img style=\"border:none\" src= \"/Content/remove.png\" TITLE=\"Eliminar\" />")%> |
                <%= Html.ActionLink("Detalles", "Details", new { id = item.CategoriaID }).Replace("Detalles", "<img style=\"border:none\" src= \"/Content/detail.png\" TITLE=\"Detalles\" />")%>
            </td>
            <td>
                <%= Html.Encode(item.CategoriaID) %>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
        </tr>
    
    <% } %>

    </table>
    <p>        
       <%= Html.ActionLink("Crear Nueva", "Create") %>
    </p>
    
</asp:Content>

