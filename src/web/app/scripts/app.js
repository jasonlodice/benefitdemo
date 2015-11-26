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
    'ngSanitize'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/employees.html',
        controller: 'EmployeeCtrl',
        controllerAs: 'ctrl'
      })
      .when('/about', {
        templateUrl: 'views/reports.html',
        controller: 'ReportCtrl',
        controllerAs: 'ctrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
