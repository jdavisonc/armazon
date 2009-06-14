<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.Categoria>>" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SeleccionarCategoria
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Categorías</h2>
    <table align="center" style="position:relative; top:20px; width:85%">
        <tr>
            <th>
                Nombre
            </th>
            <th style="width:20px"></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <a href="<%= Url.Action("SeleccionarSubCategoria", new { id=item.CategoriaID, pagina = ViewData["pagina"] }) %>">
                    <img src="<%= ResolveUrl("~/Content/detail.png") %>" title="Ver SubCategoria"/>
                </a>
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

