<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.PayPal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar PayPal
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar PayPal</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Campos</legend>
            
            <p>
                <label for="Usuario">Usuario:</label>
                <%= Html.TextBox("Usuario", Model.Usuario) %>
                <%= Html.ValidationMessage("Usuario", "*") %>
            </p>
            <p>
                <label for="Password">Password:</label>
                <%= Html.TextBox("Password", Model.Password) %>
                <%= Html.ValidationMessage("Password", "*") %>
            </p>
            <p>
                <input type="submit" value="Guardar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Volver", "Index") %>
    </div>

</asp:Content>

