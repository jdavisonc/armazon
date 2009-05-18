<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTSucursal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Borrar Sucursal
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Borrar Sucursal</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            SucursalID:
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre) %>
        </p>
        <p>
            Direccion:
            <%= Html.Encode(Model.Direccion) %>
        </p>
        <p>
            Latitud:
            <%= Html.Encode(String.Format("{0:F}", Model.Latitud)) %>
        </p>
        <p>
            Longitud:
            <%= Html.Encode(String.Format("{0:F}", Model.Longitud)) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Editar", "Edit", new { id=Model.Id }) %> |
        <%=Html.ActionLink("Ver Sucursales", "Index") %>
    </p>
    <% using (Html.BeginForm()) { %>
    <input name="confirmButton" type="submit" value="Delete" />
    <% } %>

</asp:Content>

