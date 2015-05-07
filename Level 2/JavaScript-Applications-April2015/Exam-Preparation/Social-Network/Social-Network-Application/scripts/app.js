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

        this.get('#/Post', function () {
            controller.showPostBox(selector);
        });

        this.get('#/CreatePost', function () {
            controller.createPost();
        });

        this.get('#/Edit', function () {
            controller.getEditProfilePage(selector);
        });
    });

    app.router.run('#/');
}());