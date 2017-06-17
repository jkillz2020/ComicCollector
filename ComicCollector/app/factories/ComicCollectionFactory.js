"use strict";

app.factory('ComicCollectionFactory', function ($q, $http) {
    
    var getComicCollection = function () {
        return $q((resolve, reject) => {
            $http.get('api/comiccollection')
                .then(function(response) {
                        let Comic = [];
                        resolve(response);
                        console.log("response from my api", response);
                        //$scope.response = response.data;
                    },
                    function(errorResponse) {
                        reject(errorResponse);
                    });
        });
    }

    var postNewComic = function (newComic) {
        return $q((resolve, reject) => {
            $http.post(`api/comiccollection`, newComic)
                .then(function(postResponse) {
                        resolve(postResponse);
                    },
                    function(postError) {
                        reject(postError);
                    });
        });
    }

    var deleteComic = function (comicId) {
        return $q((resolve, reject) => {
            $http.delete(`api/comiccollection/${comicId}`)
                .then(function(deleteResponse) {
                        resolve(deleteResponse);
                    },
                    function(deleteError) {
                        reject(deleteError);
                    });
        });
    }

    return {
        getComicCollection: getComicCollection,
        postNewComic: postNewComic,
        deleteComic: deleteComic,
        //getSingleComic: getSingleComic,
    }

});
