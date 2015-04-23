var initial = [
    { "gender": "Male", "firstName": "Joe", "lastName": "Riley", "age": 22, "country": "Russia" },
    { "gender": "Female", "firstName": "Lois", "lastName": "Morgan", "age": 41, "country": "Bulgaria" },
    { "gender": "Male", "firstName": "Roy", "lastName": "Wood", "age": 33, "country": "Russia" },
    { "gender": "Female", "firstName": "Diana", "lastName": "Freeman", "age": 40, "country": "Argentina" },
    { "gender": "Female", "firstName": "Bonnie", "lastName": "Hunter", "age": 23, "country": "Bulgaria" },
    { "gender": "Male", "firstName": "Joe", "lastName": "Young", "age": 16, "country": "Bulgaria" },
    { "gender": "Female", "firstName": "Kathryn", "lastName": "Murray", "age": 22, "country": "Indonesia" },
    { "gender": "Male", "firstName": "Dennis", "lastName": "Woods", "age": 37, "country": "Bulgaria" },
    { "gender": "Male", "firstName": "Billy", "lastName": "Patterson", "age": 24, "country": "Bulgaria" },
    { "gender": "Male", "firstName": "Willie", "lastName": "Gray", "age": 42, "country": "China" },
    { "gender": "Male", "firstName": "Justin", "lastName": "Lawson", "age": 38, "country": "Bulgaria" },
    { "gender": "Male", "firstName": "Ryan", "lastName": "Foster", "age": 24, "country": "Indonesia" },
    { "gender": "Male", "firstName": "Eugene", "lastName": "Morris", "age": 37, "country": "Bulgaria" },
    { "gender": "Male", "firstName": "Eugene", "lastName": "Rivera", "age": 45, "country": "Philippines" },
    { "gender": "Female", "firstName": "Kathleen", "lastName": "Hunter", "age": 28, "country": "Bulgaria" }
];

var collection = initial.slice();

// Students between 18 and 24
var filteredArray = _.remove(collection, function(person) {
    return person.age >= 18 && person.age <= 24;
});

console.log(filteredArray);
var collection = initial.slice();

// Students with first name alphabetically before their last name
filteredArray = _.remove(collection, function(person) {
    return person.firstName < person.lastName;
});

console.log(filteredArray);
var collection = initial.slice();

// Names of people who are from bulgaria
filteredArray = _.remove(collection, function (person) {
    return person.country === 'Bulgaria';
});

filteredArray = _.map(filteredArray, function(person) {
    return person.firstName;
});

console.log(filteredArray);
var collection = initial.slice();

// Last five elements
filteredArray = _.drop(collection, collection.length - 5);

console.log(filteredArray);
var collection = initial.slice();

// First three students who are not from bulgaria and are male
filteredArray = _.remove(collection, function(person) {
    return person.country !== 'Bulgaria';
});

filteredArray = _.remove(filteredArray, function(person) {
    return person.gender !== 'Male';
});

filteredArray = _.take(filteredArray, 3);

console.log(filteredArray);