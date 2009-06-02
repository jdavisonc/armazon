<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Nombre %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="contenderLeft">
        <div id="imageProductContender">
            <% if ((Model.Images.Count > 0) && (Model.Id > 0)){ %>
                <img id="PImg" src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = Model.Id } ) %>"/>
            <% }else if ((Model.Images.Count > 0) && (Model.Id == 0)){ %>
                <img id="PImg" src="<%= Model.Images[0].ImagenURL %>" width="280" height="280"/>
            <% }else{ %>
                 <img id="PImg" src="<%=ResolveUrl("~/Content/noImageAvailable.jpg") %>" width="280" height="280"/>
            <% } %>
            <br>
            <ul id="imglist">
            <% foreach (Armazon.Models.DataTypes.DTImagen img in Model.Images){ %>
                <% if (Model.Id > 0){ %>
                    <li><img width="34px" height="34px" src="<%= Url.Action( "ShowThumbnail", "Producto", new { productID = Model.Id, imageID = img.Id } ) %>" alt="<%= img.Nombre %>"/></li>
                 <% }else{ %>
                    <li><img width="34px" height="34px" src="<%= img.ImagenURL %>" alt="<%= img.Nombre %>"/></li>
                <% } %>
            <%} %>
            </ul>
        </div>
        <div id="buyBlock">
            Precio: <span style="color:#990000;font-size:20px;font-weight:bold;font-family:Arial">$<%= Model.Precio %></span><br><br>
            Cantidad: 
            <select type="text" id="cantCompra" name="cantCompra" style="font-size:9px;width:40px">
              <% for (int i = 1; i < 20; i++){ %><option value="<%= i %>"><%= i %></option><% } %>
            </select><br>
            <% if (Model.Id > 0){ %>
                <img src="<%= ResolveUrl("~/Content/agregar_carrito.png")%>" onclick="compraAjax(<%=Model.Id %>)" style="cursor:pointer">
            <% }else{ %>
                <img src="<%= ResolveUrl("~/Content/agregar_carrito.png")%>" onclick="compraAjaxTienda(<%= Model.Tienda %>,'<%= Model.ExternalID %>')" style="cursor:pointer">
            <% } %>
        </div>
    </div>
    <div class="detailProduct">
        <div class="sectionProduct">
            <h2><%= Html.Encode(Model.Nombre)%>
            <% if (Page.User.IsInRole("Administrador") && (Model.Id > 0)){ %>
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
        <div style="padding-left:5px">
            <% foreach (Armazon.Models.DataTypes.DTProductAttr attr in Model.Attrs){ %>
                 <b><%= attr.Nombre %></b>: <%= ((Armazon.Models.DataTypes.DTProductAttrString)attr).Valor %><br>
            <%} %>
        </div>
        <div id="Tags" class="sectionProduct">
            <h3><img src="<%= ResolveUrl("~/Content/tag.png") %>" class="imageMiddle"/> Etiquetas</h3>
            <div>
            <%foreach (String tag in Model.Tags){%> 
                <span style="margin-right:20px"><img src="<%= ResolveUrl("~/Content/tag_list.png") %>" class="imageMiddle"/><%=tag%></span>
            <%}%>

            </div>
            <%if ((Model.Id > 0) && (Request.IsAuthenticated)){%>
                <br/><div>
                <% using (Html.BeginForm("AddTag","Producto",FormMethod.Post)){%>
                    <input type="hidden" id="productID" name="productID" value="<%=Model.Id%>"/>
                    Agregar Etiqueta: <input type="text" id="tagCollection" name="tagCollection" />
                    <input type="submit" value="Agregar!"/>                            
                <%}%>            
                </div>
            <%}%>
        </div>
        <div id="reviews" class="sectionProduct">
            <h3><img src="<%= ResolveUrl("~/Content/comments.png") %>" class="imageMiddle"/> Comentarios</h3>
            
            <div id="comments">
            <%  int j = 0;
                foreach (Armazon.Models.DataTypes.DTComment com in Model.Comments){ %>
                <div class="commentBlock">
                    <img src="<%= ResolveUrl("~/Content/comment.png") %>" class="imageMiddle"/>
                    <span class="by">Por <%= com.Username %></span><br>
                    <!-- Rating !!! -->
                    <% j++;
                    for (int i = 1; i < 6; i++){ %>
                        <% if (i == com.Rating){ %>
                           <input name="starComment<%= j%>" type="radio" class="star" disabled="disabled" checked="checked"/>    
                        <%}else{ %>
                           <input name="starComment<%= j %>" type="radio" class="star" disabled="disabled"/>
                        <%} %>
                    <% } %>
                    <!-- ############## -->
                    <br><br>
                    <span class="comment">
                        <% if (com.Comment.Length > 100){%>
                            <%= com.Comment.Substring(0, 100) + "..."%>
                            <div class="commentExcced" id="commentExcced<%= j %>"><%= com.Comment.Substring(100, com.Comment.Length-100)%></div>
                            <a onclick="$('#commentExcced<%= j %>').slideToggle('slow');" style="cursor:pointer">Ver Mas</a>
                        <% }else{ %>
                            <%= com.Comment %>
                        <% } %>
                    </span>
                </div>       
              <% } %>
              <div id="commentJson"></div>
            </div>
            <% if ((Model.Id > 0) && (Armazon.MenuController.puedeComentar())){ %>
                <a onclick="$('#formComments').fadeIn('slow');" style="cursor:pointer;float:right" id="linkAddCommnet">
                    <img src="<%= ResolveUrl("~/Content/add_comment.png") %>" class="imageMiddle"/> Agregar Comentario
                </a>
                <br>
                <div id="formComments">
                    <form id="formformComments">
                        Tu Comentario!<br><br>
                        <input name="commentRating" type="radio" class="star" value="1"/>
                        <input name="commentRating" type="radio" class="star" value="2"/>
                        <input name="commentRating" type="radio" class="star" value="3"/>
                        <input name="commentRating" type="radio" class="star" value="4"/>
                        <input name="commentRating" type="radio" class="star" value="5"/>
                        <textarea id="comment_text" name="commnet_text" style="width: 95%; margin: 5px"></textarea>
                        <input type="hidden" id="productID" name="productID" value="<%= Model.Id %>"
                    </form>
                    <button id="btnComment">Enviar!</button>
                </div>
            <% } %>
        </div>
        
        <div id="recommended" class="sectionProduct">
            <h3><img src="<%= ResolveUrl("~/Content/recommend.png") %>" class="imageMiddle"/> Te recomendamos</h3>
            <div align="center">
                
                    <%List<Armazon.Models.DataTypes.DTProduct> productos = (List<Armazon.Models.DataTypes.DTProduct>)ViewData["LstProductos"];
                      if (productos != null && productos.Count != 0){ %>
                    
                            <ul id="mycarousel" class="jcarousel-skin-tango">
                            <%  foreach (Armazon.Models.DataTypes.DTProduct item in productos)
                                { %>
                                <li>
                                    <% if ((item.Images.Count > 0) && (item.Id > 0))
                                       { %>
                                        <input type="image" src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = item.Id } ) %>" name="btnDetalle" width="110px" height="110px" alt=""/>
                                    <% }
                                       else if ((item.Images.Count > 0) && (item.Id == 0))
                                       { %>
                                        <input type="image" src="<%= item.Images[0].ImagenURL %>" name="btnDetalle" width="110px" height="110px" alt=""/>
                                    <% }
                                       else
                                       { %>
                                        <input type="image" src="/Content/noImageAvailable.jpg" name="btnDetalle" width="110px" height="110px" alt=""/>
                                    <% } %>
                                    <p>
                                        <% if (item.Tienda >= 0)
                                           {%>
                                            <a href="<%=Url.Action("Details", "Producto", new { tiendaID = item.Tienda, externalID = item.ExternalID })%>" ><%= item.Nombre%></a>
                                        <%}
                                           else
                                           { %>
                                            <a href="<%=Url.Action("Details", "Producto", new { productID = item.Id })%>" ><%= item.Nombre%></a>
                                        <%} %>
                                    </p>
                                </li>
                            <%} %>
                            </ul>
                    <%} %>
            </div> 
        </div>
        
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <link href="<%= ResolveUrl("~/Content/Products.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/Content/jquery.rating.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/Content/jquery.rating.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveUrl("~/Scripts/CompraProducto.js")%>" type="text/javascript" ></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery.rating.js")%>" type="text/javascript" ></script>
    <script src="<%= ResolveUrl("~/Scripts/ProductDetails.js")%>" type="text/javascript" ></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery.corner.js")%>" type="text/javascript" ></script>
    <link href="<%= ResolveUrl("~/Content/carrousel/style.css") %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/jquery.jcarousel.pack.js")%>"></script>
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Content/carrousel/jquery.jcarousel.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Content/carrousel/skins/tango/skin.css") %>" />

    
    <script type="text/javascript">
    
    // Credits: Robert Penners easing equations (http://www.robertpenner.com/easing/).
        jQuery.easing['BounceEaseOut'] = function(p, t, b, c, d) {
	        if ((t/=d) < (1/2.75)) {
		        return c*(7.5625*t*t) + b;
	        } else if (t < (2/2.75)) {
		        return c*(7.5625*(t-=(1.5/2.75))*t + .75) + b;
	        } else if (t < (2.5/2.75)) {
		        return c*(7.5625*(t-=(2.25/2.75))*t + .9375) + b;
	        } else {
		        return c*(7.5625*(t-=(2.625/2.75))*t + .984375) + b;
	        }
        };

        jQuery(document).ready(function() {
            jQuery('#mycarousel').jcarousel({
                easing: 'BounceEaseOut',
                animation: 1000
            });
        });
        
        
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
