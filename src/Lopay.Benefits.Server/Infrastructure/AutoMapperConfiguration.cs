using AutoMapper;
using Lopay.Benefits.Server.Controllers.Data;
using Lopay.Benefits.Server.Domain.Entities;

namespace Lopay.Benefits.Server.Infrastructure
{
	/// <summary>
	/// Configures mapping of AutoMapper library (entities to DTOs) 
	/// </summary>
	public static class AutoMapperConfiguration
	{
		public static void CreateMaps()
		{
			Mapper.CreateMap<Employee, EmployeeData>();
			Mapper.CreateMap<EmployeeData, Employee>();
			Mapper.CreateMap<Dependent, DependentData>();
			Mapper.CreateMap<DependentData, Dependent>();
		}
	}
}
