function findMinAndMax() {
    var numbers = document.getElementById('tb-range-start').value.split(/[\[\]\,]+/);

    numbers.splice(0, 1);
    numbers.splice(numbers.length - 1, 1);
    
    var min = Number.MAX_VALUE;
    var max = Number.MIN_VALUE;

    for (var index = 0; index < numbers.length; index++) {
        if (parseInt(numbers[index]) > max) {
            max = parseInt(numbers[index]);
        }

        if (parseInt(numbers[index]) < min) {
            min = parseInt(numbers[index]);
        }
    }

    jsConsole.writeLine("Min number: " + min);
    jsConsole.writeLine("Max number: " + max);
}