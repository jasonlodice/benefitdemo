'use strict';

/**
 * @ngdoc function
 * @name benefitApp.controller:EmpdetailCtrl
 * @description
 * # EmpdetailCtrl
 * Controller of the benefitApp
 */
angular.module('benefitApp')
  .controller('EmployeeDetailCtrl', ['$routeParams', 'employeeService',
    function($routeParams, employeeService) {
      var self = this;
      employeeService.get($routeParams.id).then(function(result) {
        self.employee = result.data;
      });
    }
  ]);
