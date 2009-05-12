<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Controllers.ViewModels.CrearProductoFormVM>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear Producto</h2>
    <% using (Html.BeginForm()) {%>
        <table>
        <%foreach (var item in Model.getPropiedades()) { %>
            <tr>
                <td><%=item.Nombre%>:</td><td><input id="<%=item.PropiedadID%>" name="<%=item.PropiedadID%>" /> </td>
            </tr>
        <%} %>
        </table>
        <input type="submit" id="btnConfirmar" value="Confirmar" />
    <%} %>
</asp:Content>
