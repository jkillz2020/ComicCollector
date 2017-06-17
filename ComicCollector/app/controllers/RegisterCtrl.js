app.controller("RegisterCtrl", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {
        $scope.Email = "a@a.com",
            $scope.Password = "123456aA!",
            $scope.ConfirmPassword = "123456aA!";

        $scope.Register = function () {
            var newUser = {
                Email: $scope.Email,
                Password: $scope.Password,
                ConfirmPassword: $scope.ConfirmPassword
            }

            $http.post("/api/account/register", newUser);

            $location.path("/find-comics");
        };
    }]);