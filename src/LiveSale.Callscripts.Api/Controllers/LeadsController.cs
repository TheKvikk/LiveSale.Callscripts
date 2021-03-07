using System.Threading.Tasks;
using LiveSale.Callscripts.Api.Commands.Leads;
using LiveSale.Callscripts.Api.Queries.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LeadsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeadsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetLead(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return BadRequest();
			}

			var query = new GetLeadQuery(id);
			var response = await _mediator.Send(query);
			if (response == null)
			{
				return NotFound();
			}

			return Ok(response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateLead(string id, [FromBody] UpdateLeadsWidgetAnswerCommand command)
		{
			if (string.IsNullOrEmpty(id) ||
			    string.IsNullOrEmpty(command.PageId) ||
			    string.IsNullOrEmpty(command.WidgetId) ||
			    string.IsNullOrEmpty(command.Extra))
			{
				return BadRequest();
			}

			command.LeadId = id;
			await _mediator.Publish(command);

			return Ok();
		}
	}
}