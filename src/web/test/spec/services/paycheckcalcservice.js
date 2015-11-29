'use strict';

describe('Service: paycheckCalcService', function () {
	// load the service's module
	beforeEach(module('benefitApp'));

	// instantiate service
	var paycheckCalcService;
	beforeEach(inject(function (_paycheckCalcService_) {
		paycheckCalcService = _paycheckCalcService_;
	}));

	it('should deduct employee cost', function () {
		var employee = {
			id: 1001,
			first: "Jim",
			last: "Smith",
			taxId: "055-66-9987",
			grossPay: 2000.0,
			dependents: []
		};
		var paycheck = paycheckCalcService.calculatePaycheck(employee);
		expect(paycheck.grossPay).toBe(2000);
		expect(paycheck.employeeCost).toBeCloseTo(38.46);
		expect(paycheck.employeeDiscount).toBe(0);
		expect(paycheck.dependentCost).toBe(0);
		expect(paycheck.dependentDiscount).toBe(0);
		expect(paycheck.netPay).toBeCloseTo(1961.54);
	});

	it('should discount employee cost when first name begins with "A"', function () {
		var employee = {
			id: 1001,
			first: "Adam",
			last: "Smith",
			taxId: "055-66-9987",
			grossPay: 2000.0,
			dependents: []
		};
		var paycheck = paycheckCalcService.calculatePaycheck(employee);
		expect(paycheck.grossPay).toBe(2000);
		expect(paycheck.employeeCost).toBeCloseTo(38.46);
		expect(paycheck.employeeDiscount).toBeCloseTo(3.85);
		expect(paycheck.dependentCost).toBe(0);
		expect(paycheck.dependentDiscount).toBe(0);
		expect(paycheck.netPay).toBeCloseTo(1965.38);
	});

	it('should deduct dependent cost when has dependents', function () {
		var employee = {
			id: 1001,
			first: "Jim",
			last: "Smith",
			taxId: "055-66-9987",
			grossPay: 2000.0,
			dependents: [
				{ first: 'Susan', last: 'Smith' },
				{ first: 'Robert', last: 'Smith' }
			]
		};
		var paycheck = paycheckCalcService.calculatePaycheck(employee);
		expect(paycheck.grossPay).toBe(2000);
		expect(paycheck.employeeCost).toBeCloseTo(38.46);
		expect(paycheck.employeeDiscount).toBe(0);
		expect(paycheck.dependentCost).toBeCloseTo(38.46);
		expect(paycheck.dependentDiscount).toBe(0);
		expect(paycheck.netPay).toBeCloseTo(1923.08);
	});

	it('should discount dependent cost when dependent first begins with "A"', function () {
		var employee = {
			id: 1001,
			first: "Jim",
			last: "Smith",
			taxId: "055-66-9987",
			grossPay: 2000.0,
			dependents: [
				{ first: 'Susan', last: 'Smith' },
				{ first: 'Albert', last: 'Smith' }
			]
		};
		var paycheck = paycheckCalcService.calculatePaycheck(employee);
		expect(paycheck.grossPay).toBe(2000);
		expect(paycheck.employeeCost).toBeCloseTo(38.46);
		expect(paycheck.employeeDiscount).toBe(0);
		expect(paycheck.dependentCost).toBeCloseTo(38.46);
		expect(paycheck.dependentDiscount).toBeCloseTo(1.92);
		expect(paycheck.netPay).toBeCloseTo(1925);
	});
});
