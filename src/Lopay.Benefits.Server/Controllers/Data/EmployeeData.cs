using Lopay.Benefits.Server.Domain.Entities;

namespace Lopay.Benefits.Server.Controllers.Data
{
	/// <summary>
	/// DTO representing Employee
	/// </summary>
	public class EmployeeData
	{
		/// <summary>
		/// Employee database ID
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Employee Tax ID
		/// </summary>
		public string TaxId { get; set; }

		/// <summary>
		/// Employee First Name
		/// </summary>
		public string First { get; set; }

		/// <summary>
		/// Employee Last Name
		/// </summary>
		public string Last { get; set; }

		/// <summary>
		/// Gross Pay per pay period
		/// </summary>
		public double GrossPay { get; set; }

		/// <summary>
		/// Employee Dependents
		/// </summary>
		public Dependent[] Dependents { get; set; }
	}
}
