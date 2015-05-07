var app = app || {};

app.addProductView = (function () {
    function AddProductView(selector) {
        $(selector).empty();
        return $.get('templates/addProductPage.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector) {
            return AddProductView(selector);
        }
    }
}());