<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTCarroVendido>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

 <%int i = 1; %>
    <% foreach (var item in Model) { %>
       
         <fieldset>
        <legend>Carrito Vendido <%=i %></legend>
        <p>
            Fecha:
            <%= Html.Encode(item.DatosCarrito.Fecha) %>
        </p>
        <p>
            MetodoDePago:
            <%string aux = item.DatosCarrito.MetodoDePago.ToString();%>
            <%= Html.Encode(item.DatosCarrito.MetodoDePago.ToString().Equals("Armazon.Tarjeta") ? "Tarjeta" : "PayPal")%>
        </p>
        <p>
            Vendido a:
            <%= Html.Encode(item.DatosCarrito.Usuario.Nombre)%>
        </p>


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

    <% foreach (var item2 in item.Productos) { %>
    
        <tr>
            
            <td>
                <%= Html.Encode(item2.Nombre)%>
            </td>
            <td>
                <%= Html.Encode(item2.Precio) %>
            </td>
            <td>
                <%= Html.Encode(item2.Cant) %>
            </td>
            
        </tr>
    
    <% } %>

    </table>
    </fieldset>
    <%i++; %>   
    <% } %>


</asp:Content>













<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

