function findPalindromes() {
    var input = document.getElementById('tb-range-start').value.split(/[ \.,\']+/);
    var output = [];

    input = input.filter(function (e) { return e });

    for (var index = 0; index < input.length; index++) {
        var currentWord = input[index].toLowerCase();
        var count = currentWord.length / 2;
        var isPalindrome = true;
        for (var letter = 0; letter < count; letter++) {
            if (currentWord[letter] != currentWord[currentWord.length - (letter + 1)]) {
                isPalindrome = false;
                break;
            }
        }

        if (isPalindrome) {
            output.push(input[index]);
        }
    }

    jsConsole.writeLine(output);
}