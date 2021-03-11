using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Problems
{
	public class UnsupportedWidgetTypeProblemDetails : ProblemDetails
	{
		public UnsupportedWidgetTypeProblemDetails(string type)
		{
			Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
			Title = "Widget cannot be parsed.";
			Detail = $"Internal handler for widget {type}'s property of name \"Extra\" was not found.";
			Status = (int) HttpStatusCode.InternalServerError;
		}
	}
}