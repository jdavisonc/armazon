
// Cargo GoogleAPI Maps
google.load("maps", "2");

$(function() {
    var map = new google.maps.Map2($("#map")[0]);
    map.addControl(new google.maps.SmallMapControl());
    //map.addControl(new google.maps.MapTypeControl());
    if (($("#Latitud").val() == "") && ($("#Longitud").val() == "")) {
        $("#Latitud").val(-34.888916);
        $("#Longitud").val(-56.162281);
    }
    var startPoint = new GLatLng($("#Latitud").val(), $("#Longitud").val());
    map.setCenter(startPoint, 13);
    var marker = new GMarker(startPoint, { draggable: true });
    map.addOverlay(marker);
    GEvent.addListener(map, "click", function(overlay, latlng) {
        if (latlng) {
            $("#Latitud").val(latlng.lat());
            $("#Longitud").val(latlng.lng());
            marker.setLatLng(latlng);
        }
    });
    GEvent.addListener(marker, "dragend", function() {
        $("#Latitud").val(marker.getLatLng().lat());
        $("#Longitud").val(marker.getLatLng().lng());
    });

});
