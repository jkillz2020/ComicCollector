"use strict";

app.controller("ComicCollectionCtrl", function ($scope, $rootScope, $location, ComicCollectionFactory) {
    $scope.comics = [];

    let getComics = function () {
        ComicCollectionFactory.getComicCollection().then(function (response) {
            console.log("response", response);
            $scope.comics = response.data;
            console.log("scope comics", $scope.comics);

            //$scope.comics = {};
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

   
})