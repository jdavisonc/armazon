<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Nombre %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="contenderLeft">
        <div id="imageProductContender">
            <% if ((Model.Images.Count > 0) && (Model.Tienda == -1)){ %>
                <img id="PImg" src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = Model.Id } ) %>"/>
            <% }else if ((Model.Images.Count > 0) && (Model.Tienda != null)){ %>
                <img src="<%= Model.Images[0].ImagenURL %>" width="280" height="280"/>
            <% }else{ %>
                 <img src="<%=ResolveUrl("~/Content/noImageAvailable.jpg") %>" width="280" height="280"/>
            <% } %>
            <br>
            <ul id="imglist">
            <% foreach (Armazon.Models.DataTypes.DTImagen img in Model.Images){ %>
                <% if (Model.Tienda == -1){ %>
                    <li><img width="34px" height="34px" src="<%= Url.Action( "ShowThumbnail", "Producto", new { productID = Model.Id, imageID = img.Id } ) %>" alt="<%= img.Nombre %>"/></li>
                 <% }else{ %>
                    <li><img width="34px" height="34px" src="<%= img.ImagenURL %>" alt="<%= img.Nombre %>"/></li>
                <% } %>
            <%} %>
            </ul>
        </div>
        <div id="buyBlock">
            Cantidad: 
            <select type="text" id="cantCompra" name="cantCompra" style="font-size:9px;width:40px">
              <% for (int i = 1; i < 20; i++){ %><option value="<%= i %>"><%= i %></option><% } %>
            </select><br>
            <img src="<%= ResolveUrl("~/Content/agregar_carrito.png")%>" onclick="llamada(<%=Model.Id %>)" style="cursor:pointer">
        </div>
    </div>
    <div class="detailProduct">
        <div class="sectionProduct">
            <h2><%= Html.Encode(Model.Nombre)%>
            <% if (Page.User.IsInRole("Administrador") && (Model.Tienda == -1)){ %>
                <a href="<%= Url.Action("Edit", new { id = Model.Id, idSubCategoria = Model.SubcaterogiaID }) %>" title="Modificar">
                    <img src="<%=ResolveUrl("~/Content/doc_edit.png")%>"/>
                </a>
                <a href="<%=Url.Action("Delete", new { id = Model.Id })%>" title="Eliminar">
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
    
        <div id="Tags" class="sectionProduct">
            <h3><img src="<%= ResolveUrl("~/Content/tag.png") %>" class="imageMiddle"/> Etiquetas</h3><br>
            <%foreach (String tag in Model.Tags){%> 
                <span style="float: left;width:100px"><img src="<%= ResolveUrl("~/Content/tag_list.png") %>" class="imageMiddle"/><%=tag%></span>
            <%}%>
            <br><br/>
            
            
            
            <%if (Request.IsAuthenticated){%>
                <div style="display:inline">
                    <%using (Html.BeginForm("AddTag","Producto",FormMethod.Post)){%>
                <input type="hidden" id="productID" name="productID" value="<%=Model.Id%>"/>
                Agregar Etiqueta: <input type="text" id="tagCollection" name="tagCollection" />
                <input type="submit" value="Agregar!"/>                            
                <%}%>            
                </div>
            <%}%>
            
            
            
        </div>
        <div id="reviews" class="sectionProduct">
            <h3><img src="<%= ResolveUrl("~/Content/comments.png") %>" class="imageMiddle"/> Comentarios</h3>
            <br>
            <%  int j = 0;
                foreach (Armazon.Models.DataTypes.DTComment com in Model.Comments){ %>
                <div class="commentBlock">
                    <img src="<%= ResolveUrl("~/Content/comment.png") %>" class="imageMiddle"/>
                    <span class="by">Por <a href="#">harley</a></span><br>
                    <!-- Rating !!! -->
                    <% j++;
                    for (int i = 0; i < 5; i++){ %>
                        <% if (i == com.Rating){ %>
                           <input name="starComment<%= j%>" type="radio" class="star" disabled="disabled" checked="checked"/>    
                        <%}else{ %>
                           <input name="starComment<%= j %>" type="radio" class="star" disabled="disabled"/>
                        <%} %>
                    <% } %>
                    <!-- ############## -->
                    <br><br>
                    <span class="comment">
                        <%= com.Comment %>
                    </span>
                </div>       
              <% } %>
            
            <a onclick="$('#formComments').fadeIn('slow');" style="cursor:pointer;float:right">
                <img src="<%= ResolveUrl("~/Content/add_comment.png") %>" class="imageMiddle"/> Agregar Comentario
            </a>
            
            <div id="formComments">
                <form>
                    Tu Comentario!<br><br>
                    <input name="commentRating" type="radio" class="star"/>
                    <input name="commentRating" type="radio" class="star"/>
                    <input name="commentRating" type="radio" class="star"/>
                    <input name="commentRating" type="radio" class="star"/>
                    <input name="commentRating" type="radio" class="star"/>
                    <textarea id="commnet_text" name="commnet_text" style="width: 95%; margin: 5px"></textarea>
                    <br>
                    <input type="submit" value="Enviar!" />
                </form>
            </div>
        </div>
        <br>
        <div id="recommended" class="sectionProduct">
            <h3><img src="<%= ResolveUrl("~/Content/recommend.png") %>" class="imageMiddle"/> Te recomendamos</h3>
            
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
            $('#formComments').hide();
            $('#formComments').corner();
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