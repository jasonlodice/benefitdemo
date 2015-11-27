using Lopay.Benefits.Server.Domain.Entities;

namespace Lopay.Benefits.Server.Controllers.Data
{
	public class DependentData
	{
		/// <summary>
		/// Dependent First Name
		/// </summary>
		public string First { get; set; }

		/// <summary>
		///	Depdendent Last Name
		/// </summary>
		public string Last { get; set; }

		/// <summary>
		/// Dependent Type
		/// </summary>
		public DependentType DependentType { get; set; }
	}
}