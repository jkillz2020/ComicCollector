"use strict";

app.factory('ComicCollectionFactory', function ($q, $http, MY_API_CONFIG) {

    var getComicCollection = function (userId) {
        return $q((resolve, reject) => {
            $http.get(`${MY_API_CONFIG.databaseURL}/Comics.json?orderBy="uid"&equalTo="${userId}"`)
              .success(function (response) {
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
            $http.post(`${MY_API_CONFIG.databaseURL}/Comics.json`,
              JSON.stringify({
                  comicName: newComic.resortName,
                  address: newComic.address,
                  zipcode: newComic.zipcode,
                  uid: newComic.uid
              })
            )
              .success(function (postResponse) {
                  resolve(postResponse);
              })
              .error(function (postError) {
                  reject(postError);
              })
        })
    }

    var deleteComic = function (comicId) {
        return $q((resolve, reject) => {
            $http.delete(`${MY_API_CONFIG.databaseURL}/Comics/${comicId}.json`)
            .success(function (deleteResponse) {
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
