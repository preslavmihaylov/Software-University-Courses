// 0 - current age; 1 - max age; 2 - food type; 3 - food per day
var input = [38, 118, "chocolate", 0.5];
// modify input here since getting multiple lines of input from the console is tedious

// PS: Enlighten me if there is an easy way to get input from the console please. I would be grateful

var result = (input[1] - input[0]) * 365 * input[3];

console.log(result + "kg of" + input[2] +" would be enough until I am " + input[1] + " years old.");




