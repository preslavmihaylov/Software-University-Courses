function readInput() {
    // modify input here
    var firstArray = ['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'];
    var secondArray = ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r'];

    var result = compareChars(firstArray, secondArray);

    if (result) {
        jsConsole.writeLine("Equal");
    } else {
        jsConsole.writeLine("Not Equal");
    }
}

function compareChars(firstArray, secondArray) {
    for (var index = 0; index < Math.max(firstArray.length, secondArray.length); index++) {
        if (firstArray[index] != secondArray[index]) {
            return false;
        }
    }

    return true;
}