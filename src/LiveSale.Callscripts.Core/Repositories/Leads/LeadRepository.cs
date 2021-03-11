using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using LanguageExt;
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

		public async Task<Option<Lead>> GetLeadByIdAsync(string id)
		{
			var json = await File.ReadAllTextAsync(Path.Combine(_environment.WebRootPath, "TestData/test.json"));

			try
			{
				var lead = JsonSerializer.Deserialize<Lead>(json, _serializerOptions);
				return Option<Lead>.Some(lead);
			}
			catch
			{
				return Option<Lead>.None;
			}
		}

		public Lead Update(Lead lead)
		{
			var json = JsonSerializer.Serialize(lead, _serializerOptions);
			File.WriteAllText(Path.Combine(_environment.WebRootPath, "TestData/test_for_write_only.json"), json);

			return lead;
		}

		public async Task<Lead> InsertLeadAsync(Lead lead)
		{
			return await Task.FromResult(new Lead
			{
				Id = "testId"
			});
		}
	}
}