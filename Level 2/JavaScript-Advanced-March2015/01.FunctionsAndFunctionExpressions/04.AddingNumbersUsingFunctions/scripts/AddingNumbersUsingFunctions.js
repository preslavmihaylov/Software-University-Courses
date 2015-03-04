function readInput() {
    jsConsole.writeLine(addNumbers(5)(4)(3)(8));
}

function addNumbers() {
    var totalSum = 0;

    function inner() {
        inner.toString = function() {
             return totalSum;
        };

        if (arguments.length === 1) {
            totalSum += arguments[0];
        }
        return inner;
    }

    totalSum += arguments[0];
    return inner;
}