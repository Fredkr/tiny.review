'use strict';
angular.module('tinyreviewclientApp')
  .factory('GetReviewService', function ($http, config) {
    var reviewState =
      {
        reviews: []
      };
    
    return {
      getReview: function () {
        return reviewState;
      },
      getReview: function(userName, reviewId) {
        return $http({
            url: config.apiBaseUrl + '/User/GetReview?userName=' + userName +'&reviewId=' + reviewId,
            method: 'POST',
            data: '',
            headers: {'Content-Type': 'application/x-www-form-urlencoded'}
        }).success(function (data) {
          return data;
        }).error(function (data) {
          return data;
        });      
      },      
      getReviews: function(userName) {
        return $http({
            url: config.apiBaseUrl + '/User/GetReviews?userName=' + userName,
            method: 'POST',
            data: '',
            headers: {'Content-Type': 'application/x-www-form-urlencoded'}
        }).success(function (data) {
          reviewState.reviews = data;
          return data;
        }).error(function (data) {
          reviewState.reviews = [];
          return data;
        });      
      }
    };
  });
