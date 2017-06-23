"use strict";

app.controller("ComicCollectionCtrl", function ($scope, $rootScope, $location, comicCollectionFactory) {
    $scope.comics = [];

    let getComics = function () {
        comicCollectionFactory.getComicCollection().then(function(response) {
            $scope.comics = response.data;
        });
    }

    getComics();

    $scope.deleteComic = function (comicId) {
        comicCollectionFactory.deleteComic(comicId).then(function(response) {
            getComics();
        });
    }

   
})