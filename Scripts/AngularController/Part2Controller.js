﻿angular.module('MyApp')
	.controller('Part2Controller', function ($scope, ContactService) {
	    $scope.Contact = null;
	    ContactService.GetLastContact().then(function (d) {
	        $scope.Contact = d.data; //success
	    }, function () {
	        alert('Failed'); //Failed
	    })
	})
    .factory('ContactService', function ($http) {
        var fac = {};
        fac.GetLastContact = function () {
            return $http.get('/Data/GetLastContact')
        }
        return fac;
    });