var app = app || {};

app.userWelcomeView = (function () {
    function UserWelcomeView(selector, data) {
        $(selector).empty();
        return $.get('templates/userWelcomePage.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return UserWelcomeView(selector, data);
        }
    }
}());