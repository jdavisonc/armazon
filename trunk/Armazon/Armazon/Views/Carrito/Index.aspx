<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTPedido>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Administrar Carro
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    
    <div type="label" id="error" name="error" ><%=ViewData["errorTarjeta"] %>
    </div>
 <h2>Administrar Carro</h2>
    <table>
        <tr>
            <th></th>
            
            <th>
                Nombre
            </th>
            <th>
                Cant
            </th>
            
            <th>
                Precio
            </th>
        </tr>

    <%  int i = 0;
        foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Editar", "Edit", new {  id=i }) %> |
                <%= Html.ActionLink("Detalles", "Details", new { id=i })%>
                <%= Html.ActionLink("Borrar", "Delete", new { id=i })%>
                <%i++; %>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Cant) %>
            </td>
            
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Precio)) %>
            </td>
            
                
            
        </tr>
        
    <% } %>

    </table>
    <br />
    
    <p>
    <button onclick="$('#metodos').fadeIn('slow');$(this).hide()">Seleccionar Metodo de Pago</button>
    
    <div id="metodos" style="background-color:#EDF8FF; width:60%; height:50px;margin-left:110px; padding: 20px;">
        <% using (Html.BeginForm()){%>
            Metodo de Pago: <%= Html.DropDownList("pagos", ViewData["pagos"] as SelectList)%><br><br>
                
            <input type="submit" id="comprar" value="Comprar"  />
        
        <% }%>
    </div>
    
 
    </p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <script type="text/javascript">
        $(function() {
            $('#metodos').hide();
            $('#metodos').corner();    
        });
    </script>
</asp:Content>

