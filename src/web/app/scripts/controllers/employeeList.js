'use strict';

/**
 * @ngdoc function
 * @name benefitApp.controller:EmployeeListCtrl
 * @description
 * # EmployeeListCtrl
 * Controller of the benefitApp
 */
angular.module('benefitApp')
  .controller('EmployeeListCtrl', ['employeeService', '$location',
    function(employeeService, $location) {
      //	private fields
      var self = this;

      //	navigate to existing employee
      this.selectEmployee = function(employee) {
        $location.path('/employee/' + employee.id);
      };

      //	navigate to new employee
      this.newEmployee = function() {
        $location.path('/employee/new');
      };

      //	initialize by loading employees
      employeeService.getAll()
        .then(function(result) {
          //	real implementation would have a paging scheme
          self.employees = result.data;
        });
    }
  ]);
