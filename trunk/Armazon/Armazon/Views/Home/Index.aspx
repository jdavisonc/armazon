<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Armazon</h2>
    
    <p><a href="/Producto/BuscarProducto">Buscar Productos</a></p>
    <p><a href="/SubCategoria">Listar Productos por SubCategorías</a></p>
</asp:Content>
