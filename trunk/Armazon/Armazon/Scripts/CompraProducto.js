function llamada(id) {
    $.getJSON("/Carrito/AgregarProducto/"+id, popup);
};


function popup(variable) {
        alert('hola');
};