using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swagger.Models;
using Swashbuckle.Swagger;

namespace Swagger
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<ProductShopDbContext>(op => op.UseSqlServer(Configuration.GetConnectionString("Default")));
			services.AddSwaggerGen(gen=> {
				gen.SwaggerDoc("productV1", new OpenApiInfo
				{
					Version = "V1",
					Title = "Product documentation",
					Description = "Crud of Products",
					Contact = new OpenApiContact { Name = "Durna hasanova", Email="test"}
				});
				var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
				gen.IncludeXmlComments(xmlPath);// xml dokumentin pathi veririk
			});
			
		
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseSwagger();

			//UI goruntusu olmagi ucun
			app.UseSwaggerUI(opt=>
			{
				opt.SwaggerEndpoint("/swagger/productV1/swagger.json", "Product API");
			});
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
