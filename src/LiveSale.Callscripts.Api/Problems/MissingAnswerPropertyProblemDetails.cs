using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Problems
{
	public class MissingAnswerPropertyProblemDetails : ProblemDetails
	{
		public MissingAnswerPropertyProblemDetails(string type)
		{
			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
			Title = "Widget does not contain Answer/s property.";
			Detail = $"Target widget ({type}) doesn't contain property Answer/s. There is nothing to update.";
		}
	}
}