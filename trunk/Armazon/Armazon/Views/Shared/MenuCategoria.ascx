<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
    jQuery().ready(function() {
        $('.basic').corner();
        $('.head').corner();
        jQuery('#navigation').accordion({
            active: true,
            header: '.head',
            navigation: true,
            fillSpace: true,
        });
    });
</script>
<div class="basic">	
    <ul id="navigation">
    <%foreach (var categoria in Armazon.MenuController.getCategorias())
      { %>
      <li>
        <a class="head"><%=categoria.Nombre%></a>
        <ul>
        <%foreach (var subCategoria in categoria.SubCategorias){ %>
	        <li><a href="/Producto/Listado?idSubCategoria=<%=subCategoria.Id %>"><%=subCategoria.Nombre %></a></li>
        <%} %>
        </ul>
      </li>
    <%}%>
    </ul>
</div>

<br><br />
<div id="TagCloud">
    <%foreach (var tag in Armazon.MenuController.getTags()){%>    
        <span class="tag">
            <font size="<%= Armazon.MenuController.getSizeTag(tag.Nombre)%>">
                <a href="/Producto/ListadoPorTag?nombreTag=<%=tag.Nombre%>"><%=tag.Nombre%></a>
            </font>
        </span>
    <%}%>
</div>