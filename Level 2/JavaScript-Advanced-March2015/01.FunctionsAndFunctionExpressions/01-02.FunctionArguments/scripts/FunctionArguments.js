

function readInput() {
    printArgsInfo("some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 }, 2);

    jsConsole.writeLine();
    jsConsole.writeLine("called with call.");
    printArgsInfo.call();
    printArgsInfo.call("some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 }, 2);

    jsConsole.writeLine();
    jsConsole.writeLine("called with apply");
    printArgsInfo.apply("some string", ["string", "array"]);
    printArgsInfo.apply();
}

function printArgsInfo() {
    for (var index = 0; index < arguments.length; index++) {
        jsConsole.writeLine(arguments[index] + " | [" + Object.prototype.toString.call(arguments[index]).substring(8));
    }
}