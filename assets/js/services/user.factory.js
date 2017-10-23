(function () {
    // 'use strict';

    angular
        .module('appService', [])
        .factory('userService', userService);

    // userService.$inject = ['$http'];

    /* @ngInject */
    function userService($http) {
        var http = $http;
        var users = [];

        var service = {
            getUsers: getUsers
        };

        return service;

        function getData() { }

        function mapUser(apiUser, user) {
            user.id = apiUser.Id;
            user.firstName = apiUser.FirstName;
            user.lastName = apiUser.LastName;
            user.dob = apiUser.DOB;
            user.password = apiUser.Password;
            user.email = apiUser.Email;
            user.phoneNumber = apiUser.PhoneNumber;
            user.level = apiUser.Level;
            return user;
        }

        function markBulkUsers(users) {
            var usrs = [];
            users.forEach(function (usrApi, index) {
                var usr = {};
                usrs.push(mapUser(usrApi, usr));
            });

            return usrs;
        }

        function filterUsersByLevel(users, list, levelName) {
            users.forEach(function (usr, index) {
                if (usr.level === levelName) {
                    list.push(usr);
                }
            });
        }

        function getUsers() {
            alert('get users...');
            var scope = {
                users: [],
                beginnerUsers: [],
                level1Users: [],
                level2Users: [],
                level3Users: [],
                level4Users: []
            };

            http.get('http://localhost:32027/api/users/all')
                    .then(function (res) {
                        scope.users = markBulkUsers(res.data);
                        // users = scope.users;
                        filterUsersByLevel(scope.users, scope.beginnerUsers, 'Begginer');
                        filterUsersByLevel(scope.users, scope.level1Users, 'Level 1');
                        filterUsersByLevel(scope.users, scope.level2Users, 'Level 2');
                        filterUsersByLevel(scope.users, scope.level3Users, 'Level 3');
                        filterUsersByLevel(scope.users, scope.level4Users, 'Level 4');
                        console.log('logging users from services')


                    }).catch(function () { alert('Error') });
            return scope;
        }
    }
})();