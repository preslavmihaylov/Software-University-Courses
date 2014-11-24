function readInput() {
    var input = { name: 'Pesho', age: 21 };

    deepCopyObject(input);
}

function deepCopyObject(input) {
    var deepCopiedObject = JSON.parse(JSON.stringify(input));
    var notDeepCopiedObject = input;

    jsConsole.writeLine("deepCopiedObject == input? --> " + compareObjects(deepCopiedObject, input));
    jsConsole.writeLine("notDeepCopiedObject == input? --> " + compareObjects(notDeepCopiedObject, input));
}

function compareObjects(first, second) {
    return first == second;
}