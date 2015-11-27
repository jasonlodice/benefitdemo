// ////////////////////////////////////////////////////////////////////////////
// Carestream Health RESTRICTED INFORMATION - for internal use only
// ////////////////////////////////////////////////////////////////////////////
// 
// File:	NLogExceptionLogger.cs
// Author:	Jason  LODICE
// Date:	2015.03.17
// 
// Copyright 2015, Carestream Health, All Rights Reserved.
// 
// ////////////////////////////////////////////////////////////////////////////

using System;
using System.Net.Http;
using System.Text;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace Lopay.Benefits.Server.Infrastructure
{
	/// <summary>
	/// Logs exceptions originating in the Web API framework
	/// </summary>
	public class NLogExceptionLogger : ExceptionLogger
	{
		/// <summary>
		/// When overridden in a derived class, logs the exception synchronously.
		/// </summary>
		/// <param name="context">The exception logger context.</param>
		public override void Log(ExceptionLoggerContext context)
		{
			Logger logger = null;
			if (context.ExceptionContext.ControllerContext != null)
			{
				logger = LogManager.GetLogger(context.ExceptionContext.ControllerContext.Controller.GetType().FullName);
			}
			else
			{
				logger = LogManager.GetCurrentClassLogger();
			}

			var message = String.Format("Exception processing request {0}", RequestToString(context.Request));
			logger.Error(context.Exception, message);
		}

		private static string RequestToString(HttpRequestMessage request)
		{
			var message = new StringBuilder();
			if (request.Method != null)
				message.Append(request.Method);

			if (request.RequestUri != null)
				message.Append(" ").Append(request.RequestUri);

			return message.ToString();
		}
	}
}