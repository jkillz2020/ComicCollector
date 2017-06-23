"use strict";

app.controller('NavCtrl', function ($scope) {
    $scope.navItems = [
      {
          name: "Logout",
          url: "#!/"
      },
      {
          name: "My Comics",
          url: "#!/home"
      },
      {
          name: "Find Comics",
          url: "#!/find-comics"
      }
    ];
});