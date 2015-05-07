var app = app || {};

app.guestWelcomeView = (function() {
    function GuestWelcomeView(selector) {
        $(selector).empty();
        return $.get('templates/guestWelcomePage.html', function(template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector) {
            return GuestWelcomeView(selector);
        }
    }
}());