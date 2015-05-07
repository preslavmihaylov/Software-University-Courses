var app = app || {};

app.postBoxView = (function () {
    function PostBoxView(selector) {
        return $.get('templates/postBox.html', function (template) {
            var output = Mustache.render(template);
            $(selector).prepend(output);
        });
    }

    return {
        load: function (selector) {
            return PostBoxView(selector);
        }
    }
}());