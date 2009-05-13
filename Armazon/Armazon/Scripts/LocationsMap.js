﻿
// Cargo GoogleAPI Maps
google.load("maps", "2");

// Hago una llamada para traerme la definicion del mapa en JSON
$(function() {
    if (google.maps.BrowserIsCompatible()) {
        $.getJSON("/Sucursal/GetMap", initialise);
    }
});

function initialise(mapData) {
    var map = new google.maps.Map2($("#map")[0]);
    map.addControl(new google.maps.SmallMapControl());
    map.addControl(new google.maps.MapTypeControl());

    var latlng = new google.maps.LatLng(mapData.LatLng.Latitude, mapData.LatLng.Longitude);
    var zoom = mapData.Zoom;

    map.setCenter(latlng, zoom);

    $.each(mapData.Locations, function(i, location) {
        setupLocationMarker(map, location);
    });
}

function setupLocationMarker(map, location) {
    var latlng = new google.maps.LatLng(location.LatLng.Latitude, location.LatLng.Longitude);
    var marker = new google.maps.Marker(latlng);
    map.addOverlay(marker);

    google.maps.Event.addListener(marker, "click", function(latlng) {
        var html = "<b>Sucursal " + location.Name + "</b><br>" + location.Address;
        map.openInfoWindow(latlng, html);
    });
}

/* Evento para cuando haces click sobre el mapa te de las coordenadas
GEvent.addListener(map, "click", function(overlay, latlng) {
    if (latlng) {
        var myHtml = "The GLatLng value is: " + map.fromLatLngToDivPixel(latlng) + " at zoom level " + map.getZoom();
        map.openInfoWindow(latlng, myHtml);
    }
});*/
