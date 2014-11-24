readInput();

function readInput() {
    var input = [
        '@s@a@p@una',
        'p@@@@@@@@dna',
        '@6@t@*@*ego',
        'vdig*****ne6',
        'li??^*^*'
    ];

    solve(input);
}

function solve(input) {
    var plusFields = [];
    var elements = [];

    for (var index = 0; index < input.length; index++) {
        input[index] = input[index].trim();
        plusFields.push([]);
        elements.push([]);
        for (var ch = 0; ch < input[index].length; ch++) {
            elements[elements.length - 1].push(input[index][ch].toString());
            plusFields[plusFields.length - 1].push(false);
        }
    }

    for (var row = 0; row < elements.length; row++) {
        for (var col = 0; col < elements[row].length; col++) {

            if (row + 2 < elements.length && col - 1 >= 0 && col + 1 < elements[row + 1].length && col < elements[row + 2].length
                && isPlus(row, col, elements[row][col].toLowerCase())) {
                plusFields[row][col] = true;
                plusFields[row + 1][col] = true;
                plusFields[row + 1][col - 1] = true;
                plusFields[row + 1][col + 1] = true;
                plusFields[row + 2][col] = true;
            }
        }
    }

    for (var row = 0; row < elements.length; row++) {
        var output = "";

        for (var col = 0; col < elements[row].length; col++) {
            if (plusFields[row][col] == false) {
                output += elements[row][col];
            }
        }
        console.log(output);
    }

    function isPlus(row, col, letter) {
        if (elements[row + 1][col].toLowerCase() == letter &&
            elements[row + 1][col + 1].toLowerCase() == letter &&
            elements[row + 1][col - 1].toLowerCase() == letter &&
            elements[row + 2][col].toLowerCase() == letter) {

            return true;
        }
    }

}

// +
// row + 2, col - 1, col + 1