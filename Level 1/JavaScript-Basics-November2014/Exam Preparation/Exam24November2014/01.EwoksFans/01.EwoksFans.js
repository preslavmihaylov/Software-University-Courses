readInput();

function readInput() {
    var input = [
        '22.03.2014',
        '17.05.1933',
        '10.10.1954'
    ];
    
    solve(input);
}

function solve(input) {
    var fans = [];
    var haters = [];
    for (var index = 0; index < input.length; index++) {
        var elements = input[index].split(/[.]+/);
        elements = elements.filter(function (e) { return e || e === 0 });
        var date = new Date(parseInt(elements[2], 10),
                            parseInt(elements[1], 10) - 1,
                            parseInt(elements[0], 10)
        );
        //
        
        var start = new Date("1900-01-01");
        var end = new Date("2015-01-01");
        
        if (date < start || date >= end) {
            continue;
        }
        
        var ewoksDate = new Date('1973-05-25');
        
        if (date <= ewoksDate) {
            haters.push(date);
        } else {
            fans.push(date);
        }
    }
    
    if (fans.length > 0 || haters.length > 0) {
        fans.sort(function (a, b) {
            return b - a;
        });
        
        haters.sort(function (a, b) {
            return a - b;
        });
        
        if (fans.length > 0) {
            console.log("The biggest fan of ewoks was born on " + fans[0].toDateString());
        }
        
        if (haters.length > 0) {
            console.log("The biggest hater of ewoks was born on " + haters[0].toDateString());
        }
    } else {
        console.log("No result");
    }
}
