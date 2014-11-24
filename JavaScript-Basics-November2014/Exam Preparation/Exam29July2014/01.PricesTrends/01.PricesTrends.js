readInput();

function readInput() {
    var input = [
    '1.33',
    '1.35',
    '2.25',
    '13.00',
    '0.5',
    '0.51',
    '0.5',
    '0.5',
    '0.33',
    '1.05',
    '1.346',
    '20',
    '900',
    '1500.1',
    '1500.10',
    '2000'
    ];

    solve(input);
}

function solve(input) {
    var start = "<tr><td>";
    var fixedPrice = "</td><td><img src=\"fixed.png\"/>";
    var up = "</td><td><img src=\"up.png\"/>";
    var down = "</td><td><img src=\"down.png\"/>";
    var end = "</td></td>";

    var previousPrice = parseFloat(parseFloat(input[0]).toFixed(2));

    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');
    for (var index = 0; index < input.length; index++) {
        var currentPrice = parseFloat(parseFloat(input[index]).toFixed(2));
        if (currentPrice == previousPrice) {
            console.log(start + currentPrice.toFixed(2) + fixedPrice + end);
        } else if (currentPrice > previousPrice) {
            console.log(start + currentPrice.toFixed(2) + up + end);
        } else {
            console.log(start + currentPrice.toFixed(2) + down + end);
        }

        previousPrice = parseFloat(parseFloat(input[index]).toFixed(2));
    }
    console.log('</table>');
}