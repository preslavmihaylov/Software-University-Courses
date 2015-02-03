readInput();

function readInput() {
    var input = ["<table>",
                 "<tr><th>Product</th><th>Price</th><th>Votes</th></tr>",
                 "<tr><td>aaaAaAAAa</td><td>1.222</td><td>+12</td></tr>",
                 "<tr><td>AAAaaAaaA</td><td>1.223</td><td>+33</td></tr>",
                 "<tr><td>aaaBBBaAB</td><td>01.223</td><td>+1</td></tr>",
                 "<tr><td>bbbCCCaaa</td><td>333</td><td>+7</td></tr>",
                 "<tr><td>bbCCCCCCC</td><td>323</td><td>+7</td></tr>",
                 "<tr><td>bbCCCCC</td><td>1</td><td>+11</td></tr>",
                 "<tr><td>ccccc</td><td>1.111</td><td>+11</td></tr>",
                 "</table>"
];
    
    
    solve(input);
}

function solve(input) {
    var sortedList = [];

    for (var row = 2; row < input.length - 1; row++) {
        var elements = input[row].split(/[\<\>]/);
        elements = elements.filter(function (e) { return e || e === 0})
        var productName = elements[2];
        var price = parseFloat(elements[5]);

        var currentObject = {};
        currentObject.name = productName;
        currentObject.price = price;
        currentObject.index = row;
        sortedList.push(currentObject);
    }

    sortedList.sort(compare)

    console.log(input[0]);
    console.log(input[1]);
    for (var index = 0; index < sortedList.length; index++) {
        console.log(input[sortedList[index].index]);
    }
    console.log(input[input.length - 1]);

    function compare(a, b) {
        if (a.price < b.price)
            return -1;
        if (a.price > b.price)
            return 1;
        if (a.name.toLowerCase() < b.name.toLowerCase())
            return -1
        if (a.name.toLowerCase() > b.name.toLowerCase())
            return 1
        return 0
    }

}