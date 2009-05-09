<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Categoria>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Modificar Categoría
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Modificar Categoría</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Campos</legend>
            <p>
                <label for="Nombre">Nombre:</label>
                <%= Html.TextBox("Nombre", Model.Nombre) %>
                <%= Html.ValidationMessage("Nombre", "*") %>
            </p>
            <p>
                <input type="submit" value="Grabar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Ver Categorías", "Index") %>
    </div>

</asp:Content>

