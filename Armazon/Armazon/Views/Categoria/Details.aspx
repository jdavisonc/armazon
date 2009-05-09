<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Categoria>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Categor�a
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle Categor�a</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            CategoriaID:
            <%= Html.Encode(Model.CategoriaID) %>
        </p>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Modificar", "Edit", new { id=Model.CategoriaID }) %> |
        <%= Html.ActionLink("Eliminar", "Delete", new { id = Model.CategoriaID })%> |
        <%=Html.ActionLink("Ver Categor�as", "Index") %>
    </p>

</asp:Content>

