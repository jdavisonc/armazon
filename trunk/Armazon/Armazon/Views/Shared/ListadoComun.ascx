<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Armazon"%>
<table id="listadoProductos">
<tr><td>
<div>
    <%
       Armazon.IPagedList<Armazon.Models.DataTypes.DTProduct> pagedList = (Armazon.IPagedList<Armazon.Models.DataTypes.DTProduct>)ViewData["Collection"];
       foreach (Armazon.Models.DataTypes.DTProduct p in pagedList){ %>
    <%  %>
    <div class="fltleft prodItem">
        <% if (p.Tienda >= 0)
           { %>
        <a href="<%=Url.Action("Details", "Producto", new { tiendaID = p.Tienda, externalID = p.ExternalID })%>"
            title="<%= p.Nombre %>">
            <% }
           else
           { %>
            <a href="<%=Url.Action("Details", "Producto", new { productID = p.Id })%>" title="<%= p.Nombre %>">
                <% } %>
                <% if ((p.Images.Count > 0) && (p.Tienda == -1))
                   { %>
                <img src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = p.Id } ) %>"
                    alt="<%=p.Nombre %>" width="150" height="150" />
                <% }
                   else if ((p.Images.Count > 0) && (p.Tienda != null))
                   { %>
                <img src="<%= p.Images[0].ImagenURL %>" width="150" height="150" />
                <% }
                   else
                   { %>
                <img src="/Content/noImageAvailable.jpg" width="150" height="150" />
                <% } %>
                <p>
                    <%=p.Nombre %><br />
                    $
                    <%=p.Precio.ToString()%>
                    <% if (Page.User.IsInRole("Administrador")){ %>
                        <br><a href="<%= Url.Action("Edit", new { id = p.Id, idSubCategoria = p.SubcaterogiaID }) %>" title="Modificar">
                            <img src="<%=ResolveUrl("~/Content/doc_edit.png")%>"/>
                        </a>
                        <a href="<%=Url.Action("Delete", new { id = p.Id })%>" title="Eliminar">
                            <img src="<%=ResolveUrl("~/Content/doc_remove.png")%>"/>
                        </a>
                     <% } %>
                </p>
            </a>
    </div>
    <%} %>
</div>
</td></tr>
<tr><td align="center">
<div class="pager">
    <%= Html.Paginado(pagedList.PageSize, pagedList.PageNumber, pagedList.TotalItemCount, new { fullText = ViewData["FullText"] })%>
</div>
</td></tr></table>