function removeProgrammingLang() {
    var parent = document.getElementById('parentProgramming');
    parent.removeChild(parent.childNodes[parent.childNodes.length - 1]);
}

function addProgrammingLang() {
    var parent = document.getElementById('parentProgramming');
    var newElement = document.createElement('div');
    newElement.innerHTML = '<input type="text" name="programmingLangs[]">' +
        '<select name="levels[]">' +
        '<option value="Beginner">Beginner</option>' +
        '<option value="Intermediate">Intermediate</option>' +
        '<option value="Professional">Professional</option>' +
        '</select>';

    parent.appendChild(newElement);
}

function removeLang() {
    var parent = document.getElementById('parentLanguages');
    parent.removeChild(parent.childNodes[parent.childNodes.length - 1]);
}

function addLang() {
    var parent = document.getElementById('parentLanguages');
    var newElement = document.createElement('div');
    newElement.innerHTML = '<input type="text" name="languages[]">' +
    '<select name="comprehension[]">' +
    '<option value="Beginner" selected>-Comprehension-</option>' +
    '<option value="Beginner">Beginner</option>' +
    '<option value="Intermediate">Intermediate</option>' +
    '<option value="Professional">Professional</option>' +
    '</select>' +
    '<select name="reading[]">' +
    '<option value="Beginner" selected>-Reading-</option>' +
    '<option value="Beginner">Beginner</option>' +
    '<option value="Intermediate">Intermediate</option>' +
    '<option value="Professional">Professional</option>' +
    '</select>' +
    '<select name="writing[]">' +
    '<option value="Beginner" selected>-Writing-</option>' +
    '<option value="Beginner">Beginner</option>' +
    '<option value="Intermediate">Intermediate</option>' +
    '<option value="Professional">Professional</option>' +
    '</select>';

    parent.appendChild(newElement);
}
