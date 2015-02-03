var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Write a number to check: ", function (answer) {
    
    
    console.log("is it even?: ", isEven(answer));
    
    rl.close();
});

function isEven(answer) {
    return answer % 2 == 0;
}

