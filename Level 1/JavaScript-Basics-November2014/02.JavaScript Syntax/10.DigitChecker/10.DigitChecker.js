var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Write a number to check: ", function (answer) {
    
    
    console.log("Is the third character a three?: ", isThirdCharThree(answer));
    
    rl.close();
});

function isThirdCharThree(answer) {
    if (answer.charAt(answer.length - 3) == '3') {
        return true;
    } else {
        return false;
    }
}