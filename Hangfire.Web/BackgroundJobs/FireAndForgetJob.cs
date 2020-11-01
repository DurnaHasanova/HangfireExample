using Hangfire.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Web.BackgroundJobs
{
	public static class FireAndForgetJob
	{

		public static void ConfirmationEmailJob(string userId, string message)
		{
			//Enqueue tek seferlik calishan jobdur

			Hangfire.BackgroundJob.Enqueue<IEmailSenderService>(send => send.Sender(userId, message));

		}
		
		//diger tek seferlik joblarimizida bu klassin icinde yaza bilerik

	}
}
