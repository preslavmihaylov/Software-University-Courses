function modifyText() {
    var input = document.getElementById('tb-range-start').value.split(/[\<\>]/);

    input = input.filter(Boolean);

    for (var index = 0; index < input.length; index++) {
        if (input[index] == "upcase") {
            input[index + 1] = input[index + 1].toUpperCase();
        } else if (input[index] == "lowcase") {
            input[index + 1] = input[index + 1].toLowerCase();
        } else if (input[index] == "mixcase") {
            input[index + 1] = mixCase(input[index + 1]);
        }
    }

    for (var index = 0; index < input.length; index++) {
        if (input[index] != "upcase" && input[index] != "/upcase" &&
            input[index] != "lowcase" && input[index] != "/lowcase" &&
            input[index] != "mixcase" && input[index] != "/mixcase") {

            jsConsole.write(input[index]);
        }
    }

    jsConsole.writeLine();
}

function mixCase(value) {
    var splited = value.split('');

    for (var index = 0; index < splited.length; index++) {
        var random = Math.round(Math.random() * 100);

        if (random < 50) {
            splited[index] = splited[index].toUpperCase();
        } else {
            splited[index] = splited[index].toLowerCase();
        }
    }

    var result = splited.join("");

    return result;
}