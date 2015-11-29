using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Lopay.Benefits.Server.Controllers.Data;
using Lopay.Benefits.Server.Domain.Entities;
using Lopay.Benefits.Server.Domain.Services;
using NLog;

namespace Lopay.Benefits.Server.Controllers
{
	/// <summary>
	/// Web API controller for Employee data
	/// </summary>
	[RoutePrefix("api/employee")]
	public class EmployeeController : ApiController
	{
		private readonly IEmployeeRepository _employeeRepository;
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="employeeRepository">service for fetching employee entities</param>
		public EmployeeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		/// <summary>
		/// Get all employees
		/// </summary>
		/// <returns></returns>
		[Route]
		public IEnumerable<EmployeeData> Get()
		{
			var employees = _employeeRepository.GetAll();
			return employees.Select(Mapper.Map<EmployeeData>);
		}

		/// <summary>
		/// Get a single employee by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("{id}")]
		public EmployeeData Get(int id)
		{
			var employee = _employeeRepository.Get(id);
			return Mapper.Map<EmployeeData>(employee);			
		}

		/// <summary>
		/// Save a new employee
		/// </summary>
		/// <param name="data">Employee data to save</param>
		/// <returns></returns>
		[Route]
		public EmployeeData Post(EmployeeData data)
		{
			var employee = Mapper.Map<Employee>(data);
			_employeeRepository.Create(employee);
			_employeeRepository.Save();

			return Mapper.Map<EmployeeData>(employee);
		}

		/// <summary>
		/// Update an existing employee
		/// </summary>
		/// <param name="id">Id of Employee to update</param>
		/// <param name="data">Employee data to update</param>
		/// <returns></returns>
		[Route("{id}")]
		public EmployeeData Put(int id, [FromBody]EmployeeData data)
		{
			var employee = _employeeRepository.Get(id);
			Mapper.Map(data, employee);
			_employeeRepository.Save();

			return Mapper.Map<EmployeeData>(employee);
		}
	}
}
