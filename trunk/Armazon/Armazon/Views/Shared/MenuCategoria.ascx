<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

  
<div class="basic">	
    <ul id="navigation">
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

