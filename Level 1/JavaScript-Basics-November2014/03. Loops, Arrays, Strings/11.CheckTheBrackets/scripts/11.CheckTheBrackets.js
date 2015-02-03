function checkBrackets() {
    var input = document.getElementById('tb-range-start').value.split(/[^()]+/);
    var isCorrect = true;

    for (var index = 0; index < input.length; index++) {
        if (input[index] == "(") {
            var isClosed = false;
            for (var bracketCheck = index + 1; bracketCheck < input.length; bracketCheck++) {
                if (input[bracketCheck] == ")") {
                    input[bracketCheck] = "";
                    isClosed = true;
                    break;
                }
            }

            if (!isClosed) {
                isCorrect = false;
                break;
            }
        } else if (input[index] == ")") {
            isCorrect = false;
            break;
        }
    }

    if (isCorrect) {
        jsConsole.writeLine("correct");
    } else {
        jsConsole.writeLine("incorrect");
    }
}