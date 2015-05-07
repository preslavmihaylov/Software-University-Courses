var app = app || {};

app.officeView = (function () {
    function OfficeView(selector, data) {
        $(selector).empty();
        return $.get('templates/officeNoteTemplate.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return OfficeView(selector, data);
        }
    }
}());