function readInput() {
    var people = [
      { firstname: 'George', lastname: 'Kolev', age: 32 },
      { firstname: 'Bay', lastname: 'Ivan', age: 81 },
      { firstname: 'Baba', lastname: 'Ginka', age: 40 }
    ];

    findYoungestPerson(people);
}

function findYoungestPerson(people) {
    var minAge = 9007199254740992;
    var youngestPerson;

    for (var index = 0; index < people.length; index++) {
        if (people[index].age < minAge) {
            minAge = people[index].age;
            youngestPerson = people[index];
        }
    }

    jsConsole.writeLine("The youngest person is " + youngestPerson.firstname + " " + youngestPerson.lastname);
}