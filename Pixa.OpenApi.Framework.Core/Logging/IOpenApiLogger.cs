using System;

namespace Pixa.OpenApi.Framework.Core.Logging
{
    public interface IOpenApiLogger
    {
        void Debug(Enum eventCode, string message = null, Exception exception = null);
        void Warning(Enum eventCode, string message = null, Exception exception = null);
        void Error(Enum eventCode, string message = null, Exception exception = null);
    }
    public class OpenApiLogger : IOpenApiLogger
    {
        public void Debug(Enum eventCode, string message = null, Exception exception = null)
        {
            Console.WriteLine(eventCode.ToString());
        }

        public void Error(Enum eventCode, string message = null, Exception exception = null)
        {
            Console.WriteLine(eventCode.ToString());
        }

        public void Warning(Enum eventCode, string message = null, Exception exception = null)
        {
            Console.WriteLine(eventCode.ToString());
        }
    }
}
