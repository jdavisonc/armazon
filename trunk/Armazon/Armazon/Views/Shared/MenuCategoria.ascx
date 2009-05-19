<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
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