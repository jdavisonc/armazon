<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SubCategor�a Eliminada
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SubCategor�a Eliminada</h2>
    <div>
        <p>La subcategor�a ha sido eliminada con exito.</p>
    </div>
    <div>
        <%=Html.ActionLink("Ver SubCategorias", "ListarSubCategoria", new { id = ViewData["CategoriaID"] })%>
    </div>

</asp:Content>
