<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Tarjeta>" %>

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
                <label for="Numero">Numero:</label>
                <%= Html.TextBox("Numero") %>
                <%= Html.ValidationMessage("Numero", "*") %>
            </p>
            
            <p>
                <label for="Titular">Titular:</label>
                <%= Html.TextBox("Titular") %>
                <%= Html.ValidationMessage("Titular", "*") %>
            </p>
            <p>
                <label for="Vencimiento">Vencimiento:</label>
                <%= Html.TextBox("Vencimiento") %>
                <%= Html.ValidationMessage("Vencimiento", "*") %>
            </p>
            <p>
                <label for="Tipo">Tipo:</label>
                <%= Html.DropDownList("tiposTarjeta", ViewData["tiposTarjeta"] as SelectList)%>
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

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

