function readInput() {
    var input = [3, 5, 4, 6, 1, 2, 3, 6, 10, 32]; // modify input here

    findMaxIncreasingSequence(input);
}

function findMaxIncreasingSequence(input) {
    var maxIncreasingSequence = [];
    var currentSequence = [];

    for (var first = 0; first < input.length; first++) {
        var currentNum = input[first];
        currentSequence.push(currentNum);
        for (var second = first + 1; second < input.length; second++) {
            if (currentNum < input[second]) {
                currentSequence.push(input[second]);
            } else {
                maxIncreasingSequence = modifyMaxCount(maxIncreasingSequence, currentSequence);
                currentSequence = [];
                break;
            }
            currentNum = input[second];
        }

        maxIncreasingSequence = modifyMaxCount(maxIncreasingSequence, currentSequence);
        currentSequence = [];
    }

    if (maxIncreasingSequence.length > 1) {
        jsConsole.writeLine(maxIncreasingSequence.join(", "));
    } else {
        jsConsole.writeLine("No");
    }
    
}

function modifyMaxCount(maxIncreasingSequence, currentSequence) {
    if (maxIncreasingSequence.length < currentSequence.length) {
        maxIncreasingSequence = currentSequence;
    }

    return maxIncreasingSequence;
}