using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Pixa.OpenApi.Framework.ApiCore.Models.Exceptions;
using Pixa.OpenApi.Framework.Core.Extensions;
using Pixa.OpenApi.Framework.Core.Models.Exceptions;
using System;
using System.Net;

namespace Pixa.OpenApi.Framework.ApiCore.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>  
        /// This method will automatically trigger when any exception occurs in application level.  
        /// </summary>  
        /// <param name="context"></param>  
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                        ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                         ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                         : GetErrorCode(context.Exception.GetType());
            string errorMessage = context.Exception.Message;
            string stackTrace = context.Exception.StackTrace;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            OpenApiErrorResult openApiErrorResult = new OpenApiErrorResult();
            openApiErrorResult.StatusMessage = errorMessage;
            openApiErrorResult.StatusCode = statusCode.ToString();
            string httpJson=openApiErrorResult.JsonSerialize();
            response.ContentLength = httpJson.Length;
            response.WriteAsync(httpJson);
        }

        /// <summary>  
        /// This method will return the status code based on the exception type.  
        /// </summary>  
        /// <param name="exceptionType"></param>  
        /// <returns>HttpStatusCode</returns>  
        private HttpStatusCode GetErrorCode(Type exceptionType)
        {
            ExceptionType tryParseResult;
            if (Enum.TryParse(exceptionType.Name, out tryParseResult))
            {
                switch (tryParseResult)
                {
                    case ExceptionType.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case ExceptionType.FileNotFoundException:
                        return HttpStatusCode.NotFound;

                    case ExceptionType.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case ExceptionType.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case ExceptionType.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case ExceptionType.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case ExceptionType.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case ExceptionType.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case ExceptionType.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case ExceptionType.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case ExceptionType.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case ExceptionType.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case ExceptionType.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case ExceptionType.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case ExceptionType.IOException:
                        return HttpStatusCode.NotFound;

                    case ExceptionType.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
