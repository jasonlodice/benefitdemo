'use strict';

/**
 * @ngdoc overview
 * @name benefitApp
 * @description
 * # benefitApp
 *
 * Main module of the application.
 */
angular
  .module('benefitApp', [
    'ngAnimate',
    'ngResource',
    'ngRoute',
    'ngSanitize',
		'ngMessages'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/employee/list.html',
        controller: 'EmployeeListCtrl',
        controllerAs: 'ctrl'
      })
			.when('/employee/:id', {
				templateUrl: 'views/employee/detail.html',
				controller: 'EmployeeDetailCtrl',
				controllerAs: 'ctrl'
			})
      .when('/reports', {
        templateUrl: 'views/reports.html',
        controller: 'ReportCtrl',
        controllerAs: 'ctrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
