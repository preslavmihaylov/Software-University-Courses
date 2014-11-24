readInput();

function readInput() {
    var input = [55555, 55560];
    
    solve(input);
}

function solve(args) {
    var numStart = "<li><span class='num'>";
    var numEnd = "</span></li>";
    var rakiyaStart = "<li><span class='rakiya'>";
    var rakiyaLink = "</span><a href=\"view.php?id=";
    var rakiyaEnd = ">View</a></li>";

    // <li><span class='rakiya'>11211</span><a href="view.php?id=11211">View</a></li>

    var start = parseInt(args[0]);
    var end = parseInt(args[1]);
    
    console.log("<ul>");
    for (var index = start; index <= end; index++) {
        if (isRakiya(index)) {
            console.log(rakiyaStart + index + rakiyaLink + index + rakiyaEnd);
        } else {
            console.log(numStart + index + numEnd);
        }
    }
    console.log("</ul>");
    
    function isRakiya(number) {
        number = number.toString();

        for (var first = 0; first < number.length - 3; first++) {
            var rakiya1 = parseInt(number[first].toString() + number[first + 1]);
            for (var second = first + 2; second < number.length - 1; second++) {
                var rakiya2 = parseInt(number[second].toString() + number[second + 1]);
                if (rakiya1 == rakiya2) {
                    return true;
                }
            }
        }
    }
}