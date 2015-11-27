'use strict';

/**
 * @ngdoc function
 * @name benefitApp.controller:EmpdetailCtrl
 * @description
 * # EmpdetailCtrl
 * Controller of the benefitApp
 */
angular.module('benefitApp')
  .controller('EmployeeDetailCtrl', ['$routeParams', 'employeeService', 'paycheckCalcService',
    function($routeParams, employeeService, paycheckCalcService) {
      //	private fields
      var self = this;

      //	fetch employee
      employeeService.get($routeParams.id)
        .then(function(result) {
          self.employee = result.data;
          self.calculatePaycheck();
        });

      //	calculate called when employee detail changes
      this.calculatePaycheck = function() {
				this.paycheck = paycheckCalcService.calculatePaycheck(this.employee);
      };
    }
  ]);
