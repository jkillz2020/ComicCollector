"use strict";

app.controller('NavCtrl', function ($scope) {
    $scope.navItems = [
      {
          name: "Logout",
          url: "#!/logout"
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