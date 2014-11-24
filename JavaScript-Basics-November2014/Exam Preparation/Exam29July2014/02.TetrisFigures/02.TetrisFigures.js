readInput();

function readInput() {
    var input = [
    '--o--o-',
    '--oo-oo',
    'ooo-oo-',
    '-ooooo-',
    '---oo--'
    ];

    solve(input);
}

function solve(input) {
    var field = [];

    var output = {"I":0,"L":0,"J":0,"O":0,"Z":0,"S":0,"T":0}

    for (var row = 0; row < input.length; row++) {
        field.push([]);
        for (var col = 0; col < input[row].length; col++) {
            field[field.length - 1].push(input[row][col].toString());
        }
    }

    for (var row = 0; row < field.length; row++) {
        for (var col = 0; col < field[row].length; col++) {
            if (field[row][col] == "o") {
                if (row + 3 < field.length && isI(row, col)) {
                    output["I"] += 1;
                }

                if (row + 2 < field.length && col + 1 < field[row].length && isL(row, col)) {
                    output["L"] += 1;
                }

                if (row + 2 < field.length && col - 1 >= 0 && isJ(row, col)) {
                    output["J"] += 1;
                }

                if (row + 1 < field.length && col + 1 < field[row].length && isO(row, col)) {
                    output["O"] += 1;
                }

                if (row + 1 < field.length && col + 2 < field[row].length && isZ(row, col)) {
                    output["Z"] += 1;
                }

                if (row + 1 < field.length && col - 2 >= 0 && isS(row, col)) {
                    output["S"] += 1;
                }

                if (row + 1 < field.length && col + 2 < field[row].length && isT(row, col)) {
                    output["T"] += 1;
                }
            }
        }
    }

    console.log(JSON.stringify(output));

    function isI(row, col) {
        if (field[row + 1][col] == "o" &&
            field[row + 2][col] == "o" &&
            field[row + 3][col] == "o") {
            
            return true;
        }
    }

    function isL(row, col) {
        if (field[row + 1][col] == "o" &&
            field[row + 2][col] == "o" &&
            field[row + 2][col + 1] == "o") {

            return true;
        }
    }

    function isJ(row, col) {
        if (field[row + 1][col] == "o" &&
            field[row + 2][col] == "o" &&
            field[row + 2][col - 1] == "o") {

            return true;
        }
    }

    function isO(row, col) {
        if (field[row][col + 1] == "o" &&
            field[row + 1][col] == "o" &&
            field[row + 1][col + 1] == "o") {

            return true;
        }
    }

    function isZ(row, col) {
        if (field[row][col + 1] == "o" &&
            field[row + 1][col + 1] == "o" &&
            field[row + 1][col + 2] == "o") {

            return true;
        }
    }

    function isS(row, col) {
        if (field[row][col - 1] == "o" &&
            field[row + 1][col - 1] == "o" &&
            field[row + 1][col - 2] == "o") {

            return true;
        }
    }

    function isT(row, col) {
        if (field[row][col + 1] == "o" &&
            field[row][col + 2] == "o" &&
            field[row + 1][col + 1] == "o") {

            return true;
        }
    }

}