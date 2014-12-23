'use strict';
angular.module('tinyreviewclientApp')
  .directive('notification', function ($timeout) {
    return {
      scope: {
        model:'=',
      },
      template: '<alert type="{{model.type}}">{{model.message}}</alert>',
      link: function ($scope, elem, attr) {
        $timeout(function(){
          $scope.model.show = false;
          $scope.$apply();
        }, 3000);
      }
    };
  });