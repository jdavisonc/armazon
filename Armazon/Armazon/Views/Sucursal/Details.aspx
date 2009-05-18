<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTSucursal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalles
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles</h2>

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
            <%= Html.Encode(Model.Latitud.ToString()) %>
        </p>
        <p>
            Longitud:
            <%= Html.Encode(Model.Longitud.ToString()) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Editar", "Edit", new { id=Model.Id }) %> |
        <%=Html.ActionLink("Ver Sucursales", "Index") %>
    </p>

</asp:Content>

