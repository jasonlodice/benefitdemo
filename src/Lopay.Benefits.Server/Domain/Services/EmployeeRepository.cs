using Lopay.Benefits.Server.Domain.Entities;

namespace Lopay.Benefits.Server.Domain.Services
{
	public class EmployeeRepository : IEmployeeRepository
	{
		public Employee Get(int id)
		{
			return new Employee
			{
				Id = 123456,
				First = "Roger",
				Last = "Smith",
				TaxId = "1234554"
			};
		}
	}
}