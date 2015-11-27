'use strict';

describe('Service: paycheckCalcService', function () {

  // load the service's module
  beforeEach(module('benefitApp'));

  // instantiate service
  var paycheckCalcService;
  beforeEach(inject(function (_paycheckCalcService_) {
    paycheckCalcService = _paycheckCalcService_;
  }));

  it('should do something', function () {
    expect(!!paycheckCalcService).toBe(true);
  });

});
