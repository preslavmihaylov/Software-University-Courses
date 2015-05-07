var app = app || {};

app.myNotesView = (function () {
    function MyNotesView(selector, data) {
        $(selector).empty();
        return $.get('templates/myNoteTemplate.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return MyNotesView(selector, data);
        }
    }
}());