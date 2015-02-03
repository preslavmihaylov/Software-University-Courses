function readInput() {
    //var input = ['347135713985789531798031509832579382573195807',
    //             '817651358763158761358796358971685973163314321' ];

    var input = ['9999', '9999'];

    var output = sumTwoHugeNumbers(input[0], input[1]);

    jsConsole.writeLine(output);
}

function sumTwoHugeNumbers(first, second) {

    first = reverseString(first);
    second = reverseString(second);

    var residue = 0;
    var result = "";

    for (var index = 0; index < Math.max(first.length, second.length); index++) {
        if (first[index] == undefined) {
            result += "" + (residue + parseInt(second[index].toString()));
            residue = 0;
        } else if (second[index] == undefined) {
            result += "" + (residue + parseInt(first[index].toString()));
            residue = 0;
        } else {
            var currentValue = parseInt(first[index].toString()) + parseInt(second[index].toString());

            result += (currentValue + residue) % 10;

            residue = Math.floor((currentValue + residue) / 10);
        }
    }

    if (residue > 0) {
        result += residue;
    }

    result = reverseString(result);

    return result;
}

function reverseString(input) {
    var reversedWord = "";

    for (var ch = input.length - 1; ch >= 0; ch--) {
        reversedWord += input[ch].toString();
    }

    return reversedWord;
}