"use strict";

app.factory('ComicFinderFactory', function ($q, $http, COMIC_API_CONFIG) {

    var getComicInfo = function (seriestitle) {
        return $q((resolve, reject) => {
            $http.get("https://gateway.marvel.com:443/v1/public/series?titleStartsWith=wolverine&apikey=570494d5a6a681b21681b10b3bf4d61c")

              .then(function (response) {
                  resolve(response);
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