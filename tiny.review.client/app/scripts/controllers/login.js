'use strict';
angular.module('tinyreviewclientApp')
  .controller('LoginCtrl', function ($scope, $location, LoginService) {

  	$scope.login = function () {
     	var login = LoginService.login($scope.userName, $scope.password);
 		login.then(function(result) {  
 			if(!!result.data && result.data.Success){
 				$location.path('/main');
      		}
    	});      
    };
  });
