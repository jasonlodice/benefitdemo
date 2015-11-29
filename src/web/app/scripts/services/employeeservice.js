'use strict';

/**
 * @ngdoc service
 * @name benefitApp.employeeService
 * @description
 * # employeeService
 * Service in the benefitApp.
 */
angular.module('benefitApp')
  .service('employeeService', ['$http', function ($http) {
  	var resourcePath = 'http://localhost/lopay/api/employee';
  	var defaultGrossPay = 2000;

  	//	create employee with default values
  	this.newDefault = function () {
  		return {
  			grossPay: defaultGrossPay
  		};
  	};

  	//	fetch all employees
  	this.getAll = function () {
  		return $http.get(resourcePath);
  	};

  	//	fetch employee by id
  	this.get = function (id) {
  		return $http.get(resourcePath + '/' + id);
  	};

  	//	update employee and dependents
  	this.update = function (id, employee) {
  		return $http.put(resourcePath + '/' + id, employee);
  	};

  	//	insert new employee
  	this.create = function (employee) {
  		return $http.post(resourcePath, employee);
  	};
  }]);
