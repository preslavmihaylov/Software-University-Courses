var app = app || {};

app.editProductView = (function () {
    function EditProductView(selector, data) {
        $(selector).empty();
        return $.get('templates/editProductPage.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return EditProductView(selector, data);
        }
    }
}());