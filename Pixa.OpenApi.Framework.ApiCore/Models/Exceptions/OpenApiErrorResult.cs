using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Pixa.OpenApi.Framework.ApiCore.Models.Exceptions
{
    public class OpenApiErrorResult
    {
        /// <summary>
        /// Validation status code.
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// Validation Message
        /// </summary>
        public string StatusMessage { get; set; }
        /// <summary>
        /// Dictionary with all validations failed
        /// </summary>
        public ModelStateDictionary ValidationResult { get; set; }
    }
}
