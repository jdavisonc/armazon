<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Categoria>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear Categor�a
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear Categor�a</h2>

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
                <input type="submit" value="Crear" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Ver Categor�as", "Index") %>
    </div>

</asp:Content>

