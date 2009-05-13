<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Armazon.Valor>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Modificar Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Modificar Producto</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Campos</legend>
            
            
            <table>
                <tr>
                    <td>Nombre:</td><td><input type="text" id="txtNombre" name="txtNombre" value='<%=ViewData["nmProducto"] %>'/> </td>
                </tr>
                <%foreach (var item in Model) { %>
                    <tr>
                        <td><%=item.Propiedad.Nombre%>:</td><td><input type="text" id="<%=item.PropiedadID%>" name="<%=item.PropiedadID%>" value="<%=item.Valor1 %>"/> </td>
                    </tr>
                <%} %>
            </table>
        
            <p>
                <input type="submit" value="Grabar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Ver Productos", "Index")%>
    </div>

</asp:Content>

