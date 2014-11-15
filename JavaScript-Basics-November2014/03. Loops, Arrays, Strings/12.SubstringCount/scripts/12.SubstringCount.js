function readInput() {
    // modify input here
    // note that the first example's answer is 8 not 9. It's a mistake
    var input = ['but', 'But you were living in another world tryin\' to get your message through.'];

    countSubstringOccurs(input);
}

function countSubstringOccurs(input) {
    input[0] = input[0].toLowerCase();
    input[1] = input[1].toLowerCase();

    var words = input[1].split(/[^\w]+/);

    var count = 0;
    for (var index = 0; index < words.length; index++) {
        if (words[index].indexOf(input[0]) != -1) {
            count++;
        }
    }

    jsConsole.writeLine(count);
}