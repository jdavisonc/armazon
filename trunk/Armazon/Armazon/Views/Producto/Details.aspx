<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Producto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle Producto</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            ProductoID:
            <%= Html.Encode(Model.ProductoID)%>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id = Model.ProductoID })%> |
        <%=Html.ActionLink("Back to List", "Index")%>
    </p>

</asp:Content>

