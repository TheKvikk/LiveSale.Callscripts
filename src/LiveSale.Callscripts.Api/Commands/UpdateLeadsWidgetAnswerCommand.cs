using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Commands
{
	public class UpdateLeadsWidgetAnswerCommand : IRequest<Either<ProblemDetails, bool>>
	{
		public string LeadId { get; init; } = "";

		public string WidgetId { get; init; } = "";

		public string Extra { get; init; } = "";
	}
}