using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Problems
{
	public class MismatchedIdProblemDetails : ProblemDetails
	{
		private readonly string _nameofMismatchedProperty;

		public MismatchedIdProblemDetails(string nameofMismatchedProperty)
		{
			_nameofMismatchedProperty = nameofMismatchedProperty;

			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
			Title = $"Given id does not correspond with {_nameofMismatchedProperty} in request body.";
			Detail =
				$"Id used in request URL does not match id in request body with the name of {_nameofMismatchedProperty}.";
		}

		public string Id
		{
			init => Extensions.Add("Id", value);
		}

		public string MismatchedId
		{
			init => Extensions.Add(_nameofMismatchedProperty, value);
		}
	}
}