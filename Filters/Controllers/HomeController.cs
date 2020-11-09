using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Filters.Models;
using Filters.Filters;

namespace Filters.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		//[CustomHandleExceptionFilter(ErrorPage ="Error1")]
		public IActionResult Index()
		{
			//int a = 2, b = 0;
			//int c = a / b;
			return View();
		}
		//[CustomHandleExceptionFilter(ErrorPage = "Error2")]
		public IActionResult Privacy()
		{
			 int a = 2, b = 0;
			int c = a / b;
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Error1()
		{
			
			return View();
		}
		public IActionResult Error2()
		{
			return View();
		}
	}
}
