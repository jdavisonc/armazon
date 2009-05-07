<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Sucursal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

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
            <%= Html.Encode(String.Format("{0:F}", Model.Latitud)) %>
        </p>
        <p>
            Longitud:
            <%= Html.Encode(String.Format("{0:F}", Model.Longitud)) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.SucursalID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>
    <% using (Html.BeginForm()) { %>
    <input name="confirmButton" type="submit" value="Delete" />
    <% } %>

</asp:Content>

