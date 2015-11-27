'use strict';

/**
 * @ngdoc function
 * @name benefitApp.controller:EmployeeCtrl
 * @description
 * # EmployeeCtrl
 * Controller of the benefitApp
 */
angular.module('benefitApp')
  .controller('EmployeeCtrl', ['employeeService', function(employeeService) {
    this.blue = 'red';
    var self = this;

    employeeService.getAll().then(function(result) {
      self.employees = result.data;
    });
  }]);
