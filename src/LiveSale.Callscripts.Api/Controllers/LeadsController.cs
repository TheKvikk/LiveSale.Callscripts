using System;
using System.Threading.Tasks;
using AutoMapper;
using LiveSale.Callscripts.Api.Commands;
using LiveSale.Callscripts.Api.Dtos.Requests;
using LiveSale.Callscripts.Api.Problems;
using LiveSale.Callscripts.Api.Queries.Leads;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LeadsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public LeadsController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> InsertLead(InsertLeadDto dto)
		{
			if (!ModelState.IsValid)
			{
				return ValidationProblem();
			}
			
			var command = _mapper.Map<InsertLeadCommand>(dto);
			var response = await _mediator.Send(command);

			return Created(new Uri($"https://lscall.cz/{response.Id}"), response);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetLead(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return BadRequest();
			}

			var query = new GetLeadQuery(id);
			var response = await _mediator.Send(query);

			return response.Match<IActionResult>(Ok, NotFound);
		}

		[HttpPatch("{id}/answer")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateLeadsWidgetAnwser(string id,
			UpdateLeadsWidgetAnswerDto dto)
		{
			if (!ModelState.IsValid)
			{
				return ValidationProblem();
			}

			if (id != dto.LeadId)
			{
				return BadRequest(new MismatchedIdProblemDetails(nameof(dto.LeadId))
				{
					Id = id,
					MismatchedId = dto.LeadId
				});
			}

			var query = new GetLeadQuery(id);
			var response = await _mediator.Send(query);

			if (response.IsNone)
			{
				return NotFound();
			}

			var command = _mapper.Map<UpdateLeadsWidgetAnswerCommand>(dto);
			var updateResponse = await _mediator.Send(command);

			return updateResponse.Match<IActionResult>(_ => NoContent(), BadRequest);
		}

		[HttpPatch("{id}/state")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateLeadsState(string id, UpdateLeadsStateDto dto)
		{
			if (!ModelState.IsValid)
			{
				return ValidationProblem();
			}

			if (id != dto.LeadId)
			{
				return BadRequest(new MismatchedIdProblemDetails(nameof(dto.LeadId))
				{
					Id = id,
					MismatchedId = dto.LeadId
				});
			}

			var query = new GetLeadQuery(id);
			var response = await _mediator.Send(query);

			if (response.IsNone)
			{
				return NotFound();
			}

			var command = _mapper.Map<UpdateLeadsStateCommand>(dto);
			var updateResponse = await _mediator.Send(command);

			return updateResponse.Match<IActionResult>(_ => NoContent(), BadRequest);
		}
	}
}