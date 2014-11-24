readInput();

function readInput() {
    var input = [
        'sentinel .exe 15MB',
        'zoomIt .msi 3MB',
        'skype .exe 45MB',
        'trojanStopper .bat 23MB',
        'kindleInstaller .exe 120MB',
        'setup .msi 33.4MB',
        'winBlock .bat 1MB'
    ];
    
    solve(input);
}

function solve(input) {
    var data = {};
    for (var index = 0; index < input.length; index++) {
        var elements = input[index].split(' ');
        var program = elements[0];
        var extension = elements[1];
        var size = parseFloat(elements[2]);

        if (data[extension] == undefined) {
            data[extension] = {};
            data[extension].files = [];
            data[extension].files.push(program);
            data[extension].memory = size;
        } else {
            if (data[extension].files.indexOf(program) == -1) {
                data[extension].files.push(program);
            }

            data[extension].memory += size;
        }
    }

    data = sortObj(data, "bla");

    for (var key in data) {
        data[key].files.sort();
        data[key].memory = data[key].memory.toFixed(2);
    }

    console.log(JSON.stringify(data));

    function sortObj(obj, order) {
        "use strict";

        var key,
            tempArry = [],
            i,
            tempObj = {};

        for (key in obj) {
            tempArry.push(key);
        }

        tempArry.sort(
            function (a, b) {
                return a.localeCompare(b);
            }
        );

        if (order === 'desc') {
            for (i = tempArry.length - 1; i >= 0; i--) {
                tempObj[tempArry[i]] = obj[tempArry[i]];
            }
        } else {
            for (i = 0; i < tempArry.length; i++) {
                tempObj[tempArry[i]] = obj[tempArry[i]];
            }
        }

        return tempObj;
    }
}

// ".bat":{"files":["trojanStopper","winBlock"],"memory":"24.00"},
// ".exe":{"files":["kindleInstaller","sentinel","skype"],"memory":"180.00"},
// ".msi":{"files":["setup","zoomIt"],"memory":"36.40"}