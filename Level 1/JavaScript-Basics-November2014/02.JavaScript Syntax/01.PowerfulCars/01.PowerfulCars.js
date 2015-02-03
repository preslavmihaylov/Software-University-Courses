var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Write a number for kW to convert to Hp: ", function (answer) {

    var processed = convertKWtoHP(answer);

    console.log("kW to Hp: ", processed);

    rl.close();
});

function convertKWtoHP(answer) {
    answer = answer / 0.745699872;
    answer = answer.toFixed(2);
    return answer;
}
