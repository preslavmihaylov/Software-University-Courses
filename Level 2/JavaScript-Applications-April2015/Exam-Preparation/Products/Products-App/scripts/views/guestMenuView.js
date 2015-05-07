var app = app || {};

app.guestMenuView = (function () {
    function GuestMenuView(selector) {
        $(selector).empty();
        return $.get('templates/guestMenu.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector) {
            return GuestMenuView(selector);
        }
    }
}());