<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Tienda>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Tienda
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle Tienda</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            TiendaID:
            <%= Html.Encode(Model.TiendaID) %>
        </p>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre) %>
        </p>
        <p>
            Url:
            <%= Html.Encode(Model.Url) %>
        </p>
        <p>
            TipoAPI:
            <%= Html.Encode(Model.TipoAPI) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Modificar", "Edit", new { id=Model.TiendaID }) %> |
        <%=Html.ActionLink("Eliminar", "Delete", new { id = Model.TiendaID })%> |
        <%=Html.ActionLink("Ver Tiendas", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

