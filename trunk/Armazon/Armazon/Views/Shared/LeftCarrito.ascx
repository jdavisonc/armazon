<%@ Control Language="C#" AutoEventWireup="true"  Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
    jQuery().ready(function() {
        $("#carrito").corner();
    });
</script>
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
