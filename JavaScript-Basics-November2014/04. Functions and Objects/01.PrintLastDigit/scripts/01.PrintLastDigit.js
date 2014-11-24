function printLastDigit() {
    var input = parseInt(document.getElementById('tb-range-start').value);

    var lastDigit = input % 10;
    var result;

    switch (lastDigit) {
        case 1:
            result = "one";
            break;
        case 2:
            result = "two";
            break;
        case 3:
            result = "three";
            break;
        case 4:
            result = "four";
            break;
        case 5:
            result = "five";
            break;
        case 6:
            result = "six";
            break;
        case 7:
            result = "seven";
            break;
        case 8:
            result = "eight";
            break;
        case 9:
            result = "nine";
            break;
        case 0:
            result = "zero";
            break;
        default:
            result = "Invalid number";
            break;
    }

    jsConsole.writeLine(result);
}