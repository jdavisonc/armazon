<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>
  
<script type="text/javascript">
    setTimeout(function() {
        $.getJSON("/Menu/GetTags", silver);
    }, 1000);
    
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