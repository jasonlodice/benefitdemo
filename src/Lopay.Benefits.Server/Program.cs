using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Lopay.Benefits.Server.Infrastructure;
using Microsoft.Owin.Hosting;
using NLog;

namespace Lopay.Benefits.Server
{
	class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		private static IWindsorContainer container;

		static void Main(string[] args)
		{
			//	initialize container
			container = new WindsorContainer();
			container.Install(FromAssembly.This());
			WindsorHttpControllerActivator.Container = container;

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
