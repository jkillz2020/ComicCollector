"use strict";

app.factory("comicFinderFactory", function ($q, $http, COMIC_API_CONFIG) {

    var getComicInfo = function (seriestitle) {
        return $q((resolve, reject) => {
            $http.get(`/api/comicfinder/${seriestitle}`)
                .then(function(response) {
                        resolve(response.data);
                    },
                    function(errorResponse) {
                        reject(errorResponse);
                    });
        });
    }

    return {
        getComicInfo: getComicInfo
    }
});