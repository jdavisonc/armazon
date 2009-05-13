<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Controllers.ViewModels.DetalleProductoFromVM>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle Producto</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            Nombre:
            <%= Html.Encode(Model.getProducto().Nombre)%>
        </p>
        <%for (int i = 0; i < Model.getValores().Count; i++ ){ %>
            <p>
                <%= Model.getValores().ElementAt(i).Propiedad.Nombre%>:
                <%= Model.getValores().ElementAt(i).Valor1%>
            </p>
        <%} %>
        <p>
            SubCategoria:
            <%= Html.Encode(Model.getProducto().SubCategoria.Nombre)%>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Modificar", "Edit", new { id = Model.getProducto().ProductoID })%> |
        <%= Html.ActionLink("Eliminar", "Delete", new { id = Model.getProducto().ProductoID })%> |
        <%=Html.ActionLink("Ver Productos", "Index")%>
    </p>

</asp:Content>

