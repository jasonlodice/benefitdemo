'use strict';

describe('Service: employeeService', function () {

  // load the service's module
  beforeEach(module('benefitApp'));

  // instantiate service
  var employeeService;
  beforeEach(inject(function (_employeeService_) {
    employeeService = _employeeService_;
  }));

  it('should do something', function () {
    expect(!!employeeService).toBe(true);
  });

});
