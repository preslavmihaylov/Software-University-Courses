var app = app || {};

(function() {
    app.model = app.serverManager.load(app.requester.load('https://api.parse.com/1/'));
    // app.model.logout();

    var controller = app.controller.load(app.model);

    app.router = Sammy(function () {
        var selector = '#main';

        this.get('#/', function () {
            controller.getHomePage(selector);
        });

        this.get('#/Login', function () {
            controller.getLoginPage(selector);
        });

        this.get('#/Register', function () {
            controller.getRegisterPage(selector);
        });

        this.get('#/Logout', function () {
            controller.logoutUser();
        });

        this.get('#/Products', function () {
            controller.getProductsPage(selector);
        });

        this.get('#/Edit/:id', function (data) {
            // Controller - Get Post page
            var id = data['params'].id;
            controller.getEditProductPage(selector, id);

        });

        this.get('#/Delete/:id', function (data) {
            // Controller - Get Post page
            var id = data['params'].id;
            controller.getDeleteProductPage(selector, id);
        });

        this.get('#/AddProduct', function () {
            controller.getAddProductPage(selector);
        });
    });

    app.router.run('#/');
}());