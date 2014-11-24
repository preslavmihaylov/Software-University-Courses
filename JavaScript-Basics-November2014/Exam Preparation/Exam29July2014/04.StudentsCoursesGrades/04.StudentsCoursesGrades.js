readInput();

function readInput() {
    var input = [
    'Peter Nikolov | PHP  | 5.50 | 8',
    'Maria Ivanova | Java | 5.83 | 7',
    'Ivan Petrov   | PHP  | 3.00 | 2',
    'Ivan Petrov   | C#   | 3.00 | 2',
    'Peter Nikolov | C#   | 5.50 | 8',
    'Maria Ivanova | C#   | 5.83 | 7',
    'Ivan Petrov   | C#   | 4.12 | 5',
    'Ivan Petrov   | PHP  | 3.10 | 2',
    'Peter Nikolov | Java | 6.00 | 9'
    ];

    solve(input);
}

function solve(input) {
    var data = {};

    for (var index = 0; index < input.length; index++) {
        var elements = input[index].split(/[|]+/);
        elements = elements.filter(function (e) { return e || e === 0 });
        
        var student = elements[0].trim();
        var course = elements[1].trim();
        var grade = parseFloat(elements[2].trim());
        var visits = parseFloat(elements[3].trim());

        if (data[course] == undefined) {
            data[course] = {};
            data[course]['avgGrade'] = grade;
            data[course]['totalGrades'] = 1;
            data[course]['avgVisits'] = visits;
            data[course]['totalVisits'] = 1;
            data[course]['students'] = [];
            data[course]['students'].push(student);
        } else {
            data[course]['avgGrade'] += grade;
            data[course]['avgVisits'] += visits;
            if (data[course]['students'].indexOf(student) == -1) {
                data[course]['students'].push(student);
            }

            data[course]['totalVisits'] += 1;
            data[course]['totalGrades'] += 1;
        }
    }

    for (var course in data) {
        data[course]['avgGrade'] = parseFloat((data[course]['avgGrade'] / data[course]['totalGrades']).toFixed(2));
        data[course]['avgVisits'] = parseFloat((data[course]['avgVisits'] / data[course]['totalVisits']).toFixed(2));
        delete data[course]['totalVisits'];
        delete data[course]['totalGrades'];
        data[course]['students'].sort();
    }

    data = sortObj(data, "bla");

    console.log(JSON.stringify(data));

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

// averageVisits  ??
// average score

// "C#":{"avgGrade":4.61,"avgVisits":5.5,"students":["Ivan Petrov","Maria Ivanova","Peter Nikolov"]},
// "Java":{"avgGrade":5.92,"avgVisits":8,"students":["Maria Ivanova","Peter Nikolov"]},
// "PHP":{"avgGrade":3.87,"avgVisits":4,"students":["Ivan Petrov","Peter Nikolov"]}