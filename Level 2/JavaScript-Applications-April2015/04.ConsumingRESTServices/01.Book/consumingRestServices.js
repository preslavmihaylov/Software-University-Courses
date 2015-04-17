var headers = {
    'X-Parse-Application-Id' : 'KgA7HqxYDhA0F8c6vUcppRyt0l4eDuJte74BOyLN',
    'X-Parse-REST-API-Key': 'ydveeQUVug7YmI5cALoRoIJGmYZlXwz0OehkCusL'
};
listAllBooks();

function listAllBooks() {
    $.ajax({
        method: 'GET',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Book'
    }).success(function (data) {
        var booksContainer = $('#booksContainer');
        for (var book in data.results) {
            var liElement = $('<li></li>')
                .html('<b>Title:</b> ' + data.results[book].title
                + '<br/> <b>Author:</b> ' + data.results[book].author
                + '<br/> <b>ISBN:</b> ' + data.results[book].isbn + '<br/>');

            var editButton = document.createElement('button');
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick', 'javascript: showEditForm("'
                + data.results[book].objectId + '")');

            var deleteButton = document.createElement('button');
            deleteButton.innerText = 'Delete';
            deleteButton.setAttribute('onclick', 'javascript: deleteBook("'
                + data.results[book].objectId + '");');

            liElement.append(editButton);
            liElement.append(deleteButton);

            booksContainer.append(liElement);
        }
    });
}

function showCreateForm() {
    $('#editForm').hide();
    $('#createForm').show();
}

function showEditForm(id) {
    $.ajax({
        method: 'GET',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Book/' + id
    }).success(function (data) {
        $('#createForm').hide();
        $('#editForm').show();
        $('#editTitle').val(data.title);
        $('#editAuthor').val(data.author);
        $('#editISBN').val(data.isbn);
        $('#editSubmit').click(function() {
            editBook(data.objectId);
        })
    });
}

function deleteBook(id) {
    $.ajax({
        method: 'DELETE',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Book/' + id
    }).success(function() {
        window.location.replace(window.location.href);
    });
}

function editBook(id) {
    var data = {
        'title': $('#editTitle').val(),
        'author': $('#editAuthor').val(),
        'isbn': $('#editISBN').val()
    }

    $('#editForm').hide();
    $.ajax({
        method: 'PUT',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Book/' + id,
        data: JSON.stringify(data)
    }).success(function() {
        window.location.replace(window.location.href);
    });
}

function createBook() {
    var data = {
        'title' : $('#createTitle').val(),
        'author' : $('#createAuthor').val(),
        'isbn': $('#createISBN').val()
    }

    $.ajax({
        method: 'POST',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Book',
        data: JSON.stringify(data)
    }).success(function() {
        window.location.replace(window.location.href);
    });
}