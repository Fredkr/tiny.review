'use strict';
angular.module('tinyreviewclientApp')
  .controller('ReviewCtrl', function ($scope, GetReviewService, LoginService) {
  	$scope.user = LoginService.getLoginState().user;
  	$scope.reviews = [];
		$scope.getRating = function(num) {
		    return new Array(num);   
		};

  	(function() {
     	var reviews = GetReviewService.getReviews($scope.user.Name);
   		reviews.then(function(result) {  
   			if(!!result.data){
   				$scope.reviews = result.data;
        }
      });      
    })();
  });
