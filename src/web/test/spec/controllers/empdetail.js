'use strict';

describe('Controller: EmpdetailCtrl', function () {

  // load the controller's module
  beforeEach(module('benefitApp'));

  var EmpdetailCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    EmpdetailCtrl = $controller('EmpdetailCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(EmpdetailCtrl.awesomeThings.length).toBe(3);
  });
});
