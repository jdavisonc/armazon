<%@ Control Language="C#" AutoEventWireup="true"  Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="carrito">
    <div id="monto"><%/*HttpCookie cogeCookie = Request.Cookies.Get("monto");
                      if (cogeCookie ==null)
                        Response.Write("");
                      else
                          Response.Write("Monto actual del Carrito= "+cogeCookie.Value);*/
                         if (Armazon.MenuController.getProductos()==null)
                             Response.Write("");
                         else
                             Response.Write("Monto actual del Carrito= "+Armazon.MenuController.getProductos().MontoActual);   
                          
                        
                        
                         %>
    </div>    
    <br />
    <div id="productos"><% if (Armazon.MenuController.getProductos() == null)
                               Response.Write("");
                           else
                           {
                            int i = 0;
                                foreach(Armazon.Models.DataTypes.DTPedido aux in Armazon.MenuController.getProductos().Productos)
                                {
                                   
                                       Response.Write("<div id=" + "producto" + i + ">"+"producto: " + aux.Nombre+" cant: " + aux.Cant+"</div>");
                                       i++;                   

                                
                               } 
                           }    
                        %></div>
    
   
</div>
