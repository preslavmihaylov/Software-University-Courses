var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Input a number: ", function (answer) {
    
    var primeNum = isPrime(answer);
    
    console.log("Is it prime?: ", primeNum);
    
    rl.close();
});

function isPrime(answer) {
    if (answer == 1) {
        return false;
    }
    

    for (var index = 2; index <= Math.sqrt(answer); index++) {
        if (answer % index == 0) {
            return false;
        }
    }

    return true;
}