'use strict';

describe('Service: paycheckConfig', function () {

  // load the service's module
  beforeEach(module('benefitApp'));

  // instantiate service
  var paycheckConfig;
  beforeEach(inject(function (_paycheckConfig_) {
    paycheckConfig = _paycheckConfig_;
  }));

  it('should do something', function () {
    expect(!!paycheckConfig).toBe(true);
  });

});
