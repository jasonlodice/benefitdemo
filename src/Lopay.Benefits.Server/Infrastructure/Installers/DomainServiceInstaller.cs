using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lopay.Benefits.Server.Domain.Services;

namespace Lopay.Benefits.Server.Infrastructure.Installers
{
	public class DomainServiceInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			//	register all domain services into the container
			container.Register(Classes.FromThisAssembly()
				.InSameNamespaceAs<IEmployeeRepository>()
				.WithServiceFirstInterface()
				.LifestyleSingleton());
		}
	}
}