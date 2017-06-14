"use strict";

app.factory('ComicCollectionFactory', function ($q, $http) {

    var getComicCollection = function (userId) {
        return $q((resolve, reject) => {
            $http.get(`${MY_API_CONFIG.databaseURL}/Comics.json?orderBy="uid"&equalTo="${userId}"`)
              .then(function (response) {
                  let Comics = [];
                  Object.keys(response).forEach(function (key) {
                      response[key].id = key;
                      Comics.push(response[key]);
                  });
                  resolve(Comics);
              })
              .error(function (errorResponse) {
                  reject(errorResponse);
              })
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
