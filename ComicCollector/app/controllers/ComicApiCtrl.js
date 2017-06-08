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

    $scope.addNewComicToCollection = function () {
        // $scope.newComic.uid = $rootScope.user.uid;
        let ApiComic = {
            uid: $rootScope.user.uid,
            name: comicInfo[0].name,
            description: comicInfo[0].description,
        };
        // console.log("comicInfo", comicInfo);
        console.log("ApiComic", ApiComic);
        ComicFactory.postNewComic(ApiComic).then(function (comicId) {
            $location.url("/comics/collection");
            $scope.newComic = {};
        })
    }

})