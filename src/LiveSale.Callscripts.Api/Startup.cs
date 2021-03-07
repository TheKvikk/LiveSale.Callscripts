using System.Net;
using System.Text.Json;
using LiveSale.Callscripts.Api.Converters;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LiveSale.Callscripts.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<ForwardedHeadersOptions>(options => options.KnownProxies.Add(IPAddress.Parse("10.10.1.1")));

			services.AddRouting(options => options.LowercaseUrls = true);
			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
				options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
				options.JsonSerializerOptions.Converters.Add(new WidgetDtoConverter());
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new()
				{
					Title = "LiveSale.Callscripts.Api",
					Version = "v1",
					Contact = new()
						{Name = "Martin Obadal", Email = "martin.obadal@livesale.cz"}
				});
			});

			services.AddMediatR(typeof(Startup));
			services.AddAutoMapper(typeof(Startup));

			services.AddSingleton<LeadRepository>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiveSale.Callscripts.Api v1"));
			}

			app.UseForwardedHeaders(new()
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
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