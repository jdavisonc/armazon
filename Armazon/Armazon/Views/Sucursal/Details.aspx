<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Sucursal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            SucursalID:
            <%= Html.Encode(Model.SucursalID) %>
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

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.SucursalID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

