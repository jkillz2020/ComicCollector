"use strict";

app.controller("ComicCollectionCtrl", function ($scope, $rootScope, $location, ComicCollectionFactory) {
    $scope.comics = [];

    let getComics = function () {
        ComicCollectionFactory.getComicCollection($rootScope.user.uid).then(function (dbComics) {
            $scope.comics = dbComics;
        })
    }

    getComics();

    $scope.deleteComic = function (comicId) {
        console.log("you deleted a comic", comicId);
        ComicCollectionFactory.deleteComic(comicId).then(function (response) {
            console.log("here now", response)
            getComics();
        })
    }

    $scope.addNewComicToCollection = function () {
        $scope.newComic.uid = $rootScope.user.uid;
        let ApiComic = {
            uid: $rootScope.user.uid,
            name: comicInfo[0].name,
            description: comicInfo[0].description,
        };
        // console.log("comicInfo", comicInfo);
        console.log("ApiComic", ApiComic);
        ComicFactory.postNewComic(ApiComic).then(function (comicId) {
            $location.url("/api/comiccollection");
            $scope.newComic = {};
        })
    }
})