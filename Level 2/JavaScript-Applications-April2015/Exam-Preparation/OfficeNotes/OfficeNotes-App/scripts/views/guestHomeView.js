var app = app || {};

app.guestHomeView = (function () {
    function GuestHomeView(selector) {
        $(selector).empty();
        return $.get('templates/welcome.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector) {
            return GuestHomeView(selector);
        }
    }
}());