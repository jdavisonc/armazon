<%@ Control Language="C#" AutoEventWireup="true"  Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
    jQuery().ready(function() {
        $("#contentCarrito").corner();
        $("#adicional").corner();
    });
</script>
<div id="contentCarrito">
    <h2>Carrito</h2>
    <div id="carrito">
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
                  Response.Write("Monto actual del Carrito= " + Armazon.MenuController.getProductos().MontoActual);
                  Response.Write("<br />");
                  Response.Write("<br />");  
                  Response.Write("Productos en el carrito:");                
            }   
      %>
        </div>    
        <br />
        <div id="productos">
        <% if (Armazon.MenuController.getProductos() == null)
               Response.Write("");
           else
           {
            int i = 0;
                foreach(Armazon.Models.DataTypes.DTPedido aux in Armazon.MenuController.getProductos().Productos)
                {
                   
                       Response.Write("<div id=" + "producto" + i + ">"+aux.Nombre+" cant: " + aux.Cant+" precio: "+aux.Precio+"</div>");
                       i++;                   

                
               } 
           }    
        %></div>
    </div>
</div>

<div id="adicional">
    <div>
        <a href="/Carrito/" title="Ver Carrito" ><img src="/Content/Shopping_Cart.png" onclick="window.location('Carrito')"/></a>
    </div>
    <div style="position:relative; top: -30px; left:70px;">
        <a href="/Carrito/" title="Ver Carrito" >Ver Carrito</a>
    </div>
</div>

<div>
    <div style="position:relative; left:10px;">
        <a href="/Sucursal/ViewMap" title="Ver Sucursales" ><img src="/Content/sucursales.jpg"/></a>
    </div>
    <div style="position:relative; top: -30px; left:60px;">
        <a href="/Sucursal/ViewMap" title="Ver Sucursales" >Ver Sucursales</a>
    </div>
</div>
