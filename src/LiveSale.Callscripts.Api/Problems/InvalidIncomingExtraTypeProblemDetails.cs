using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Problems
{
	public class InvalidIncomingExtraTypeProblemDetails : ProblemDetails
	{
		public InvalidIncomingExtraTypeProblemDetails(string type)
		{
			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
			Title = "Invalid incoming type of extra.";
			Detail =
				$"Incoming property of name extra is not compatible with widgets extra property type. Type {type} was expected.";
		}
	}
}