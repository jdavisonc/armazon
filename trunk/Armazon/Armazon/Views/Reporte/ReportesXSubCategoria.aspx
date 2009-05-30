<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.Categoria>>" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SeleccionarCategoria
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Categorías</h2>
    <hr />
    <table align="center" style="position:relative; top:40px">
        <tr>
            <th></th>
            <th>
                Nombre
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Ver SubCategoría", "SeleccionarSubCategoria", new { id=item.CategoriaID, pagina = ViewData["pagina"] })%>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
        </tr>
    
    <% } %>
    <tr>
        <td colspan=3 align=center>
            <div class="pager">
                <%= Html.Paginado(Model.PageSize, Model.PageNumber, Model.TotalItemCount)%>
            </div>
        </td>
    </tr>
    </table>
    
</asp:Content>

