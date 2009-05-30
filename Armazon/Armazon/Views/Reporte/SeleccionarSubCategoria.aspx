<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.SubCategoria>>" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de SubCategorias
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de SubCategorias</h2>
    <hr />
    <table align="center" style="position:relative; top:40px">
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
                <%= Html.ActionLink("Productos más vendidos", "ProductosMasVendidos", new { id = item.SubCategoriaID, idCategoria = ViewData["IdCategoria"], pagina = Model.PageNumber })%> |
                <%= Html.ActionLink("Productos mejor calificados", "ProductosMejorCalificados", new { id = item.SubCategoriaID, idCategoria = ViewData["IdCategoria"], pagina = Model.PageNumber })%>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Categoria.Nombre) %>
            </td>
        </tr>
    
    <% } %>
    <tr>
        <td colspan=3 align="center">
            <div class="pager">
                <%= Html.Paginado(Model.PageSize, Model.PageNumber, Model.TotalItemCount)%>
            </div>
        </td>
    </tr>
    </table>
    <div style="text-align: center;position: relative;top:260px">
        <%= Html.ActionLink("Volver", "ReportesXSubCategoria", new { page = ViewData["pagina"]})%> 
   </div>

    

</asp:Content>

