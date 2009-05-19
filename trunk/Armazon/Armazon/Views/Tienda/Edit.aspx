<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Tienda>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Modificar Tienda
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Modificar Tienda</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Campos</legend>
            <p>
                <label for="Nombre">Nombre:</label>
                <%= Html.TextBox("Nombre",Model.Nombre) %>
                <%= Html.ValidationMessage("Nombre", "*") %>
            </p>
            <p>
                <label for="Url">Url:</label>
                <%= Html.TextBox("Url", Model.Url) %>
                <%= Html.ValidationMessage("Url", "*") %>
            </p>
            <p>
                <label for="TipoAPI">TipoAPI:</label>
                <%= Html.TextBox("TipoAPI", Model.TipoAPI) %>
                <%= Html.ValidationMessage("TipoAPI", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Ver Tiendas", "Index") %>
    </div>
</asp:Content>

