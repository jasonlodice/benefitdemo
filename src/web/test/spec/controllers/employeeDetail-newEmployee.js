'use strict';

describe('Controller: EmployeeDetailCtrl - new employee route', function() {

  // load the controller's module
  beforeEach(module('benefitApp'));

	var ctrl,
		routeParams = {
			id: 'new'
		};

	// Initialize the controller
	beforeEach(inject(function($controller, employeeService, $location, paycheckCalcService) {
		//	no need to delay ctrl instantiation, so create for every spec
		ctrl = $controller('EmployeeDetailCtrl', {
			$routeParams: routeParams,
			$location: $location,
			employeeService: employeeService,
			paycheckCalcService: paycheckCalcService
		});
	}));

  it('should initialize a default employee', function() {
    expect(ctrl.employee.id).not.toBeDefined();
  });

	it('should default newDependent', function() {
    expect(ctrl.newDependent).toEqual({});
  });

	it('should not be editingDependent', function() {
    expect(ctrl.editingDependent).toBe(false);
  });
});
