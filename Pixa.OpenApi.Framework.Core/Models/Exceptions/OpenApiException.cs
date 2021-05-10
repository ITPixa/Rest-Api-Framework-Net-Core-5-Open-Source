using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixa.OpenApi.Framework.Core.Models.Exceptions
{
    /// <summary>  
    /// This class will allow to generate the custom exception message.  
    /// </summary>  
    public class OpenApiException : Exception
    {
        public OpenApiException()
        {
        }

        public OpenApiException(string message) : base(message)
        {
        }

        public OpenApiException(string message, string responseModel) : base(message)
        {
        }

        public OpenApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
