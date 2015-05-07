var app = app || {};

(function() {
    var model = app.serverManager.load(app.requester.load('https://api.parse.com/1/'));
    // app.model.logout();
    app.notesLimitCount = 10;
    var controller = app.controller.load(model);

    app.router = Sammy(function () {
        var selector = '#container';

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

        this.get('#/AddNote', function () {
            controller.getAddNotePage(selector);
        });

        this.get('#/MyNotes', function () {
            window.location.replace(window.location.href + '/1');
        });

        this.get('#/MyNotes/:page', function (data) {
            var page = parseInt(data['params'].page);
            controller.getMyNotesPage(selector, page, app.notesLimitCount);
        });

        this.get('#/Office', function () {
            window.location.replace(window.location.href + '/1');
        });

        this.get('#/Office/:page', function (data) {
            var page = parseInt(data['params'].page);
            controller.getOfficePage(selector, page, app.notesLimitCount);
        });

        this.get('#/Edit', function() {
            var splitted = window.location.href.split('#');
            window.location.replace(splitted[0] + '#/');
        });

        this.get('#/Edit/:id', function (data) {
            // Controller - Get Post page
            var id = data['params'].id;
            controller.getEditPage(selector, id);

        });

        this.get('#/Delete', function () {
            var splitted = window.location.href.split('#');
            window.location.replace(splitted[0] + '#/');
        });

        this.get('#/Delete/:id', function (data) {
            // Controller - Get Post page
            var id = data['params'].id;
            controller.getDeletePage(selector, id);
        });
    });

    app.router.run('#/');
}());