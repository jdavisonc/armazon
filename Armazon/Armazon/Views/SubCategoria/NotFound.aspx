<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NotFound
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>No se encuentra la SubCategoría</h2>
    
    <p><%=Html.ActionLink("Ver SubCategorias", "ListarSubCategoria", new { id = ViewData["CategoriaID"] })%></p>
    
</asp:Content>
