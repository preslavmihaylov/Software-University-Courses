readInput();

function readInput() {
    var input = [
        '17.8',
        '19.4',
        '13',
        '55.8',
        '126.96541651',
        '3'
    ];

    solve(input);
}

function solve(input) {
    var output = '<table border="1">\n' + 
                 '<thead>\n' + 
                 '<tr><th colspan="3">Blades</th></tr>\n' + 
                 '<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>\n' + 
                 '</thead>\n' +
                 '<tbody>\n';

    for (var index = 0; index < input.length; index++) {
        var number = parseInt(input[index]);

        if (number > 10) {
            var type = 'dagger';

            if (number > 40) {
                type = 'sword';
            }

            var applicationIndex = number % 5;
            if (applicationIndex === 0) {
                applicationIndex = 5;
            }

            var application;
            switch (applicationIndex) {
                case 1:
                    application = 'blade';
                    break;
                case 2:
                    application = 'quite a blade';
                    break;
                case 3:
                    application = 'pants-scraper';
                    break;
                case 4:
                    application = 'frog-butcher';
                    break;
                case 5:
                    application = '*rap-poker';
                    break;
                default:
                    throw Error();
                    break;
            }

            output += '<tr><td>' + number +
                '</td><td>' + type +
                '</td><td>' + application + '</td></tr>\n';
        }
    }

    output += '</tbody>\n' +
              '</table>';

    console.log(output);
}