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
            
            <th style="width: 490px">
                Nombre
            </th>
            <th>
                Cant
            </th>
            
            <th>
                Precio
            </th>
            <th></th>
        </tr>

    <%  int i = 0;
        foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Cant) %>
            </td>
            
            <td>
                <%= Html.Encode("$" + String.Format("{0:F}", item.Precio)) %>
            </td>
            <td>
                <%= Html.ActionLink("Editar", "Edit", new { id = i }).Replace("Editar", "<img style=\"border:none\" src= \"/Content/pencil.png\" TITLE=\"Editar\" />")%> |                
                <%= Html.ActionLink("Borrar", "Delete", new { id = i }).Replace("Borrar", "<img style=\"border:none\" src= \"/Content/remove.png\" TITLE=\"Eliminar\" />")%>
                <%i++; %>
            </td>
            
                
            
        </tr>
        
    <% } %>

    </table>
    <br />
    
    <p>
    <input type="image" onclick="$('#metodos').fadeIn('slow');$(this).hide()" src="<%= ResolveUrl("~/Content/btn_pagos.png") %>" style="vertical-align:middle;margin-left:50px"/>     
    
    <div id="metodos" style="background-color:#D2E8F1; width:60%; height:50px;margin-left:110px; padding: 20px;">
        <% using (Html.BeginForm()){%>
            Metodo de Pago: <%= Html.DropDownList("pagos", ViewData["pagos"] as SelectList)%><br><br>
                
            <input type="image" src="<%= ResolveUrl("~/Content/btn_comprar.png") %>" value="Submit" alt="Submit" style="vertical-align:middle">     
        
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

