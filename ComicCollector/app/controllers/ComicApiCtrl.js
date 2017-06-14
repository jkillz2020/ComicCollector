"use strict";

app.controller("ComicApiCtrl", function ($scope, $rootScope, $routeParams, $location, ComicFinderFactory) {
    let searchInfo = $scope.input
    let comicInfo = {};
    $scope.getPlaces = function (searchInfo) {
        ComicFinderFactory.getComicInfo(searchInfo).then(function (response) {
            $scope.comicInfo = response.results;
            comicInfo = response.results;
        })
        console.log("searchInfo", searchInfo);
    };

})