using System.IO;
using System.Text.Json;
using LiveSale.Callscripts.Core.Converters;
using LiveSale.Callscripts.Core.Models.Leads;
using Microsoft.AspNetCore.Hosting;

namespace LiveSale.Callscripts.Core.Repositories.Leads
{
	public class LeadRepository
	{
		private static readonly JsonSerializerOptions _serializerOptions = new()
			{PropertyNameCaseInsensitive = true, WriteIndented = true, Converters = {new WidgetConverter()}};

		private readonly IWebHostEnvironment _environment;

		public LeadRepository(IWebHostEnvironment environment)
		{
			_environment = environment;
		}

		public Lead GetLeadById(string id)
		{
			var json = File.ReadAllText(Path.Combine(_environment.WebRootPath, "TestData/test.json"));

			return JsonSerializer.Deserialize<Lead>(json, _serializerOptions);
		}
		
		public Lead Update(Lead lead)
		{
			var json = JsonSerializer.Serialize(lead, _serializerOptions);
			File.WriteAllText(Path.Combine(_environment.WebRootPath, "TestData/test_for_write_only.json"), json);

			return lead;
		}
	}
}