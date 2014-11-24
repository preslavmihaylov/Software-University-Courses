readInput();

function readInput() {
    var input = ['5tffwj(//*7837xzc2---34rlxXP%$”.'];
    
    solve(input);
}

function solve(input) {
    var output = [];
    var numbers = input[0].split(/[\D]+/);
    numbers = numbers.filter(function (e) { return e || e === 0 });
    for (var index = 0; index < numbers.length; index++) {
        var number = parseInt(numbers[index]).toString(16).toUpperCase();
        switch (number.length) {
            case 1:
                output.push("0x000" + number);
                break;
            case 2:
                output.push("0x00" + number);
                break;
            case 3:
                output.push("0x0" + number);
                break;
            default:
                output.push("0x" + number);
                break;
        }
    }

    console.log(output.join('-'));

}