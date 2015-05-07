var app = app || {};

app.productsView = (function () {
    function ProductsView(selector, data) {
        $(selector).empty();
        return $.get('templates/productsListPage.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return ProductsView(selector, data);
        }
    }
}());