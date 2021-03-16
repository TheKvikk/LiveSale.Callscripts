using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Problems
{
	public class InvalidNewActiveWidgetIndexProblemDetails : ProblemDetails
	{
		public InvalidNewActiveWidgetIndexProblemDetails(int newActiveWidgetIndex)
		{
			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
			Title = $"Invalid active widget index.";
			Detail =
				$"New active widget index ({newActiveWidgetIndex}) can not be less or equal than previous one and have to be one more than previous one.";
		}
	}
}