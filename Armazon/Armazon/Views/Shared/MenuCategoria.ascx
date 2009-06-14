<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
    jQuery().ready(function() {
        $('.head').corner();
        jQuery('#navigation').accordion({
            active: true,
            header: '.head',
            navigation: true,
            fillSpace: true
        });
        $('#navigation').css('visibility', 'visible');
    });
</script>
  
<div class="basic">	
    <ul id="navigation" style="visibility:hidden">
    <%foreach (var categoria in Armazon.MenuController.getCategorias())
      { %>
      <li>
        <a class="head back"><%=categoria.Nombre%></a>
        <ul>
        <%foreach (var subCategoria in categoria.SubCategorias){ %>
	        <li><a href="/Producto/Listado?idSubCategoria=<%=subCategoria.Id %>"><%=subCategoria.Nombre %></a></li>
        <%} %>
        </ul>
      </li>
    <%}%>
    </ul>
</div>

