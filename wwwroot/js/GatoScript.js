function query(botonPresionado) {
    var dataString = "";
    var c1 = $("#c1").text();
    var c2 = $("#c2").text();
    var c3 = $("#c3").text();
    var c4 = $("#c4").text();
    var c5 = $("#c5").text();
    var c6 = $("#c6").text();
    var c7 = $("#c7").text();
    var c8 = $("#c8").text();
    var c9 = $("#c9").text();
    dataString = "c1=" + c1 + "&c2=" + c2 + "&c3=" + c3 + "&c4=" + c4 + "&c5=" + c5 + "&c6=" + c6 + "&c7=" + c7 + "&c8=" + c8 + "&c9=" + c9 + "&botonPresionado=" + botonPresionado;
    //alert(dataString); // Solo para verificar que se esté obteniendo correctamente, descomentar para testear de ser necesario
    $.ajax({
        type: "POST",
        url: "/gato/jugada",
        data: { dataString },
        success: function (data) {
            //alert("Actualidad"); // Solo para verificar que se esté obteniendo una respuesta del POST correctamente, descomentar para testear de ser necesario
            //ahora vamos a procesar la respuesta del controller que es un simple string, se la mostraremos al usuario en un alert
            //Esto es solo para verificar que se está obteniendo correctamente, por el momento no funciona
            //alert(data);
            const entradas = data.split('&');
            const valores = [];
            for (let i = 0; i < entradas.length; i++) {
                valores[i] = entradas[i].split('=');
            }
            for (let i = 0; i < valores.length; i++) {
                let id = valores[i][0]; // Obtener el ID del componente HTML
                let valor = valores[i][1]; // Obtener el valor que debería tener

                // Con JavaScript puro
                // Cambiar el texto dentro del botón
                //document.getElementById(id).innerText = valor;

                // Si el valor es "X" o "O", aplicar los estilos
                //if (valor === "X" || valor === "O") {
                //    // Eliminar todos los estilos actuales y agregar la nueva regla
                //    document.getElementById(id).removeAttribute("style");
                //    document.getElementById(id).style.pointerEvents = "none";
                //}
                
                // Usando JQuery
                if (valor === "X" || valor === "O") {
                    $("#" + id).text(valor).removeAttr("style").css("pointer-events", "none");
                } else {
                    $("#" + id).text(valor); // Si no es "X" ni "O", solo cambiar el texto
                }
            }
        }
    });
}