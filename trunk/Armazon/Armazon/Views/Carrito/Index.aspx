<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Carrito>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

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
            Fecha:
            <%= Html.Encode(String.Format("{0:g}", Model.Fecha)) %>
        </p>
        <p>
            Total:
            <%= Html.Encode(String.Format("{0:F}", Model.Total)) %>
        </p>
        <p>
            MetodoDePagoID:
            <%= Html.Encode(Model.MetodoDePagoID) %>
        </p>
        <p>
            CarritoType:
            <%= Html.Encode(Model.CarritoType) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.CarritoID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

