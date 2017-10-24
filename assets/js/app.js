(function () {


    var app = angular.module('app', ['appService']);

    // app.constant('API', {url:''})

    app.controller('appController', appController);

    function appController($scope, $http, userService) {
        var scope = $scope;
        var http = $http;
        var url='http://sabeelul.apphb.com/api/users/'
       // var url = 'http://localhost:61427/api/users/';
        scope.users = [];
        scope.name = 'Norms'
        scope.sayHello = sayHello;
        scope.beginnerUsers = [];
        scope.level1Users = [];
        scope.level2Users = [];
        scope.level3Users = [];
        scope.level4Users = [];
        scope.searchKeyword = '';
        scope.user = {};
        scope.newUser = {};
        scope.levels = ['Beginners', 'Level 1', 'Level 2', 'Level 3', 'Level 4'];
        scope.edit = edit;
        scope.register = register;
        scope.save = save;
        scope.addNew = addNew;
        scope.isValid = false;
        scope.swalTest = swalTest;
        scope.addRow = addRow;
        scope.removeRow = removeRow;

        function edit(user) {
            // if (user.id > 0) {
            scope.user = user;

            //  }
            //  else {
            // var lastId = scope.users[scope.users.length - 1].id;
            // user.id = lastId + 1;
            //scope.newUser=user;
            //    scope.addRow(scope.users);
            // }
        }

        function register() {
            http.post(url + 'create', scope.newUser);
            scope.user = {};
            loadUsers();
        }

        function save() {
            notify('info', 'Sorry', 'You can\t edit User information at the moment', false, 'Ok', '');
            //if (!hasValue(scope.user.password)) {
            //    scope.user.password = '';
            //}

            //http.put(url + 'edit', scope.user)
            //    .then(function (res) {
            //        if (res.Ok) {
            //            notify('success', 'Good!', 'Opertion Successful...', false, 'Ok', '');
            //        }

            //    }).catch(function () {
            //        notify('error', 'Oops!', 'An error occoured while saving user information...', false, 'I will Try Later', '');
            //    });
            loadUsers();
        }

        function hasValue(str) {
            return (!(!str || 0 === str.length));
        }

        function validate(user) {
            if (hasValue(user.firstName) && hasValue(user.lastName)) {
                scope.isValid = true;
            }
            else {
                scope.isValid = false;
            }
        }

        function notify(type, title, message, cancel, confirmButtonText, cancelButtonText, preConfirm) {
            swal({
                title: title,
                text: message,
                type: type,
                showCancelButton: cancel,
                confirmButtonColor: "#f96332",
                confirmButtonText: confirmButtonText,
                cancelButtonText: cancelButtonText,
                preConfirm: preConfirm
            });
        }

        function swalTest() {
            notify('success', 'Test', 'This is a test alert', false, 'Good Job', '')
        }

        function addNew(user) {
            // validate(user);
            notify('info', 'You are Set', 'About to add a new recard to the Database... ', true, 'Yes, Proceed', 'No!', function () { swal({ text: 'Pre confirm', confirmButtonColor: "#f96332" }); });
            if (hasValue(user.firstName) && hasValue(user.lastName) && hasValue(user.level)) {
                var lastId = scope.users[scope.users.length - 1].id;
                user.id = lastId + 1;
                addRow(user);
                scope.newUser = {};
            }
            else { notify('warning', 'Note', 'Please fill all required fields', false, 'Try Again') }
        }

        function sayHello(name) {
            alert('Angular Says, Hello ' + name + ' ' + scope.users[0].lastName);
            console.log(scope.users);
        }

        function filterUsersByLevel(list, levelName) {
            scope.users.forEach(function (usr, index) {
                if (usr.level === levelName) {
                    list.push(usr);
                }
            });
        }

        function addRow(user) {
            scope.users.push(user);

        }

        function removeRow(id) {
            var index = -1;
            var usrArr = eval(scope.users);

            for (i = 0; i < usrArr.length; i++) {
                if (usrArr[i].id === id) {
                    index = i;
                    break;
                }
            }
            if (index === -1) {
                notify('error', 'Oops!', 'Something went wrong', false, 'Retry')
            }

            scope.users.splice(index, 1);

        }

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

        function loadUsers() {
            http.get(url + 'all')
                    .then(function (res) {
                        scope.users = markBulkUsers(res.data);
                        // users = scope.users;
                        filterUsersByLevel(scope.users, scope.beginnerUsers, 'Begginer');
                        filterUsersByLevel(scope.users, scope.level1Users, 'Level 1');
                        filterUsersByLevel(scope.users, scope.level2Users, 'Level 2');
                        filterUsersByLevel(scope.users, scope.level3Users, 'Level 3');
                        filterUsersByLevel(scope.users, scope.level4Users, 'Level 4');
                    }).catch(function () { swal('Opps!', 'An error occoured...', 'error') });
        }

        function init() {
            loadUsers();
            //alert('App initialize...'+scope.beginnerUsers[0].lastName);
        }

        init();

    }

})();