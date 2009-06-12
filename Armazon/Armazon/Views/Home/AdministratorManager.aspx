<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AdministratorManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Administrador</h2>
        <ul>
        <li><a href="/Categoria">Administación de Categorías</a></li>
        <li><a href="/SubCategoria">Administación de SubCategorías</a></li>
        <li><a href="/Propiedad">Administación de Propiedades</a></li>
        <li><a href="/Sucursal">Administación de Sucursales</a></li>
        <li><a href="/Account">Administación de Usuarios</a></li>
        <li><a href="/PayPal">Administación de Metodos de Pago PayPal</a></li>   
        <li><a href="/Tarjeta">Administación de Metodos de Pago Tarjeta</a></li>
        <li><a href="/Tienda">Administación de Tiendas</a></li>
        <li><a href="/Reporte/VentasTotalesXPeriodo">Ventas Totales por Período</a></li>
		<li><a href="/Reporte/UsuariosQueMasTaguean">Usuarios Que Mas Taguean</a></li>		
		<li><a href="/Reporte/ReportesXSubCategoria">Reportes por SubCategoría</a></li>
		</ul>
</asp:Content>
