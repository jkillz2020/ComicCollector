app.controller("RegisterCtrl", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {
        $scope.Email = "a@a.com",
            $scope.Password = "123456",
            $scope.ConfirmPassword = "123456";

        $scope.signUp = function () {

            $http({
                url: "/api/Account/Register",
                method: "POST",
                data: {
                    "Email": $scope.Email,
                    "Password": $scope.Password,
                    "ConfirmPassword": $scope.ConfirmPassword
                }
            })
                .then(function (result) {
                    console.log(result);
                });

            $location.path("/home");
        };
    }]);