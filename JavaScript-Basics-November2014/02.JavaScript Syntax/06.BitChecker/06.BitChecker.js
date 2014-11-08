var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Write a number to check: ", function (answer) {
    
    
    console.log("Is the third bit a one?: ", isThirdBitOne(answer));
    
    rl.close();
});

function isThirdBitOne(answer) {
    var thirdBit = (answer >> 3) & 1;

    return thirdBit == 1;
}

