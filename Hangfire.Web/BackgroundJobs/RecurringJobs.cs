using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Web.BackgroundJobs
{
	public class RecurringJobs
	{
		//If we want to do something daily monthly weekly or something else

		public static void ReportingJob()
		{
			Hangfire.RecurringJob.AddOrUpdate("reportJob1", ()=> EmailReport(),Cron.Minutely);
		}

		public static void EmailReport()
		{
			Debug.WriteLine("Report has been sent as e-mail");
		}
	}
}
