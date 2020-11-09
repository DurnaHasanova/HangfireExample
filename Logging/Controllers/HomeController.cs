using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Logging.Models;

namespace Logging.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		//private readonly ILoggerFactory _loggerFactory;

		//public HomeController(ILoggerFactory loggerFactory)
		//{
		//	_loggerFactory = loggerFactory;
		//}

		public IActionResult Index()
		{
			//var _logger=_loggerFactory.CreateLogger("HomeClass");

			
			_logger.LogInformation("Using of index Page");

			try
			{
				int a = 2, b = 0;
				int c = a / b;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
			}
			
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
