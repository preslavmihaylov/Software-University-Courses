readInput();

function readInput() {
    var input = [
        'Terra-Nova 16 2',
        'Perseus 2.6 4.8',
        'Virgo 1.6 7',
        '2 5',
        '4'
    ];
    
    solve(input);
}

function solve(input) {
    var firstStarInfo = input[0].split(' ').filter(function(e) { return e || e === 0});
    firstStar = { name: firstStarInfo[0].toLowerCase(), x: parseFloat(firstStarInfo[1]), y: parseFloat(firstStarInfo[2]) };

    var secondStarInfo = input[1].split(' ').filter(function (e) { return e || e === 0 });
    secondStar = { name: secondStarInfo[0].toLowerCase(), x: parseFloat(secondStarInfo[1]), y: parseFloat(secondStarInfo[2]) };

    var thirdStarInfo = input[2].split(' ').filter(function (e) { return e || e === 0 });
    thirdStar = { name: thirdStarInfo[0].toLowerCase(), x: parseFloat(thirdStarInfo[1]), y: parseFloat(thirdStarInfo[2]) };

    var initialCoords = input[3].split(' ');
    var x = parseFloat(initialCoords[0]);
    var y = parseFloat(initialCoords[1]);
    var moves = parseFloat(input[4]);

    Object.prototype.contains = function (x, y) {
        if (this.x + 1 >= x && this.x - 1 <= x &&
            this.y + 1 >= y && this.y  - 1 <= y) {

            return true;
        } else {
            return false;
        }
    };

    for (var count = 0; count <= moves; count++) {
        if (firstStar.contains(x, y)) {
            console.log(firstStar.name);
        } else if (secondStar.contains(x, y)) {
            console.log(secondStar.name);
        } else if (thirdStar.contains(x, y)) {
            console.log(thirdStar.name);
        } else {
            console.log("space");
        }
        y++;
    }

    
}