'use strict';

describe('Controller: EmployeeDetailCtrl - existing employee route', function () {

	// load the controller's module
	beforeEach(module('benefitApp'));

	var createController, $httpBackend, employeeGetHandler,
	  baseUrl = 'http://localhost/lopay/api/employee/',
	  routeParams = {
	  	id: 1001
	  },
	  empSmith = {
	  	id: 1001,
	  	first: "Jim",
	  	last: "Smith",
	  	taxId: "055-66-9987",
	  	grossPay: 2000.0,
	  	dependents: []
	  };

	// Initialize the controller
	beforeEach(inject(function ($controller, _$httpBackend_, employeeService, $location, paycheckCalcService) {
		// Set up the mock http service responses
		$httpBackend = _$httpBackend_;

		// backend definition common for all tests
		employeeGetHandler = $httpBackend.whenGET(baseUrl + '1001')
		  .respond(empSmith);

		//	instantiate controller
		createController = function () {
			return $controller('EmployeeDetailCtrl', {
				$routeParams: routeParams,
				$location: $location,
				employeeService: employeeService,
				paycheckCalcService: paycheckCalcService
			});
		};
	}));

	afterEach(function () {
		$httpBackend.verifyNoOutstandingExpectation();
		$httpBackend.verifyNoOutstandingRequest();
	});

	it('should query for existing employee using routeParams', function () {
		$httpBackend.expectGET(baseUrl + '1001');
		var ctrl = createController();
		$httpBackend.flush();
	});

	it('should set employee after load', function () {
		var ctrl = createController();
		$httpBackend.flush();
		expect(ctrl.employee)
		  .toEqual(empSmith);
	});

	it('should calculatePaycheck after load', function () {
		var ctrl = createController();
		$httpBackend.flush();
		expect(ctrl.paycheck.netPay)
		  .toBeCloseTo(1961.54);
	});

	it('should default newDependent', function () {
		var ctrl = createController();
		$httpBackend.flush();
		expect(ctrl.newDependent)
		  .toEqual({});
	});

	it('should not be editingDependent', function () {
		var ctrl = createController();
		$httpBackend.flush();
		expect(ctrl.editingDependent)
		  .toBe(false);
	});

	//	additional tests for saveDependent, deleteDepdent,
	//	cancelDependent startNewDependent, save
});
