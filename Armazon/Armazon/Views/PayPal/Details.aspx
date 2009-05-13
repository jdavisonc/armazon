<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.PayPal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            MetodoDePagoID:
            <%= Html.Encode(Model.MetodoDePagoID) %>
        </p>
        <p>
            MetodoDePagoType:
            <%= Html.Encode(Model.MetodoDePagoType) %>
        </p>
        <p>
            Usuario:
            <%= Html.Encode(Model.Usuario) %>
        </p>
        <p>
            Password:
            <%= Html.Encode(Model.Password) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.MetodoDePagoID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

