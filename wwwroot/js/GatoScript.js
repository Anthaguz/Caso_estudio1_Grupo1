$(function () {
    // set up form validation here
});

$("#gatoform").on("submit", function (e) {
    e.preventDefault();
    await(10000);
    query();
});

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
            alert(data);

        }
    });
}


//<div id="contact_form">
//    <form name="contact" action="">
//        <fieldset>
//            <div class="input-box">
//                <label for="name" id="name_label">Name</label>
//                <input type="text" name="name" id="name" minlength="3" placeholder="Monty" class="text-input" required />
//            </div>

//            <div class="input-box">
//                <label for="email" id="email_label">Email</label>
//                <input type="email" name="email" id="email" placeholder="example@tutsplus.com" class="text-input" />
//            </div>

//            <div class="input-box">
//                <label for="phone" id="phone_label">Phone</label>
//                <input type="tel" name="phone" id="phone" class="text-input" placeholder="856-261-9988" />
//            </div>

//            <input type="submit" name="submit" class="button" id="submit_btn" value="Send" />
//        </fieldset>
//    </form>
//    <div class="greetings">
//        <h1>Contact US</h1>
//        <p>We are waiting to hear from you!</p>
//    </div>
//</div>