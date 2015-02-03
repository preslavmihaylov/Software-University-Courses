readInput();

function readInput() {
    var input = [
        'ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
        'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
        'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
        'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
        'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
        'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
        'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
        'Helloween | London | 28-Jul-2014 | Wembley Stadium',
        'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
        'Metallica | London | 03-Oct-2014 | Olympic Stadium',
        'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
        'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium'
    ];

    solve(input);
}

function solve(input) {
    var data = {};
    for (var index = 0; index < input.length; index++) {
        var elements = input[index].split(/[\|]+/);
        elements = elements.filter(function (e) { return e || e === 0 });

        var band = elements[0].trim();
        var city = elements[1].trim();
        var venue = elements[3].trim();

        if (data[city] == undefined) {
            data[city] = {};
            data[city][venue] = [];
            data[city][venue].push(band);
        } else {
            if (data[city][venue] == undefined) {
                data[city][venue] = [];
                data[city][venue].push(band);
            } else {
                if (data[city][venue].indexOf(band) == -1) {
                    data[city][venue].push(band);
                }
            }
        }
    }

    for (var city in data) {
        data[city] = sortObj(data[city], "bla");
        for (var venue in data[city]) {
            data[city][venue].sort();
        }
    }

    data = sortObj(data, "bla");

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