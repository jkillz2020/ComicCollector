"use strict";

app.controller("FindComicsCtrl", function ($scope, $rootScope, $routeParams, comicFinderFactory, comicCollectionFactory) {
    let seriestitle = $routeParams.seriestitle;
    let getComicInfo = function (searchInfo) {
        comicFinderFactory.getComicInfo(searchInfo).then(function(response) {
            for (var comic = 0; comic < response.length; comic++) {
                response[comic].buttonText = "Add Comic To Collection";
            }

            $scope.comicInfo = response;
        });
    }

    $scope.addComicToCollection = function (comic) {
        $scope.button = "Adding...";
        let ApiComic = {
            Title: comic.Title,
            Description: comic.Description,
            IssueNumber: comic.IssueNumber,
            Image: comic.Thumbnail.Path
        };

        comicCollectionFactory.postNewComic(ApiComic).then(function (comicId) {
            $scope.newComic = {};
        });
    }

    $scope.getComicInfo = getComicInfo;
});