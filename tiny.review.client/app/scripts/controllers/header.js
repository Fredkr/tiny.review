'use strict';
angular.module('tinyreviewclientApp')
  .controller('HeaderCtrl', function ($scope, $location, LoginService) {

    $scope.isLoggedIn = LoginService.getLoginState().isLoggedIn;

   	var isLoggedInService = function () {
          return LoginService.getLoginState().isLoggedIn;
      };

      $scope.$watch(isLoggedInService, 
      	function (newVal) {
  	        $scope.isLoggedIn = newVal;
  	});

  	$scope.isActive = function (viewLocation) { 
  		return viewLocation === $location.path();
  	};

  });
