function checkNumbers() {
    var number = document.getElementById('tb-range-start').value;
    
    var output = [];
    for (var count = 1; count <= number; count++) {
        if (count % 5 != 0 && count % 4 != 0) {
            output.push(count);
        }
    }

    if (output.length > 0) {
        jsConsole.writeLine(output.join(", "));
    } else {
        jsConsole.writeLine("no");
    }
    
}