using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveSale.Callscripts.Api.Validation.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
		AllowMultiple = false)]
	public class ExactLengthAttribute : ValidationAttribute
	{
		private readonly int _exactLength;

		public ExactLengthAttribute(int exactLength)
			: base(() =>
			{
				var sb = new StringBuilder();
				sb.Append("The field {0} must have exact length of ");
				sb.Append($"{exactLength}.");

				return sb.ToString();
			})
		{
			_exactLength = exactLength;
		}
		
		public override bool IsValid(object? value)
		{
			if (value == null)
			{
				return false;
			}

			if (value.GetType().IsArray)
			{
				return (value as Array)!.Length == _exactLength;
			}

			return true;
		}
	}
}