'use strict';
angular.module('tinyreviewclientApp')
  .controller('ReviewDetailCtrl', function ($scope,$routeParams,GetReviewService, LoginService) {
  	$scope.user = LoginService.getLoginState().user;

    (function() {
      var reviews = GetReviewService.getReview($scope.user.Name, $routeParams.reviewId);
      reviews.then(function(result) {  
        if(!!result.data){
          $scope.review = result.data;
        }
      });      
    })();
  });
