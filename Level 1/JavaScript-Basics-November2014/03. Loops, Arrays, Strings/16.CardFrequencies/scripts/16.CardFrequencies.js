function printCardFrequencies() {
    var input = document.getElementById('tb-range-start').value.split(/[ \'\.,]/);

    input = input.filter(function (e) {
        return e || e === 0;
    });

    var cardFrequencies = [];

    cardFrequencies.contains = function (word) {
        for (var index = 0; index < cardFrequencies.length; index++) {
            for (var key in cardFrequencies[index]) {
                if (key == word) {
                    return true;
                }
            }
        }
    };

    cardFrequencies.find = function (word) {
        for (var index = 0; index < cardFrequencies.length; index++) {
            var found = false;
            for (var key in cardFrequencies[index]) {
                if (key == word) {
                    found = true;
                }
            }

            if (found) {
                return index + 1;
            }
        }
    };

    var totalCount = input.length;

    for (var index = 0; index < input.length; index++) {
        var face = input[index][0].toString();
        if (face == "1") {
            face += "0";
        }

        if (!cardFrequencies.contains(face)) {
            var currentFrequency = {};
            currentFrequency[face] = 1;
            cardFrequencies.push(currentFrequency);
        } else {
            cardFrequencies[cardFrequencies.find(face) - 1][face] += 1;
        }
    }

    for (var index = 0; index < cardFrequencies.length; index++) {
        for (var key in cardFrequencies[index]) {
            jsConsole.writeLine(key + " -> " + (cardFrequencies[index][key] / totalCount * 100).toFixed(2) + "%");
        }
    }
}