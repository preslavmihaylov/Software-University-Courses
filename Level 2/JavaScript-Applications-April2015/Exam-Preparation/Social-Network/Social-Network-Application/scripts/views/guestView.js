var app = app || {};

app.guestView = (function() {
    function GuestView(selector) {
        $(selector).empty();
        return $.get('templates/guestHome.html', function(template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector) {
            return GuestView(selector);
        }
    }
}());