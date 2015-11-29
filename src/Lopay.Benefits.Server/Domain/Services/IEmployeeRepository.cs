using System.Collections.Generic;
using Lopay.Benefits.Server.Domain.Entities;

namespace Lopay.Benefits.Server.Domain.Services
{
	/// <summary>
	/// Service for interacting with Employee Entities
	/// </summary>
	public interface IEmployeeRepository
	{
		/// <summary>
		/// Get Employee entity by Id
		/// </summary>
		/// <param name="id">Employee entity id</param>
		/// <returns></returns>
		Employee Get(int id);

		/// <summary>
		/// Get all Employee entities
		/// </summary>
		/// <returns></returns>
		IEnumerable<Employee> GetAll();

		/// <summary>
		/// Add a new employee entity
		/// </summary>
		/// <param name="employee"></param>
		void Create(Employee employee);
		
		/// <summary>
		/// Persist changes in the repository
		/// </summary>
		void Save();
	}
}