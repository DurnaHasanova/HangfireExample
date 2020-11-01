using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hangfire.Web.Models;
using Hangfire.Web.BackgroundJobs;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Hangfire.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
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

		public IActionResult SignUp()
		{
			//register ishlemi bu metodda gercekleshir
			// mail adresini de burda gondermek olar
			FireAndForgetJob.ConfirmationEmailJob("1", "test");
			Console.WriteLine("MailSended");

			return View();
		}

		public IActionResult AddImage()
		{
			RecurringJobs.ReportingJob();
			return View();
		}
		[HttpPost]
		
		public async Task<IActionResult> AddImage(IFormFile file)
		{
			string newFileName = string.Empty;

			if(file!=null && file.Length>0)
			{
				newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newFileName);
				using (var stream= new FileStream(path, FileMode.Create))
				{

					await file.CopyToAsync(stream);
				}

				string jobId = Delayedjobs.ApplyWaterMarkJob(newFileName, "www.mysite.com");
				ContinuationsJobs.WaterMarkStatusJob(jobId, newFileName);
			}
			return View();
		}
	
	
	
	}
}
