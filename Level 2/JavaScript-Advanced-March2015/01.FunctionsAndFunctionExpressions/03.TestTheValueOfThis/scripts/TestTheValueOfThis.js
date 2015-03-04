function readInput() {
    testContext();

    testFuncScope();

    var funcObj = new Function("", "testContext()");
    funcObj();
}

function testContext() {
    jsConsole.writeLine(this);
    console.log(this);
}

function testFuncScope() {
    testContext();
}