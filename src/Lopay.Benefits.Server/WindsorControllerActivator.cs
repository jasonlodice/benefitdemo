using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopay.Benefits.Server
{	
	using System;
	using System.Net.Http;
	using System.Web.Http.Controllers;
	using System.Web.Http.Dispatcher;
	using Castle.Windsor;

	namespace Csh.Xrs.Web.Infrastructure.WebApi
	{
		/// <summary>
		/// http://blog.ploeh.dk/2012/10/03/DependencyInjectioninASP.NETWebAPIwithCastleWindsor/
		/// </summary>
		public class WindsorHttpControllerActivator : IHttpControllerActivator
		{
			private readonly IWindsorContainer container;

			/// <summary>
			/// </summary>
			/// <param name="container"></param>
			public WindsorHttpControllerActivator(IWindsorContainer container)
			{
				this.container = container;
			}

			/// <summary>
			/// Creates an <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
			/// </summary>
			/// <returns>
			/// An <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
			/// </returns>
			/// <param name="request">The message request.</param>
			/// <param name="controllerDescriptor">The HTTP controller descriptor.</param>
			/// <param name="controllerType">The type of the controller.</param>
			public IHttpController Create(
				HttpRequestMessage request,
				HttpControllerDescriptor controllerDescriptor,
				Type controllerType)
			{
				var controller =
					(IHttpController)container.Resolve(controllerType);

				request.RegisterForDispose(
					new Release(
						() => container.Release(controller)));

				return controller;
			}

			private class Release : IDisposable
			{
				private readonly Action release;

				public Release(Action release)
				{
					this.release = release;
				}

				public void Dispose()
				{
					release();
				}
			}
		}
	}
}
