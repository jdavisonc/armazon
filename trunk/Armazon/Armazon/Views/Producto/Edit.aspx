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
            
            <img src="<%= Url.Action( "ShowThumbnail", "Imagen", new { id = Model.Images[0].Id } ) %>" />
            <br>
            
            <input type="file" name="files" id="files" onchange="document.getElementById('moreUploadsLink').style.display = 'block';" />
            <div id="moreUploads"></div>
            <div id="moreUploadsLink" style="display:none;"><a href="javascript:addFileInput();">Agregar Otra Imagen</a></div>

            <p>
                <input type="submit" value="Grabar" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <script type="text/javascript">
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
    </script>
</asp:Content>

