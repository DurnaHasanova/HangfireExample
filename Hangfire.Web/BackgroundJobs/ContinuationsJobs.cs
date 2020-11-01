using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Web.BackgroundJobs
{
	public class ContinuationsJobs
	{

		public static void WaterMarkStatusJob(string id, string fileName)
		{
			Hangfire.BackgroundJob.ContinueJobWith(id, () => Status(fileName));
		}

		public static void Status(string fileName)
		{
			Console.WriteLine($"{fileName} resime watermark eklenmishdir");
		}
	}
}
