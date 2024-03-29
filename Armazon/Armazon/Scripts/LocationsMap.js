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
    //map.addControl(new google.maps.MapTypeControl());

    var latlng = new google.maps.LatLng(mapData.LatLng.Latitude, mapData.LatLng.Longitude);
    var zoom = mapData.Zoom;

    map.setCenter(latlng, zoom);

    $.each(mapData.Locations, function(i, location) {
        setupLocationMarker(map, location);
    });
}

function setupLocationMarker(map, location) {
    // Create our "tiny" marker icon
    var blueIcon = new GIcon(G_DEFAULT_ICON);
    blueIcon.image = "/Content/Home.png";
    blueIcon.iconSize = new GSize(24, 24);
    blueIcon.iconAnchor = new GPoint(9, 9);
    blueIcon.shadow = "";


    // Set up our GMarkerOptions object
    markerOptions = { icon: blueIcon };

    var latlng = new google.maps.LatLng(location.LatLng.Latitude, location.LatLng.Longitude);
    var marker = new google.maps.Marker(latlng, markerOptions);
    map.addOverlay(marker);

    GEvent.addListener(marker, "click", function(latlng) {
        var html = "<b>Sucursal " + location.Name + "</b><br>" + location.Address;
        map.openInfoWindow(latlng, html);
    });
}

