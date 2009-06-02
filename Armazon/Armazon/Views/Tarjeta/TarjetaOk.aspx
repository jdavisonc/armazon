<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.MetodoDePago>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	TarjetaOk
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>La compra se ha realizado satisfactoriamente</h2>
    <% double total = Armazon.MenuController.getMontoEnCarroActivo();%>
    <%if (total > 70000)
      {
          string error = "La compra ha exedido el monto soportado por la tarjeta.";
          Response.Redirect("/Carrito/index?error="+error);
    

      } %>
    <%  Armazon.Models.DataTypes.DTCarroVendido dtcvendido = Armazon.MenuController.finalizarVentaCarrito();%>
    
    
    
    
    <fieldset>
        <legend>Carrito Vendido</legend>
        <p>
            Fecha:
            <%= Html.Encode(dtcvendido.DatosCarrito.Fecha) %>
        </p>
        <p>
            MetodoDePago:
            <%string aux = dtcvendido.DatosCarrito.MetodoDePago.ToString();%>
            <%= Html.Encode(dtcvendido.DatosCarrito.MetodoDePago.ToString().Equals("Armazon.Tarjeta") ? "Tarjeta" : "PayPal")%>
        </p>
        <p>
            Vendido a:
            <%= Html.Encode(dtcvendido.DatosCarrito.Usuario.Nombre) %>
        </p>
</fieldset>

<table>
        <tr>
            
            <th>
                Nombre
            </th>
            <th>
                Precio
            </th>
            <th>
                Cantidad
            </th>
            
        </tr>

    <% foreach (var item in dtcvendido.Productos) { %>
    
        <tr>
            
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Precio) %>
            </td>
            <td>
                <%= Html.Encode(item.Cant) %>
            </td>
            
        </tr>
    
    <% } %>

    </table>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>
