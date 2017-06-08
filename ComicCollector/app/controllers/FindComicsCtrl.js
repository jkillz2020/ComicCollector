"use strict";

app.controller("FindComicsCtrl", function ($scope, $rootScope, $routeParams, ComicFinderFactory) {
    let seriesname = $routeParams.seriesname
    let getComicInfo = function () {
        ComicFinderFactory.getComicInfo("wolverine").then(function (response) {
            $scope.comicInfo = response;
            console.log("comicInfo", $scope.comicInfo);
        })
    }

    getComicInfo();
});