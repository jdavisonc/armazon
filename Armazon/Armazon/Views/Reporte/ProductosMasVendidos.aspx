<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.Producto>>" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ProductosMasVendidos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Productos más vendidos</h2>
    <hr />
    <div style="position: relative; top: 40px">
        
        <table align="center">
            <tr>
                <th>
                    Nombre
                </th>
                <th>
                    Precio
                </th>
                <th>
                    SubCategoria
                </th>
            </tr>
        <% foreach (Producto item in Model){ %>
            <tr>
                <td>
                    <%=item.Nombre %>
                </td>
                <td>
                    <%=item.Precio %>
                </td>
                <td>
                    <%=item.SubCategoria.SubCategoriaID %>
                </td>
            </tr>
	    
        <%} %>
        <tr>
            <td colspan=3 align=center>
                <div class="pager">
                    <%= Html.Paginado(Model.PageSize, Model.PageNumber, Model.TotalItemCount)%>
                </div>
            </td>
        </tr>
        </table>
   </div>
   
   <div style="text-align: center;position: relative;top:200px">
        <%= Html.ActionLink("Volver", "SeleccionarSubCategoria", new { id = ViewData["IdCategoria"], pagina = ViewData["pagina"]})%> 
   </div>
	
</asp:Content>
