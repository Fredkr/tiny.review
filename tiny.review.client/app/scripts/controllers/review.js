'use strict';
angular.module('tinyreviewclientApp')
  .controller('ReviewCtrl', function ($scope, GetReviewService, LoginService) {
  	$scope.user = LoginService.getLoginState().user;
  	$scope.reviews = [];

  	(function() {
     	var reviews = GetReviewService.getReviews($scope.user.Name);
   		reviews.then(function(result) {  
   			if(!!result.data && result.data.Success){
   				$scope.reviews = result.data;
        }
      	});      
    })();
  });
