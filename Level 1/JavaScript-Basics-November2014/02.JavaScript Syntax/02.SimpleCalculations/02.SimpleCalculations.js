var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Input a number: ", function (answer) {
    
    var floored = Math.floor(answer);
    var rounded = Math.round(answer);
    
    console.log("Floored: ", floored);
    console.log("Rounded: ", rounded);
    
    rl.close();
});