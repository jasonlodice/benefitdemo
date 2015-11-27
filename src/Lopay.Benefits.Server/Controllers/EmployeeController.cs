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
	[RoutePrefix("api/employee")]
	public class EmployeeController : ApiController
	{
		private readonly IEmployeeRepository _employeeRepository;
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public EmployeeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[Route]
		public IEnumerable<EmployeeData> Get()
		{
			var employees = _employeeRepository.GetAll();
			return employees.Select(Mapper.Map<EmployeeData>);
		}

		[Route("{id}")]
		public EmployeeData Get(int id)
		{
			var employee = _employeeRepository.Get(id);
			return Mapper.Map<EmployeeData>(employee);			
		}

		[Route]
		public EmployeeData Post(EmployeeData data)
		{
			var employee = Mapper.Map<Employee>(data);
			_employeeRepository.Create(employee);
			_employeeRepository.Save();

			return Mapper.Map<EmployeeData>(employee);
		}

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
