function readInput() {
    var input = [5, 888.88];
    var digits = input[1].toString().split(/[.-]+/).join('');

    printNthDigit(input[0], parseInt(digits));
}

function printNthDigit(index, digits) {
    var result;
    while (index > 0) {
        result = digits % 10;
        digits = Math.floor(digits / 10);
        if (digits == 0 && index > 1) {
            jsConsole.writeLine("The number doesn't have enough digits");
            return;
        }
        index -= 1;
    }

    jsConsole.writeLine(result);
}
