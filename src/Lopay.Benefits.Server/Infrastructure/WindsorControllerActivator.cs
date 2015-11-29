using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace Lopay.Benefits.Server.Infrastructure
{
	/// <summary>
	/// http://blog.ploeh.dk/2012/10/03/DependencyInjectioninASP.NETWebAPIwithCastleWindsor/
	/// </summary>
	public class WindsorHttpControllerActivator : IHttpControllerActivator
	{
		public static IWindsorContainer Container { get; set; }

		/// <summary>
		/// Creates an <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
		/// </returns>
		/// <param name="request">The message request.</param>
		/// <param name="controllerDescriptor">The HTTP controller descriptor.</param>
		/// <param name="controllerType">The type of the controller.</param>
		public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
		{
			var controller =
				(IHttpController)Container.Resolve(controllerType);

			request.RegisterForDispose(
				new Release(
					() => Container.Release(controller)));

			return controller;
		}

		private class Release : IDisposable
		{
			private readonly Action _release;

			public Release(Action release)
			{
				_release = release;
			}

			public void Dispose()
			{
				_release();
			}
		}
	}
}
