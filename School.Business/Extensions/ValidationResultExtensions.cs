using FluentValidation.Results;
using School.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Extensions
{
	public static class ValidationResultExtensions
	{
		public static List<CustomValidationError> CovertToCustomValidationError(this ValidationResult validationResult)
		{
			List<CustomValidationError> errors = new();
			foreach (var error in validationResult.Errors)
			{
				errors.Add(new()
				{
					ErrorMessage = error.ErrorMessage,
					PropertyName = error.PropertyName,
				});
			}

			return errors;
		}
	}
}
