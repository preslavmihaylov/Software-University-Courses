function readInput() {
    var input = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];

    Array.prototype.remove = function (value) {
        for (var index = 0; index < this.length; index++) {
            if (value === this[index]) {
                this.splice(index, 1);
            }
        }
    };

    input.remove(1);

    jsConsole.writeLine(JSON.stringify(input));
}
