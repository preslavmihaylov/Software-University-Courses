function readInput() {
    var input = [5, 3.3];
    //var input = [33, 44, -99, 0, 20];

    var output = findNumWithLargestSum(input);

    jsConsole.writeLine(output);
}

function findNumWithLargestSum(input) {
    var maxDigitSum = 0;
    var numWithMaxDigitSum;

    for (var index = 0; index < input.length; index++) {
        if (isInteger(input[index])) {
            var digitSum = findDigitSum(input[index]);

            if (digitSum > maxDigitSum) {
                maxDigitSum = digitSum;
                numWithMaxDigitSum = input[index];
            }
        } else {
            return "undefined";
        }
    }

    return numWithMaxDigitSum;
}

function findDigitSum(number) {
    number = Math.abs(number);
    var digitSum = 0;
    while (number > 0) {
        digitSum += number % 10;
        number = Math.floor(number / 10);
    }

    return digitSum;
}

function isInteger(n) {
    return n % 1 === 0;
}