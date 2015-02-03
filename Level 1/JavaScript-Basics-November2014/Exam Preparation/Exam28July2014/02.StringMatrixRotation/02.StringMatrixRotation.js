readInput();

function readInput() {
    var input = ["Rotate(270)",
                  "hello",
                  "softuni",
                  "exam"];

    
    solve(input);
}

function solve(input) {
    var cols = input.length - 1;
    var rows = 0;
    var rotationCount = numOfRotations(input[0]);
    var matrix = [];

    for (var index = 1; index < input.length; index++) {
        if (input[index].length > rows) {
            rows = input[index].length;
        }

        matrix.push(input[index]);
    }

    for (var count = 0; count < rotationCount; count++) {
        matrix = rotate(matrix);
    }

    for (var index = 0; index < matrix.length; index++) {
        console.log(matrix[index]);
    }

    function rotate(matrix) {
        var newMatrix = [];
        
        for (var row = 0; row < rows; row++) {
            newMatrix.push("");

            var empty = true;
            for (var col = cols - 1; col >= 0; col--) {
                if (matrix[col][row]) {
                    newMatrix[row] += matrix[col][row];
                    empty = false;
                } else {
                    newMatrix[row] += " ";
                }
            }

            if (empty) {
                newMatrix.splice(row, 1);
            }
        }

        var temp = cols;
        cols = rows;
        rows = temp;
        return newMatrix;
    }

    function numOfRotations(value) {
        var number = value.split(/[^0-9]/);
        number = number.filter(function (e) { return e || e === 0 });
        return number[0] / 90;
    }

}

