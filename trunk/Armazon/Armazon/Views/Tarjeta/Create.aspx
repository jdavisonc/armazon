<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Tarjeta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Ingresar datos de tarjeta
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ingresar datos de tarjeta</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Datos</legend>
            
            
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
                <input type="image" src="<%= ResolveUrl("~/Content/btn_comprar.png") %>" value="Submit" alt="Submit" style="vertical-align:middle">     
            </p>
        </fieldset>

    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

