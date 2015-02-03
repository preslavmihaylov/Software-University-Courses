function readInput() {
    var input = [2, 'qwe', 'qwe', 3, 3, '3']; // modify input here

    printMaxSequence(input);
}

function printMaxSequence(input) {
    var maxSequence = [];
    var currentSequence = [];

    var lastElement = input[0];
    for (var index = 0; index < input.length; index++) {
        if (lastElement === input[index]) {
            currentSequence.push(input[index]);
        } else {
            if (maxSequence.length <= currentSequence.length) {
                maxSequence = currentSequence;
            }
            currentSequence = [];
            lastElement = input[index];
            index--;
        }
    }

    if (maxSequence.length <= currentSequence.length) {
        maxSequence = currentSequence;
    }

    for (var index = 0; index < maxSequence.length; index++) {
        jsConsole.writeLine(maxSequence[index]);
    }
}