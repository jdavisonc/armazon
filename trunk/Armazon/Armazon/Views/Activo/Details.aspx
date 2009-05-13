<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Activo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            CarritoID:
            <%= Html.Encode(Model.CarritoID) %>
        </p>
        <p>
            UsuarioID:
            <%= Html.Encode(Model.UsuarioID) %>
        </p>
        
        
        <p>
            CarritoType:
            <%= Html.Encode(Model.CarritoType) %>
        </p>
        
         <% using (Html.BeginForm()) { %>
        <input name="confirmButton" type="submit" value="Comprar" />
    <% } %>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.CarritoID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

