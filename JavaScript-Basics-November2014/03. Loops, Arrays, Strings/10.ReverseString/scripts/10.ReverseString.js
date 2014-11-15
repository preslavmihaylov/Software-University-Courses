function reverseString() {
    var input = document.getElementById('tb-range-start').value;

    for (var index = input.length - 1; index >= 0; index-= 1) {
        jsConsole.write(input[index]);
    }

    jsConsole.writeLine();
}