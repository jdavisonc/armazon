<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Categoria>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de Categorías
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Categorías</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Nombre
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Ver SubCategoría", "ListarSubCategoria", new { id=item.CategoriaID })%>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
        </tr>
    
    <% } %>

    </table>
    
</asp:Content>

