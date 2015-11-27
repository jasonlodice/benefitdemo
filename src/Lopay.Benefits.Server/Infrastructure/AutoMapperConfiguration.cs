using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lopay.Benefits.Server.Controllers.Data;
using Lopay.Benefits.Server.Domain.Entities;

namespace Lopay.Benefits.Server.Infrastructure
{
	public static class AutoMapperConfiguration
	{
		public static void CreateMaps()
		{
			Mapper.CreateMap<Employee, EmployeeData>();
		}
	}
}
