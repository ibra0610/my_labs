function agregar() {
    var lista = document.getElementById("lista");
    var nuevoNumero = document.getElementsByTagName("li").length + 1;

    var nuevoElemento = document.createElement("li");
    nuevoElemento.textContent = "Elemento" + nuevoNumero;
    lista.appendChild(nuevoElemento);
}

function cambiarFondo() {
    var colorActual = document.body.style.backgroundColor;

    if (colorActual === "" || colorActual === "white" || colorActual === "rgb(255, 255, 255)") {
        document.body.style.backgroundColor = "#83ffc1ff";
    } else {
        document.body.style.backgroundColor = "white";
    }
}

function borrar() {
    var lista = document.getElementById("lista");
    var elementos = lista.getElementsByTagName("li");

    if (elementos.length > 0) {
        lista.removeChild(elementos[elementos.length - 1]);
    }
}