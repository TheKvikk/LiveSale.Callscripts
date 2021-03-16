using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unit = MediatR.Unit;

namespace LiveSale.Callscripts.Api.Commands
{
	public class UpdateLeadsStateCommand : IRequest<Either<ProblemDetails, Unit>>
	{
		public string LeadId { get; init; } = "";

		public string WidgetId { get; set; } = "";

		public int ActiveWidgetIndex { get; init; }

		public bool Started { get; init; }

		public bool Completed { get; init; }
	}
}