function printNumberOfDivs() {
    var input = document.getElementById('tb-range-start').value.split(/[\<\>]+/);

    input = input.filter(Boolean);

    var count = 0;
    for (var i = 0; i < input.length; i++) {
        if (input[i] == "/div") {
            count++;
        }
    }

    jsConsole.writeLine(count);
}