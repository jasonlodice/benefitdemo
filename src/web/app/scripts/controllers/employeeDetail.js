'use strict';

/**
 * @ngdoc function
 * @name benefitApp.controller:EmpdetailCtrl
 * @description
 * # EmpdetailCtrl
 * Controller of the benefitApp
 */
angular.module('benefitApp')
  .controller('EmployeeDetailCtrl', ['$routeParams', 'employeeService', 'paycheckConfigService',
    function($routeParams, employeeService, paycheckConfigService) {

      //	private fields
      var self = this;
      var perPeriodEmpCost = paycheckConfigService.annualEmpBenefitCost / paycheckConfigService.payPeriods;
      var perPeriodEmpDiscount = perPeriodEmpCost * paycheckConfigService.vipDiscountRate;
      var perPeriodDependentCost = paycheckConfigService.annualDepBenefitCost / paycheckConfigService.payPeriods;
      var perPeriodDependentDiscount = perPeriodDependentCost * paycheckConfigService.vipDiscountRate;

      //	public fields
      this.payPeriods = paycheckConfigService.payPeriods;
      this.employeeCost = perPeriodEmpCost;

      //	fetch employee
      employeeService.get($routeParams.id)
        .then(function(result) {
          self.employee = result.data;
          self.calculatePaycheck();
        });

      //	determine if employee or dependent qualifies for discount
      var qualifiesForVipDiscount = function(person) {
        return person.first && person.first.length > 0 && person.first[0] === 'A';
      }

      //	calculate called when employee detail changes
      this.calculatePaycheck = function() {
        this.grossPay = this.employee.grossPay;
        this.employeeDiscount = qualifiesForVipDiscount(this.employee) ? perPeriodEmpDiscount : 0;
        this.dependentCost = this.employee.dependents.length * perPeriodDependentCost;

				//	count vip dependents
        var vipDependents = 0;
        angular.forEach(this.employee.dependents, function(dep) {
          if (qualifiesForVipDiscount(dep)) {
            vipDependents++;
          }
        });

        this.dependentDiscount = vipDependents * perPeriodDependentDiscount;
      };
    }
  ]);
