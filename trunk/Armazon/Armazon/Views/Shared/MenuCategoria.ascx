<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
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
		            <li><a href="/Producto/Listado?idSubCategoria=<%=subCategoria.Id %>"><%=subCategoria.Nombre %></a></li>
	            </ul>
            <%} %>
        </li>
    <%} %>
</ul>

<ul id="TagCloud">
    <%foreach (var tag in Armazon.MenuController.getTags()){%>
        <li>
	        <h3 class="head"><a href="javascript:;"><%=tag.Nombre%></a></h3>	        
        </li>
    <%}%>
</ul>