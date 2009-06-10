function compraAjax(id) {
    $("#productos").slideUp();
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
    $("#productos").html("");
    var table = jQuery('<table></table>').attr('id', 'tabCarrito');
    for (var obj in variable.Productos) {
        var name = variable.Productos[obj].Nombre;
        if (name.length > 18)
            name = name.substring(0,18) + "...";
        table.append("<tr><td class='prod'>" + variable.Productos[obj].Cant + " · " + name + "</td><td class='precio'>$" + variable.Productos[obj].Precio + "</td></tr>");
    }
    $("#productos").append(table);
    $("#monto").html("Total: $" + variable.MontoActual);
    $("#productos").slideDown();
    
}