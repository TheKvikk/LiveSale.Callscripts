using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Problems
{
	public class MissingIncomingAnswerPropertyProblemDetails : ProblemDetails
	{
		public MissingIncomingAnswerPropertyProblemDetails()
		{
			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
			Title = "Incoming property extra is missing answer/s.";
			Detail = "Incoming property of name extra is missing property answer/s. Update can't be performed.";
		}
	}
}