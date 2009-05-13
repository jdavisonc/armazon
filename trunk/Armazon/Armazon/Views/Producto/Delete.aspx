<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Producto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Eliminar Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Eliminar Producto</h2>
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
        <%=Html.ActionLink("Ver Productos", "Index") %>
    </div>

</asp:Content>
