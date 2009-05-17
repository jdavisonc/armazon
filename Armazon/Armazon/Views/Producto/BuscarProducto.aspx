<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Producto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BuscarProducto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <h2>Buscar Productos</h2>
    <% using (Html.BeginForm()){%>
        <p>
            <label for="Nombre">Ingrese el nombre del producto: </label> <input type="text" id="fullText" name="fullText" />
        </p>
        <input type="submit" id="btnBuscar" name="btnBuscar" value="Buscar" />
    <%} %>
    
    <% if (Model != null){ %>
        <table>
            <tr>
                <th>Nombre</th>
            </tr>
            <%foreach (Armazon.Producto item in Model)
              { %>
                <tr>
                    <td><%=item.Nombre%></td>
                </tr>
            <%} %>
        </table>
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>
