using System;
using System.ComponentModel.DataAnnotations;

namespace LiveSale.Callscripts.Api.Validation.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
		AllowMultiple = false)]
	public class MustSumToAttribute : ValidationAttribute
	{
		private readonly int _sum;

		public MustSumToAttribute(int sum)
			: base("The field {0} does not add up to 100.")
		{
			_sum = sum;
		}
		
		public override bool IsValid(object? value)
		{
			if (value == null)
			{
				return false;
			}

			if (!value.GetType().IsArray)
			{
				return true;
			}
			
			var a = value as int[];
			return a[0] + a[1] == _sum;
		}
	}
}