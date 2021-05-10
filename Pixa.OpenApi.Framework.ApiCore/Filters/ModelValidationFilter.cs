using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pixa.OpenApi.Framework.ApiCore.Enums;
using Pixa.OpenApi.Framework.ApiCore.Models.Exceptions;
using Pixa.OpenApi.Framework.Core.Extensions;
using Pixa.OpenApi.Framework.Core.Logging;
using System;
using System.Threading.Tasks;

namespace Pixa.OpenApi.Framework.ApiCore.Filters
{
    public class ModelValidationFilter : Attribute, IAsyncActionFilter
    {
        private readonly IOpenApiLogger _logger;
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                //Log Context
                _logger.Debug(OpenApiErrorCodes.InvalidModelState, context.JsonSerialize());
                var openapiErrorResult = new OpenApiErrorResult();
                openapiErrorResult.StatusCode = OpenApiErrorCodes.InvalidModelState.ToString();
                openapiErrorResult.StatusMessage = OpenApiErrorCodes.InvalidModelState.GetDescription();
                openapiErrorResult.ValidationResult = context.ModelState;
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
            await next();
        }
    }
}
