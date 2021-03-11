using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Problems
{
	public class InvalidWidgetIdProblemDetails : ProblemDetails
	{
		public InvalidWidgetIdProblemDetails(string widgetId)
		{
			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
			Title = "Widget id does not exist.";
			Detail = $"Widget id ({widgetId}) used in request body was not found among given lead's widgets.";
		}
	}
}