var app = app || {};

app.userMenuView = (function () {
    function UserMenuView(selector) {
        $(selector).empty();
        return $.get('templates/userMenu.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector) {
            return UserMenuView(selector);
        }
    }
}());