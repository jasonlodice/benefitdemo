'use strict';

/**
 * @ngdoc function
 * @name benefitApp.controller:EmployeeDetailCtrl
 * @description
 * # EmployeeDetailCtrl
 * Controller of the benefitApp
 */
angular.module('benefitApp')
  .controller('EmployeeDetailCtrl', ['$routeParams', '$location', 'employeeService', 'paycheckCalcService',
    function($routeParams, $location, employeeService, paycheckCalcService) {
      //	private fields
      var self = this;

      //	public fields
      this.newDependent = {};
      this.editingDependent = false;

      //	recalculate the paycheck
      this.calculatePaycheck = function() {
        this.paycheck = paycheckCalcService.calculatePaycheck(this.employee);
      };

			//	save a depdendent
      this.saveDependent = function() {
        //	save value
        this.employee.dependents.push(this.newDependent);
        this.save();
        this.cancelDependent();
      };

			//	delete a depdendent
      this.deleteDependent = function(dependent) {
        var index = this.employee.dependents.indexOf(dependent);
        if (index > -1) {
          this.employee.dependents.splice(index, 1);
        }
        this.save();
      };

			//	save the employee and dependents
      this.save = function() {
        if (this.employee.id) {
					//	this is saving an existing employee
					employeeService.update(this.employee.id, this.employee)
            .then(function(result) {
              self.employee = result.data;
              self.calculatePaycheck();
            });
        } else {
					//	this is a first time save
          employeeService.create(this.employee)
            .then(function(result) {
							//	reload the page with new id
              $location.path('/employee/' + result.data.id);
            });
        }
      };

			//	begin editing a dependent
      this.startNewDependent = function() {
        this.editingDependent = true;
      };

			//	finish editing a dependent
      this.cancelDependent = function() {
        //	reset the model
        this.newDependent = {};
        this.editingDependent = false;
      };

      //	initialize data
      if ($routeParams.id === 'new') {
				//	if new, get default values for form
        this.employee = employeeService.newDefault();
        this.calculatePaycheck();
      } else {
				//	fetch existing employee
        employeeService.get($routeParams.id)
          .then(function(result) {
            self.employee = result.data;
            self.calculatePaycheck();
          });
      }
  }]);
