<%@ Control Language="C#" AutoEventWireup="true"  Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="contentCarrito">
    <a href="/Carrito/" title="Ver Carrito" style="margin-left:-2px;margin-bottom:0px;padding:0px"><img src="<%= ResolveUrl("~/Content/ver_carrito.png") %>" /></a>
    <div id="carrito">  
        <div id="productos">
            <table id="tabCarrito">
            
                <% if (Armazon.MenuController.getProductos() == null)
                       Response.Write("");
                   else
                   {
                    int i = 0;
                        foreach(Armazon.Models.DataTypes.DTPedido aux in Armazon.MenuController.getProductos().Productos)
                        {
                            string name = aux.Nombre;
                            if (aux.Nombre.Length > 18)
                                name = aux.Nombre.Substring(0, 18) + "...";
                            Response.Write("<tr><td class='prod'>" + aux.Cant + " · " + name + "</td><td class='precio'>$" + aux.Precio + "</td></tr>");
                           i++;                                   
                       } 
                   }    
                %>
            </table>
        </div>
        <div id="monto">
        <%/*HttpCookie cogeCookie = Request.Cookies.Get("monto");
          if (cogeCookie ==null)
            Response.Write("");
          else
              Response.Write("Monto actual del Carrito= "+cogeCookie.Value);*/
            if (Armazon.MenuController.getProductos() == null)
                Response.Write("");
            else
            {
                  Response.Write("Total:  $" + Armazon.MenuController.getProductos().MontoActual);            
            }   
      %>
        </div>  
    </div>
</div>
<div id="adicional">
    <a href="/Sucursal/ViewMap" title="Ver Carrito" ><img src="<%= ResolveUrl("~/Content/ver_sucursales.png") %>"/></a>
</div>
