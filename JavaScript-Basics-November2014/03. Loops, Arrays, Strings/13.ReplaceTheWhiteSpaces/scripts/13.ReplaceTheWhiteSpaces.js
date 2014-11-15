function removeWhiteSpace() {
    var input = document.getElementById('tb-range-start').value.split(/[ ]+/);

    var output = '';
    for (var index = 0; index < input.length; index++) {
        output += input[index];
    }

    jsConsole.writeLine(output);
}