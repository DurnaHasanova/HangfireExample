using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Web.BackgroundJobs
{
	public static class Delayedjobs
	{
		public static string ApplyWaterMarkJob(string filename, string text)
		{

			var id= BackgroundJob.Schedule(() =>  ApplyWatermark(filename, text), TimeSpan.FromSeconds(30));
			return id;
		}

		public static void ApplyWatermark(string filename, string watermarktext)
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);
			//bitmaplarla calishmaq system drawing common paketini yuklemek lazimdir
			using (var bitmap = Bitmap.FromFile(path))
			{
				// bow cercivede eni uzunluq teyin edirik
				using (var temp=new Bitmap(bitmap.Width, bitmap.Height))
				{

					// burda grafik olushturuyoruz
					using (var gpr = Graphics.FromImage(temp))
					{
						gpr.DrawImage(bitmap,0,0);
						var font =new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
						var color = Color.Red;
						var brush = new SolidBrush(color);
						var point = new Point(25, bitmap.Height-50);
						gpr.DrawString(watermarktext, font, brush, point);
						temp.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/watermarks", filename));
					}
				}
			}
		}
	}
}
