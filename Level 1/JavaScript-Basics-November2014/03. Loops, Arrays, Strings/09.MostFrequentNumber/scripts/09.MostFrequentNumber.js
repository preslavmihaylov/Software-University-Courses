function readInput() {
    var input = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]; // modify input here

    findMostFrequentNum(input);
}

function findMostFrequentNum(input) {
    var maxCount = 0;
    var mostFrequentNum = 0;
    var count = 0;
    for (var currentNum = 0; currentNum < input.length; currentNum++) {
        for (var index = 0; index < input.length; index++) {
            if (input[index] == input[currentNum]) {
                count++;
            }
        }

        if (count > maxCount) {
            maxCount = count;
            mostFrequentNum = input[currentNum];
        }
        count = 0;
    }

    jsConsole.writeLine(mostFrequentNum + " (" + maxCount + " times)");
}