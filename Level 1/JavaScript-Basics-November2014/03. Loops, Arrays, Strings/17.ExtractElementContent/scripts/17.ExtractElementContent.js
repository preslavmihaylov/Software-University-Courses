function extractContent() {
    var input = document.getElementById('tb-range-start').value.split('');

    input = input.filter(function (e) {
        return e !== "'"
    });

    var output = "";
    var content = false;
    for (var index = 0; index < input.length; index++) {
        if (input[index] == ">") {
            content = true;
        } else if (input[index] == "<") {
            content = false;
        } else if (content) {
            output += input[index];
        }
    }

    jsConsole.writeLine(output);
}