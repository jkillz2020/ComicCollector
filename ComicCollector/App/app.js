var app = angular.module("ComicCollector", ["ngRoute"]);

app.config([
    "$routeProvider", function ($routeProvider) {
        $routeProvider
            .when("/",
            {
                templateUrl: "app/partials/login.html",
                controller: "LoginCtrl"
            })
            .when("/home",
            {
                templateUrl: "app/partials/comic-collection.html",
                controller: "ComicCollectionCtrl"
            })
           .when("/find-comics",
           {
               templateUrl: "app/partials/find-comics.html",
               controller: "FindComicsCtrl"
           })
           .when("/detail-view",
           {
               templateUrl: "app/partials/comic-detail.html",
               controller: "ComicDetailCtrl"
           });
    }
])

app.run(["$http", function ($http) {

    var token = sessionStorage.getItem('token');

    if (token)
        $http.defaults.headers.common['Authorization'] = `bearer ${token}`;

}
]);