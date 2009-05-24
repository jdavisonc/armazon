<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

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
            Etiquetas:  <%foreach (String tag in Model.Tags){%> <%=tag%> | <%}%>
        </p>
        <p>
            <% using (Html.BeginForm("AddTag","Producto",FormMethod.Post)) {%>
                <input type="hidden" id="productID" name="productID" value="<%=Model.Id%>"/>
                <input type="text" id="tagCollection" name="tagCollection"/>
                <input type="submit" value="Etiquetar"/>            
                
            <%}%>            
        </p>
        <p>
        
        <input type="button" value="Comprar" onclick="llamada(<%=Model.Id %>)" />
        <input id="Text1" type="text" name="cantCompra"/>  
       
       &nbsp;</p>
        
    </fieldset>
    <p>
        <%=Html.ActionLink("Modificar", "Edit", new { id = Model.Id, idSubCategoria = Model.SubcaterogiaID })%> |
        <%=Html.ActionLink("Eliminar", "Delete", new { id = Model.Id })%>
    </p>    
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/CompraProducto.js" type="text/javascript" ></script>
</asp:Content>