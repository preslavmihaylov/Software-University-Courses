var app = app || {};

app.userHeaderView = (function () {
    function UserHeaderView(selector) {
        $(selector).empty();
        return $.get('templates/userHeader.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector) {
            return UserHeaderView(selector);
        }
    }
}());