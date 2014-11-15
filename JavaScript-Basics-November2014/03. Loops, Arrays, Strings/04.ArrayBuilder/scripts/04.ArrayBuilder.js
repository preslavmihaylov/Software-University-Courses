function buildArray() {
    var numbers = [];

    for (var index = 0; index <= 20; index++) {
        numbers.push(index * 5);
    }

    for (var index in numbers) {
        jsConsole.write(numbers[index] + " ");
    }
    jsConsole.writeLine();
}