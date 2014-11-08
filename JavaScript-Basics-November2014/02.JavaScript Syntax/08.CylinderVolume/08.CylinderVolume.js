var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Input the cylinder radius and height in format [r, h]: ", function (answer) {
    
    
    var input = answer.toString().split(/[\D]+/);
    
    input.splice(0, 1);
    input.splice(input.length - 1, 1);
    
    calcCylinderVolume(input[0], input[1]);
    rl.close();
});

function calcCylinderVolume(radius, height) {
    var baseArea = Math.PI * Math.pow(radius, 2);

    var cylinderVolume = baseArea * height;

    console.log("The cylinder volume is: " + cylinderVolume.toFixed(3));
}