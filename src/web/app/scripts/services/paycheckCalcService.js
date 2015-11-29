'use strict';

/**
 * @ngdoc service
 * @name benefitApp.paycheckCalcService
 * @description
 * # paycheckCalcService
 * Service in the benefitApp.
 */
angular.module('benefitApp')
  .service('paycheckCalcService', ['paycheckConfigService', function (paycheckConfigService) {
  	var perPeriodEmpCost = paycheckConfigService.annualEmpBenefitCost / paycheckConfigService.payPeriods;
  	var perPeriodEmpDiscount = perPeriodEmpCost * paycheckConfigService.vipDiscountRate;
  	var perPeriodDependentCost = paycheckConfigService.annualDepBenefitCost / paycheckConfigService.payPeriods;
  	var perPeriodDependentDiscount = perPeriodDependentCost * paycheckConfigService.vipDiscountRate;

  	//	determine if employee or dependent qualifies for discount
  	var qualifiesForVipDiscount = function (person) {
  		return person.first && person.first.length > 0 && person.first[0] === 'A';
  	};

  	//	calculate called when employee detail changes
  	this.calculatePaycheck = function (employee) {
  		var paycheck = {};

  		//	count vip dependents
  		var vipDependents = 0;
  		angular.forEach(employee.dependents, function (dep) {
  			vipDependents += qualifiesForVipDiscount(dep) ? 1 : 0;
  		});

  		paycheck.payPeriods = paycheckConfigService.payPeriods;
  		paycheck.grossPay = employee.grossPay || 0;
  		paycheck.employeeCost = perPeriodEmpCost;
  		paycheck.employeeDiscount = qualifiesForVipDiscount(employee) ? perPeriodEmpDiscount : 0;
  		paycheck.dependentCost = employee.dependents ? employee.dependents.length * perPeriodDependentCost : 0;
  		paycheck.dependentDiscount = vipDependents * perPeriodDependentDiscount;
  		paycheck.netPay = paycheck.grossPay - paycheck.employeeCost + paycheck.employeeDiscount - paycheck.dependentCost + paycheck.dependentDiscount;
  		return paycheck;
  	};
  }]);
