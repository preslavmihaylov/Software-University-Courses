readInput();

function readInput() {
    var input = [
        '<!DOCTYPE html>',
        '<html>',
        '<head>',
        '<title>Hyperlinks</title>',
        '<link href="theme.css" rel="stylesheet" />',
        '</head>',
        '<body>',
        '<ul><li><a   href="/"  id="home">Home</a></li><li><a',
        ' class="selected" href=/courses>Courses</a>',
        '</li><li><a href = ',
        '\'/forum\' >Forum</a></li><li><a class=\"href\"',
        'onclick="go()" href= \"#\">Forum</a></li>',
        '<li><a id="js" href =',
        '"javascript:alert(\'hi yo\')" class="new">click</a></li>',
        '<li><a id=\'nakov\' href =',
        'http://www.nakov.com class=\'new\'>nak</a></li></ul>',
        '<a href=\"#empty\"></a>',
        '<a id="href">href=\'fake\'<img src=\'http\://abv.bg/i.gif\' ',
        'alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>',
        '<!-- This code is commented:',
        '<a href="#commented">commentex hyperlink</a> -->',
        '</body>'
    ];

    extractLinks(input);
}

function extractLinks(input) {
    var html = input.join('\n');
    var regex = /<a\s+([^>]+\s+)?href\s*=\s*('([^']*)'|"([^"]*)|([^\s>]+))[^>]*>/g;
    var match;
    while (match = regex.exec(html)) {
        var hrefValue = match[3];
        if (hrefValue == undefined) {
            var hrefValue = match[4];
        }
        if (hrefValue == undefined) {
            var hrefValue = match[5];
        }
        for (var i = 0; i < match.length; i++) {
            console.log(match[i]);
        }
    }
}

function solve(input) {
    var content = ""

    for (var index = 0; index < input.length; index++) {
        content += input[index];
    }

    var elements = content.split(/[\<\>]+/);
    for (var index = 0; index < elements.length; index++) {
        var temp = elements[index].split('');
        if (temp[0] != "a") {
            elements.splice(index, 1);
            index--;
        }
    }

    for (var index = 0; index < elements.length; index++) {
        var links = elements[index].split(/href[ ]?=/);
        if (links.length > 1) {
            var linkElements = links[1].split(/[ \"\']/);
            linkElements = linkElements.filter(Boolean);
            if (linkElements[0][0].toString() == "'") {
                linkElements[0] = clearQuotes(linkElements[0]);
            }
            console.log(linkElements[0]);

        }
    }

    function clearQuotes(word) {
        var result = "";
        for (var ch = 1; ch < word.length - 1; ch++) {
            result += word[ch].toString();
        }

        return result;
    }
}