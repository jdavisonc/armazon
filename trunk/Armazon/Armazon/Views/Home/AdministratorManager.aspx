<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AdministratorManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AdministratorManager</h2>

        <p><a href="/Categoria">Administaci�n de Categor�as</a></p>
        <p><a href="/SubCategoria">Administaci�n de SubCategor�as</a></p>
        <p><a href="/Propiedad">Administaci�n de Propiedades</a></p>
        <p><a href="/Sucursal">Administaci�n de Sucursales</a></p>
        <p><a href="/Account">Administaci�n de Usuarios</a></p>
        <p><a href="/PayPal">Administaci�n de Metodos de Pago PayPal</a></p>   
        <p><a href="/Tarjeta">Administaci�n de Metodos de Pago Tarjeta</a></p>
        <p><a href="/Tienda">Administaci�n de Tiendas</a></p>
        <p><a href="/Reporte/VentasTotalesXPeriodo">Ventas Totales por Per�odo</a></p>
		<p><a href="/Reporte/UsuariosQueMasTaguean">Usuarios Que Mas Taguean</a></p>		<p><a href="/Reporte/ReportesXSubCategoria">Reportes por SubCategor�a</a></p></asp:Content>
