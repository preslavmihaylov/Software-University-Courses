var app = app || {};

app.navigationBarView = (function () {
    function NavigationBarView(selector, data) {
        $(selector).empty();
        return $.get('templates/navigationBar.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return NavigationBarView(selector, data);
        }
    }
}());