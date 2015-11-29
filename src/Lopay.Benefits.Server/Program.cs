using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Lopay.Benefits.Server.Infrastructure;
using Microsoft.Owin.Hosting;

namespace Lopay.Benefits.Server
{
	class Program
	{
		private static IWindsorContainer _container;

		static void Main(string[] args)
		{
			//	initialize container
			_container = new WindsorContainer();
			_container.Install(FromAssembly.This());
			WindsorHttpControllerActivator.Container = _container;

			//	initialize auto mapper
			AutoMapperConfiguration.CreateMaps();

			//	start the server
			WebApp.Start("http://+:80/lopay");

			Console.WriteLine("Web API server started...");

			//	keep server running
			Console.ReadLine();
		}
	}
}
