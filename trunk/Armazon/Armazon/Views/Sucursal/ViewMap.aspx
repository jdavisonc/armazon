<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Mapa de Sucursales
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Mapa de Sucursales</h2>
    
    <div id="map" style="width : 100%; height : 400px; margin : 0px; padding : 10px; float : middle;"></div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <!--<script src="http://www.google.com/jsapi?key=ABQIAAAAPywn24BLjZz4J8wGxSmDYBT2yXp_ZAY8_ufC3CFXhHIE1NvwkxS-a7EL29HXobr7gLj77MS16aXbIQ" type="text/javascript"></script>-->
    <script src="http://www.google.com/jsapi?key=ABQIAAAAp0Kj6-TRULdy9KWugN_GfxTAdLk6fhpyuNdDdRr81ySzv4W5CRSHcX_iuexOywKZQSEdjN-rXx8BAA" type="text/javascript"></script>
    <script src="../../Scripts/LocationsMap.js" type="text/javascript" ></script>
</asp:Content>
