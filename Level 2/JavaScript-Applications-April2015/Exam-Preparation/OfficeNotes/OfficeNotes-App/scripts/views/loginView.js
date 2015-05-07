var app = app || {};

app.loginView = (function () {
    function LoginView(selector) {
        $(selector).empty();
        return $.get('templates/login.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector) {
            return LoginView(selector);
        }
    }
}());