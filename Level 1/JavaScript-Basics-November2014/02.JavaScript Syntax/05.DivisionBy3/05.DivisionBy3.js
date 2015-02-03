var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Write a number to check: ", function (answer) {
    
    
    console.log("is it divisible by three without reminder?: ", isDivisibleBy3(answer));
    
    rl.close();
});

function isDivisibleBy3(answer) {
    var result = 0;

    for (var index = 0; index < answer.length; index++) {
        result += parseInt(answer.charAt(index).toString());
    }

    return result % 3 == 0;
}

