var Person = function person(firstName, lastName) {
    Object.defineProperty(this, "firstName", {
        get: function () {
            return firstName;
        },
        set: function (val) {
            return firstName = val;
        }
    });
    Object.defineProperty(this, "lastName", {
        get: function () {
            return lastName;
        },
        set: function (val) {
            return lastName = val;
        }
    });
    Object.defineProperty(this, "fullName", {
        get: function () {
            return firstName + " " + lastName;
        },
        set: function (val) {
            var splitted = val.split(' ');
            firstName = splitted[0];
            lastName = splitted[1];
            return firstName + " " + lastName;
        }
    });

}
var pesho = new Person("Pesho", "Atanasov");

pesho.firstName = "Gosho";

console.log(pesho.firstName);
console.log(pesho.lastName);
console.log(pesho.fullName);

pesho.lastName = "Tosho";

console.log(pesho.firstName);
console.log(pesho.lastName);
console.log(pesho.fullName);

pesho.fullName = "Bosho Toshkov";

console.log(pesho.firstName);
console.log(pesho.lastName);
console.log(pesho.fullName);
