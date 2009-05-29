<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.Models.DataTypes.DTPedido>>" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DetalleCarrito
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle Carrito</h2>
    <hr />
    <div style="position:relative; top:20px">
        <table align="center">
            <tr>
                <th>
                    Producto
                </th>
                <th>
                    Precio
                </th>
                <th>
                    Cantidad
                </th>
            </tr>
	        <% foreach (Armazon.Models.DataTypes.DTPedido item in Model){ %>
	            <tr>
                    <td>
                        <%= item.Nombre%> 
                    </td>
                    <td>
                        <%=item.Precio %>
                    </td>
                    <td>
                        <%=item.Cant %>
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
	   <p>
	        <form action="/Reporte/VentasTotalesXPeriodo" id="frmVolver" method="post">
	            
	            <input type="hidden" id="txtFechaInicio" name="txtFechaInicio" value='<%=ViewData["txtFechaInicio"] %>' />
	            <input type="hidden" id="txtFechaFin" name="txtFechaFin" value='<%=ViewData["txtFechaFin"] %>' />
	            <input type="hidden" id="page" name="page" value='<%=ViewData["pagina"] %>' />
	            <input type="submit" id="btnVolver" name="btnVolver" value="Volver" />
	        </form>
	   </p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>
