﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Application.Models;

namespace CleanArch.WebApi.Filters
{
	public class ValidateModelAttribute : Attribute, IAsyncResultFilter
	{
		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (!context.ModelState.IsValid)
			{
				var errors = context.ModelState.Values
					.SelectMany(modelState => modelState.Errors)
					.Select(modelError => modelError.ErrorMessage);

				context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(errors));
			}

			await next();
		}
	}
}