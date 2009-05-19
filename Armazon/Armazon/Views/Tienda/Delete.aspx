<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Tienda>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Eliminar Tienda
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Eliminar Tienda</h2>
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
        <%=Html.ActionLink("Ver Tiendas", "Index") %>
    </div>
</asp:Content>