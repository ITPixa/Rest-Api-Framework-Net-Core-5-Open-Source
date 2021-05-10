using System.ComponentModel;

namespace Pixa.OpenApi.Framework.ApiCore.Enums
{
    public enum OpenApiErrorCodes
    {
        [Description("Error cause unknown")]
        Unknown = 1,
        [Description("Request model parameters are not valid")]
        InvalidModelState
    }
}
