<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Producto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle Producto</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            ProductoID:
            <%= Html.Encode(Model.ProductoID)%>
        </p>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre)%>
        </p>
        <%for (int i = 0; i < Model.Valors.Count; i++ ){ %>
            <p>
                <%= Model.Valors.ElementAt(i).Propiedad.Nombre%>:
                <%= Model.Valors.ElementAt(i).Valor1%>
            </p>
        <%} %>
    </fieldset>
    <p>

        <%=Html.ActionLink("Modificar", "Edit", new { id = Model.ProductoID })%> |
        <%= Html.ActionLink("Eliminar", "Delete", new { id = Model.ProductoID })%> |
        <%=Html.ActionLink("Ver Productos", "Index")%>
    </p>

</asp:Content>

