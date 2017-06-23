"use strict";

app.controller("ComicApiCtrl", function ($scope, $rootScope, $routeParams, $location, comicFinderFactory) {
    let searchInfo = $scope.input;
    let comicInfo = {};
    $scope.getPlaces = function (searchInfo) {
        comicFinderFactory.getComicInfo(searchInfo).then(function(response) {
            $scope.comicInfo = response.results;
            comicInfo = response.results;
        });
    };

})