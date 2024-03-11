function mostrarTablero(tablero) {
    //var tablero = $("#" + idPartida).val();
    for (var i = 0; i < tablero.length; i++) {
        processCharacter(tablero[i], i);
    }
}

function processCharacter(character, id) {
    id = id + 1;
    if (character === 'X') {
        console.log("Found X");
        $("#c" + id).text(character).removeAttr("style").css({
            "pointer-events": "none",
            "background-color": "red"
        });
    } else if (character === 'O') {
        console.log("Found O");
        $("#c" + id).text(character).removeAttr("style").css({
            "pointer-events": "none",
            "background-color": "blue"
        });
    } else {
        console.log("Found something else");
        // Do something if it's something else
    }
}