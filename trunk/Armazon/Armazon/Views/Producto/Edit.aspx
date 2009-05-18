<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTProduct>" %>

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
                    <td>Nombre:</td><td><input type="text" id="txtNombre" name="txtNombre" value='<%= Model.Nombre %>'/> </td>
                </tr>
                <% foreach (Armazon.Models.DataTypes.DTProductAttr attr in Model.Attrs) { %>
                    <tr>
                        <td><%=attr.Nombre%>:</td><td><input type="text" id="<%=attr.ID%>" name="<%=attr.ID%>" value="<%= ((Armazon.Models.DataTypes.DTProductAttrString)attr).Valor %>"/> </td>
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

