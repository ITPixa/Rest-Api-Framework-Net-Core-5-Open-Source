using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pixa.OpenApi.Framework.ApiCore.Filters;
using Pixa.OpenApi.Framework.ApiCore.Models.Exceptions;
using Pixa.OpenApi.Framework.Core.Extensions;
using System;
using System.Net;

namespace Pixa.OpenApi.Framework.ApiCore
{

    [ApiController]
    [ModelValidationFilter]
    public class OpenApiBaseController : ControllerBase
    {
        public OpenApiBaseController() : base()
        {
        }

        protected BadRequestObjectResult BadRequest<T>(Enum errorCode, string errorMessage = null) where T : Enum
        {
            return new BadRequestObjectResult(CreateErrorResponse(HttpStatusCode.BadRequest, errorCode, errorMessage));
        }
        private OpenApiErrorResult CreateErrorResponse(HttpStatusCode httpStatusCode, Enum errorCode, string errorMessage = null)
        {
            HttpContext.Response.StatusCode = (int)httpStatusCode;
            return new OpenApiErrorResult() { StatusCode = errorCode.ToString(), StatusMessage = errorMessage ?? errorCode.GetDescription() };
        }
    }


    #region OpenApiErrorCodeResult - Not used for now
    /*
    //
    // Summary:
    //     Represents an Microsoft.AspNetCore.Mvc.IActionResult that when executed will
    //     produce an HTTP response with the specified Microsoft.AspNetCore.Mvc.Infrastructure.IStatusCodeActionResult.StatusCode.
    public interface IOpenApiStatusCodeActionResult : IActionResult
    {
        int? StatusCode { get; }
        string StatusMessage { get; }
    }

    /// <summary>
    /// Represents an <see cref="ActionResult"/> that when executed will
    /// produce an HTTP response with the given response status code.
    /// </summary>
    public class OpenApiErrorResult : ActionResult, IOpenApiStatusCodeActionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCodeResult"/> class
        /// with the given <paramref name="statusCode"/>.
        /// </summary>
        /// <param name="statusCode">The HTTP status code of the response.</param>
        public OpenApiErrorResult(int statusCode, string statusMessage)
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage;
        }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        public int StatusCode { get; }
        public string StatusMessage { get; }

        int? IOpenApiStatusCodeActionResult.StatusCode => StatusCode;
        string IOpenApiStatusCodeActionResult.StatusMessage => StatusMessage;


        /// <inheritdoc />
        public override void ExecuteResult(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Execute(context.HttpContext);
        }

        /// <summary>
        /// Sets the status code on the HTTP response.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/> for the current request.</param>
        /// <returns>A task that represents the asynchronous execute operation.</returns>
        Task IActionResult.ExecuteResultAsync(ActionContext context)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("A", "B");
            BadRequestObjectResult objectResult = new BadRequestObjectResult(dic);
            var executor = context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<BadRequestObjectResult>>();
            return executor.ExecuteAsync(context, objectResult);
            //Execute(context.HttpContext);
            //return Task.CompletedTask;
        }

        private void Execute(HttpContext httpContext)
        {
            var factory = httpContext.RequestServices.GetRequiredService<ILoggerFactory>();
            var logger = factory.CreateLogger<StatusCodeResult>();

            //logger.HttpStatusCodeResultExecuting(StatusCode);
            httpContext.Response.Headers.Add("Content-Type", StatusMessage);
            httpContext.Response.StatusCode = StatusCode;
        }
    }*/
    #endregion

}
