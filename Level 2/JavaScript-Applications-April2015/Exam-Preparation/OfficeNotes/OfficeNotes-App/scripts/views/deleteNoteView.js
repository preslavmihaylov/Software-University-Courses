var app = app || {};

app.deleteNoteView = (function () {
    function DeleteNoteView(selector, data) {
        $(selector).empty();
        return $.get('templates/deleteNote.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return DeleteNoteView(selector, data);
        }
    }
}());