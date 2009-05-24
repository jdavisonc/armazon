function llamada(id) {

    alert(id);
    var num = document.getElementById("Text1").value;
    var url = "/Producto/AgregarProducto?cant="+num+ "&idProducto="+id;
    alert(url);
    $.getJSON(url, popup);
};


function popup(variable) {
    $("#carrito").hide();
    $("#monto").html("Monto actual del Carrito= " + variable.MontoActual);

    $("#productos").html("");
    for (var obj in variable.Productos) {


        $("#productos").append("<div id=" + "producto" + obj + ">" + "producto: " + variable.Productos[obj].Nombre + " cant: " + variable.Productos[obj].Cant + "</div>");
        



    }
    
    $("#carrito").show();    
    
};