readInput();

function readInput() {
    var input = [
        'http://lotr.wikia.com/wiki/Elves?find=elf&elves=amarie%20%20%20%20nimrodel&elves=gil-galad+galadriel&mortal=harry%20potter&elven=legolas&mortal=he-who-must-not-be-named+&mortal=boromir&immortal=spirit&mortal=bilbo+beggins&evil=sauron&answer%20of%20everything++++=42',
        'https://www.google.bg/search?q=whitespace&oq=whitespace&aqs=chrome.0.0l6.1165j0j7&sourceid=chrome&es_sm=93&ie=UTF-8',
        'numbers=20&symbols=#%*^(^('
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
            

            var pairValues = elements[pair].split(/[\=]+/);
            pairValues = pairValues.filter(function (e) { return e || e === 0 });

            
            var field = pairValues[0].split(/[\+]|%20/).filter(Boolean);
            field = field.join(' ');
            
            var value = pairValues[1].split(/[\+]|%20/).filter(Boolean);
            value = value.join(' ');
            
            if (currentElements[field] == undefined) {
                currentElements[field] = [];
            }
            
            if (currentElements[field].indexOf(value) == -1) {
                currentElements[field].push(value);
            }
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