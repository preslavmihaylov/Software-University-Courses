var app = app || {};

app.filterBoxView = (function () {
    function FilterBoxView(selector, data) {
        $(selector).empty();
        return $.get('templates/filterBoxPage.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return FilterBoxView(selector, data);
        }
    }
}());