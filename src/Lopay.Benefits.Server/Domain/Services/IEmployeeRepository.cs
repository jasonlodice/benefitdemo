using Lopay.Benefits.Server.Domain.Entities;

namespace Lopay.Benefits.Server.Domain.Services
{
	public interface IEmployeeRepository
	{
		Employee Get(int id);
	}
}