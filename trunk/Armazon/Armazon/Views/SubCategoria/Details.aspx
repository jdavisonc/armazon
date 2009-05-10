<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.SubCategoria>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle SubCategoría
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle SubCategoría</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            SubCategoriaID:
            <%= Html.Encode(Model.SubCategoriaID) %>
        </p>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre) %>
        </p>
        <p>
            Categoria:
            <%= Html.Encode(Model.Categoria.Nombre) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Modificar", "Edit", new { id=Model.SubCategoriaID }) %> |
        <%= Html.ActionLink("Eliminar", "Delete", new { id = Model.SubCategoriaID, categoriaID = Model.CategoriaID })%> |
        <%=Html.ActionLink("Ver SubCategorias", "ListarSubCategoria", new { id = Model.CategoriaID })%>
    </p>

</asp:Content>

