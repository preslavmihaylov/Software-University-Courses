function checkInput(key) {
    if (key == 13) {
        var input = document.getElementById('field');

        if (isNaN(input.value)) {
            input.style.background = "red";
        } else {
            input.value = "";
            input.style.background = "white";
        }
    }
}