function llamada(id) {
    
    var num = document.getElementById("cantCompra").value;
    var url = "/Producto/AgregarProducto?cant="+num+ "&idProducto="+id;
    
    $.getJSON(url, popup);
};


function popup(variable) {
    $("#carrito").hide();
    $("#monto").html("Monto actual del Carrito= " + variable.MontoActual+"<br />"+"<br />"+"Productos en el carrito:");

    $("#productos").html("");
    for (var obj in variable.Productos) {


        $("#productos").append("<div id=" + "producto" + obj + ">" + variable.Productos[obj].Nombre + " cant: " + variable.Productos[obj].Cant + " precio: " + variable.Productos[obj].Precio + "</div>");
        



    }
    
    $("#carrito").show();    
    
};