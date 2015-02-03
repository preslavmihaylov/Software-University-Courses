
// modify input here
var input = [[3, 5, 2, 7, 9],
            ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'],
            ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'],
            ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']];

soothsayer(input);

function soothsayer(input) {
    console.log(
        "You will work " + input[0][Math.round(Math.random() * 4)] + " years on " + input[1][Math.round(Math.random() * 4)] + 
        ". You will live in " + input[2][Math.round(Math.random() * 4)] + " and drive " + input[3][Math.round(Math.random() * 4)] + "."
        );
}

