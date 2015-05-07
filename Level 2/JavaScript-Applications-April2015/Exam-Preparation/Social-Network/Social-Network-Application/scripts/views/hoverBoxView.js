var app = app || {};

app.hoverBoxView = (function () {
    function HoverBoxView(selector, data) {
        return $.get('templates/hoverBox.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return HoverBoxView(selector, data);
        }
    }
}());