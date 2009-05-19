<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Tienda>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear Categoría
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear Categoría</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Campos</legend>
            <p>
                <label for="Nombre">Nombre:</label>
                <%= Html.TextBox("Nombre") %>
                <%= Html.ValidationMessage("Nombre", "*") %>
            </p>
            <p>
                <label for="Url">Url:</label>
                <%= Html.TextBox("Url") %>
                <%= Html.ValidationMessage("Url", "*") %>
            </p>
            <p>
                <label for="TipoAPI">TipoAPI:</label>
                <%= Html.TextBox("TipoAPI") %>
                <%= Html.ValidationMessage("TipoAPI", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>        
        <%=Html.ActionLink("Ver Tiendas", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

