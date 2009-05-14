<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Controllers.ViewModels.BuscarProductoFormVM>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BuscarProducto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <h2>Buscar Productos</h2>
    <% using (Html.BeginForm()){%>
        <p>
            <label for="Nombre">Ingrese el nombre del producto: </label> <input type="text" id="fullText" name="fullText" value="<%=Model.FullText %>" />
        </p>
        <input type="submit" id="btnBuscar" name="btnBuscar" value="Buscar" />
    <%} %>
    
    <table>
        <%if (Model.dtProductos.Count != 0 || Model.lstProductos.Count != 0){ %>
        <tr>
            <th>Nombre</th>
        </tr>
        <%} %>
        <%foreach (var item in Model.lstProductos){ %>
            <tr>
                <td><%=item.Nombre %></td>
            </tr>
        <%} %>
        <%foreach (var item in Model.dtProductos){ %>
            <tr>
                <td><%=((Armazon.Models.DataTypes.DTProductAttrString)item.Attrs.First()).Valor %></td>
            </tr>
        <%} %>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>
