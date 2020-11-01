using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Hangfire.Web.Services
{
	public class EmailSenderService : IEmailSenderService
	{
		private readonly IConfiguration configuration;

		public EmailSenderService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task Sender(string userId, string message)
		{
			//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
			//userId ye sahib kullanicini bulub emailini goturmek lazimdir
			var apiKey = configuration.GetSection("APIs")["SendGridApi"];
			Console.WriteLine(apiKey);
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("subaru656@yahoo.com", "Example User");
			var subject = "Hangfire test email";
			var to = new EmailAddress("durna.hasanova@outlook.com", "Example User");
			//var plainTextContent = "and easy to do anywhere, even with C#";
			var htmlContent = "<strong>Your first email from your application</strong>";
			var msg = MailHelper.CreateSingleEmail(from, to, subject,null,  htmlContent);
			 await client.SendEmailAsync(msg);
			Console.WriteLine("Job IShledi");
		}
	}
}
