<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AdministratorManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Administrador</h2>
        <ul>
        <li><a href="/Categoria">Administaci�n de Categor�as</a></li>
        <li><a href="/SubCategoria">Administaci�n de SubCategor�as</a></li>
        <li><a href="/Propiedad">Administaci�n de Propiedades</a></li>
        <li><a href="/Sucursal">Administaci�n de Sucursales</a></li>
        <li><a href="/Account">Administaci�n de Usuarios</a></li>
        <li><a href="/PayPal">Administaci�n de Metodos de Pago PayPal</a></li>   
        <li><a href="/Tarjeta">Administaci�n de Metodos de Pago Tarjeta</a></li>
        <li><a href="/Tienda">Administaci�n de Tiendas</a></li>
        <li><a href="/Reporte/VentasTotalesXPeriodo">Ventas Totales por Per�odo</a></li>
		<li><a href="/Reporte/UsuariosQueMasTaguean">Usuarios Que Mas Taguean</a></li>		
		<li><a href="/Reporte/ReportesXSubCategoria">Reportes por SubCategor�a</a></li>
		</ul>
</asp:Content>
