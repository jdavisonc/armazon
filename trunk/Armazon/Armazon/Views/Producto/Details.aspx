<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle Producto</h2>

    <fieldset>
        <legend>Campos</legend>
        <p>
            Nombre:
            <%= Html.Encode(Model.Nombre)%>
        </p>
        <% foreach (Armazon.Models.DataTypes.DTProductAttr attr in Model.Attrs){ %>
            <p>
                <%= attr.Nombre %>:
                <%= ((Armazon.Models.DataTypes.DTProductAttrString)attr).Valor %>
            </p>
        <%} %>
        <p>
            SubCategoria:
            <%= Html.Encode(Model.Subcategoria)%>
        </p>        
        <p>
            Etiquetas:
            <% foreach (String tag in Model.Tags){ %>
                <p>
                    <%= tag %>
                </p>
            <%} %>
        </p>
        <p>
            <% using (Html.BeginForm("AddTag","Producto",FormMethod.Post)) {%>
                <input type="hidden" id="productID" name="productID" value="<%=Model.Id%>"/>
                <input type="text" id="tagCollection" name="tagCollection"/>
                <input type="submit" value="Etiquetar"/>            
            <%}%>            
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Modificar", "Edit", new { id = Model.Id, idSubCategoria = Model.SubcaterogiaID })%> |
        <%=Html.ActionLink("Eliminar", "Delete", new { id = Model.Id })%>
    </p>    
</asp:Content>

