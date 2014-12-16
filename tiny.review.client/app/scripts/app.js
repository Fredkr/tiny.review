'use strict';

/**
 * @ngdoc overview
 * @name tinyreviewclientApp
 * @description
 * # tinyreviewclientApp
 *
 * Main module of the application.
 */
angular
  .module('tinyreviewclientApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
