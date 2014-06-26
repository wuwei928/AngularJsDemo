
var demoUser = angular.module("userApp", ['ui.bootstrap']);
var url = 'api/UserApi';

demoUser.factory("userService", function ($http) {
    return {
        getUser: function (callBack) {
            $http.get(url).success(callBack);
        },
        addUser: function (user, callBack) {
            $http.post(url, user).success(callBack);
        },
        updateUser: function (user, callBack) {
            $http.put(url + '/' + user.Id, user).success(callBack);
        },
        deleteUser: function (id, callBack) {
            $http.delete(url + '/' + id).success(callBack);
        }
    };
});

demoUser.controller("userContrller", function ($scope, $modal, userService) {
    getUser();

    $scope.deleteUser = function (user) {
        var deleteUser = $modal.open({
            templateUrl: 'DeleteUserModal',
            controller: DeleteUserModalInstanceCtrl,
            backdrop: 'static',
            resolve: {
                user: function () { return user; }
            }
        });

        deleteUser.result.then(function (returnUser) {
            var index = $scope.users.indexOf(returnUser);
            $scope.users.splice(index, 1);
        });
    };

    $scope.addUser = function (size) {
        var addUser = $modal.open({
            templateUrl: 'AddUserModal',
            controller: AddUserModalInstanceCtrl,
            size: size,
            backdrop: 'static'
        });

        addUser.result.then(function (returnUser) {
            getUser();
        });
    };

    $scope.editUser = function (user) {
        $modal.open({
            templateUrl: 'EditUserModal',
            controller: EditUserModalInstanceCtrl,
            backdrop: 'static',
            resolve: {
                user: function () { return angular.copy(user); }
            }
        });

        editUser.result.then(function (returnUser) {
            var index = $scope.users.indexOf(returnUser);
            $scope.users[index] = data;
        });
    }

    function getUser() {
        userService.getUser(function (results) {
            $scope.users = results;
        });
    }
});

var AddUserModalInstanceCtrl = function ($scope, $modalInstance, userService) {
    $scope.user = {};
    $scope.ok = function () {
        userService.addUser($scope.user, function () {
            $modalInstance.close();
        });
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};

var EditUserModalInstanceCtrl = function ($scope, user, $modalInstance, userService) {
    $scope.user = user;
    $scope.ok = function () {
        userService.updateUser($scope.user, function () {
            $modalInstance.close($scope.user);
        });
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};

var DeleteUserModalInstanceCtrl = function ($scope, user, $modalInstance, userService) {
    $scope.ok = function () {
        userService.deleteUser(user.Id, function () {
            $modalInstance.close(user);
        });
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};

