var app = angular.module("VideoSystem", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '../app/templates/main.html',
            controller: 'MainController'
        })
        .when('/Add', {
            templateUrl: '../app/templates/addVideo.html',
            controller: 'MainController'
        })
        .otherwise({ redirectTo: '/' })

});