function readInput() {
    var input = [12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]; // modify input here

    var input = sortArray(input);

    jsConsole.writeLine(input.join(", "));
}

function sortArray(input) {
    input.sort(function (a, b) { return a - b });

    return input;
}