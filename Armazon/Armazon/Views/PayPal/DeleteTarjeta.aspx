<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Tarjeta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Borrar Tarjeta
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Borrar Tarjeta</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            MetodoDePagoID:
            <%= Html.Encode(Model.MetodoDePagoID) %>
        </p>
        <p>
            MetodoDePagoType:
            <%= Html.Encode(Model.MetodoDePagoType) %>
        </p>
        <p>
            Numero:
            <%= Html.Encode(Model.Numero) %>
        </p>
       <% using (Html.BeginForm()) { %>
        <input name="confirmButton" type="submit" value="Eliminar" />
    <% } %>
    </fieldset>
    <p>

        <%=Html.ActionLink("Editar", "Edit", new { id=Model.MetodoDePagoID }) %> |
        <%=Html.ActionLink("Volver", "Index") %>
    </p>

</asp:Content>

