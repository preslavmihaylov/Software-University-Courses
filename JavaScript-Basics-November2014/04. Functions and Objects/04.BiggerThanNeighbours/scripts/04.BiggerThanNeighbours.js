function readInput() {
    var index = 2;
    var input = [1, 2, 3, 3, 5]; // modify input here

    var output = isBiggerThanNeighbours(index, input);

    jsConsole.writeLine(output);
}

function isBiggerThanNeighbours(index, input) {
    if (index < 0 || index >= input.length) {
        return "invalid index";
    } else if (index == 0 || index == input.length - 1) {
        return "only one neighbour";
    }

    if (input[index] > input[index + 1] && input[index] > input[index - 1]) {
        return "bigger";
    } else {
        return "not bigger";
    }


}