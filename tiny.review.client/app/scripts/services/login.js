'use strict';
angular.module('tinyreviewclientApp')
  .factory('LoginService', function ($http, config) {
    var loginState =
      {
        isLoggedIn: false,
        user: null
      };
    
    return {
      getLoginState: function () {
        return loginState;
      },
      login: function(userName, password) {
        return $http({
            url: config.apiBaseUrl + '/Login/login?userName='+userName+'&email=test@example.com&password=' + password,
            method: 'POST',
            data: '',
            headers: {'Content-Type': 'application/x-www-form-urlencoded'}
        }).success(function (data) {
          loginState.isLoggedIn = data.Success;
          loginState.user = data.User;
          return data;
        }).error(function (data) {
          loginState.isLoggedIn = false;
          return data;
        });      
      },
      logout: function() {
        loginState.isLoggedIn = false;
        loginState.user = null;
      }
    };
  });
