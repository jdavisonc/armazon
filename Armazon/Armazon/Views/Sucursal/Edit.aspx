<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Sucursal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Nombre">Nombre:</label>
                <%= Html.TextBox("Nombre", Model.Nombre) %>
                <%= Html.ValidationMessage("Nombre", "*") %>
            </p>
            <p>
                <label for="Direccion">Direccion:</label>
                <%= Html.TextBox("Direccion", Model.Direccion) %>
                <%= Html.ValidationMessage("Direccion", "*") %>
            </p>
            <p>
                <label for="Latitud">Latitud:</label>
                <%= Html.TextBox("Latitud", Model.Latitud.ToString()) %>
                <%= Html.ValidationMessage("Latitud", "*") %>
            </p>
            <p>
                <label for="Longitud">Longitud:</label>
                <%= Html.TextBox("Longitud", Model.Longitud.ToString()) %>
                <%= Html.ValidationMessage("Longitud", "*") %>
            </p>
            <div id="map" style="width : 400px; height : 400px; margin : 0px; padding : 10px; background-color:Black"></div>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="http://www.google.com/jsapi?key=ABQIAAAAp0Kj6-TRULdy9KWugN_GfxTAdLk6fhpyuNdDdRr81ySzv4W5CRSHcX_iuexOywKZQSEdjN-rXx8BAA" type="text/javascript"></script>
    <script src="../../Scripts/LocationMapAdd.js" type="text/javascript" ></script>
</asp:Content>