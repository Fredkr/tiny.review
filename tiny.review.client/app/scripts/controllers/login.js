'use strict';
angular.module('tinyreviewclientApp')
  .controller('LoginCtrl', function ($scope, $location, LoginService) {

    $scope.notification = {
      show: false
    };

  	$scope.login = function () {
     	var login = LoginService.login($scope.userName, $scope.password);
   		login.then(function(result) {  
   			if(!!result.data && result.data.Success){
          $scope.notification.type = 'success';
          $scope.notification.message = 'Succesfully logged in!';
          $scope.notification.show = true;
          $location.path('/main');
        }
      	});      
    };
  });
