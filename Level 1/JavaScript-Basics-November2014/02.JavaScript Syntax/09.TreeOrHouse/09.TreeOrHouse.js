var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Input the cylinder radius and height in format [r, h]: ", function (answer) {
    
    
    var input = answer.toString().split(/[\D]+/);
    
    input.splice(0, 1);
    input.splice(input.length - 1, 1);
    
    treeOrHouse(input[0], input[1]);
    rl.close();
});

function treeOrHouse(houseHeight, treeHeight) {
    houseArea = (houseHeight * houseHeight) + (houseHeight * (houseHeight * 2 / 3) / 2);

    treeArea = treeHeight * (treeHeight / 3) + Math.PI * Math.pow((treeHeight * 2 / 3), 2);

    if (houseArea > treeArea) {
        console.log("house/" + houseArea.toFixed(2));
    } else {
        console.log("tree/" + treeArea.toFixed(2));
    }
}