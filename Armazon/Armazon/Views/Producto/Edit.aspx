<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Models.DataTypes.DTProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Modificar Producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Modificar Producto</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm("Edit", "Producto", FormMethod.Post, new { enctype = "multipart/form-data" })) {%>

        <fieldset>
            <legend>Campos</legend>
            <table>
                <tr>
                    <td>Nombre:</td><td><input type="text" id="txtNombre" name="txtNombre" value='<%= Model.Nombre %>'/> </td>
                </tr>
                <tr>
                    <td>Precio:</td><td><input type="text" id="Text1" name="txtPrecio" value='<%= Model.Precio %>'/> </td>
                </tr>
                <% foreach (Armazon.Models.DataTypes.DTProductAttr attr in Model.Attrs) { %>
                    <tr>
                        <td><%=attr.Nombre%>:</td><td><input type="text" id="<%=attr.ID%>" name="<%=attr.ID%>" value="<%= ((Armazon.Models.DataTypes.DTProductAttrString)attr).Valor %>"/> </td>
                    </tr>
                <%} %>
            </table>
            <br>
            <h3>Imagenes</h3>
            <br>
            
            <div style="display:inline-table">
                <% foreach (Armazon.Models.DataTypes.DTImagen img in Model.Images){ %>
                  <div id="images-<%=img.Id %>" class="images">
                    <img src="<%= Url.Action( "ShowThumbnail", "Producto", new { productID = Model.Id, imageID = img.Id } ) %>" alt="<%= img.Nombre %>" width="150" height="150"/>
                    <br><br>
                    <a onclick="deleteImage(<%=img.Id %>);" style="cursor:pointer"><img src="/Content/remove.png"/></a>
                  </div>
                <% } %>
            </div>
            <br><br>
            <div>
                <p>
                    Subir Imagenes: 
                    <div id="moreUploads"><input type="file" name="files" id="files" onchange="document.getElementById('moreUploadsLink').style.display = 'block';" /></div>
                    <br>
                    <div id="moreUploadsLink" style="display:none;"><a href="javascript:addFileInput();">Agregar Otra Imagen</a><br/><br></div>
                </p>
                <p>
                    <input type="submit" value="Guardar Producto" />
                </p>
            </div>
        </fieldset>

    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/jquery.corner.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('div.images').each(function() {
                $(this).corner();
            });
        });
        var upload_number = 2;
        function addFileInput() {
            var d = document.createElement("div");
            var file = document.createElement("input");
            file.setAttribute("type", "file");
            file.setAttribute("name", "files"+upload_number);
            d.appendChild(file);
            document.getElementById("moreUploads").appendChild(d);
            upload_number++;
        }
        var divimgID;
        function deleteImage(imgID) {
            divimgID = imgID;
            var url = "<%= ResolveUrl("~/Producto/DeleteImage?productID=" + Model.Id) %>&imageID=" + imgID;
            $.getJSON(url, callback);
        }
        function callback(obj) {
            if (obj == true) {
                var nameDiv = '#images-' + divimgID;
                $(nameDiv).hide("slow");
            }
        }
    </script>
</asp:Content>

