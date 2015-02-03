readInput();

function readInput() {
    var input = ['200', 'drunk'];

    solve(input);
}

function solve(input) {
    var bill = parseFloat(input[0]);
    var mood = input[1];
    var result = 0;

    switch (mood) {
        case "happy":
            // 10%
            result = bill * 10 / 100;
            break;
        case "married":
            // 0.05%
            result = bill * 0.05 / 100;
            break;
        case "drunk":
            // (15% * bill)^n
            result = bill * 15 / 100;
            var n = getFirstDigit(result);
            for (var count = 1; count < n; count++) {
                result *= result;
            }
            break;
        default:
            // 5%
            result = bill * 5 / 100;
            break;
    }

    console.log(result.toFixed(2));

    function getFirstDigit(value) {
        var firstDigit;
        while (value > 0) {
            firstDigit = Math.round(value % 10);
            value /= 10;
            value = Math.floor(value);
        }

        return firstDigit;
    }
}