"use strict";

app.controller('NavCtrl', function ($scope) {
    $scope.navItems = [
      {
          name: "Logout",
          url: "#/logout"
      },
      {
          name: "My Comics",
          url: "#/comics/collection"
      },
      {
          name: "Find Comics",
          url: "#/comics/find-comics"
      }
    ];
});