<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Propiedad>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Propiedad
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle Propiedad</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            PropiedadID:
            <%= Html.Encode(Model.PropiedadID) %>
        </p>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Modificar", "Edit", new { id=Model.PropiedadID }) %> |
        <%=Html.ActionLink("Eliminar", "Delete", new { id=Model.PropiedadID }) %> |
        <%=Html.ActionLink("Ver Propiedades", "Index") %>
    </p>

</asp:Content>

