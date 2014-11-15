function autoComplete(key) {

    if (key == 13) {
        result();
        return;
    } else if (key == 32) {
        complete();
    }

    var dictionary = ['hello', 'bla', 'blaaaa', 'softuni', 'java', 'dido', 'pesho', 'nakov', 'Nakov'];

    var currentWord = document.getElementById('input').value;
    var preview = document.getElementById('preview');

    var autoCompletes = [];

    for (var possibility = 0; possibility < dictionary.length; possibility++) {
        if (dictionary[possibility].toLowerCase().indexOf(currentWord.toLowerCase()) == 0) {
            autoCompletes.push(dictionary[possibility]);
        }
    }

    clearPossibilities(autoCompletes);

    if (autoCompletes.length >= 1 && currentWord != "") {
        preview.innerHTML = autoCompletes[0];
    } else {
        preview.innerHTML = "";
    }
    
}

function clearPossibilities(autoCompletes) {
    while (autoCompletes.length > 1) {

        if (autoCompletes[0].length < autoCompletes[1].length) {
            autoCompletes.splice(1, 1);
            continue;
        } else if (autoCompletes[0].length > autoCompletes[1].length) {
            autoCompletes.splice(0, 1);
            continue;
        }
        var resultFound = false;

        for (var index = 0; index < autoCompletes[0].length; index++) {
            var first = autoCompletes[0].toLowerCase();
            var second = autoCompletes[1].toLowerCase();
            if (first[index] < second[index]) {
                autoCompletes.splice(1, 1);
                resultFound = true;
                break;
            } else if (first[index] > second[index]) {
                autoCompletes.splice(0, 1);
                resultFound = true;
                break;
            }
        }

        if (!resultFound) {
            break;
        }
    }
}

function result() {
    var currentWord = document.getElementById('input').value;
    var ul = document.getElementById('output');
    var li = document.createElement("li");
    li.appendChild(document.createTextNode(currentWord));
    ul.appendChild(li);
}

function complete() {
    var input = document.getElementById('input');
    var autoComplete = document.getElementById('preview').innerHTML;

    if (autoComplete != "") {
        input.value = autoComplete;
    }
}