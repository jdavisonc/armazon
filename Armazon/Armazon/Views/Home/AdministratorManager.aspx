<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AdministratorManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AdministratorManager</h2>

        <p><a href="/Categoria">Administación de Categorías</a></p>
        <p><a href="/SubCategoria">Administación de SubCategorías</a></p>
        <p><a href="/Propiedad">Administación de Propiedades</a></p>
        <p><a href="/Sucursal">Administación de Sucursales</a></p>
        <p><a href="/Account">Administación de Usuarios</a></p>
        <p><a href="/PayPal">Administación de Metodos de Pago PayPal</a></p>   
        <p><a href="/Tarjeta">Administación de Metodos de Pago Tarjeta</a></p>
        <p><a href="/Producto/BuscarProducto">Buscar Productos</a></p>
        <p><a href="/Tienda">Administación de Tiendas</a></p>
</asp:Content>
