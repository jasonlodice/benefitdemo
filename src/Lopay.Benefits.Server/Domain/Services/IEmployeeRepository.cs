using System.Collections;
using System.Collections.Generic;
using Lopay.Benefits.Server.Domain.Entities;

namespace Lopay.Benefits.Server.Domain.Services
{
	public interface IEmployeeRepository
	{
		Employee Get(int id);

		IEnumerable<Employee> GetAll();
		void Create(Employee employee);
		void Save();
	}
}