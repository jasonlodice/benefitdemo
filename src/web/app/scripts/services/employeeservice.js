'use strict';

/**
 * @ngdoc service
 * @name benefitApp.employeeService
 * @description
 * # employeeService
 * Service in the benefitApp.
 */
angular.module('benefitApp')
  .service('employeeService', ['$http', function($http) {

		var resourcePath = 'http://localhost/lopay/api/employee';

    this.getAll = function() {
      return $http.get(resourcePath);
    };

    this.get = function(id) {
      return $http.get(resourcePath + '/' + id);
    };

    this.update = function(id, employee) {
      return $http.put(resourcePath + '/' + id, employee);
    };

    this.create = function(employee) {
			return $http.post(resourcePath, employee);
    };
  }]);
