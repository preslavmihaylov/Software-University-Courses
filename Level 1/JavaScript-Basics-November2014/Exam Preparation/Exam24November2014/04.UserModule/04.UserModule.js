readInput();

function readInput() {
    var input = [
        'name^courses',
        '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
        '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
        '{"id":2,"firstname":"Angel","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
        '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
        '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps"],"lecturesPerDay":2}'
    ];
    
    solve(input);
}

function solve(input) {
    var criterias = input[0].split(/[\^]+/);
    var studentsCriteria = criterias[0];
    var trainersCriteria = criterias[1];
    
    var data = {};
    data.students = [];
    data.trainers = [];
    
    for (var index = 1; index < input.length; index++) {
        var element = JSON.parse(input[index]);
        
        if (element.role == "student") {
            data.students.push({});
            data.students[data.students.length - 1].id = element.id;
            data.students[data.students.length - 1].firstname = element.firstname;
            data.students[data.students.length - 1].lastname = element.lastname;
            data.students[data.students.length - 1].averageGrade = calculateAverageGrade(element.grades);
            data.students[data.students.length - 1].certificate = element.certificate;
            data.students[data.students.length - 1].level = element.level;
        } else {
            data.trainers.push({});
            data.trainers[data.trainers.length - 1].id = element.id;
            data.trainers[data.trainers.length - 1].firstname = element.firstname;
            data.trainers[data.trainers.length - 1].lastname = element.lastname;
            data.trainers[data.trainers.length - 1].courses = element.courses;
            data.trainers[data.trainers.length - 1].lecturesPerDay = element.lecturesPerDay;
        }
    }
    
    if (studentsCriteria == "level") {
        data.students.sort(function (a, b) {
            if (parseInt(a.level) - parseInt(b.level) == 0) {
                return parseInt(a.id) - parseInt(b.id);
            } else {
                return parseInt(a.level) - parseInt(b.level);
            }
        });
    } else {
        data.students.sort(function (a, b) {
            if (a.firstname == b.firstname) {
                if (a.lastname < b.lastname) return -1;
                if (a.lastname > b.lastname) return 1;
                return 0;
            } else {
                if (a.firstname < b.firstname) return -1;
                if (a.firstname > b.firstname) return 1;
                return 0;

            }
        });
    }
    
    for (var index = 0; index < data.students.length; index++) {
        delete data.students[index].level;
    }
    
    data.trainers.sort(function (a, b) {
        if (a.courses.length - b.courses.length == 0) {
            return parseInt(a.lecturesPerDay) - parseInt(b.lecturesPerDay) // !
        } else {
            return a.courses.length - b.courses.length;
        }
    });
    
    console.log(JSON.stringify(data));
    
    function calculateAverageGrade(grades) {
        var averageGrade = 0;
        for (var grade = 0; grade < grades.length; grade++) {
            averageGrade += parseFloat(grades[grade]);
        }
        
        averageGrade /= grades.length;
        return averageGrade.toFixed(2);
    }

}