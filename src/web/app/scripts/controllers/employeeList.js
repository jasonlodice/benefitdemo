'use strict';

/**
 * @ngdoc function
 * @name benefitApp.controller:EmployeeCtrl
 * @description
 * # EmployeeCtrl
 * Controller of the benefitApp
 */
angular.module('benefitApp')
  .controller('EmployeeListCtrl', ['employeeService', '$location',
    function(employeeService, $location) {
      this.blue = 'red';
      var self = this;

      employeeService.getAll().then(function(result) {
        self.employees = result.data;
      });

      this.selectEmployee = function(employee) {
        $location.path('/employee/' + employee.id);
      };
    }
  ]);
