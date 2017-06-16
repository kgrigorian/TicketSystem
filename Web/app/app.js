/// <reference path="C:\Users\Dr.Cymb\Desktop\VR2ProjectFinal\TicketSystem\Web\Scripts/angular.js" />

var myApp = angular.module("myapp", []);

myApp.controller("usersController",
    function($scope) {
        console.log("Hello world!");
        $scope.users = [
            {
                "$id": "1",
                "userId": 2,
                "firstName": "Kalev",
                "lastName": "Velak",
                "userEmail": "Kalev@gmail.com",
                "userRole": 0,
                "ticketsCreatedCount": 0,
                "ticketsAssignedCount": 0
            },
            {
                "$id": "2",
                "userId": 3,
                "firstName": "BOB",
                "lastName": "OBO",
                "userEmail": "asdasdasdasdadsasda",
                "userRole": 0,
                "ticketsCreatedCount": 0,
                "ticketsAssignedCount": 0
            },
            {
                "$id": "3",
                "userId": 4,
                "firstName": "BOB",
                "lastName": "OBO",
                "userEmail": "asdasdasdasdadsasda",
                "userRole": 0,
                "ticketsCreatedCount": 0,
                "ticketsAssignedCount": 0
            },
            {
                "$id": "4",
                "userId": 5,
                "firstName": "BOB",
                "lastName": "OBO",
                "userEmail": "asdasdasdasdadsasda",
                "userRole": 0,
                "ticketsCreatedCount": 0,
                "ticketsAssignedCount": 0
            }
        ];

        $scope.selectedUser = {};

        $scope.editUser = function(user) {
            $scope.selectedUser = user;
        }

    });