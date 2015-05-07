var app = app || {};

app.deleteProductView = (function () {
    function DeleteProductView(selector, data) {
        $(selector).empty();
        return $.get('templates/deleteProductPage.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return DeleteProductView(selector, data);
        }
    }
}());