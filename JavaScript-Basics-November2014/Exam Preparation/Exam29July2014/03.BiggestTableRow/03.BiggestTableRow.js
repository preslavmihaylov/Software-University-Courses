readInput();

function readInput() {
    var input = [
    '<table>',
    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
    '<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
    '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
    '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
    '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
    '</table>'
    ];

    solve(input);
}

function solve(input) {
    var maxSum = '-';
    var output = "";

    for (var index = 2; index < input.length - 1; index++) {
        var elements = input[index].split(/[\<\>]/);
        elements = elements.filter(function(e) {
            return e || e === 0;
        });

        var store1 = elements[5];
        var store2 = elements[8];
        var store3 = elements[11];
        var currentSum = "-";

        if (store1 != '-') {
            currentSum = parseFloat(store1);
        }

        if (store2 != '-') {
            if (currentSum != '-') {
                currentSum += parseFloat(store2);
            } else {
                currentSum = parseFloat(store2);
            }
        }

        if (store3 != '-') {
            if (currentSum != '-') {
                currentSum += parseFloat(store3);
            } else {
                currentSum = parseFloat(store3);
            }
        }

        if (currentSum != '-') {
            if (maxSum != '-') {
                if (maxSum < currentSum) {
                    maxSum = currentSum;
                    setOutput(store1, store2, store3);
                }
            } else {
                maxSum = currentSum;
                setOutput(store1, store2, store3);
            }
        }
    }

    if (maxSum != "-") {
        console.log(maxSum + " = " + output);
    } else {
        console.log("no data");
    }

    function setOutput(store1, store2, store3) {
        output = "";
        if (store1 != "-" && output != "") {
            output += " + " + store1;
        } else if (store1 != "-") {
            output = store1;
        }

        if (store2 != "-" && output != "") {
            output += " + " + store2;
        } else if (store2 != "-") {
            output = store2;
        }

        if (store3 != "-" && output != "") {
            output += " + " + store3;
        } else if (store3 != "-") {
            output = store3;
        }
    }
}