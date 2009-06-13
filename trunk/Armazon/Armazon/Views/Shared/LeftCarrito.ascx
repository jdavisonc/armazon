<%@ Control Language="C#" AutoEventWireup="true"  Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>

<script type="text/javascript">
    setTimeout(function() {
        $.getJSON("/Menu/GetTags", silver);
    }, 2000);
    
    function silver(variable) {
        var control = document.getElementsByName("Xaml1")[0];
        var ruta = document.getElementById("hdnRuta").value;
        for(var i in variable){
            var src = ruta + "/Producto/ListadoPorTag?nombreTag=" + variable[i].Nombre;
            control.content.TagCloud.AddTag(variable[i].Nombre,src, variable[i].CantAp);
        }
        control.content.TagCloud.ProcessTags();
    }
        
    jQuery().ready(function() {
        $('.basic').corner();
        $('.head').corner();
        jQuery('#navigation').accordion({
            active: true,
            header: '.head',
            navigation: true,
            fillSpace: true
        });
    });
</script>


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

<br/><br/>    
    
<div style="width:190px; height:190px;">
    <form id="form1" runat="server" style="height:100%;">
        <input type="hidden" id="hdnRuta" value="<%="http://" + Request.Url.Host + ":" + Request.Url.Port%>" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div  style="height:100%;">
            <asp:Silverlight ID="Xaml1" name="Xaml1" runat="server" Source="~/ClientBin/DiggSample.xap" MinimumVersion="2.0.31005.0" Width="100%" Height="100%" />
        </div>
    </form>
</div>