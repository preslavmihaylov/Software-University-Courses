readInput();

function readInput() {
    var input = [
        'foo=%20foo&value=+val&foo+=5+%20+20323+++++232%20%20 34-443',
        'foo=poo%20&asdsadsa===?value=valley&%20dog pesho=+++%20%20wow+%20%20&pesho=+++%20%20wow+%20%20',
        'url=https://softuni.bg/trainings/coursesinstances/details/1070',
        'https://softuni.bg/trainings?nakov=nakov&course=oop&course=php'
    ];

    solve(input);
}

function solve(input) {
    for (var index = 0; index < input.length; index++) {

        var elements = input[index].split(/[\&]+/);
        elements = elements.filter(function (e) { return e || e === 0 });

        var currentElements = {};

        for (var pair = 0; pair < elements.length; pair++) {
            elements[pair] = elements[pair].split(/[?]+/);
            if (elements[pair].length > 1) {
                elements[pair].splice(0, 1);
            }

            elements[pair] = elements[pair][0];

            var pairValues = elements[pair].split(/[\+\=]+|%20/);
            pairValues = pairValues.filter(function (e) { return e || e === 0 });

            pairValues[0] = pairValues[0].trim();

            if (currentElements[pairValues[0]] == undefined) {
                currentElements[pairValues[0]] = [];
            }

            var values = "";
            for (var value = 1; value < pairValues.length; value++) {
                if (currentElements[pairValues[0]].indexOf(pairValues[value].trim()) == -1) {
                    if (pairValues[value] != pairValues[pairValues.length - 1]) {
                        values += pairValues[value].trim() + " ";
                    } else {
                        values += pairValues[value].trim();
                    }
                }
            }

            currentElements[pairValues[0]].push(values);
        }

        var output = "";
        for (var key in currentElements) {
                output += "" + key + "=[";
                output += currentElements[key].join(', ');
                output += "]"
        }

        console.log(output);
    }
}

// foo=%20foo&value=+val&foo+=5+%20+203