app.controller("MainController", function ($scope, videoFactory) {
    var videos = videoFactory.getVideos();

    $scope.addVideo = function () {
        if (!$scope.title || !$scope.picture || !$scope.length || !$scope.category) {
            return;
        }

        videoFactory.addVideo($scope.title,
            $scope.picture,
            $scope.length,
            $scope.category,
            $scope.subtitles ? true : false);
        

        var splitted = window.location.href.split('#');
            window.location.replace(splitted[0] + '#/');
    }

    $scope.videos = videos;

});