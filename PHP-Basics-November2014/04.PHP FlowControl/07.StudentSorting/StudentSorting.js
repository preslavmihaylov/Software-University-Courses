function removeStudent() {
    var parent = document.getElementById('data');
    if (parent.childNodes.length > 2) {
        parent.removeChild(parent.childNodes[parent.childNodes.length - 1]);
    }
}

function addStudent() {
    var table = document.getElementById('data');
    var tr = document.createElement('tr');
    tr.innerHTML = '<td><input type="text" name="firstNames[]" /></td>' +
    '<td><input type="text" name="lastNames[]" /></td>' +
    '<td><input type="text" name="emails[]" /></td>' +
    '<td><input type="number" name="scores[]" /><button type="button" onclick="removeStudent()">-</button></td>';
    table.appendChild(tr);
}