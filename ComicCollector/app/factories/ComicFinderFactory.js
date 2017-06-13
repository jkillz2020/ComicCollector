"use strict";

app.factory('ComicFinderFactory', function ($q, $http, COMIC_API_CONFIG) {

    var getComicInfo = function (seriestitle) {
        console.log("seriestitle", seriestitle);
        return $q((resolve, reject) => {
            $http.get(`/api/comicfinder/${seriestitle}`)

              .then(function (response) {
                  console.log("response.data", response.data);
                  resolve(response.data);
              }
              ,function (errorResponse) {
                  reject(errorResponse);
              })
        })
    }

    return {
        getComicInfo: getComicInfo
    }
});