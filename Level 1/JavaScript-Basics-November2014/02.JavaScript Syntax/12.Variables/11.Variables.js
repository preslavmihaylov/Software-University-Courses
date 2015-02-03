var input = ['Pesho', 22, true, ['fries', 'banana', 'cake']]// modify the input here

variablesTypes(input);

function variablesTypes(input) {
    console.log("My name is: " + input[0] + "//Type is " + typeof input[0]);
    console.log("My age: " + input[1] + "//Type is " + typeof input[1]);
    console.log("I am male: " + input[2] + "//Type is " + typeof input[2]);
    console.log("My favourite foods are: " + input[3] + "//Type is " + typeof input[3]);
}

