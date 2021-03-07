using System.Net;
using System.Text.Json;
using LiveSale.Callscripts.Api.Commands.Leads;
using LiveSale.Callscripts.Api.Converters;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;

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
				options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
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

				c.MapType<UpdateLeadsWidgetAnswerCommand>(() => new()
				{
					Type = "string",
					Example = new OpenApiString(
						"{\n  \"leadId\": \"602a5c68170dfa40b173822a\",\n  \"pageId\": \"60453c4ab5c8894f0493b5e7\",\n  \"widgetId\": \"5fc8ad9c58101c52b9dff004\",\n  \"extra\": \"{\\\"value\\\":{\\\"parts\\\":[\\\"Domácnosti\\\",\\\"Firmy\\\"],\\\"values\\\":[50,50],\\\"id\\\":null,\\\"order\\\":1},\\\"answer\\\":{\\\"parts\\\":[\\\"Domácnosti\\\",\\\"Firmy\\\"],\\\"values\\\":[20,70],\\\"id\\\":null,\\\"order\\\":1}}\"\n}")
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