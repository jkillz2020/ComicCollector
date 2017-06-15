"use strict";

app.factory('ComicCollectionFactory', function ($q, $http) {
    
    var getComicCollection = function () {
        return $q((resolve, reject) => {
            $http.get('api/comiccollection')
              .then(function (response) {
                  let Comic = [];
                  //Object.keys(response).forEach(function (key) {
                  //response[key].id = key;
                  //Comics.push();
                  resolve(response);
                  console.log("response from my api", response);
                  //$scope.response = response.data;
              }, function (errorResponse) {
                  reject(errorResponse);
              });
        })
    }

    var postNewComic = function (newComic) {
        return $q((resolve, reject) => {
            $http.post(`api/comiccollection`, newComic)
              .then(function (postResponse) {
                  resolve(postResponse);
              }, function (postError) {
                  reject(postError);
              });
        })
    }

    var deleteComic = function (comicId) {
        return $q((resolve, reject) => {
            $http.delete(`${MY_API_CONFIG.databaseURL}/Comics/${comicId}.json`)
            .then(function (deleteResponse) {
                resolve(deleteResponse);
            })
            .error(function (deleteError) {
                reject(deleteError);
            })
        })
    }

    return {
        getComicCollection: getComicCollection,
        postNewComic: postNewComic,
        deleteComic: deleteComic,
        //getSingleResort: getSingleResort,
    }

});
