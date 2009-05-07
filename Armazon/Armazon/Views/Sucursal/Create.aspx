<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Sucursal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="SucursalID">SucursalID:</label>
                <%= Html.TextBox("SucursalID") %>
                <%= Html.ValidationMessage("SucursalID", "*") %>
            </p>
            <p>
                <label for="Nombre">Nombre:</label>
                <%= Html.TextBox("Nombre") %>
                <%= Html.ValidationMessage("Nombre", "*") %>
            </p>
            <p>
                <label for="Direccion">Direccion:</label>
                <%= Html.TextBox("Direccion") %>
                <%= Html.ValidationMessage("Direccion", "*") %>
            </p>
            <p>
                <label for="Latitud">Latitud:</label>
                <%= Html.TextBox("Latitud") %>
                <%= Html.ValidationMessage("Latitud", "*") %>
            </p>
            <p>
                <label for="Longitud">Longitud:</label>
                <%= Html.TextBox("Longitud") %>
                <%= Html.ValidationMessage("Longitud", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

