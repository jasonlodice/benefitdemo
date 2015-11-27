using System.Collections;
using System.Collections.Generic;

namespace Lopay.Benefits.Server.Domain.Entities
{
	/// <summary>
	/// Employee entity
	/// </summary>
	public class Employee
	{
		private IList<Dependent> _dependents;

		/// <summary>
		/// Employee database ID
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Employee First Name
		/// </summary>
		public string First { get; set; }

		/// <summary>
		/// Employee Last Name
		/// </summary>
		public string Last { get; set; }

		/// <summary>
		/// Employee Tax ID
		/// </summary>
		public string TaxId { get; set; }

		/// <summary>
		/// Gross Pay per pay period
		/// </summary>
		public double GrossPay { get; set; }

		public IList<Dependent> Dependents
		{
			get { return _dependents ?? (_dependents = new List<Dependent>()); }
			set { _dependents = value; }
		}
	}
}