function compraAjax(id) {
    $("#carrito").slideUp();
    var num = document.getElementById("cantCompra").value;
    var url = "/Producto/AgregarProducto?cant="+num+ "&idProducto="+id;
    $.getJSON(url, popup);
}

function compraAjaxTienda(tiendaID, externalID) {
    var url = "/Producto/PersistirProductoTienda?tiendaID=" + tiendaID + "&externalID=" + externalID;
    $.getJSON(url, function(result) {
        if (result > 0) {
            compraAjax(result);
        }
    });
}

function popup(variable) {
    $("#monto").html("Monto actual del Carrito= " + variable.MontoActual+"<br />"+"<br />"+"Productos en el carrito:");
    $("#productos").html("");
    for (var obj in variable.Productos) {
        $("#productos").append("<div id=" + "producto" + obj + ">" + variable.Productos[obj].Nombre + " cant: " + variable.Productos[obj].Cant + " precio: " + variable.Productos[obj].Precio + "</div>");
    }
    $("#carrito").slideDown();
    
}