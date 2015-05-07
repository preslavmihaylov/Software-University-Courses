var app = app || {};

app.userHomeView = (function () {
    function UserHomeView(selector, data) {
        $(selector).empty();
        return $.get('templates/home.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return UserHomeView(selector, data);
        }
    }
}());