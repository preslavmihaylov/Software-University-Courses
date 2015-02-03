readInput();

function readInput() {
    var input = [
        'aa',
        'aaa',
        'aaaa',
        'aaaaa'
    ];

    solve(input);
}

function solve(input) {
    var triangleFields = [];
    var elements = [];

    for (var index = 0; index < input.length; index++) {
        triangleFields.push([]);
        elements.push([]);
        for (var ch = 0; ch < input[index].length; ch++) {
            elements[elements.length - 1].push(input[index][ch].toString());
            triangleFields[triangleFields.length - 1].push(false);
        }
    }
    
    for (var row = 0; row < elements.length; row++) {
        for (var col = 0; col < elements[row].length; col++) {
            if (row + 1 < elements.length && col + 1 < elements[row + 1].length &&
                col - 1 >= 0 && isTriangle(row, col, elements[row][col])) {

                triangleFields[row][col] = true;
                triangleFields[row + 1][col] = true;
                triangleFields[row + 1][col + 1] = true;
                triangleFields[row + 1][col - 1] = true;
            }
        }
    }

    for (var row = 0; row < elements.length; row++) {
        for (var col = 0; col < elements[row].length; col++) {
            if (triangleFields[row][col] == true) {
                elements[row][col] = '*';
            }
        }
        console.log(elements[row].join(''));
    }

    function isTriangle(row, col, letter) {
        if (elements[row + 1][col] == letter &&
            elements[row + 1][col + 1] == letter &&
            elements[row + 1][col - 1] == letter) {
            
            return true;
        }
    }
}