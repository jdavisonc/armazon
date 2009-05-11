<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Armazon</h2>
    
        <p><a href="/Categoria">Administación de Categorías</a></p>
        <p><a href="/SubCategoria">Administación de SubCategorías</a></p>
        <p><a href="/Propiedad">Administación de Propiedades</a></p>
        <p><a href="/Sucursal">Administación de Sucursales</a></p>
        
</asp:Content>
