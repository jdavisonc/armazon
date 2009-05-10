<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SubCategoría Eliminada
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SubCategoría Eliminada</h2>
    <div>
        <p>La subcategoría ha sido eliminada con exito.</p>
    </div>
    <div>
        <%=Html.ActionLink("Ver SubCategorias", "ListarSubCategoria", new { id = ViewData["CategoriaID"] })%>
    </div>

</asp:Content>
