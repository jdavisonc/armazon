<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTCarroVendido>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Mi historial de compras
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Mi historial de compras</h2>
    
    <% if (Model == null || Model.Count() == 0) {%>
        <div style="margin:20px">Usted no ha realizo ninguna compra aun.</div>
    <% } %>

 <%int i = 1; %>
    <% foreach (var item in Model) { %>
       
         <fieldset>
        <legend>Compra <%=i %></legend>
        <p>
            Fecha:
            <%= Html.Encode(item.DatosCarrito.Fecha) %>
        </p>
        <p>
            MetodoDePago:
            <%string aux = item.DatosCarrito.MetodoDePago.ToString();%>
            <%= Html.Encode(item.DatosCarrito.MetodoDePago.ToString().Equals("Armazon.Tarjeta") ? "Tarjeta" : "PayPal")%>
        </p>
        <img src="<%= ResolveUrl("~/Content/btn_ver_detalle.png") %>" onclick="$('#compra<%= i %>').slideDown('slow');$(this).hide();" style="cursor:pointer"/>

<div id="compra<%= i %>" class="compratable">
<br>
<table >
        <tr>
            
            <th style="width: 490px">
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
    </div>
    </fieldset>
    <%i++; %>   
    <% } %>
    <br>
    <a href="<%= Url.Action("Profile","Account",null,null) %>">
    <img src="<%= ResolveUrl("~/Content/btn_volver.png") %>" style="margin-left:20px;" />
    </a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <script type="text/javascript">
        $(function() {
            $('.compratable').hide();  
        });
    </script>
</asp:Content>

