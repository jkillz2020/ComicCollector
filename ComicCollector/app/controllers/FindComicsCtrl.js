"use strict";

app.controller("FindComicsCtrl", function ($scope, $rootScope, $routeParams, ComicFinderFactory) {
    let seriestitle = $routeParams.seriestitle
    let getComicInfo = function (searchInfo) {
        console.log("searchInfo", searchInfo);
        ComicFinderFactory.getComicInfo(searchInfo).then(function (response) {
            $scope.comicInfo = response;
            console.log("comicInfo", $scope.comicInfo);
        })
    }

    $scope.getComicInfo = getComicInfo;
});