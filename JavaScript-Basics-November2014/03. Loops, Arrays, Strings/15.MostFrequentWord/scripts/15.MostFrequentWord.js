function findMostFrequentWord() {
    var input = document.getElementById('tb-range-start').value.split(/[ \'\.,]+/);

    input = input.filter(function (e) { return e || e === 0});

    var wordFrequency = [];

    Array.prototype.contains = function (word) {
        for (var index = 0; index < wordFrequency.length; index++) {
            for (var key in wordFrequency[index]) {
                if (key == word) {
                    return true;
                }
            }
        }

    };

    var maxCount = 0;

    for (var word = 0; word < input.length; word++) {
        if (wordFrequency.contains(input[word].toLowerCase())) {
            continue;
        }

        var count = 0;
        for (var frequency = word; frequency < input.length; frequency++) {
            if (input[word].toLowerCase() == input[frequency].toLowerCase()) {
                count++;
            }
        }
        var currentFrequency = {};
        currentFrequency[input[word].toLowerCase()] = count;
        wordFrequency.push(currentFrequency);

        if (maxCount < count) {
            maxCount = count;
        }
    }

    for (var index = 0; index < wordFrequency.length; index++) {
        for (var key in wordFrequency[index]) {
            if (maxCount == wordFrequency[index][key]) {
                jsConsole.writeLine(key + " -> " + wordFrequency[index][key]);
            }
        }
    }
    
}