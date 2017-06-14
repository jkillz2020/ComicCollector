"use strict";

app.controller("FindComicsCtrl", function ($scope, $rootScope, $routeParams, ComicFinderFactory, ComicCollectionFactory) {
    let seriestitle = $routeParams.seriestitle
    let getComicInfo = function (searchInfo) {
        console.log("searchInfo", searchInfo);
        ComicFinderFactory.getComicInfo(searchInfo).then(function (response) {
            $scope.comicInfo = response;
            console.log("comicInfo", $scope.comicInfo);
        })
    }

    $scope.addComicToCollection = function (comic) {
        
        let ApiComic = {
            Title: comic.Title,
            Description: comic.Description,
            IssueNumber: comic.IssueNumber,
            Image: comic.Thumbnail.Path
        };
        // console.log("comicInfo", comicInfo);
        console.log("ApiComic", ApiComic);
        ComicCollectionFactory.postNewComic(ApiComic).then(function (comicId) {
            $location.url("/home");
            $scope.newComic = {};
        })
    }

    $scope.getComicInfo = getComicInfo;
});