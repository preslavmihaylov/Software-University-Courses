readInput();

function readInput() {
    var input = ["Germany / Argentina: 1-0",
                 "Brazil / Netherlands: 0-3",
                 "Netherlands / Argentina: 0-0",
                 "Brazil / Germany: 1-7",
                 "Argentina / Belgium: 1-0",
                 "Netherlands / Costa Rica: 0-0",
                 "France / Germany: 0-1",
                 "Brazil / Colombia: 2-1 "
];
    
    
    solve(input);
}

// split not by whitespace and trim
// NaN fix

function solve(input) {
    var output = {};

    for (var index = 0; index < input.length; index++) {
        var elements = input[index].split(/[\:\-\/]+/);
        elements = elements.filter(function (e) { return e || e === 0 });
        elements = elements.map(Function.prototype.call, String.prototype.trim)

        var homeTeam = elements[0];
        var awayTeam = elements[1];
        var homeScore = parseInt(elements[2]);
        var awayScore = parseInt(elements[3]);

        if (output[homeTeam] != undefined) {
            updateScore(homeTeam, awayTeam, homeScore, awayScore);
        } else {
            createScore(homeTeam, awayTeam, homeScore, awayScore);
        }

        if (output[awayTeam] != undefined) {
            updateScore(awayTeam, homeTeam, awayScore, homeScore);
        } else {
            createScore(awayTeam, homeTeam, awayScore, homeScore);
        }
    }

    for (var key in output) {
        output[key]['matchesPlayedWith'].sort();
    }

    output = sortObj(output, "bla");

    console.log(JSON.stringify(output));

    function updateScore(team1, team2, score1, score2) {
        output[team1]['goalsScored'] += score1;
        output[team1]['goalsConceded'] += score2;

        if (output[team1]['matchesPlayedWith'].indexOf(team2) == -1) {
            output[team1]['matchesPlayedWith'].push(team2);
        }
    }

    function createScore(team1, team2, score1, score2) {
        output[team1] = {};
        var homeStats = { "goalsScored": score1, "goalsConceded": score2 }
        homeStats['matchesPlayedWith'] = [];
        homeStats['matchesPlayedWith'].push(team2);
        output[team1] = homeStats;
    }

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