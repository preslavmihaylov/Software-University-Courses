function hideOddRows() {
    var elements = document.getElementsByTagName('tr');
    var table = document.getElementsByTagName('table');

    for (var index = 0; index < elements.length; index++) {
        if ((index + 1) % 2 == 1) {
            elements[index].parentNode.removeChild(elements[index]);
        }
    }
}