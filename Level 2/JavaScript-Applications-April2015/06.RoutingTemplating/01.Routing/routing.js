var app = app || {};

(function () {

    app.router = Sammy(function () {

        this.get('#/', function () {
            $('#wrapper').text('Welcome Home');
            // Controller - Get homepage

            // Add ways to sort posts by get parameter
        });

        this.get('#/Sam', function () {
            $('#wrapper').text('Hi Sam !');
        });

        this.get('#/Bob', function () {
            $('#wrapper').text('Hi Bob !');
        });
    });

    app.router.run('#/');
}());