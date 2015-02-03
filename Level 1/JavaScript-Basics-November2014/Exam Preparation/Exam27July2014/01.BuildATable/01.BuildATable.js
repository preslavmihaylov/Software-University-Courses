readInput();

function readInput() {
    var input = ['55', '56'];

    solve(input);
}

function solve(input) {
    function generateFibonacci() {
        var result = [0, 1, 1];
        var first = 1;
        var second = 1;
        while (second < 1000000) {
            result.push(first + second);
            var temp = second;
            second = first + second;
            first = temp;
        }

        return result;
    }

    var fibonacci = generateFibonacci();
    var start = '<tr><td>';
    var middle = '</td><td>';
    var end = '</td></tr>';


    console.log('<table>');
    console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');
    for (var index = parseInt(input[0]); index <= parseInt(input[1]); index++) {
        var num = index;
        var squared = num * num;
        var fib;
        if (fibonacci.indexOf(num) != -1) {
            fib = "yes";
        } else {
            fib = "no";
        }

        console.log(start + num + middle + squared + middle + fib + end);
    }
    console.log('</table>');
}

// <table>
// <tr><th>Num</th><th>Square</th><th>Fib</th></tr>
// <tr><td>2</td><td>4</td><td>yes</td></tr>
// <tr><td>3</td><td>9</td><td>yes</td></tr>
// <tr><td>4</td><td>16</td><td>no</td></tr>
// <tr><td>5</td><td>25</td><td>yes</td></tr>
// <tr><td>6</td><td>36</td><td>no</td></tr>
// </table>
