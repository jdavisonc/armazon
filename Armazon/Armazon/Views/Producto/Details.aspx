<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="contenderLeft">
        <div id="imageProductContender">
            <% if (Model.Images.Count > 0){ %>
                <img id="PImg" src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = Model.Id } ) %>"/>
            <% }else{ %>
                 <img src="<%=ResolveUrl("~/Content/noImageAvailable.jpg") %>" width="280" height="280"/>
            <% } %>
            <br>
            <ul id="imglist">
            <% foreach (Armazon.Models.DataTypes.DTImagen img in Model.Images){ %>
                 <li><img width="34px" height="34px" src="<%= Url.Action( "ShowThumbnail", "Producto", new { productID = Model.Id, imageID = img.Id } ) %>" alt="<%= img.Nombre %>"/></li>
            <%} %>
            </ul>
        </div>
        <div id="buyBlock">
            Cantidad: 
            <select type="text" name="cantCompra" style="font-size:9px;width:40px">
              <% for (int i = 1; i < 20; i++){ %><option value="<%= i %>"><%= i %></option><% } %>
            </select><br>
            <img src="<%= ResolveUrl("~/Content/agregar_carrito.png")%>" onclick="llamada(<%=Model.Id %>)" style="cursor:pointer">
        </div>
    </div>
    <div class="detailProduct">
        <div class="sectionProduct">
            <h2><%= Html.Encode(Model.Nombre)%>
            <% if (Page.User.IsInRole("Administrador")){ %>
                <a href="<%= Url.Action("Modificar", "Edit", new { id = Model.Id, idSubCategoria = Model.SubcaterogiaID }) %>" title="Modificar">
                    <img src="<%=ResolveUrl("~/Content/doc_edit.png")%>"/>
                </a>
                <a href="<%=Url.Action("Eliminar", "Delete", new { id = Model.Id })%>" title="Eliminar">
                    <img src="<%=ResolveUrl("~/Content/doc_remove.png")%>"/>
                </a>
            <% } %>
            </h2>
            <!-- Rating !!! -->
            <input name="starPro" type="radio" class="star" disabled="disabled"/>
            <input name="starPro" type="radio" class="star" disabled="disabled"/>
            <input name="starPro" type="radio" class="star" checked="checked" disabled="disabled"/>
            <input name="starPro" type="radio" class="star" disabled="disabled"/>
            <input name="starPro" type="radio" class="star" disabled="disabled"/>
            <!-- ############## -->
        </div>
        <br>
                    Precio: <span style="color:#990000;font-size:16px;font-weight:bold;font-family:Arial">$<%= Model.Precio %></span><br>
        <% foreach (Armazon.Models.DataTypes.DTProductAttr attr in Model.Attrs){ %>
             <%= attr.Nombre %>: <%= ((Armazon.Models.DataTypes.DTProductAttrString)attr).Valor %><br>
        <%} %>
    
        <div id="addTag" class="sectionProduct">
            <h3><img src="<%= ResolveUrl("~/Content/tag.png") %>" class="imageMiddle"/> Etiquetas</h3><br>
            <%foreach (String tag in Model.Tags){%> 
                <img src="<%= ResolveUrl("~/Content/tag_list.png") %>" class="imageMiddle"/><%=tag%><br>
            <%}%><br>
            <% using (Html.BeginForm("AddTag","Producto",FormMethod.Post)) {%>
                <input type="hidden" id="productID" name="productID" value="<%=Model.Id%>"/>
                Agregar Etiqueta: <input type="text" id="tagCollection" name="tagCollection" />
                <input type="submit" value="Agregar!"/>                            
            <%}%>            
        </div>
        <div id="reviews" class="sectionProduct">
            <h3><img src="<%= ResolveUrl("~/Content/comments.png") %>" class="imageMiddle"/> Comentarios</h3>
            <br>
            <div class="commentBlock">
                <img src="<%= ResolveUrl("~/Content/comment.png") %>" class="imageMiddle"/>
                <span class="by">Por <a href="#">harley</a></span><br>
                <!-- Rating !!! -->
                <input name="starComment1" type="radio" class="star" disabled="disabled"/>
                <input name="starComment1" type="radio" class="star" disabled="disabled"/>
                <input name="starComment1" type="radio" class="star" disabled="disabled"/>
                <input name="starComment1" type="radio" class="star" disabled="disabled"/>
                <input name="starComment1" type="radio" class="star" disabled="disabled" checked="checked"/>
                <!-- ############## -->
                <br><br>
                <span class="comment">
                    Don't even think about this magazine unless you are into shopping!!! I thought I had everything I needed until I peeked into Lucky one day.
                    <br>
                    The magazine scours the globe to find great items from clothing and accessories to cosmetics to housewares and so forth. They even listed sites for locating old-fashioned sweets and soda (great gift for a parent or grandparent)!
                </span>
            </div>
        </div>
        <div id="recommended" class="sectionProduct">
            <h3>Te recomendamos</h3>
            
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/Products.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveUrl("~/Scripts/jquery-1.3.2.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery.corner.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/CompraProducto.js")%>" type="text/javascript" ></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery.rating.js")%>" type="text/javascript" ></script>
    <link href="<%= ResolveUrl("~/Content/jquery.rating.css")%>" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function() {
            $('#buyBlock').corner();
            $('.commentBlock').corner();
            $('#imglist li img').hover(
                function() {
                    $('#PImg').attr("src", this.src);
                },
                function() {
                }
            );
        });
    </script>
</asp:Content>