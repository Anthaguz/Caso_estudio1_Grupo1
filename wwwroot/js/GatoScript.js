//$(function () {
//    // set up form validation here
//});

//$("#gatoform").on("submit", function (e) {
//    e.preventDefault();
//    await(10000);
//    query();
//});

function query(botonPresionado) {
    var dataString = "";
    var c1 = $("#c1").val();
    var c2 = $("#c2").val();
    var c3 = $("#c3").val();
    var c4 = $("#c4").val();
    var c5 = $("#c5").val();
    var c6 = $("#c6").val();
    var c7 = $("#c7").val();
    var c8 = $("#c8").val();
var c9 = $("#c9").val();
    dataString = "c1=" + c1 + "&c2=" + c2 + "&c3=" + c3 + "&c4=" + c4 + "&c5=" + c5 + "&c6=" + c6 + "&c7=" + c7 + "&c8=" + c8 + "&c9=" + c9 + "&botonPresionado=" + botonPresionado;
    alert(dataString); // Solo para verificar que se esté obteniendo correctamente
    $.ajax({
        type: "POST",
        url: "/gato/jugada",
        data: { dataString },
        success: function () {
            alert("Actualidad");
            //ahora vamos a procesar la respuesta del controller que es un simple string, se la mostraremos al usuario en un alert
            //Esto es solo para verificar que se está obteniendo correctamente, por el momento no funciona
            alert(data);

        }
    });
}