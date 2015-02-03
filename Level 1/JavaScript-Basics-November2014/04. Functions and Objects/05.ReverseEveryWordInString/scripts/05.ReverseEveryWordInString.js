function reverseWords() {
    var input = document.getElementById('tb-range-start').value.split(/[ \']+/);
    input = input.filter(function (e) { return e || e === 0 });

    for (var index = 0; index < input.length; index++) {
        var reversedWord = "";

        for (var ch = input[index].length - 1; ch >= 0; ch--) {
            reversedWord += input[index][ch].toString();
        }

        input[index] = reversedWord;
    }

    jsConsole.writeLine(input.join(" "));
}