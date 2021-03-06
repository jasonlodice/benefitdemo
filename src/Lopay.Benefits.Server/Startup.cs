﻿using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using Lopay.Benefits.Server.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Lopay.Benefits.Server
{
	/// <summary>
	/// OWIN configuration
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Called configure OWIN application
		/// </summary>
		/// <param name="appBuilder"></param>
		public void Configuration(IAppBuilder appBuilder)
		{
			//	server web api from 
			appBuilder.UseWebApi(BuildHttpConfiguration());
		}

		private static HttpConfiguration BuildHttpConfiguration()
		{			
			var configuration = new HttpConfiguration();

			// configure JSON serialization
			var serializerSettings = configuration.Formatters.JsonFormatter.SerializerSettings;
			serializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
			serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
#if DEBUG
			serializerSettings.Formatting = Formatting.Indented;
#endif
			serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			serializerSettings.Converters.Add(new StringEnumConverter());

			//	enable cors since web server is different port than api server
			var cors = new EnableCorsAttribute("*", "*", "*");
			configuration.EnableCors(cors);

			//	use attribute routing
			configuration.MapHttpAttributeRoutes();

			//	custom factory for web api controllers
			configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator());

			// Global Exception Logger (log exceptions to NLog)
			configuration.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());

			return configuration;
		}
	}
}