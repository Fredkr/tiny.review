'use strict';
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
      .when('/main', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
      })
      .when('/register', {
        templateUrl: 'views/register.html',
        controller: 'RegisterCtrl'
      })
       .when('/login', {
        templateUrl: 'views/login.html',
        controller: 'LoginCtrl'
      })
      .otherwise({
        redirectTo: '/login'
      });
  })
  .run( function($rootScope, $location, LoginService) {
    $rootScope.$on( '$routeChangeStart', function(event, next) {
      if (!LoginService.getLoginState().isLoggedIn && !next.templateUrl && next.templateUrl !== 'views/register.html') {
        $location.path('/login');
      }
    });
  });
