using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Lopay.Benefits.Server.Controllers.Data;
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

		[Route("{id}")]
		public EmployeeData Get(int id)
		{
			var employee = _employeeRepository.Get(id);
			return Mapper.Map<EmployeeData>(employee);			
		}
	}
}
