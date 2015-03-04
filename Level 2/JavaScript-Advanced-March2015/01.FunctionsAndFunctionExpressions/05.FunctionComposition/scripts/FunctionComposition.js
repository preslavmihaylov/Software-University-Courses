

function readInput() {
    jsConsole.writeLine(compose(addOne, square)(5));
    jsConsole.writeLine(compose(addOne, add)(5, 6));
    jsConsole.writeLine(compose(Math.cos, addOne)(-1));
    jsConsole.writeLine(compose(addOne, Math.cos)(-1));

    var compositeFunction = compose(Math.sqrt, Math.cos);

    jsConsole.writeLine(compositeFunction(0.5));
    jsConsole.writeLine(compositeFunction(1));
    jsConsole.writeLine(compositeFunction(-1));

}

function compose(func1, func2) {
    function operate() {
        var result = func2.apply(this, arguments);
        return func1(result);
    }

    return operate;
}

function add(x, y) {
    return x + y;
}
function addOne(x) {
    return x + 1;
}
function square(x) {
    return x * x;
}