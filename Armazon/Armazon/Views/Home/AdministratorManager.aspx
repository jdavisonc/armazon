<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AdministratorManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AdministratorManager</h2>

        <p><a href="/Categoria">Administaci�n de Categor�as</a></p>
        <p><a href="/SubCategoria">Administaci�n de SubCategor�as</a></p>
        <p><a href="/Producto">Administaci�n de Productos</a></p>
        <p><a href="/Propiedad">Administaci�n de Propiedades</a></p>
        <p><a href="/Sucursal">Administaci�n de Sucursales</a></p>
        <p><a href="/Account">Administaci�n de Usuarios</a></p>


</asp:Content>
