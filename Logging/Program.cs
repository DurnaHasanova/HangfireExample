using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Logging
{
	public class Program
	{
		public static void Main(string[] args)
		{
			
			var host=CreateHostBuilder(args).Build();

			//var logger = host.Services.GetRequiredService<ILogger<Program>>();
			//logger.LogInformation("Program is starting..........................................");
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>().ConfigureLogging(log=> {
						log.ClearProviders();
						//log.AddConsole();
						// deactivate of Logging Providers
					}).UseNLog();
				});
	}
}
