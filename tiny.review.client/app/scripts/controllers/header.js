'use strict';
angular.module('tinyreviewclientApp')
  .controller('HeaderCtrl', function ($scope, $location) {
	  $scope.isActive = function (viewLocation) { 
	  	var test1 = $location.path();
	  	var test2 = viewLocation === $location.path()
	  	return test2;
	  };
  });
