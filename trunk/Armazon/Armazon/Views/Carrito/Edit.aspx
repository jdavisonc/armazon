<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTPedido>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>
        
        <fieldset>
            <legend>Datos del Producto</legend>
            <input type="hidden" id="Id" name="Id" value="<%=Model.Id %>"/>
            <p>
                <label for="Cant">Cant:</label>
                <%= Html.DropDownList("Cant", ViewData["CantProd"] as SelectList)%>
                <%= Html.ValidationMessage("Cant", "*") %>
            </p>
            <p>
                <label for="Nombre">Nombre:</label>
                <label for="lbNombre"><%=Model.Nombre%></label>
            </p>
            <p>
                <label for="Precio">Precio:</label>
                <label for="lbPrecio">$<%=Model.Precio%></label>
            </p>
            <p>
                <input type="image" value="submit" src="<%= ResolveUrl("~/Content/btn_guardar.png") %>" />
            </p>
        </fieldset>

    <% } %>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

