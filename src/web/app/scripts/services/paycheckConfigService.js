'use strict';

/**
 * @ngdoc service
 * @name benefitApp.paycheckConfig
 * @description
 * # paycheckConfig
 * Service in the benefitApp.
 */
angular.module('benefitApp')
  .service('paycheckConfigService', function () {
  	//	these values may be been fetched from an API endpoint
  	this.payPeriods = 26;
  	this.annualEmpBenefitCost = 1000;
  	this.annualDepBenefitCost = 500;
  	this.vipDiscountRate = 0.1;
  });
