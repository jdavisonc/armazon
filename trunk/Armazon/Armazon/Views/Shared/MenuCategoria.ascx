<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% if (Page.User.IsInRole("Administrador")){ %>
    <p><a href="/Categoria">Administación de Categorías</a></p>
    <p><a href="/SubCategoria">Administación de SubCategorías</a></p>
    <p><a href="/Propiedad">Administación de Propiedades</a></p>
    <p><a href="/Sucursal">Administación de Sucursales</a></p>
    <p><a href="/Account">Administación de Usuarios</a></p>
    <p><a href="/PayPal">Administación de Metodos de Pago PayPal</a></p>   
    <p><a href="/Tarjeta">Administación de Metodos de Pago Tarjeta</a></p>
    <p><a href="/Producto/BuscarProducto">Buscar Productos</a></p>
    <p><a href="/Tienda">Administación de Tiendas</a></p>
<%} else {%>
    <script type="text/javascript">
    jQuery().ready(function(){	
	    // applying the settings
	    jQuery('#theMenu').Accordion({
		    active: 'h3.selected',
		    header: 'h3.head',
		    alwaysOpen: false,
		    animated: true,
		    showSpeed: 400,
		    hideSpeed: 800
	    });
    });	
    </script>
    <ul id="theMenu">
        <%foreach (var categoria in Armazon.MenuController.getCategorias())
          { %>
	        <li>
		        <h3 class="head"><a href="javascript:;"><%=categoria.Nombre%></a></h3>
		        <%foreach (var subCategoria in categoria.SubCategorias){ %>
		            <ul>
			            <li><a href="/SubCategoria/VerProductosXSubCategoria?idSubCategoria=<%=subCategoria.Id %>"><%=subCategoria.Nombre %></a></li>
		            </ul>
                <%} %>
	        </li>
	    <%} %>
    </ul>
<%} %>