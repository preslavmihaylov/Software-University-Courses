function readInput() {
    var args = ['gramadat gramaden grandioz',
'gr',
'gram',
'grad',
'grand']


    jsConsole.write(solve(args));

}

function solve(args) {
    var completes = args[0].split(" ");

    function clearPossibilities(autoCompletes) {

        var min = 0;

        for (var index = 1; index < autoCompletes.length; index++) {
            if (autoCompletes[min].length < autoCompletes[index].length) {
                min = min;
                continue;
            } else if (autoCompletes[min].length > autoCompletes[index].length) {
                min = index;
            } else {
                for (var ch = 0; ch < autoCompletes[index].length; ch += 1) {
                    var first = autoCompletes[min].toLowerCase();
                    var second = autoCompletes[index].toLowerCase();
                    if (first[ch] < second[ch]) {
                        min = min;
                        break;
                    } else if (first[ch] > second[ch]) {
                        min = index;
                        break;
                    }
                }
            }
        }

        return min;
    }

    for (var index = 1; index < args.length; index += 1) {
        var autoCompletes = [];

        for (var possibility = 0; possibility < completes.length; possibility += 1) {
            if (completes[possibility].toLowerCase().indexOf(args[index].toLowerCase()) == 0) {
                autoCompletes.push(completes[possibility]);
            }
        }

        var min = clearPossibilities(autoCompletes);
        if (autoCompletes.length == 0) {
            console.log("-");
        } else {
            console.log(autoCompletes[min]);
        }
    }
}