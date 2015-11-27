using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Lopay.Benefits.Server.Controllers.Data;
using NLog;

namespace Lopay.Benefits.Server.Controllers
{
	[RoutePrefix("api/employee")]
	public class EmployeeController : ApiController
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public EmployeeController()
		{
		}

		[Route("{id}")]
		public EmployeeData Get(int id)
		{
			return new EmployeeData
			{
				Id = 123456,
				First = "Roger",
				Last = "Smith",
				TaxId = "1234554"
			};
		}
	}
}
