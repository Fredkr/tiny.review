'use strict';
angular.module('tinyreviewclientApp')
  .controller('ReviewCtrl', function ($scope, GetReviewService, LoginService) {
  	$scope.user = LoginService.getLoginState().user;
    $scope.currentPage = 1;
    $scope.numPerPage = 6;
    $scope.filteredReviews = [];
    $scope.reviews = [];

		$scope.getRating = function(num) {
		    return new Array(num);   
		};

    $scope.changePage = function() {
      var begin = (($scope.currentPage - 1) * $scope.numPerPage);
      var end = begin + $scope.numPerPage;      
      $scope.filteredReviews = $scope.reviews.slice(begin, end);
    };

    $scope.$watch('currentPage + numPerPage', function() {
      $scope.changePage();
    });

  	(function() {
     	var reviews = GetReviewService.getReviews($scope.user.Name);
   		reviews.then(function(result) {  
   			if(!!result.data){
   				$scope.reviews = result.data;
          $scope.totalReviews = result.data.length;
          $scope.changePage();
        }
      });      
    })();
  });
