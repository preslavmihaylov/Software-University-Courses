function readInput() {
    // NOTE: I have modified the program to sort the output object alphabetically. 
    // Furthermore, note that there is a mistake in the 'lastName' input

    var people = [
        new Person("Scott", "Guthrie", 38),
        new Person("Scott", "Johns", 36),
        new Person("Scott", "Hanselman", 39),
        new Person("Jesse", "Liberty", 57),
        new Person("Jon", "Skeet", 38)
    ];

    var firstNameGroup = group(people, 'firstName');

    printResult(firstNameGroup);
}

function group(people, key) {
    var grouped = {};

    Object.prototype.contains = function contains(value) {
        for (var key in this) {
            if (key == value) {
                return true;
            }
        }
    }

    for (var index = 0; index < people.length; index++) {
        if (grouped.contains("Group " + people[index][key])) {
            grouped["Group " + people[index][key]].push(people[index]);
        } else {
            grouped["Group " + people[index][key]] = [];
            grouped["Group " + people[index][key]].push(people[index]);
        }
    }

    grouped = sortObj(grouped, 'bla');
    return grouped;
}

function printResult(group) {
    for (var key in group) {
        if (key == "contains") {
            continue;
        }
        var output = key + " : [";
        for (var innerKey in group[key]) {
            if (innerKey == "contains") {
                continue;
            }
            output += group[key][innerKey].firstName + " ";
            output += group[key][innerKey].lastName + "(";
            output += "age " + group[key][innerKey].age + "), ";
        }

        output = deleteLastTwoChar(output);
        output += "]"

        jsConsole.writeLine(output);
    }
}

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

function deleteLastTwoChar(output) {
    var result = "";

    for (var index = 0; index < output.length - 2; index++) {
        result += output[index].toString();
    }

    return result;
}

function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}