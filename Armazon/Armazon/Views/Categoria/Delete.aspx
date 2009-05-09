<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Categoria>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Eliminar Categoría
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Eliminar Categoría</h2>
    <fieldset>
        <legend>Campos</legend>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre) %>
        </p>
        
    <% using (Html.BeginForm()) { %>
        <input name="confirmButton" type="submit" value="Eliminar" />
    <% } %>
    </fieldset>
    <div>
        <%=Html.ActionLink("Ver Categorías", "Index") %>
    </div>
</asp:Content>
